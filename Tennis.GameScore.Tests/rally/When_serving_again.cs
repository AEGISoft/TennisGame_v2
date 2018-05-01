using System;
using Xunit;

namespace Tennis.GameScore.Tests
{

    #region arrange
    public class When_serving_again : AaaStyleTest
    {
        protected I_manage_a_rally_state secondServeRally;
        protected Type actualType;

        protected override void Arrange()
        {
            Player servingPlayer = new Player("serving");
            Player receivingPlayer = new Player("receiving");
            TennisGame game = new TennisGame(servingPlayer, receivingPlayer);

            secondServeRally = new PlayerServing(servingPlayer, receivingPlayer)
                                .ServeOrReturnFaulty();

        }
    }
    #endregion

    public class When_serving_again_correctly: When_serving_again
    {
        protected override void Act()
        {
            actualType = secondServeRally.ServeOrReturnCorrectly().GetType();
        }

        [Fact] public void Receiving_player_should_return_the_serve()
        {
            Assert.Equal(typeof(ReceivingPlayerReturning), actualType);
        }
    }

    public class When_serving_again_faulty : When_serving_again
    {
        protected override void Act()
        {
            actualType = secondServeRally.ServeOrReturnFaulty().GetType();
        }

        [Fact] public void Receiving_player_scores_a_point()
        {
            var actualScore = secondServeRally.RallyBetween.receivingPlayer.Score;
            Assert.Equal("Fifteen", actualScore);
        }
        [Fact] public void Rally_ends()
        {
            Assert.Equal(typeof(PlayerServing), actualType);
        }
    }
}
