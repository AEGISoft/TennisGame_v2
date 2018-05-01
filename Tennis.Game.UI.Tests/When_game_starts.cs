using System.Collections.Generic;
using Xunit;

namespace Tennis.Game.UI.Tests
{
    public class When_game_starts
    {
        [Fact]
        public void The_startscore_is_displayed_as_LOVE_ALL()
        {
            //arrange
            var mockedHandler = new UIhandlerMock(new List<char> { 'Y', '!' });

            //act
            GameState gamestate = new GameState(mockedHandler);
            do
            {
                gamestate = gamestate.Next();
            }
            while (!gamestate.EndGame);

            //assert
            var targetFound = false;
            foreach (var item in mockedHandler.Recordings)
            {
                if (item.Contains("Love all"))
                {
                    targetFound = true;
                    break;
                }
            }
            Assert.True(targetFound);
        }
    }
}
