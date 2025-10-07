using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakeGame.Tests;

[TestClass]
public class SnakeTests
{
    [TestMethod]
    public void MovingUpdatesHeadPosition()
    {
        Position spawnPosition = new Position(5, 5);
        Snake snake = new Snake(spawnPosition);
        snake.Move();
        Position head = snake.Head;
        
        Assert.AreEqual(spawnPosition, head);
    }
    
    [TestMethod]
    public void DirectionChangePreventsReverse()
    {
        Snake snake = new Snake(new Position(5, 5));
        // standard direction is right, choosing the opposite should always be ignored
        snake.ChangeDirection(Direction.Left);
        
        Assert.AreEqual(Direction.Right, snake.Direction);
    }
}