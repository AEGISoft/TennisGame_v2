namespace Tennis.Game.UI
{
    internal class ReturnRally : GameState
    {
        public ReturnRally(GameState gameState):base(gameState)
        {
            currentPlayer = currentPlayer.OtherPlayer;
        }

        public override GameState Next()
        {
            char response = '!';

            if (!ForcedExit) response = Choose(currentPlayer.Name + " returned correctly (Y/N)");

            switch (response)
            {
                case 'Y': rallying = rallying.Return(); return new ReturnRally(this);
                case 'N': serving = rallying.Miss(); return new FirstServe(this);
                default: return new EndGame(this);
            }
        }
    }
}
