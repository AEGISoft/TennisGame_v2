using System;
using Tennis.GameScore;

namespace Tennis.Game.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mega Tennis !");
            Console.WriteLine("------------------------");
            Console.WriteLine();
            Console.WriteLine("notice: responding with '!' always ends the game.");
            Console.WriteLine();
            Console.Write("New Game (Y/N) ");
            var response = Console.ReadLine().ToUpper();

            Player player1 = null;
            Player player2 = null;
            TennisGame game = null;

            if (response == "Y")
            {
                if (response != "!") response = CreatePlayer("One", ref player1);
                if (response != "!") response = CreatePlayer("Two", ref player2);
                if (response != "!") response = CreateGame(player1, player2, ref game);
//                if (response != "!") response = ReturnOnServe(player1, player2, response);
            }

        }

//        private static string ReturnOnServe(Player player1, Player player2, string response)
//        {
//            if (response == "Y") return ServeResponse(player1, player2);
//            return 
//        }

        private static string CreateGame(Player player1, Player player2, ref TennisGame game)
        {
            string response;

            game = new TennisGame(player1, player2);

            Console.WriteLine(FormatScore(player1.Name + " vs " + player2.Name, game));
            Console.Write(player1.Name + " serves correctly (Y/N) ");
            response = Console.ReadLine().ToUpper();

            return response;
        }

        private static string FormatScore(string prefix, TennisGame game)
        {
            if (prefix.Length > 38) prefix = prefix.Substring(0, 38);
            var spaces = 40 - prefix.Length;
            return prefix + new string(' ',spaces) + " Score:" + game.Score;
        }

        private static string CreatePlayer(string playerNr, ref Player player)
        {
            string response;
            Console.Write("Name Player "+ playerNr + ": ");
            response = Console.ReadLine();

            if (response != "!")
            {
                player = new Player(response);
            }

            return response;
        }
    }
}
