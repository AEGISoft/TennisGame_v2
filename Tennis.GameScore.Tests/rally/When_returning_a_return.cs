using System;
using Xunit;

namespace Tennis.GameScore.Tests
{

    #region arrange
    public class When_returning_a_return : AaaStyleTest
    {
        protected I_manage_a_rally_state returnRally;
        protected Type actualType;

        protected override void Arrange()
        {
            Player servingPlayer = new Player("serving");
            Player receivingPlayer = new Player("receiving");
            TennisGame game = new TennisGame(servingPlayer, receivingPlayer);

            returnRally = new PlayerServing(servingPlayer, receivingPlayer)
                                .ServeOrReturnCorrectly()
                                .ServeOrReturnCorrectly();

        }
    }
    #endregion

    public class When_returning_a_return_correctly: When_returning_a_return
    {
        protected override void Act()
        {
            actualType = returnRally.ServeOrReturnCorrectly().GetType();
        }

        [Fact] public void Other_player_should_return_the_rally()
        {
            Assert.Equal(typeof(ReceivingPlayerReturning), actualType);
        }
    }

    public class When_returning_a_return_faulty : When_returning_a_return
    {
        protected override void Act()
        {
            actualType = returnRally.ServeOrReturnFaulty().GetType();
        }

        [Fact] public void Other_player_scores_a_point()
        {
            var actualScore = returnRally.RallyBetween.receivingPlayer.Score;
            Assert.Equal("Fifteen", actualScore);
        }
        [Fact] public void Rally_ends()
        {
            Assert.Equal(typeof(PlayerServing), actualType);
        }
    }
}
