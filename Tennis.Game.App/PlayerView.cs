using System.Windows;
using System.Windows.Controls;
using Tennis.GameScore;

namespace Tennis.Game.App
{
    class PlayerView : IPlayerView
    {
        #region construction
        private readonly Button createPlayer_Button;
        private readonly TextBox playerName_Textbox;
        private readonly Label playerName_Label;
        private readonly Button playerServes_Button;
        private readonly Button playerMisses_Button;
        private readonly Button playerFaults_Button;
        private readonly Button playerReturns_Button;

        public PlayerView(Button CreatePlayer_button,
                          TextBox PlayerName_textbox,
                          Label PlayerName_label,
                          Button PlayerServes_button,
                          Button PlayerMisses_button,
                          Button PlayerFaults_button,
                          Button PlayerReturns_button)
        {
            createPlayer_Button = CreatePlayer_button;
            playerName_Textbox = PlayerName_textbox;
            playerName_Label = PlayerName_label;
            playerServes_Button = PlayerServes_button;
            playerMisses_Button = PlayerMisses_button;
            playerFaults_Button = PlayerFaults_button;
            playerReturns_Button = PlayerReturns_button;
        }
        #endregion

        public void PaintGameInitializeLayout(Player player)
        {
            createPlayer_Button.Visibility = Visibility.Visible;

            playerName_Textbox.Visibility = Visibility.Hidden;
            playerName_Label.Visibility = Visibility.Hidden;

            playerServes_Button.Visibility = Visibility.Hidden;
            playerMisses_Button.Visibility = Visibility.Hidden;
            playerFaults_Button.Visibility = Visibility.Hidden;
            playerReturns_Button.Visibility = Visibility.Hidden;

            playerName_Label.Content = player.Name;
            playerName_Textbox.Text = player.Name;
        }

        public void AllowWritingPlayerName()
        {
            playerName_Textbox.Visibility = Visibility.Visible;
            playerName_Textbox.Focus();
            playerName_Textbox.SelectAll();

            createPlayer_Button.Visibility = Visibility.Hidden;
        }

        public void ConfirmPlayerName()
        {
            playerName_Textbox.Visibility = Visibility.Hidden;
            playerName_Label.Content = playerName_Textbox.Text;
        }

    }
}
