
namespace SportsDash.SportsBookPack
{
    public class Bet
    {
        private float wager { get; set; }
        private float winnings { get; set; }
        private int odds { get; set; }
        private string team1 { get; set; }
        private string team2 { get; set; }
        private string gameWinner { get; set; }
        private bool betWin { get; set; } = false;
        private bool openBet { get; set; } = true;

        public Bet(float wager, int odds, float winnings)
        {
            this.wager = wager;
            this.odds = odds;
            this.winnings = winnings;
        }

        public Bet(float wager, int odds, float winnings, string team1, string team2, string gameWinner, bool betWin, bool openBet)
        {
            this.wager = wager;
            this.odds = odds;
            this.winnings = winnings;
            this.team1 = team1;
            this.team2 = team2;
            this.gameWinner = gameWinner;
            this.betWin = betWin;
            this.openBet = openBet;
            this.betWin = openBet;
        }

        // Function for calculating the amount won including the wager
        public float calculateWins(int odds)
        {
            int multiplier;

            if (odds < 0)
            {
                multiplier = 100 / odds * -1;
                winnings = wager * multiplier + wager;

            }
            else
            {
                multiplier = odds / 100;
                winnings = wager * multiplier + wager;
            }
            return winnings;
        }

        public override string ToString()
        {
            return "Bet:\nTeam 1: " + team1+ " | Team 2: " + team2 + " | Game Winner: " + gameWinner + " | Wager: " + wager + " | Odds: " + odds +
                " | Bet Win: " + betWin + " | Open Bet: " + openBet;
        }


    }
}
