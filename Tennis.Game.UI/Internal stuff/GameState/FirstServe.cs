namespace Tennis.Game.UI
{
    internal class FirstServe : GameState
    {
        public FirstServe(GameState gameState) : base(gameState) 
        {
            SayScore();
            Say();

            currentPlayer = player1;
            serving = game.Started;
        }

        public override GameState Next()
        {
            char response='!';

            if (!ForcedExit) response = Choose(player1.Name + " served correctly (Y/N)");

            switch (response)
            {
                case 'Y': rallying = serving.Serve();       return new ReturnRally(this);
                case 'N': serving = serving.ServeFaulty();  return new SecondServe(this);
                default: return new EndGame(this);
            }
        }
    }  
}
