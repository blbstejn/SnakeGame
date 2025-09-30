namespace SnakeGame;

public class Snake
{
    private readonly LinkedList<Position> body = new();
    public Direction Direction { get; private set; }

    public Snake(Position start)
    {
        body.AddFirst(start);
    }
    
    public IEnumerable<Position> Body => body;
    
    public Position Head => body.First!.Value;

    public Position PeekNextHead(Direction? newDirection = null)
    {
        Direction dir = newDirection ?? Direction;
        return Head.Next(dir);
    }

    public void ChangeDirection(Direction newDirection)
    {
        if (IsOppositeInput(newDirection))
            return;
        
        this.Direction = newDirection;
    }

    private bool IsOppositeInput(Direction newDirection)
    {
        return (this.Direction == Direction.Left && newDirection == Direction.Right) ||
               (this.Direction == Direction.Right && newDirection == Direction.Left) ||
               (this.Direction == Direction.Up && newDirection == Direction.Down) ||
               (this.Direction == Direction.Down && newDirection == Direction.Up);
    }

    public Position Move(bool grow = false)
    {
        Position head = body.First!.Value;
        Position newHead = head.Next(Direction);

        body.AddFirst(newHead);

        if (!grow)
            body.RemoveLast();
        
        return newHead;
    }

    public bool IsCollidingWithSelf()
    {
        return this.body.Skip(1).Any(segment => segment.Equals(Head));
    }

    public int Length => body.Count;
}