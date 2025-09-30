using System.Linq;

namespace SnakeGame;

public class Game
{
    public Board Board { get; }
    public Snake Snake { get; }
    public Food Food { get; }
    public int Score { get; private set; }
    public bool IsGameOver { get; private set; }

    private readonly Random rng;

    public Game(int width, int height, Random? rng = null)
    {
        Board = new Board(width, height);
        Position start = new Position(width / 2, height / 2);
        Snake = new Snake(start);
        this.rng = rng ?? new Random();
        Food = new Food(this.rng);
        Food.Respawn(Board, Snake.Body);
        Score = 0;
        IsGameOver = false;
    }

    public void Update(Direction? input = null)
    {
        if (IsGameOver)
            return;
        
        if(input.HasValue)
            Snake.ChangeDirection(input.Value);

        Position next = Snake.PeekNextHead();
        
        // wall collision
        if (!Board.IsInside(next))
        {
            IsGameOver = true;
            return;
        }
        
        // collision with self
        if (Snake.Body.Skip(1).Contains(next))
        {
            IsGameOver = true;
            return;
        }

        bool snakeGrowth = next.Equals(Food.Position);
        Snake.Move(grow: snakeGrowth);

        if (snakeGrowth)
        {
            Score++;
            Food.Respawn(Board, Snake.Body);
        }
    }
}