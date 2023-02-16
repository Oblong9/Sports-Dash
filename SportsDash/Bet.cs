using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash
{
    internal class Bet
    {
        private float wager { get; set; }
        private float winnings { get; set; }
        private int odds { get; set; }
        private String game { get; set; }
        private String gameWinner { get; set; }
        private Boolean betWin { get; set; } = false;
        private Boolean openBet { get; set; } = true;
    }
}
