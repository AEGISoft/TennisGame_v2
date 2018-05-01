using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_serving_player_faults_his_first_serve
    {
        [Fact]
        public void Serving_player_gets_another_chance()
        {
            // Arrange
            var servingPlayer = new Player("servingPlayer");
            var receivingPlayer = new Player("receivingPlayer");
            var game = new TennisGame(servingPlayer, receivingPlayer);

            // Act
            game.ServeFaulty();

            // Assert
            Assert.Equal("Love all", game.Score);

        }
    }
}
