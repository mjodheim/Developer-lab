# Exercise 01 — Bug Zoo

## Context

Welcome to the Bug Zoo, a small wildlife park whose animal-management program is behaving strangely.

Animals disappear from reports, food quantities become impossible, searches sometimes crash, and the daily feeding bill cannot always be trusted. The previous developer insists that everything worked on their machine.

Your mission is to diagnose and repair the application without rewriting it from scratch.

## Learning objectives

This exercise is designed to assess and strengthen your ability to:

- read and understand unfamiliar C# code;
- reproduce and isolate a defect;
- use a debugger instead of guessing;
- handle null values and invalid input;
- reason about collections and object mutability;
- identify boundary and calculation errors;
- use exceptions appropriately;
- write automated tests that prevent regressions;
- improve code carefully without changing expected behaviour.

## Functional rules

The application manages animals and their daily food requirements.

Each animal has:

- a unique identifier;
- a name;
- a species;
- an age greater than or equal to zero;
- a daily food quantity expressed in kilograms;
- an enclosure number.

The program must allow a user to:

1. list all animals;
2. find an animal by its identifier;
3. search for animals by species;
4. add a new animal;
5. move an animal to another enclosure;
6. calculate the total daily food requirement;
7. generate a feeding report.

## Business constraints

- Two animals cannot share the same identifier.
- An animal name cannot be empty or whitespace.
- Age cannot be negative.
- Daily food quantity must be strictly positive.
- Enclosure numbers must be positive.
- A search that finds nothing must not crash the application.
- Species searches must not depend on letter casing.
- Moving an unknown animal must produce a clear, controlled failure.
- Reports must not accidentally modify the animals stored by the application.
- Food totals must remain correct for decimal quantities.

## Your mission

The starter application will contain several intentional defects. They may involve:

- incorrect conditions;
- null handling;
- collection manipulation;
- calculations;
- object references and mutability;
- exceptions;
- boundary cases.

Do not attempt to repair everything immediately.

For each defect:

1. reproduce the unexpected behaviour;
2. describe what you expected and what actually happened;
3. locate the cause using the debugger or a focused experiment;
4. make the smallest reasonable correction;
5. verify that the original scenario now works;
6. add a test that would catch the defect if it returned.

## Working rules

- Do not rewrite the entire application.
- Do not add a framework or database.
- Do not copy a complete solution from an AI assistant.
- You may ask for explanations, questions, hints, or code review.
- Commit after each coherent repair, not after every edited line.
- Use meaningful commit messages that describe the repaired behaviour.

Example:

```text
fix: prevent duplicate animal identifiers
```

## Expected deliverables

By the end of the exercise, the project should contain:

- a working .NET console application;
- a test project;
- tests for the repaired defects and important business rules;
- a short `BUG_REPORT.md` documenting each discovered defect;
- a project README explaining how to run the application and the tests;
- a clean and understandable Git history.

## Definition of done

The exercise is complete when:

- all known scenarios behave according to the functional rules;
- invalid input is handled deliberately;
- all automated tests pass;
- the application builds without warnings introduced by your changes;
- every repaired defect is documented;
- you can explain each correction and why your test proves it.

## First checkpoint

Before changing any code:

1. build and run the starter application;
2. explore every menu option;
3. write down at least three suspicious behaviours;
4. choose one defect and explain your initial hypothesis.

At that point, ask for the first code-review checkpoint before making broad changes.
