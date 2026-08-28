# Bug Zoo — C# Debugging Exercise

## Goal

Bug Zoo is a deliberately defective C# console application used to practise debugging, defensive programming, object mutability, business invariants, exceptions and automated testing.

The objective is not to rewrite the application, but to reproduce defects, understand their causes, make focused corrections and protect the repaired behaviour with tests.

## Authorship

- **Starter application and exercise brief:** supplied as a debugging exercise.
- **Diagnosis and implementation of repairs:** Anthony Mets.
- **AI assistance:** tutoring, hints and code review. The completed fixes are not supplied as a ready-made implementation.

This distinction is intentional: the project belongs to my [`Developer-lab`](../README.md), whose purpose is to demonstrate code I can understand, implement and explain myself.

## Concepts practised

- reading unfamiliar code;
- debugging instead of guessing;
- collection boundaries;
- null and missing-value handling;
- decimal calculations;
- case-insensitive comparison;
- object mutability and encapsulation;
- business-rule validation;
- controlled exceptions;
- avoiding accidental state mutation;
- automated regression testing.

## Current status

The main debugging and design corrections are implemented. The next step is to complete the automated test suite and document the repaired defects before considering the exercise finished.

See [`EXERCISE.md`](./EXERCISE.md) for the full brief.
