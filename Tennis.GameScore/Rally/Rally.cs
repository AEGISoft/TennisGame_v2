namespace Tennis.GameScore
{
    /// <summary>
    /// purpose: provide a strict interface to avoid illegal state-transitions
    /// </summary>
    internal class Rally : I_am_rallying, I_am_serving
    {
        #region construction
        private I_manage_a_rally_state rally;

        private Rally(I_manage_a_rally_state rallyState)
        {
            this.rally = rallyState;
        }

        public Rally(Player player1, Player player2)
        {
            this.rally = new PlayerServing(player1, player2);
        }
        #endregion

        #region internal interface
        I_am_rallying I_am_serving.Serve()      { return new Rally(rally.ServeOrReturnCorrectly()); }
        I_am_serving I_am_serving.ServeFaulty() { return new Rally(rally.ServeOrReturnFaulty()); }

        I_am_rallying I_am_rallying.Return()    { return new Rally(rally.ServeOrReturnCorrectly()); }
        I_am_serving I_am_rallying.Miss()       { return new Rally(rally.ServeOrReturnFaulty()); }
        #endregion
    }
}