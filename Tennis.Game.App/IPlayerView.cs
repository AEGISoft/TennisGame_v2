using Tennis.GameScore;

namespace Tennis.Game.App
{
    interface IPlayerView
    {
        void PaintGameInitializeLayout(Player player);
        void AllowWritingPlayerName();
        void ConfirmPlayerName();
    }
}
