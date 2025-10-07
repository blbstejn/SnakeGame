using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeGame.Tests;

[TestClass]
public class FoodAndGameTests
{
    [TestMethod]
    public void NoFoodRespawnOnSnake()
    {
        Board board = new Board(10, 10);
        Snake snake = new Snake(new Position(5, 5));
        
        snake.Move(true);
        snake.Move(true);
        
        Food food = new Food(new System.Random(0));
        food.Respawn(board, snake.Body);
        
        CollectionAssert.DoesNotContain(snake.Body.ToList(), food.Position);
    }

    [TestMethod]
    public void EatingFoodIncrementsScoreAndGrowsSnake()
    {
        var rng = new System.Random();
        Game game = new Game(10, 10, rng);

        Position next = game.Snake.PeekNextHead();
        game.Food.SetPosition(next);
        
        int initialLength = game.Snake.Length;
        game.Update();
        
        Assert.AreEqual(initialLength + 1, game.Snake.Length);
        Assert.AreEqual(1, game.Score);
    }
}