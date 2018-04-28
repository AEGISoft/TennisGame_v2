namespace Tennis.GameScore
{
    public class Player: ITennisScore
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
        public void PlayingAgainst(Player otherPlayer)
        {
            OtherPlayer = otherPlayer;
            OtherPlayer.OtherPlayer = this;
        }

        public void ScoredPoint() { Points++; }

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

        public string WinScore          { get { return Name + " wins"; } }
        public string AdvantageScore    { get { return Name + " has advantage"; } }

        public bool Wins()                          { return (Points >= 4 && Points - OtherPlayer.Points > 1); }
        public bool HasAdvantage()                  { return (Points >= 4 && Points - OtherPlayer.Points == 1); }
        public bool HasDeuceScoreWithOtherPlayer()  { return (Points >= 3) && HasEqualScoreWithOtherPlayer(); }
        public bool HasEqualScoreWithOtherPlayer()  { return (Points == OtherPlayer.Points); }
        #endregion

        #region private parts
        private string Name { get; }
        private int Points { get; set; }

        private Player OtherPlayer { get; set; }
        #endregion
    }
}