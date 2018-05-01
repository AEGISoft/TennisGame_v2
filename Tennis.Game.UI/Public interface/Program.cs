namespace Tennis.Game.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameState gamestate = new GameState(new GameStateForConsole());
            do
            {
                gamestate = gamestate.Next();
            }
            while (gamestate.GetType() != typeof(EndGame));
        }
    }
}
