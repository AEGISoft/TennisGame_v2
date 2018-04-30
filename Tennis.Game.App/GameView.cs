using System.Windows.Controls;

namespace Tennis.Game.App
{
    class GameView: IGameView
    {
        #region constructor
        private readonly Label gameScore_Label;
        private readonly Button newGame_Button;

        public GameView(Label gameScore_label,
                        Button newGame_button)
        {
            gameScore_Label = gameScore_label;
            newGame_Button = newGame_button;
        }
        #endregion
    }
}
