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

            PlayerOneWinsRally(game); Assert.Equal("Fifteen - Love", game.Score);
            PlayerOneWinsRally(game); Assert.Equal("Thirty - Love", game.Score);

            PlayerTwoWinsRally(game); Assert.Equal("Thirty - Fifteen", game.Score);
            PlayerTwoWinsRally(game); Assert.Equal("Thirty all", game.Score);
            PlayerTwoWinsRally(game); Assert.Equal("Thirty - Forty", game.Score);

            PlayerOneWinsRally(game); Assert.Equal("Deuce", game.Score);
            PlayerOneWinsRally(game); Assert.Equal("Björn has advantage", game.Score);

            PlayerTwoWinsRally(game); Assert.Equal("Deuce", game.Score);
            PlayerTwoWinsRally(game); Assert.Equal("John has advantage", game.Score);
            PlayerTwoWinsRally(game); Assert.Equal("John wins", game.Score);

        }

        private static I_am_serving PlayerTwoWinsRally(TennisGame game)
        {
            return game.Serve().Return().Miss();
        }

        private static void PlayerOneWinsRally(TennisGame game)
        {
            game.Serve().Miss();
        }
    }
}
