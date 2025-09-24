namespace SnakeGame;

public class Board
{
    public int Width { get; }
    public int Height { get; }

    public Board(int width, int height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Board dimensions must be > 0");
        
        Width = width;
        Height = height;
    }

    public bool IsInside(Position p)
    {
        return p.X >= 0 && p.X < this.Width && p.Y >= 0 && p.Y < this.Height;
    }
}