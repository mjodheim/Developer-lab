# Bug Zoo — Bug Report

This report documents the defects identified while debugging Bug Zoo, the cause of each problem, the correction applied and the regression coverage added afterwards.

The goal of the exercise was to repair the existing application incrementally rather than replace it with a new implementation.

---

## 1. The last animal was missing from the list

**Status:** Resolved

### Symptom

The application contained four animals, but the list command displayed only three.

### Cause

The loop stopped at `animals.Count - 1`, so the last valid index was never processed.

```csharp
for (int index = 0; index < animals.Count - 1; index++)
```

### Fix

The iteration boundary was corrected. The listing code was later simplified to iterate over the returned snapshots with `foreach`.

### Lesson

Collection bounds are a common source of off-by-one defects. Iterating directly over a collection can also remove unnecessary index management when the index itself is not needed.

---

## 2. Species search was case-sensitive

**Status:** Resolved

### Symptom

Searching for `lion` did not reliably represent the same business search as `Lion`.

### Cause

The initial comparison relied on case-sensitive string equality.

An intermediate repair converted both strings to lower case, which worked but performed unnecessary transformations.

### Fix

The comparison now expresses the intent directly:

```csharp
string.Equals(
    animal.Species,
    species,
    StringComparison.OrdinalIgnoreCase)
```

### Regression coverage

- `SearchBySpecies_WithDifferentCase_ReturnsMatchingAnimal`
- `SearchBySpecies_WithUnknownSpecies_ReturnsEmptyCollection`

### Lesson

Prefer comparison APIs that explicitly describe the required semantics instead of modifying values before comparing them.

---

## 3. Duplicate animal identifiers were accepted incorrectly

**Status:** Resolved for `AddAnimal`; one constructor edge case remains

### Symptom

The add operation used the wrong collection predicate and therefore did not enforce the uniqueness rule correctly.

### Cause

The original condition used `All` with an inverted meaning. The business question is simpler: "does an animal with this ID already exist?"

### Fix

`AddAnimal` checks the collection with `Any` and throws an `InvalidOperationException` when the identifier already exists.

### Regression coverage

- `AddAnimal_WithDuplicateId_ThrowsInvalidOperationException`
- `AddAnimal_WithUniqueId_AddsAnimal`

The duplicate test also verifies that the collection remains unchanged after the rejected operation.

### Remaining edge case

The current `ZooService` constructor still copies its initial `IEnumerable<Animal>` directly with `ToList()`. An initial collection containing duplicate IDs can therefore bypass the rule enforced by `AddAnimal`.

The final repair should make construction enforce the same uniqueness invariant and add a test such as:

```text
Constructor_WithDuplicateIds_ThrowsInvalidOperationException
```

### Lesson

A business invariant must hold for every path that can create or modify an object's state, including construction.

---

## 4. Food totals lost decimal precision

**Status:** Resolved

### Symptom

Daily food requirements such as `6.5 kg` and `12.75 kg` could produce an incorrect total.

### Cause

Each decimal quantity was converted to `int` before being summed, truncating its fractional part.

### Fix

The values are summed directly as `decimal` values:

```csharp
return _animals.Sum(animal => animal.DailyFoodKg);
```

### Regression coverage

`CalculateTotalDailyFood_WithTwoAnimals_ReturnsSumOfDailyFood`

The tested example verifies that `6.50 + 12.75` produces `19.25`.

### Lesson

Numeric types are part of the business model. Converting monetary or measured decimal values to integers can silently corrupt results.

---

## 5. Unknown identifiers caused an uncontrolled lookup failure

**Status:** Resolved

### Symptom

Looking up an unknown animal relied on LINQ `First`, which throws when no item matches but does not provide a domain-specific explanation.

The same lookup behaviour was also needed by the move operation.

### Fix

Entity lookup was centralised in `FindEntityById`:

```csharp
return _animals.FirstOrDefault(animal => animal.Id == animalId)
       ?? throw new KeyNotFoundException(
           $"No animal found with id {animalId}.");
```

Both `FindById` and `MoveAnimal` reuse this behaviour.

### Regression coverage

- `FindById_WithIncorrectId_ThrowsKeyNotFoundException`
- `MoveAnimal_WithUnknownId_ThrowsKeyNotFoundException`

### Lesson

Failure is easier to understand and test when the application chooses an explicit exception rather than leaking an incidental implementation exception.

---

## 6. Animals could be created in invalid states

**Status:** Resolved

### Symptom

The original `Animal` constructor accepted values that violate the exercise rules, including:

- non-positive identifiers;
- empty or whitespace names;
- empty or whitespace species;
- negative ages;
- zero or negative daily food quantities;
- non-positive enclosure numbers.

### Cause

The constructor assigned incoming values directly to public properties without validation.

### Fix

The constructor now validates its arguments before accepting them.

Examples:

```csharp
Id = id > 0
    ? id
    : throw new ArgumentOutOfRangeException(nameof(id));

Age = age >= 0
    ? age
    : throw new ArgumentOutOfRangeException(nameof(age));
```

String values are checked with `string.IsNullOrWhiteSpace`, and food/enclosure values must be positive.

### Regression coverage

The xUnit suite covers invalid IDs, names, species, ages, food quantities and enclosure numbers. Several boundary cases use `[Theory]` with multiple `[InlineData]` values, notably zero and negative values.

### Lesson

If a domain object has mandatory invariants, construction is a strong place to protect them because invalid instances never enter the rest of the application.

---

## 7. Animal state was externally mutable

**Status:** Resolved

### Symptom

All `Animal` properties originally had public setters. Code receiving an `Animal` reference could therefore change IDs, age, food requirements or enclosure numbers without passing through validation.

### Cause

The model exposed unrestricted mutation.

### Fix

Property setters were changed to `private set`.

Enclosure movement now goes through:

```csharp
MoveToEnclosure(int newEnclosureNumber)
```

which validates the new enclosure before modifying the object.

### Regression coverage

- `MoveToEnclosure_WithValidEnclosureNumber_UpdatesEnclosureNumber`
- `MoveToEnclosure_WithInvalidEnclosureNumber_ThrowsAndKeepsCurrentEnclosure`

The invalid-move test checks both the exception and the important secondary guarantee that the original enclosure remains unchanged.

### Lesson

Encapsulation is not only about hiding fields. It prevents state changes from bypassing business rules.

---

## 8. Read operations exposed mutable domain objects

**Status:** Resolved

### Symptom

`GetAllAnimals`, `FindById` and species searches originally returned `Animal` objects directly.

Even when the collection itself was exposed through `IReadOnlyList`, callers still received references to mutable domain entities.

### Cause

A read-only collection does not make the objects stored inside it immutable.

### Fix

`ZooService` now exposes `AnimalSnapshot`, an immutable record containing the values required by callers.

```csharp
public sealed record AnimalSnapshot(
    int Id,
    string Name,
    string Species,
    int Age,
    decimal DailyFoodKg,
    int EnclosureNumber);
```

Internal mutation still operates on `Animal` entities through the private `FindEntityById` method.

### Regression coverage

The service tests consume snapshots through `GetAllAnimals`, `FindById` and `SearchBySpecies`, while mutation remains available only through controlled service/domain methods.

### Lesson

`IReadOnlyList<T>` protects the collection interface, not necessarily the mutability of `T`. Returning immutable projections is one way to create a safer read boundary.

---

## 9. Generating a feeding report changed application state

**Status:** Resolved

### Symptom

Generating a report sorted `_animals` in place by enclosure number.

After requesting a report, the order returned by the rest of the application was therefore different even though generating a report should be a read-only operation.

### Cause

The implementation called `List.Sort` directly on the service's internal collection.

### Fix

The report now creates an ordered enumeration instead:

```csharp
IEnumerable<Animal> animalsByEnclosure =
    _animals.OrderBy(animal => animal.EnclosureNumber);
```

The report is generated from that sequence without changing `_animals`.

### Regression coverage

- `GenerateFeedingReport_WithTwoAnimals_GeneratesFeedingReport`
- `GenerateFeedingReport_DoesNotChangeAnimalOrder`

### Lesson

Query/report methods should avoid hidden side effects. A regression test can protect not only returned data but also the state that must remain unchanged.

---

## Test strategy

The test suite was added incrementally after the initial debugging work.

It includes:

- positive-path tests confirming expected behaviour;
- exception tests for invalid inputs and unknown identifiers;
- boundary tests using zero and negative values;
- `[Theory]` tests to cover several invalid values with one behavioural rule;
- state-preservation assertions after failed operations;
- a side-effect regression test proving that report generation does not reorder stored animals.

This progression is visible in the Git history: the application was first debugged and hardened, then the xUnit suite was introduced and expanded in several passes.

---

## Key takeaways

Bug Zoo reinforced several principles that scale beyond this small console application:

- reproduce a defect before repairing it;
- fix the cause rather than only the visible symptom;
- keep corrections focused;
- protect domain invariants at their boundaries;
- make invalid state difficult to represent;
- distinguish read models from mutable domain entities;
- make failure modes explicit;
- avoid hidden mutations in query operations;
- use regression tests to turn repaired bugs into permanent guarantees.
