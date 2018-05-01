using Tennis.GameScore;

namespace Tennis.Game.UI
{
    internal class CreateGame : GameState
    {
        public CreateGame(GameState gameState): base(gameState) { }

        public override GameState Next()
        {
            if (!ForcedExit) player1 = new Player(Ask("Name of serving player   :"));
            if (!ForcedExit) player2 = new Player(Ask("Name of receiving player :"));
            if (ForcedExit) return new EndGame(this);


            game = new TennisGame(player1, player2);
            serving = game.Started;

            return new FirstServe(this);
        }
    } 
}
