namespace Tennis.Game.UI
{
    public interface UIhandler
    {
        void Say(string information);
        string Ask(string question);
        char Choose(string question);
    }

}
