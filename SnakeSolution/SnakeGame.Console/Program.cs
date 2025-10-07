using SnakeGame;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        const int width = 40;
        const int height = 20;
        
        Console.SetWindowSize(width + 2, height + 2);
        
        Game game = new Game(width, height);

        const int tickMs = 150;
        Position? previousTail = null;
        
        // setup playing board
        for (int y = 0; y < game.Board.Height; y++)
        {
            for (int x = 0; x < game.Board.Width; x++)
            {
                DrawCharacterAtPosition(new Position(x, y), '.');
            }
        }

        while (!game.IsGameOver)
        {
            // handle input
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                Direction? dir = KeyToDirection(key);

                if (dir.HasValue)
                    game.Update(dir.Value);
                else
                    game.Update();
            }
            else
            {
                game.Update();
            }
            
            Render(game, ref previousTail);
            Thread.Sleep(tickMs);
        }
    }

    static void Render(Game game, ref Position? previousTail)
    {
        // replace position of tail from previous rendercall with emptiness
        if (previousTail.HasValue)
            DrawCharacterAtPosition(previousTail.Value, '.');
        
        // food
        DrawCharacterAtPosition(game.Food.Position, '*');
        
        //snake
        bool first = true;
        foreach (Position segment in game.Snake.Body)
        {
            char segmentChar = first ? 'O' : 'o';
            DrawCharacterAtPosition(segment, segmentChar);
            first = false;
        }
        
        // portray score
        Console.SetCursorPosition(0, game.Board.Height);
        Console.Write($"Score: {game.Score}");

        previousTail = game.Snake.PreviousTail;
    }

    static void DrawCharacterAtPosition(Position position, char character)
    {
        if (position.X >= 0 && position.Y >= 0)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(character);
        }
    }

    static Direction? KeyToDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                return Direction.Up;
            case ConsoleKey.DownArrow:
                return Direction.Down;
            case ConsoleKey.LeftArrow:
                return Direction.Left;
            case ConsoleKey.RightArrow:
                return Direction.Right;
            default:
                return null;
        }
    }
}