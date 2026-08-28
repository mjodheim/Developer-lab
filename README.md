<div align="center">

# Developer Lab

### Pratique personnelle de programmation · Personal programming practice

Comprendre, implémenter, casser, corriger, tester et expliquer le code que je sais écrire moi-même.

[![C#](https://img.shields.io/badge/C%23-Bug_Zoo-239120?style=for-the-badge&logo=csharp&logoColor=white)](./01-bug-zoo-csharp)
[![Learning](https://img.shields.io/badge/Parcours-Learning-2563EB?style=for-the-badge&logo=github&logoColor=white)](https://github.com/mjodheim/Learning)
[![Profile](https://img.shields.io/badge/Profil-mjodheim-16A34A?style=for-the-badge&logo=github&logoColor=white)](https://github.com/mjodheim)

</div>

> **Positionnement / Authorship** — Developer Lab est le dépôt que j'utilise pour montrer le plus clairement possible ce que je peux **comprendre, implémenter et expliquer moi-même**. L'IA peut intervenir comme professeur : explications, questions, indices, revue de code ou suggestions de cas de test. Elle n'est pas destinée à fournir l'implémentation terminée des exercices. Lorsqu'un projet part d'un code fourni, d'un template ou d'une contribution externe significative, cette origine est documentée dans le projet concerné.
>
> **Positioning / Authorship** — Developer Lab is the repository I use to show as clearly as possible what I can **understand, implement and explain myself**. AI may act as a tutor through explanations, guiding questions, hints, code review or test-case suggestions. It is not intended to provide the completed implementation of these exercises. When a project starts from supplied code, a template or a substantial external contribution, that origin is documented inside the relevant project.

## 🇫🇷 Français

Developer Lab complète mon dépôt de formation **[Learning](https://github.com/mjodheim/Learning)** avec des exercices plus ciblés, réalisés en dehors de la séquence normale du cursus.

L'objectif n'est pas d'accumuler de gros projets ni de produire artificiellement du code parfait. Je veux construire une trace lisible de ma progression personnelle sur des sujets qui comptent réellement en développement : **debugging, conception objet, algorithmes, tests, backend, données, concurrence, architecture, sécurité et pratiques de production**.

Chaque exercice doit pouvoir répondre à quatre questions simples : **qu'est-ce que j'ai construit, pourquoi je l'ai construit ainsi, qu'est-ce qui a échoué, et qu'est-ce que j'en ai appris ?**

### Progression actuelle

- 🐛 **Debugging** — lecture de code existant, reproduction d'un défaut, diagnostic et correction ciblée.
- 🧱 **Conception et invariants** — encapsulation, mutabilité, validation des données et protection de l'état métier.
- 🧪 **Testing** — progression vers des tests automatisés de régression et des cas limites reproductibles.
- 🧠 **Compréhension avant implémentation** — privilégier le raisonnement, le débogueur et les petites corrections plutôt que la réécriture complète.
- 📝 **Documentation** — conserver l'énoncé, les décisions importantes et les apprentissages lorsqu'ils apportent une vraie valeur.
- 🚀 **Suite prévue** — Java, SQL, Spring Boot, concurrence, TypeScript/Angular, Python, Docker, CI/CD, sécurité et observabilité.

### Projets

| # | Projet | Technologie | Objectif principal | Statut |
|---:|---|---|---|---|
| 01 | **[Bug Zoo](./01-bug-zoo-csharp)** | C# | Debugging, invariants, mutabilité, exceptions et tests | **En cours** |
| 02 | Dungeon Inventory | Java | POO, composition, collections et génériques | Prévu |
| 03 | SQL Murder Mystery | SQL | Jointures, CTE, fonctions fenêtre et index | Prévu |
| 04 | URL Shortener | Java / Spring Boot | REST, validation, JPA et persistance | Prévu |
| 05 | Rate Limiter | C# | Algorithmes, concurrence et thread safety | Prévu |
| 06 | The World's Worst Bank | Java | Transactions, isolation et idempotence | Prévu |
| 07 | State Machine | TypeScript | Modélisation par les types, génériques et architecture | Prévu |
| 08 | Control Room | Angular | Composants, RxJS/signals, routing et intégration | Prévu |
| 09 | Realtime Chat | Java ou C# + Angular | WebSockets, événements et état temps réel | Prévu |
| 10 | Job Queue | Python | Workers, retries, priorités et concurrence | Prévu |
| 11 | Tiny Git | Python | Hashing, fichiers, stockage d'objets et graphes | Prévu |
| 12 | Search Engine | Java ou Python | Indexation, ranking et algorithmes | Prévu |
| 13 | Knowledge Assistant | Multi-langage | Recherche, embeddings, RAG et évaluation | Prévu |
| 14 | Bureaucracy Simulator | Python / Odoo | Modèles, vues, ACL et règles métier | Prévu |
| 15 | Microservices Disaster Simulator | Multi-langage | Messaging, résilience et observabilité | Prévu |

La liste est volontairement ambitieuse. Certains projets resteront de petits exercices d'une compétence précise ; d'autres pourront évoluer vers des applications de portfolio avec tests, documentation, Docker et CI/CD.

### Standard des projets

À mesure que le dépôt grandit, les projets suffisamment importants viseront une structure proche de celle-ci :

```text
project/
├── README.md        # objectif, état et exécution du projet
├── EXERCISE.md      # énoncé ou défi d'origine lorsqu'il existe
├── src/             # implémentation
├── tests/           # tests automatisés lorsqu'ils sont pertinents
└── DECISIONS.md     # choix de conception importants sur les projets plus larges
```

Tous les petits exercices n'ont pas besoin de tous ces fichiers. La structure doit rester au service de l'apprentissage, pas devenir une contrainte artificielle.

### Méthode de travail

`Comprendre → Reproduire → Diagnostiquer → Implémenter → Tester → Relire → Documenter`

Quand l'IA est utilisée dans ce dépôt, elle peut m'aider à comprendre un concept, poser des questions, fournir un indice, relire ce que j'ai écrit ou proposer des cas limites. **L'objectif reste que je sois capable de défendre le code et les décisions sans dépendre de l'IA pour les expliquer.**

### Relation avec mes autres dépôts

| Dépôt | Rôle |
|---|---|
| **[Learning](https://github.com/mjodheim/Learning)** | Parcours de formation structuré : exercices de cours, progression Full Stack et projets liés au cursus. |
| **Developer Lab** | Preuve la plus explicite de ma pratique personnelle et de ce que je peux implémenter et expliquer moi-même. |
| **[Mira Genesis](https://github.com/mjodheim/mira-genesis)** / **[AutoEmpiric](https://github.com/mjodheim/auto-empiric)** | Recherche et systèmes agentiques, où l'IA fait volontairement partie du processus d'ingénierie. |

---

## 🇬🇧 English

Developer Lab complements my formal training repository, **[Learning](https://github.com/mjodheim/Learning)**, with more focused exercises developed outside the normal course sequence.

The goal is not to accumulate large projects or artificially polished code. I want to build a readable record of my own progression in areas that matter in real software development: **debugging, object design, algorithms, testing, backend development, data, concurrency, architecture, security and production practices**.

Each exercise should ultimately answer four simple questions: **what did I build, why did I build it that way, what failed, and what did I learn from it?**

### Current progression

- 🐛 **Debugging** — reading existing code, reproducing defects, diagnosing causes and making focused repairs.
- 🧱 **Design and invariants** — encapsulation, mutability, data validation and protection of business state.
- 🧪 **Testing** — progressing towards automated regression tests and reproducible edge cases.
- 🧠 **Understanding before implementation** — favouring reasoning, debugger-driven investigation and small corrections over complete rewrites.
- 📝 **Documentation** — preserving the original challenge, important decisions and useful lessons when they add real value.
- 🚀 **Planned progression** — Java, SQL, Spring Boot, concurrency, TypeScript/Angular, Python, Docker, CI/CD, security and observability.

### Projects

| # | Project | Technology | Main focus | Status |
|---:|---|---|---|---|
| 01 | **[Bug Zoo](./01-bug-zoo-csharp)** | C# | Debugging, invariants, mutability, exceptions and testing | **In progress** |
| 02 | Dungeon Inventory | Java | OOP, composition, collections and generics | Planned |
| 03 | SQL Murder Mystery | SQL | Joins, CTEs, window functions and indexes | Planned |
| 04 | URL Shortener | Java / Spring Boot | REST, validation, JPA and persistence | Planned |
| 05 | Rate Limiter | C# | Algorithms, concurrency and thread safety | Planned |
| 06 | The World's Worst Bank | Java | Transactions, isolation and idempotency | Planned |
| 07 | State Machine | TypeScript | Type modelling, generics and architecture | Planned |
| 08 | Control Room | Angular | Components, RxJS/signals, routing and integration | Planned |
| 09 | Realtime Chat | Java or C# + Angular | WebSockets, events and realtime state | Planned |
| 10 | Job Queue | Python | Workers, retries, priorities and concurrency | Planned |
| 11 | Tiny Git | Python | Hashing, files, object storage and graphs | Planned |
| 12 | Search Engine | Java or Python | Indexing, ranking and algorithms | Planned |
| 13 | Knowledge Assistant | Multi-language | Search, embeddings, RAG and evaluation | Planned |
| 14 | Bureaucracy Simulator | Python / Odoo | Models, views, ACLs and business rules | Planned |
| 15 | Microservices Disaster Simulator | Multi-language | Messaging, resilience and observability | Planned |

The roadmap is deliberately ambitious. Some entries will remain short, focused exercises; others may grow into portfolio-grade applications with tests, documentation, Docker and CI/CD.

### Project standard

As the repository grows, sufficiently substantial projects will aim for a structure similar to this one:

```text
project/
├── README.md        # purpose, status and run instructions
├── EXERCISE.md      # original brief or challenge when applicable
├── src/             # implementation
├── tests/           # automated tests when relevant
└── DECISIONS.md     # important design choices for larger projects
```

Not every small exercise needs every file. Structure should support learning rather than become an artificial constraint.

### Working method

`Understand → Reproduce → Diagnose → Implement → Test → Review → Document`

When AI is used in this repository, it may help me understand a concept, ask questions, provide a hint, review code I wrote or suggest edge cases. **The goal remains that I can defend the code and its design decisions without depending on AI to explain them for me.**

### Relationship with my other repositories

| Repository | Role |
|---|---|
| **[Learning](https://github.com/mjodheim/Learning)** | Structured training path: course exercises, Full Stack progression and curriculum-related projects. |
| **Developer Lab** | The clearest evidence of my personal implementation practice and of what I can write and explain myself. |
| **[Mira Genesis](https://github.com/mjodheim/mira-genesis)** / **[AutoEmpiric](https://github.com/mjodheim/auto-empiric)** | Research and agentic systems where AI is deliberately part of the engineering process. |

---

## Technologies pratiquées ou ciblées · Practised or targeted technologies

<div align="center">

![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Java](https://img.shields.io/badge/Java-ED8B00?style=flat-square&logo=openjdk&logoColor=white)
![Spring Boot](https://img.shields.io/badge/Spring_Boot-6DB33F?style=flat-square&logo=springboot&logoColor=white)
![SQL](https://img.shields.io/badge/SQL-336791?style=flat-square&logo=postgresql&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat-square&logo=postgresql&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=flat-square&logo=angular&logoColor=white)
![Python](https://img.shields.io/badge/Python-3776AB?style=flat-square&logo=python&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=flat-square&logo=git&logoColor=white)

</div>

<div align="center">

> Construire pour comprendre. Comprendre pour mieux construire.<br>
> Build to understand. Understand to build better.

</div>
