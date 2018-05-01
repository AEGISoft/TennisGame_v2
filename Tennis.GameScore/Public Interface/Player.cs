namespace Tennis.GameScore
{
    public class Player
    {
        #region construction
        public Player(string name)
        {
            Name = name;
            Points = 0;
            OtherPlayer = this;// start by playing against yourself :-)
        }

        #endregion

        #region published interface
        public string Name { get; }
        public Player OtherPlayer { get; set; }

        public string Score
        { get {
            switch (Points)
            {
                case 0:  return "Love";
                case 1:  return "Fifteen";
                case 2:  return "Thirty";
                default: return "Forty"; 
            }
        } }
        #endregion

        #region internal interface
        internal void PlayingAgainst(Player otherPlayer)
        {
            OtherPlayer = otherPlayer;
            OtherPlayer.OtherPlayer = this;
        }

        internal void ScoredPoint() { Points++; }

        internal string WinScore { get { return Name + " wins"; } }
        internal string AdvantageScore { get { return Name + " has advantage"; } }

        internal bool Wins() { return (Points >= 4 && Points - OtherPlayer.Points > 1); }
        internal bool HasAdvantage() { return (Points >= 4 && Points - OtherPlayer.Points == 1); }
        internal bool HasDeuceScoreWithOtherPlayer() { return (Points >= 3) && HasEqualScoreWithOtherPlayer(); }
        internal bool HasEqualScoreWithOtherPlayer() { return (Points == OtherPlayer.Points); }
        #endregion

        #region private parts
        private int Points { get; set; }
        #endregion
    }
}