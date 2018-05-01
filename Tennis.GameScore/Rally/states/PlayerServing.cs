namespace Tennis.GameScore
{
    public class PlayerServing : RallyState, I_manage_a_rally_state
    {
        #region construction
        // startpoint for a rally - the only public constructor
        public PlayerServing(Player servingPlayer, Player receivingPlayer) : base(new RallyBetween(servingPlayer, receivingPlayer)) { }
        
        internal PlayerServing(RallyBetween rallyBetween) : base(rallyBetween) { } //just passing on the internal state
        #endregion

        #region published interface
        public I_manage_a_rally_state ServeOrReturnCorrectly()  { return new ReceivingPlayerReturning(RallyBetween); }
        public I_manage_a_rally_state ServeOrReturnFaulty()     { return new PlayerServingAgain(RallyBetween); }
        #endregion
    }
}
    