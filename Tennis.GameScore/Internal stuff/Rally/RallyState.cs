namespace Tennis.GameScore
{
    /// <summary>
    /// purpose: base class for the different states in a rally.  
    /// responsibility: contains a reference to the players in the rally, for the subclasses to access
    /// </summary>
    internal class RallyState
    {
        #region construction
        public RallyBetween RallyBetween { get; private set; }

        internal RallyState(RallyBetween rallyBetween)
        {
            this.RallyBetween = rallyBetween;
        }
        #endregion
    }
}
    