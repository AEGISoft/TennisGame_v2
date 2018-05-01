using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_example_game_is_played
    {
        [Fact]
        public void Scoring_happens_on_faulty_returns_or_double_servefaults()
        {
            // Arrange
            var servingPlayer = new Player("servingPlayer");
            var receivingPlayer = new Player("receivingPlayer");
            var game = new TennisGame(servingPlayer, receivingPlayer);


            // Act & assert 1st rally
            game.Serve().Return().Miss();
            Assert.Equal("Love - Fifteen", game.Score);

            // Act & assert 2nd rally
            game.Serve().Miss();
            Assert.Equal("Fifteen all", game.Score);

            // Act & assert 3rd rally
            game.ServeFaulty().ServeFaulty();
            Assert.Equal("Fifteen - Thirty", game.Score);

            // Act & assert fourth rally
            game.Serve().Return().Return().Miss();
            Assert.Equal("Thirty all", game.Score);

        }
    }
}
