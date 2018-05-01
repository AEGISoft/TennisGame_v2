namespace Tennis.Game.UI
{
    public interface I_handle_the_UI
    {
        void Say(string information);
        string Ask(string question);
        char Choose(string question);
    }

}
