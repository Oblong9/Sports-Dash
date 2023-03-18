namespace SportsDash.Models.UserPack
{
    public class User
    {
        //public int Id { get; set; }
        private string userName { get; set; }
        private int wins { get; set; } = 0;
        private int losses { get; set; } = 0;
        private int gamesPlayed { get; set; } = 0;
        private float totalEarn { get; set; } = 0.00F;
        private float totalLost { get; set; } = 0.00F;
        private float net { get; set; } = 0;

        // Used for new accounts
        public User(string userName)
        {
            this.userName = userName;
        }

        // Used to add existing accounts that lost data
        public User(string userName, int wins, int losses, int gamesPlayed, float totalEarn, float totalLost)
        {
            this.userName = userName;
            this.wins = wins;
            this.losses = losses;
            this.gamesPlayed = gamesPlayed;
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

        public void addGamesPlayed()
        {
            gamesPlayed++;
        }

        public void updateNet()
        {
            net = totalEarn - totalLost;
        }

        public void changeTotalEarn(float earned)
        {
            totalEarn += earned;
        }

        public void changeTotalLost(float loss)
        {
            totalLost -= loss;
        }

        public override string ToString()
        {
            return "User:\nUsername: " + userName + "\nWins: " + wins + "\nLosses: " + losses + "\nGames Played: " + gamesPlayed + "\nTotal Earned: " + totalEarn + "\nTotal Lost: " + totalLost + "\nNet: " + net;
        }

    }

}
