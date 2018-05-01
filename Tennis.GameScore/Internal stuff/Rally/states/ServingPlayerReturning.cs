namespace Tennis.GameScore
{
    internal class ServingPlayerReturning : RallyState, I_manage_a_rally_state
    {
        #region construction
        internal ServingPlayerReturning(RallyBetween rallyBetween) : base(rallyBetween) { }
        #endregion

        #region published interface
        public I_manage_a_rally_state ServeOrReturnCorrectly()  { return new ReceivingPlayerReturning(RallyBetween); }
        public I_manage_a_rally_state ServeOrReturnFaulty()
        {
            RallyBetween.receivingPlayer.ScoredPoint();
            return new PlayerServing(RallyBetween);
        }
        #endregion
    }
}
    