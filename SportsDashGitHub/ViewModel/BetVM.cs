using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.Driver;
using SportsDash.Models.UserPack;
using System.Configuration;
using MongoDB.Bson;
using SportsDash.Models.SportsBookPack;
using SportsDash.ViewModel;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.ObjectModel;

namespace SportsDash.ViewModel
{
    class BetVM : ObservableObject
    {
        private IMongoCollection<Bet> betCollection;

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

        public ICommand SubmitBetButton { get;}

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
            
            /*Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Current User: ", currentUser);
                    Thread.Sleep(1500);
                }
            });
            */
                      
            SubmitBetButton = new RelayCommand(OnSubmit);
        }

        private async void OnSubmit(object obj)
        {
            // If no time show top 3 earns and losses on dashboard
            // Use text in here that shows a green button when a bet is successfully added. Maybe a timer function to turn off after 5 seconds
            // MAKE SURE TO PARSE THE NUMBERS ADDED FOR + AND - SO IT CAN BE USED TO CALCULATE THE ODDS BETTER, Currently only calculating + Odds
            bet = new Bet(_wager, _odds, _selectedLeague, _team1, _team2, _selectedTeam, _betWin);
            bet.winnings = bet.calculateWins(_odds);

            await betCollection.InsertOneAsync(bet);
        }

        public async Task addBet(Bet bet)
        {
            await betCollection.InsertOneAsync(bet);
        }
    }
}
