using System.Collections.Generic;

namespace Tennis.Game.UI.Tests
{
    /// <summary>
    /// purpose : Mock dependecy on system.IO out
    /// responsibilities: hold the fort until the Moq framework becomes available for dotnet Core 2.0 
    /// </summary>
    class UIhandlerMock : I_handle_the_UI
    {
        private readonly List<char> chooseAnswer;
        int chooseAnswerCounter =0;

        public List<string> Recordings { get; private set; }

        public UIhandlerMock()
        {
            Recordings = new List<string>();
            chooseAnswer = new List<char>();
        }
        public UIhandlerMock(List<char> ChooseAnswer):this() { chooseAnswer = ChooseAnswer; }

        public string Ask(string question)
        {
            return "p";
        }

        public char Choose(string question)
        {
            return chooseAnswer[chooseAnswerCounter++];
        }
        public void Say(string information)
        {
            Recordings.Add(information);
        }

        
    }
}
