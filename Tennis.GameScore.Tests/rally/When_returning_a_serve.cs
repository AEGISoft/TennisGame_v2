using System;
using Xunit;

namespace Tennis.GameScore.Tests
{

    #region arrange
    public class When_returning_a_serve : AaaStyleTest
    {
        protected I_manage_a_rally_state returnRally;
        protected Type actualType;

        protected override void Arrange()
        {
            Player servingPlayer = new Player("serving");
            Player receivingPlayer = new Player("receiving");
            TennisGame game = new TennisGame(servingPlayer, receivingPlayer);

            returnRally = new PlayerServing(servingPlayer, receivingPlayer)
                                .ServeOrReturnCorrectly();

        }
    }
    #endregion

    public class When_returning_a_serve_correctly: When_returning_a_serve
    {
        protected override void Act()
        {
            actualType = returnRally.ServeOrReturnCorrectly().GetType();
        }

        [Fact] public void Other_player_should_return_the_rally()
        {
            Assert.Equal(typeof(ServingPlayerReturning), actualType);
        }
    }

    public class When_returning_a_serve_faulty : When_returning_a_serve
    {
        protected override void Act()
        {
            actualType = returnRally.ServeOrReturnFaulty().GetType();
        }

        [Fact] public void Other_player_scores_a_point()
        {
            var actualScore = returnRally.RallyBetween.servingPlayer.Score;
            Assert.Equal("Fifteen", actualScore);
        }
        [Fact] public void Rally_ends()
        {
            Assert.Equal(typeof(PlayerServing), actualType);
        }
    }
}
