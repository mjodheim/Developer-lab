# Dungeon Inventory — Java OOP, Collections & Generics Exercise

## Context

You are building the inventory system for a small dungeon-crawling game.

An adventurer explores dungeons, collects loot and carries different kinds of items.

At first, the problem looks simple: store a few objects in a collection.

However, a real inventory quickly introduces several questions:

- Can every item be stacked?
- What happens when two identical items are collected?
- How much can the adventurer carry?
- How should equipment differ from consumables?
- How can items be searched or filtered?
- How should quantities be represented?
- Should every item type inherit from a large common hierarchy?
- When do interfaces, composition and generics become useful?

The objective of this exercise is to progressively design a maintainable solution instead of immediately building a large inheritance tree.

---

## Goal

Build a Java inventory system that demonstrates understanding of:

- object-oriented design;
- encapsulation;
- composition;
- collections;
- enums;
- interfaces;
- business invariants;
- exceptions;
- searching and filtering;
- generics;
- automated testing.

The emphasis is not on building a complete game.

The inventory itself is the project.

---

## Learning objectives

By completing the exercise, you should be able to:

- identify the main domain concepts from a written problem;
- decide which concepts deserve their own classes;
- distinguish inheritance from composition;
- protect object state through encapsulation;
- choose appropriate Java collections;
- express business rules explicitly;
- model different item behaviours without creating unnecessary inheritance;
- use enums for finite domain concepts;
- introduce interfaces where behaviour matters more than implementation;
- understand why generics are useful instead of using them only because they exist;
- write tests for both normal behaviour and edge cases.

---

# Functional requirements

## 1. Items

The dungeon contains different items.

Every item must have at least:

- a name;
- a weight;
- a monetary value.

Weight and value must never be negative.

Items may later have additional properties depending on their role.

Examples could include:

- weapons;
- armour;
- potions;
- food;
- crafting materials;
- quest items.

You do not need to implement all of these immediately.

The model should be able to evolve without requiring a complete rewrite.

---

## 2. Inventory

An adventurer owns an inventory.

The inventory must be able to:

- add an item;
- remove an item;
- determine whether an item is present;
- expose its current contents;
- calculate the total weight;
- calculate the total value;
- search for items.

The inventory must not expose its internal mutable collection in a way that allows callers to bypass its rules.

---

## 3. Carrying capacity

An inventory has a maximum carrying capacity.

Adding an item must fail when the resulting total weight would exceed that capacity.

Example:

```text
Maximum capacity: 20 kg
Current weight:   18 kg
Item weight:       3 kg

Result: the item cannot be added.