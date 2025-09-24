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
        // Set up once food and snake are finalized
    }
}