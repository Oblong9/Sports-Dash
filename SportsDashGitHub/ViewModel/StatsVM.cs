using MongoDB.Driver;
using SportsDash.Models.SportsBookPack;
using SportsDash.Models.UserPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
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

        private float winnings { get; set; }
        private float wager { get; set; }
        private int odds { get; set; }
        private string league { get; set; }
        private string homeTeam { get; set; }
        private string awayTeam { get; set; }
        private string gameWinner { get; set; }
        private bool betWin { get; set; }
        

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
            
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            BetCollection = database.GetCollection<Bet>("Bets");
            
            LoadData();
        }

        public async Task LoadData()
        {
            var filter = Builders<Bet>.Filter.Eq("user", Username);

            try
            {
                var results = await BetCollection.Find(filter).ToListAsync();

                DBContent.Clear();
                
                // WORKS WELL JUST REMOVE THE WINDOWS.SYSTEM.WHATEVER PART OF THE STRING IN THIS SECTION WHEN LOAING FROM DB.
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
                // Log the exception here
                Debug.WriteLine($"Error in LoadData(): {ex.Message}");
            }

        }
    }
}
