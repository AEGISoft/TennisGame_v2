using Xunit;

namespace Tennis.GameScore.Tests
{
    public class When_game_starts
    {
        [Fact]
        public void Score_should_Be_LOVE_ALL()
        {
            var game = new TennisGame(new Player("p1"),new Player("p2"));
            Assert.Equal("Love all", game.Score);
        }
    }
}
