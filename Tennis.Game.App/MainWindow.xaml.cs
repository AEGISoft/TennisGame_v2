using System.Windows;

namespace Tennis.Game.App
{
    public partial class MainWindow : Window
    {
        #region construction
        private readonly IPlayerView player1View;
        private readonly IPlayerView player2View;
        private readonly IGameView gameView;
        private readonly GameController gameController;

        public MainWindow()
        {
            InitializeComponent();

            gameView = new GameView(GameScore_label, NewGame_Button);

            player1View = new PlayerView(
                CreatePlayer1_Button,
                Player1Name_Textbox,
                Player1Name_label,
                Player1Serves_Button,
                Player1Misses_Button,
                Player1Faults_Button,
                Player1Returns_Button);

            player2View = new PlayerView(
                CreatePlayer2_Button,
                Player2Name_Textbox,
                Player2Name_label,
                Player2Serves_Button,
                Player2Misses_Button,
                Player2Faults_Button,
                Player2Returns_Button);

            gameController = new GameController(player1View, player2View, gameView);

        }
        #endregion
    }
}
