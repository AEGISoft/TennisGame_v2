namespace Tennis.Game.UI
{
    internal class StartGame : GameState
    {
        public StartGame(GameState gameState): base(gameState) { }

        public override GameState Next()
        {
            Say("Welcome to Mega Tennis !");
            Say("------------------------");
            Say();
            Say("notice: responding with '!' always ends the game.");
            Say();

            char response = '!';
            if (!ForcedExit) response = Choose("New Game? (Y/N)");

            switch (response)
            {
                case 'Y': return new CreateGame(this);
                default : return new EndGame(this);
            }
        }
    }
}
