# Bug Zoo — C# Debugging & Testing Exercise

## Goal

Bug Zoo is a deliberately defective C# console application used to practise debugging, defensive programming, object mutability, business invariants, exceptions and automated testing.

The objective is not to rewrite the application, but to reproduce defects, understand their causes, make focused corrections and protect the repaired behaviour with regression tests.

## Authorship

- **Starter application and exercise brief:** supplied as a debugging exercise.
- **Diagnosis and implementation of repairs:** Anthony Mets.
- **AI assistance:** tutoring, hints and code review. The completed fixes were not supplied as a ready-made implementation.

This distinction is intentional: the project belongs to my [`Developer-lab`](../README.md), whose purpose is to demonstrate code I can understand, implement and explain myself.

## What was repaired

The work performed on the application includes:

- fixing an off-by-one error that omitted the last animal from the list;
- making species searches case-insensitive without manual string normalisation;
- preventing duplicate identifiers when animals are added;
- preserving decimal precision when calculating food totals;
- replacing uncontrolled lookup failures with a clear `KeyNotFoundException`;
- validating animal state at construction time;
- validating enclosure changes;
- restricting direct mutation by making `Animal` setters private;
- returning immutable `AnimalSnapshot` values instead of exposing mutable domain objects;
- generating feeding reports without sorting and mutating the internal animal collection;
- adding an xUnit regression suite covering normal behaviour, invalid inputs and side effects.

The detailed defect-by-defect analysis is available in [`BUG_REPORT.md`](./BUG_REPORT.md).

## Concepts practised

- reading unfamiliar code;
- debugging instead of guessing;
- boundary and off-by-one errors;
- LINQ queries and collection handling;
- decimal calculations;
- case-insensitive string comparison;
- object mutability and encapsulation;
- business-rule validation and invariants;
- controlled exceptions;
- avoiding accidental state mutation;
- immutable snapshots / read models;
- xUnit `[Fact]` and `[Theory]` tests;
- automated regression testing.

## Project structure

```text
01-bug-zoo-csharp/
├── src/
│   └── BugZoo/
│       ├── Animal.cs
│       ├── ZooService.cs
│       └── Program.cs
├── tests/
│   └── BugZoo.Tests/
│       ├── AnimalTest.cs
│       └── ZooServiceTests.cs
├── BUG_REPORT.md
├── EXERCISE.md
├── README.md
└── BugZoo.slnx
```

## Run the application

From `01-bug-zoo-csharp`:

```bash
dotnet run --project src/BugZoo
```

## Run the tests

```bash
dotnet test
```

The current suite covers constructor validation, enclosure changes, lookups, case-insensitive searches, duplicate additions, food totals, report ordering and protection against unintended collection reordering.

## Development approach

For each defect, the intended workflow was:

1. reproduce the unexpected behaviour;
2. identify the expected behaviour;
3. isolate the cause;
4. apply the smallest reasonable correction;
5. verify the corrected scenario;
6. add a test that would fail if the defect returned.

The Git history intentionally reflects that progression: initial debugging, domain-model hardening and snapshot encapsulation, followed by several passes of xUnit regression tests.

## Current status

The main defects found during the exercise are repaired and covered by automated tests.

One final invariant is still worth tightening before marking the exercise fully complete: `AddAnimal` prevents duplicate identifiers, but the `ZooService` constructor currently copies its initial collection directly. Therefore, an initial collection containing duplicate IDs can still create an invalid service state. The final correction should make construction enforce the same uniqueness rule and add the corresponding regression test.

After that, the exercise can be considered complete once the full test suite passes.

See [`EXERCISE.md`](./EXERCISE.md) for the original brief.
