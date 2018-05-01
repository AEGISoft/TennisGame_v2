using Tennis.GameScore;

namespace Tennis.Game.UI
{

    public class GameState 
    {
        #region fields
        protected bool ForcedExit = false;
        protected Player player1;
        protected Player player2;
        protected Player currentPlayer;

        protected TennisGame game;
        protected I_am_rallying rallying;
        protected I_am_serving serving;

        protected UIhandler uiHandler;
        #endregion

        #region construction
        public GameState(UIhandler uiHandler) { this.uiHandler = uiHandler; }
        protected GameState(GameState previousState)
        {
            player1 = previousState.player1;
            player2 = previousState.player2;
            game = previousState.game;
            currentPlayer = previousState.currentPlayer;
            rallying = previousState.rallying;
            serving = previousState.serving;
            uiHandler = previousState.uiHandler;
        }
        #endregion

        #region helpers
        protected void SayScore()
        {
            uiHandler.Say(FormatScore(player1.Name + " vs " + player2.Name, game.Score)); 
        }
        private static string FormatScore(string prefix, string gameScore)
        {
            if (prefix.Length > 38) prefix = prefix.Substring(0, 38);
            var spaces = 40 - prefix.Length;
            return prefix + new string(' ', spaces) + " Score:" + gameScore;
        }

        protected void Say()
        {
            uiHandler.Say("");
        }
        protected void Say(string information)
        {
            uiHandler.Say(information);
        }
        protected string Ask(string question)
        {
            var response = uiHandler.Ask(question);

            if (response.ToCharArray()[0] == '!') ForcedExit = true;

            return response;
        }
        protected char Choose(string question)
        {
            var response = uiHandler.Choose(question);

            if (response == '!') ForcedExit = true;

            return response;
        }

        protected GameState CorrectReturn(GameState gameState)
        {
            rallying.Return();

            return new ReturnRally(gameState);
        }
        protected GameState FaultyReturn(GameState gameState)
        {
            rallying.Miss();

            return new FirstServe(gameState);
        }
        protected GameState CorrectServe(GameState gamestate)
        {
            rallying = serving.Serve();

            return new ReturnRally(gamestate);
        }
        protected GameState FaultyServe(GameState gamestate) {
            if (gamestate.GetType() == typeof(FirstServe))
            {
                serving = game.ServeFaulty();
                return new SecondServe(gamestate);
            }
            else
            {
                serving.ServeFaulty();
                return new FirstServe(gamestate);
            }
        }
        #endregion

        #region published interface
        public virtual GameState Next()
        {
            return new StartGame(this);
        }
        #endregion
    }

}
