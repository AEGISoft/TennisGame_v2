using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_receiving_player_returns_the_serve
    {
        [Fact]
        public void No_one_makes_a_point()
        {
            // Arrange
            var servingPlayer = new Player("servingPlayer");
            var receivingPlayer = new Player("receivingPlayer");
            var game = new TennisGame(servingPlayer, receivingPlayer);

            // Act
            game.Serve().Return();

            // Assert
            Assert.Equal("Love all", game.Score);

        }
    }
}
