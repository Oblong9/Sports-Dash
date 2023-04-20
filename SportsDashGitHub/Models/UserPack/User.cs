using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportsDash.Models.UserPack
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Username")]
        public string userName { get; set; }

        [BsonElement("Wins")]
        public int wins { get; set; } = 0;

        [BsonElement("Losses")]
        public int losses { get; set; } = 0;

        [BsonElement("Games Played")]
        public int gamesPlayed { get; set; } = 0;

        [BsonElement("Total Earned")]
        public float totalEarn { get; set; } = 0.00F;

        [BsonElement("Total Lost")]
        public float totalLost { get; set; } = 0.00F;


        // Used for new accounts
        public User(string userName)
        {
            this.userName = userName;
        }

        public User(string userName, int wins, int losses, int gamesPlayed, float totalEarn, float totalLost)
        {
            this.userName = userName;
            this.wins = wins;
            this.losses = losses;
            this.gamesPlayed = gamesPlayed;
            this.totalEarn = totalEarn;
            this.totalLost = totalLost;
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

        public override string ToString()
        {
            return "User:\nUsername: " + userName + "\nWins: " + wins + "\nLosses: " + losses + "\nGames Played: " + gamesPlayed + "\nTotal Earned: " + totalEarn + "\nTotal Lost: " + totalLost;
        }

    }

}
