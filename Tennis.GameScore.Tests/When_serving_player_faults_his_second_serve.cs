using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_serving_player_faults_his_second_serve
    {
        [Fact]
        public void Serving_player_looses_a_point()
        {
            // Arrange
            var servingPlayer = new Player("servingPlayer");
            var receivingPlayer = new Player("receivingPlayer");
            var game = new TennisGame(servingPlayer, receivingPlayer);

            // Act
            game.ServeFaulty().ServeFaulty();

            // Assert
            Assert.Equal("Love - Fifteen", game.Score);

        }
    }
}
