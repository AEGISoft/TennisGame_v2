using System;

namespace Tennis.Game.UI
{
    internal class GameStateForConsole : UIhandler
    {
        public void Say(string information)
        {
            Console.WriteLine(information);
        }

        public string Ask(string question)
        {
            Console.Write(question + " ");

            string response;
            do { response = Console.ReadLine().ToUpper(); }
            while (response.Length == 0);

            return response;
        }

        public char Choose(string question)
        {
            return Ask(question).ToCharArray()[0];
        }

    }

}
