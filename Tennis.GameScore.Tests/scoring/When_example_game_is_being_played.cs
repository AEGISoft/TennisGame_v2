using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_example_game_is_being_played
    {
        [Fact]
        public void Score_should_be_right_on_each_point_scored()
        {
            var player1 = new Player("Björn");
            var player2 = new Player("John");
            var game = new TennisGame(player1, player2);

            player1.ScoredPoint(); Assert.Equal("Fifteen - Love", game.Score);
            player1.ScoredPoint(); Assert.Equal("Thirty - Love", game.Score);

            player2.ScoredPoint(); Assert.Equal("Thirty - Fifteen", game.Score);
            player2.ScoredPoint(); Assert.Equal("Thirty all", game.Score);
            player2.ScoredPoint(); Assert.Equal("Thirty - Forty", game.Score);

            player1.ScoredPoint(); Assert.Equal("Deuce", game.Score);
            player1.ScoredPoint(); Assert.Equal("Björn has advantage", game.Score);

            player2.ScoredPoint(); Assert.Equal("Deuce", game.Score);
            player2.ScoredPoint(); Assert.Equal("John has advantage", game.Score);
            player2.ScoredPoint(); Assert.Equal("John wins", game.Score);

        }
    }
}
