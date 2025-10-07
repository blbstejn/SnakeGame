# SnakeGame (C#/.NET Console Project)

Implementation of the game "Snake" for the "Software Engineering" course for my university.
The aim is to set up a small game (Snake) with a thought out structure, class diagram, unit tests and documentation.

---

## Game description
Snake runs in a console.
- Controlled by **arrow keys**
- Eating ('*') heightens the snake's length and the score
- Game ends upon **colliding with a wall** or **colliding with itself**

## Architecture and design

### Project structure
- *SnakeGame* (Class library) -> Game logic (Board, Snake, Food, Game)
- *SnakeGame.Console* (Console and visuals) -> rendering and input handling

### Class diagram
(see docs/SnakeGameClassDiagram)

## Design decisions
- *Clear separation of logic and visuals/rendering* - 'SnakeGame' ist independent of the UI
- *Central game class* - Singleton-like 'Game' class handles Board, Snake, Food and Score
- *Project entirely independent of engines* - Barebones console project with focus on tests and clear code
- *Conventions*
	- Classes and methods: *PascalCase*
	- Variables and fields: *camelCase*
	- Constants (not used, but for completion's sake): *UPPER_CASE*
- *GitHub commit prefixes*
	- Implemented feature: *feat*
	- Changes to documentation: *docs*
	- Implemented tests: *test*

### Design patterns
- *Single responsibility*: every class has clearly separated tasks
- *Encapsulation*: Snake capsules body and movement
- *MVC-light*: classes and logic clearly separated from console UI

## Tests

## Setup and run
