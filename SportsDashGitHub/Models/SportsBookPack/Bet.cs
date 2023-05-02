using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SportsDash.Models.UserPack;

namespace SportsDash.Models.SportsBookPack
{
    public class Bet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("user")]
        public string user { get; set; }

        [BsonElement("wager")]
        public float wager { get; set; }

        [BsonElement("winnings")]
        public float winnings { get; set; }

        [BsonElement("odds")]
        public int odds { get; set; }

        [BsonElement("league")]
        public string league { get; set; }

        [BsonElement("homeTeam")]
        public string team1 { get; set; }

        [BsonElement("awayTeam")]
        public string team2 { get; set; }

        [BsonElement("gameWinner")]
        public string gameWinner { get; set; }

        [BsonElement("betWin")]
        public bool betWin { get; set; } = false;

        public Bet(float wager, int odds, float winnings, string league, string team1, string team2, string gameWinner, bool betWin)
        {
            this.wager = wager;
            this.odds = odds;
            this.winnings = winnings;
            this.league = league;
            this.team1 = team1;
            this.team2 = team2;
            this.gameWinner = gameWinner;
            this.betWin = betWin;
            this.user = Account.GLOBALUSERNAME;
        }

        public Bet(float wager, int odds, string league, string team1, string team2, string gameWinner, bool betWin)
        {
            this.wager = wager;
            this.odds = odds;
            this.league = league;
            this.team1 = team1;
            this.team2 = team2;
            this.gameWinner = gameWinner;
            this.betWin = betWin;
            this.user = Account.GLOBALUSERNAME;

            if (betWin == false)
            {
                winnings = (-1) * wager;
            }
            else
            {
                winnings = calculateWins(odds);
            }
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
            return "Bet:\nUser: " + user + " | Team 1: " + team1 + " | Team 2: " + team2 + " | Game Winner: " + gameWinner + " | Wager: " + wager + " | Odds: " + odds +
                " | Bet Win: " + betWin;
        }


    }
}
