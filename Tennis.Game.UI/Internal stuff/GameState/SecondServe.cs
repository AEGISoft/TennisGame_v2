namespace Tennis.Game.UI
{
    internal class SecondServe : GameState
    {
        public SecondServe(GameState gameState):base(gameState) { }

        public override GameState Next()
        {
            char response = '!';

            if (!ForcedExit) response = Choose(player1.Name + " served correctly (Y/N)");

            switch (response)
            {
                case 'Y': rallying = serving.Serve();       return new ReturnRally(this);
                case 'N': serving = serving.ServeFaulty();  return new FirstServe(this);                       
                default: return new EndGame(this);
            }
        }

    }
}
