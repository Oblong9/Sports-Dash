using System;
using System.Windows.Input;
using MongoDB.Driver;
using SportsDash.Models.UserPack;
using System.Configuration;
using SportsDash.Models.SportsBookPack;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Threading;
using System.Windows;

namespace SportsDash.ViewModel
{
    class BetVM : ObservableObject
    {
        private IMongoCollection<Bet> betCollection;

        private IMongoCollection<User> userStatCollection;
        
        private Account currentUser { get; set; }

        private Bet bet { get; set; }


        private String _league;
        public String League
        {
            get { return _league; }
            set
            {
                _league = value;
                OnPropertyChanged();
            }
        }

        private String _team1;
        public String Team1
        {
            get { return _team1; }
            set
            {
                if(_team1 != value)
                {
                    _team1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private String _team2;
        public String Team2
        {
            get { return _team2; }
            set
            {
                _team2 = value;
                OnPropertyChanged();
            }
        }

        private String _winner;
        public String Winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                OnPropertyChanged();
            }
        }

        private float _wager;
        public float Wager
        {
            get { return _wager; }
            set
            {
                _wager = value;
            }
        }

        private int _odds;
        public int Odds
        {
            get { return _odds; }
            set
            {
                _odds = value;
                OnPropertyChanged();
            }
        }

        private Boolean _betWin;

        public Boolean BetWin
        {
            get { return _betWin; }
            set 
            {
                _betWin = value;
                OnPropertyChanged();
            }
        
        }

        private String _selectedTeam;
        public String SelectedTeam
        {
            get { return _selectedTeam; }
            set 
            {
                _selectedTeam = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<String> _leagues;

        public ObservableCollection<String> Leagues
        {
            get { return _leagues; }
            set { _leagues = value; }
        }

        private String _selectedLeague;

        public String selectedLeague
        {
            get { return _selectedLeague; }
            set
            {
                _selectedLeague = value;
                OnPropertyChanged();
            }
        }

        // Finish Adding this in just set to true when submit works and do a try catch maybe or if statement
        private bool _betAdded = false;
        public bool BetAdded
        {
            get { return _betAdded; }
            set
            {
                _betAdded = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitBetButton { get;}

        private DispatcherTimer timer;


        public BetVM(Account currentUser)
        {
            this.currentUser = currentUser;

            Leagues = new ObservableCollection<String>() 
            {
                "NBA", "NHL", "MLS", "NFL", "MLB"
            };

            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            betCollection = database.GetCollection<Bet>("Bets");
                      
            SubmitBetButton = new RelayCommand(OnSubmit);
        }

        private void OnSubmit(object obj)
        {
            // If no time, show top 3 earns and losses on dashboard
            // Use text in here that shows a green button when a bet is successfully added. Maybe a timer function to turn off after 5 seconds
            bet = new Bet(_wager, _odds, _selectedLeague, _team1, _team2, _selectedTeam.Remove(0, 37).TrimStart(), _betWin);
            betCollection.InsertOneAsync(bet);
            updateUserStats();

            BetAdded = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Show label for 5 seconds
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            BetAdded = false;
        }

        public void updateUserStats()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            userStatCollection = database.GetCollection<User>("User Stats");

            var filter = Builders<User>.Filter.Eq("Username", Account.GLOBALUSERNAME);

            var update = Builders<User>.Update.Inc("Games Played", 1);

            if(_betWin == true)
            {
                update = update.Inc("Wins", 1)
                               .Inc("Total Earned", bet.winnings);
            }
            else
            {
                update = update.Inc("Losses", 1)
                               .Inc("Total Lost", -bet.wager);
            }

            var updateResult = userStatCollection.UpdateOne(filter, update);

            if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            {
                Console.WriteLine("Successful update");
            }
            else
            {
                Console.WriteLine("Update failed");
            }

        }
    }
}
