using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash
{
    public class Bet
    {
        private float wager { get; set; }
        private float winnings { get; set; }
        private int odds { get; set; }
        private String game { get; set; }
        private String gameWinner { get; set; }
        private Boolean betWin { get; set; } = false;
        private Boolean openBet { get; set; } = true;

        public Bet(float wager, int odds, float winnings)
        {
            this.wager = wager;
            this.odds = odds;
            this.winnings = winnings;
        }
        
        public Bet(float wager, int odds, float winnings, String game, String gameWinner, Boolean betWin, Boolean openBet) 
        {
            this.wager = wager;
            this.odds = odds;
            this.winnings = winnings;
            this.game = game;
            this.gameWinner = gameWinner;
            this.betWin = betWin;
            this.openBet = openBet;
            this.betWin = openBet;
        }

        // Function for calculating the amount won including the wager
        public float calculateWins(int odds)
        {
            int multiplier;

            if(odds < 0)
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

        public String ToString()
        {
            return "Bet:\nGame: " + game + " | Game Winner: " + gameWinner + " | Wager: " + wager + " | Odds: " + odds +
                " | Bet Win: " + betWin + " | Open Bet: " + openBet;
        }


    }
}
