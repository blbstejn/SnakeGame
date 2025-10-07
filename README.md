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
- *SnakeGame.Console* (Console and visuals) -> Rendering and input handling
- *SnakeGame.Tests* (MSTest) -> Unit testing
- *docs* -> class diagram and possibly other important documents

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
	- Implemented feature or fixes: *feat*
	- Changes to documentation: *docs*
	- Implemented tests: *test*

### Design patterns
- *Single responsibility*: every class has clearly separated tasks
- *Encapsulation*: Snake capsules body and movement
- *MVC-light*: classes and logic clearly separated from console UI

## Tests
**Set up two test classes for the snake and food and snake separately**
- *Tests for Snake*
	- *MovingUpdatesSpawnPosition*: check whether the move function causes changes in position
	- *DirectionChangePreventsReverse*: Receiving the opposite input of the snake's current direction is being ignored
- *Tests for Food and Game*
	- *NoFoodRespawnOnSnake*: food does not respawn on top of the snake's body
	- *EatingFoodIncrementsScoreAndGrowsSnake*: Check whether the score begins at 0; Make sure eating food both increments score and grows the snake
## Setup and run
- Run program in separate console
- Do not move mouse cursor by mouse as this breaks the program