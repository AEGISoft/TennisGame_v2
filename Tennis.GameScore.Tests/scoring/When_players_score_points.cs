using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_players_score_points
    {
        [Theory]
        //combinations - player1 : 0 points
        [InlineData("Björn", 0, "John", 0, "Love all")]
        [InlineData("Björn", 0, "John", 1, "Love - Fifteen")]
        [InlineData("Björn", 0, "John", 2, "Love - Thirty")]
        [InlineData("Björn", 0, "John", 3, "Love - Forty")]
        [InlineData("Björn", 0, "John", 4, "John wins")]

        //combinations - player1 : 1 point
        [InlineData("Björn", 1, "John", 0, "Fifteen - Love")]
        [InlineData("Björn", 1, "John", 1, "Fifteen all")]
        [InlineData("Björn", 1, "John", 2, "Fifteen - Thirty")]
        [InlineData("Björn", 1, "John", 3, "Fifteen - Forty")]
        [InlineData("Björn", 1, "John", 4, "John wins")]

        //combinations - player1 : 2 points
        [InlineData("Björn", 2, "John", 0, "Thirty - Love")]
        [InlineData("Björn", 2, "John", 1, "Thirty - Fifteen")]
        [InlineData("Björn", 2, "John", 2, "Thirty all")]
        [InlineData("Björn", 2, "John", 3, "Thirty - Forty")]
        [InlineData("Björn", 2, "John", 4, "John wins")]

        //combinations - player1 : 3 points
        [InlineData("Björn", 3, "John", 0, "Forty - Love")]
        [InlineData("Björn", 3, "John", 1, "Forty - Fifteen")]
        [InlineData("Björn", 3, "John", 2, "Forty - Thirty")]
        [InlineData("Björn", 3, "John", 3, "Deuce")]
        [InlineData("Björn", 3, "John", 4, "John has advantage")]
        [InlineData("Björn", 3, "John", 5, "John wins")]

        //combinations - player1 : 4 points
        [InlineData("Björn", 4, "John", 0, "Björn wins")]
        [InlineData("Björn", 4, "John", 1, "Björn wins")]
        [InlineData("Björn", 4, "John", 2, "Björn wins")]
        [InlineData("Björn", 4, "John", 3, "Björn has advantage")]
        [InlineData("Björn", 4, "John", 4, "Deuce")]
        [InlineData("Björn", 4, "John", 5, "John has advantage")]
        [InlineData("Björn", 4, "John", 6, "John wins")]

        //combinations - player1 : 4+ points
        [InlineData("Björn", 5, "John", 3, "Björn wins")]
        [InlineData("Björn", 5, "John", 5, "Deuce")]
        [InlineData("Björn", 15, "John", 16, "John has advantage")]
        [InlineData("Björn", 21, "John", 20, "Björn has advantage")]
        [InlineData("Björn", 50, "John", 50, "Deuce")]

        //illegal combinations : prove that we can deal with these without breaking
        [InlineData("Björn", 5, "John", 0, "Björn wins")]
        [InlineData("Björn", 5, "John", 1, "Björn wins")]
        [InlineData("Björn", 5, "John", 2, "Björn wins")]

        public void Score_should_be_translated(string player1Name, int player1Points, string player2Name, int player2Points, string expectedScore)
        {
            //arrange
            Player player2 = new Player(player2Name);
            Player player1 = new Player(player1Name);
            var game = new TennisGame(player1, player2);
            bool PlayerOneWinning = player1Points > player2Points;
            bool PlayerTwoWinning = player2Points > player1Points;
            int ScoringAtEqualPace = CalculateEqualPace(player1Points, player2Points, PlayerOneWinning, PlayerTwoWinning);

            //act
            BothPlayersScoreAtEqualPace(ScoringAtEqualPace, game);
            if (PlayerOneWinning) PlayerOneScoresExtra(player1Points - ScoringAtEqualPace, game);
            if (PlayerTwoWinning) PlayerTwoScoresExtra(player2Points - ScoringAtEqualPace, game);

            //assert
            Assert.Equal(expectedScore, game.Score);
        }

        #region private parts
        private static void PlayerOneScoresExtra(int extraScores, TennisGame game)
        {
            for (int points = 0; points < extraScores; points++) { PlayerOneScores(game); }
        }
        private static void PlayerTwoScoresExtra(int extraScores, TennisGame game)
        {
            for (int points = 0; points < extraScores; points++) { PlayerTwoScores(game); }
        }
        private static void BothPlayersScoreAtEqualPace(int ScoringAtEqualPace, TennisGame game)
        {
            for (int points = 0; points < ScoringAtEqualPace; points++)
            {
                PlayerOneScores(game);
                PlayerTwoScores(game);
            }
        }

        private static int CalculateEqualPace(int player1Points, int player2Points, bool PlayerOneWinning, bool PlayerTwoWinning)
        {
            int ScoringAtEqualPace = player1Points;
            if (PlayerOneWinning) ScoringAtEqualPace = player2Points;
            if (PlayerTwoWinning) ScoringAtEqualPace = player1Points;
            return ScoringAtEqualPace;
        }
        private static void PlayerTwoScores(TennisGame game)
        {
            game.ServeFaulty().ServeFaulty();
        }
        private static void PlayerOneScores(TennisGame game)
        {
            game.Serve().Miss();
        }
        #endregion
    }
}
