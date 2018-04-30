using Tennis.GameScore;

namespace Tennis.Game.App
{
    class GameController
    {
        #region construction
        private readonly IPlayerView player1View;
        private readonly IPlayerView player2View;
        private readonly IGameView gameView;
        private readonly Player player1;
        private readonly Player player2;

        public GameController(IPlayerView player1View,
                                IPlayerView player2View,
                                IGameView gameView)
        {
            this.player1 = new Player("player 1");
            this.player2 = new Player("player 2");

            this.player1View = player1View;
            this.player2View = player2View;
            this.gameView = gameView;

            player1View.PaintGameInitializeLayout(this.player1);
            player2View.PaintGameInitializeLayout(this.player2);
        }
        #endregion

        public void CreatePlayerOne()
        {
            player1View.AllowWritingPlayerName();
        }

        internal void PlayerOneNameCreated()
        {
            player1View.ConfirmPlayerName();

        }
    }
}
