using MongoDB.Driver;
using SportsDash.Models.SportsBookPack;
using SportsDash.Models.UserPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportsDash.ViewModel
{
    class StatsVM : ObservableObject
    {
        private readonly string Username = Account.GLOBALUSERNAME;

        private IMongoCollection<Bet> BetCollection;
        private IMongoCollection<User> UserStatsCollection;

        private float winnings { get; set; }
        private float wager { get; set; }
        private int odds { get; set; }
        private string league { get; set; }
        private string homeTeam { get; set; }
        private string awayTeam { get; set; }
        private string gameWinner { get; set; }
        private bool betWin { get; set; }

        // do the thing to set it public so it can be accessed by the statview and use {binding "name"} to get it to display the co
        private int _gamesPlayed;
        public int GamesPlayed
        {
            get { return _gamesPlayed; } 
            set
            {
                _gamesPlayed = value;
            }
        }

        private int _wins;
        public int Wins
        {
            get { return _wins;}
            set
            {
                _wins = value;
            }
        }

        private int _losses;
        public int Losses
        {
            get { return _losses; }
            set
            {
                _losses = value;
            }
  
        }

        private float _totalEarned;
        public float TotalEarned
        {
            get { return _totalEarned; }
            set
            {
                _totalEarned = value;
            }
        }

        private float _totalLost;
        public float TotalLost
        {
            get { return _totalLost; }
            set
            {
                _totalLost = value;
            }
        }

        private float _net;
        public float Net
        {
            get { return _net; }
            set
            {
                _net = value;
            }
        }


        private ObservableCollection<Bet> _dbcontent { get; set; }
        public ObservableCollection<Bet> DBContent 
        {
            get { return _dbcontent; } 
            set 
            { 
                _dbcontent = value;
            }
        }

        public StatsVM()
        { 
            DBContent = new ObservableCollection<Bet>();

            UserDataLoad();
            LoadData();

        }

        public async Task LoadData()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            BetCollection = database.GetCollection<Bet>("Bets");

            UserStatsCollection = database.GetCollection<User>("User Stats");
            var filter = Builders<Bet>.Filter.Eq("user", Username);

            try
            {
                var results = await BetCollection.Find(filter).ToListAsync();

                DBContent.Clear();
                
                foreach (var result in results)
                {
                    wager = result.wager;
                    odds = result.odds;
                    league = result.league;
                    homeTeam = result.team1;
                    awayTeam = result.team2;
                    gameWinner = result.gameWinner;
                    betWin = result.betWin;
                    winnings = result.winnings;

                    Bet newBet = new Bet(wager, odds, winnings, league, homeTeam, awayTeam, gameWinner, betWin);

                    DBContent.Add(newBet);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LoadData(): {ex.Message}");
            }

        }

        public void UserDataLoad()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            UserStatsCollection = database.GetCollection<User>("User Stats");

            var filter = Builders<User>.Filter.Eq("Username", Username);

            try
            {
                var userResult = UserStatsCollection.Find(filter).First();
                _gamesPlayed = userResult.gamesPlayed;
                _wins = userResult.wins;
                _losses = userResult.losses;
                _totalEarned = userResult.totalEarn;
                _totalLost = userResult.totalLost;
                _net = _totalEarned + _totalLost;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in LoadData(): {ex.Message}");
            }
        }
    }
}
