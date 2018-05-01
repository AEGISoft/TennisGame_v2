namespace Tennis.GameScore
{
    /// <summary>
    /// purpose: grouping of the players in a rally
    /// responsibility: allows RallyStates to call the players 
    /// </summary>
    internal class RallyBetween 
    {
        #region construction
        public readonly Player servingPlayer;
        public readonly Player receivingPlayer;

        internal RallyBetween(Player servingPlayer, Player receivingPlayer)
        {
            this.servingPlayer = servingPlayer;
            this.receivingPlayer = receivingPlayer;
        }
        #endregion

        internal void ServingPlayerScores()   { servingPlayer.ScoredPoint(); }
        internal void ReceivingPlayerScores() { receivingPlayer.ScoredPoint(); }
    }
}
    