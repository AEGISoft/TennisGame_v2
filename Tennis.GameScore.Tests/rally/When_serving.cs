using System;
using Xunit;

namespace Tennis.GameScore.Tests
{
    #region arrange
    public class When_serving : AaaStyleTest
    {
        protected I_manage_a_rally_state startedRally;
        protected Type actualType;

        protected override void Arrange()
        {
            startedRally = new PlayerServing(new Player("serving"), new Player("receiving"));
        }
    }
    #endregion

    public class When_serving_correctly: When_serving
    {
        protected override void Act()
        {
            actualType = startedRally.ServeOrReturnCorrectly().GetType();
        }

        [Fact]
        public void Receiving_player_should_return_the_serve()
        {
            Assert.Equal(typeof(ReceivingPlayerReturning), actualType);
        }
    }

    public class When_serving_faulty : When_serving
    {
        protected override void Act()
        {
            actualType = startedRally.ServeOrReturnFaulty().GetType();
        }

        [Fact]
        public void Serving_player_can_try_again()
        {
            Assert.Equal(typeof(PlayerServingAgain), actualType);
        }
    }
}
