namespace Tennis.GameScore
{
    public class ReceivingPlayerReturning : RallyState, I_manage_a_rally_state
    {
        #region construction
        internal ReceivingPlayerReturning(RallyBetween rallyBetween) : base(rallyBetween) { }
        #endregion

        #region published interface
        public I_manage_a_rally_state ServeOrReturnCorrectly()  { return new ServingPlayerReturning(RallyBetween); }
        public I_manage_a_rally_state ServeOrReturnFaulty()
        {
            RallyBetween.servingPlayer.ScoredPoint();
            return new PlayerServing(RallyBetween);
        }
        #endregion
    }
}
    