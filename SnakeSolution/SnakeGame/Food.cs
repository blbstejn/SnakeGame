using System;

namespace SnakeGame;

public class Food
{
    private readonly Random rng;
    public Position Position { get; private set; }

    public Food(Random? rng = null)
    {
        this.rng = rng ?? new Random();
        Position = new Position(0, 0);
    }

    // directly sets position, practical for tests
    public void SetPosition(Position pos)
    {
        this.Position = pos;
    }

    public void Respawn(Board board, IEnumerable<Position> occupied)
    {
        var occupiedSet = new HashSet<Position>(occupied);
        var freePositions = new List<Position>();
        
        for (int x = 0; x < board.Width; x++)
        {
            for (int y = 0; y < board.Height; y++)
            {
                var p = new Position(x, y);
                if (!occupiedSet.Contains(p))
                    freePositions.Add(p);
            }
        }

        if (freePositions.Count == 0)
            throw new InvalidOperationException("No free positions found to respawn food.");
        
        Position = freePositions[this.rng.Next(freePositions.Count)];
    }
}