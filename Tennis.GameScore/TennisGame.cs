namespace Tennis.GameScore
{
    public class TennisGame : ITennisScore
    {
        #region construction
        private readonly Player player1;
        private readonly Player player2;

        public TennisGame(Player player1, Player player2)
        {
            player1.PlayingAgainst(player2);

            this.player1 = player1;
            this.player2 = player2;
        }
        #endregion

        #region published interface
        public string Score
        {
            get
            {
                if (player1.Wins()) return player1.WinScore;
                if (player2.Wins()) return player2.WinScore;
                if (player1.HasAdvantage()) return player1.AdvantageScore;
                if (player2.HasAdvantage()) return player2.AdvantageScore;
                if (PlayersHaveDeuceScore()) return DeuceScore;

                return GameScore;
            }
        }

        #endregion

        #region private parts
        private bool PlayersHaveDeuceScore() { return player1.HasDeuceScoreWithOtherPlayer(); }
        private bool PlayersHaveEqualScore() { return player1.HasEqualScoreWithOtherPlayer(); }

        private string DeuceScore { get { return "Deuce"; } }
        private string GameScore
        {
            get
            {
                if (PlayersHaveEqualScore())
                    return player1.Score + " all";
                else
                    return player1.Score + " - " + player2.Score;
            }
        }
        #endregion
    }
}