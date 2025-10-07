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
            
            Render(game);
            Thread.Sleep(tickMs);
        }
    }

    static void Render(Game game)
    {
        // pretty simple renderer setup: clear and draw everything
        Console.Clear();

        for (int y = 0; y < game.Board.Height; y++)
        {
            for (int x = 0; x < game.Board.Width; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('.');
            }
        }
        
        // food
        var foodPos = game.Food.Position;
        Console.SetCursorPosition(foodPos.X, foodPos.Y);
        Console.Write('*');
        
        // snake
        bool first = true;
        foreach (var seg in game.Snake.Body)
        {
            Console.SetCursorPosition(seg.X, seg.Y);
            Console.Write(first ? '0' : 'o');
            first = false;
        }
        
        // portray score
        Console.SetCursorPosition(0, game.Board.Height);
        Console.Write($"Score: {game.Score}");
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