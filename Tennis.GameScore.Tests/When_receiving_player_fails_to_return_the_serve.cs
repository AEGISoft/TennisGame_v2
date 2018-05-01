using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_receiving_player_fails_to_return_the_serve
    {
        [Fact]
        public void Serving_player_makes_a_point()
        {
            // Arrange
            var servingPlayer = new Player("servingPlayer");
            var receivingPlayer = new Player("receivingPlayer");
            var game = new TennisGame(servingPlayer, receivingPlayer);

            // Act
            game.Serve().Miss();

            // Assert
            Assert.Equal("Fifteen - Love", game.Score);

        }
    }
}
