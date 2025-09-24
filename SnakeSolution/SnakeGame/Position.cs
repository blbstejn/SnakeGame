namespace SnakeGame;

public readonly record struct Position(int X, int Y)
{
    public Position Next(Direction direction)
    {
        switch (direction)
        {
            case (Direction.Up):
                return new Position(this.X, this.Y - 1);
            case (Direction.Down):
                return new Position(this.X, this.Y + 1);
            case (Direction.Left):
                return new Position(this.X - 1, this.Y);
            case (Direction.Right):
                return new Position(this.X + 1, this.Y);
            default:
                return this;
        }
    }
}