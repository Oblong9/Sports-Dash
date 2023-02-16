using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash
{
    public class User
    {
        //public int Id { get; set; }
        private String userName { get; set; }
        private int wins { get; set; }
        private int losses { get; set; }
        private int gamesPlayed { get; set; }
        private float totalEarn { get; set; }
        private float totalLost { get; set; }
        private float net { get; set; }

        // Used for new accounts
        public User(String userName)
        {
            this.userName= userName;
        }

        // Used to add existing accounts th at lost data
        public User(String userName, int wins, int losses, int gamesPlayed, float totalEarn, float totalLost)
        {
            this.userName = userName;
            this.wins = wins;
            this.losses = losses;
            this.gamesPlayed= gamesPlayed;
            this.totalEarn = totalEarn;
            this.totalLost = totalLost;
            net = totalEarn - totalLost;
        }

        public void addWin()
        {
            wins++;
        }

        public void addLoss()
        {
            losses++;
        }

        public void addTotalEarn(float earned)
        {
            totalEarn += earned;
        }

        public void addTotalLost(float loss)
        {
            totalLost -= loss;
        }
        public override String ToString()
        {
            return "User:\nUsername: " + userName + "\nWins: " + wins + "\nLosses: " + losses + "\nGames Played: " + gamesPlayed + "\nTotal Earned: " + totalEarn + "\nTotal Lost: " + totalLost + "\nNet: " + net;
        }

    }

}
