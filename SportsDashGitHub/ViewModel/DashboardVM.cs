using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using MongoDB.Driver;
using SportsDash.Models.SportsBookPack;
using SportsDash.Models.UserPack;

namespace SportsDash.ViewModel
{
    class DashboardVM : ObservableObject
    {
        private readonly string Username = Account.GLOBALUSERNAME;

        private IMongoCollection<Bet> BetCollection;

        public IMongoCollection<User> UserStatsCollection { get; private set; }

        private ChartValues<float> _values;
        public ChartValues<float> Values
        {
            get { return _values; }
            set
            {
                _values = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection LineSeries { get; set; }

        public SeriesCollection ColumnSeries1 { get; set; }
        public SeriesCollection ColumnSeries2 { get; set; }

        private ObservableCollection<Bet> _data;
        public ObservableCollection<Bet> Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        private ObservableCollection<User> _dataLoad2;
        public ObservableCollection<User> DataLoad2
        {
            get { return _dataLoad2; }
            set
            {
                _dataLoad2 = value;
                OnPropertyChanged("DataLoad2");
            }
        }

        public DashboardVM()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");
            BetCollection = database.GetCollection<Bet>("Bets");
            UserStatsCollection = database.GetCollection<User>("User Stats");

            var filter = Builders<Bet>.Filter.Eq("user", Username);
            var filter1 = Builders<User>.Filter.Eq("Username", Username);

            var mongoData = BetCollection.Find(filter).ToList();
            var columnData = UserStatsCollection.Find(filter1).ToList();

            Data = new ObservableCollection<Bet>(mongoData);
            DataLoad2 = new ObservableCollection<User>(columnData);

            // Create a LineSeries object and add it to the SeriesCollection
            LineSeries = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Profit",
                    Values = new ChartValues<float>(Data.Select(d => d.winnings))

                }
            };

            var winSeries = new ColumnSeries
            {
                Title = "Wins",
                Values = new ChartValues<int>(DataLoad2.Select(d => d.wins)),
                Fill = Brushes.Green,
                MaxColumnWidth = 75
            };

            var lossSeries = new ColumnSeries
            {
                Title = "Losses",
                Values = new ChartValues<int>(DataLoad2.Select(d => d.losses)),
                Fill = Brushes.Red,
                MaxColumnWidth = 75
            };

            var earnedSeries = new ColumnSeries
            {
                Title = "Earned",
                Values = new ChartValues<float>(DataLoad2.Select(d => d.totalEarn)),
                Fill = Brushes.Blue,
                MaxColumnWidth = 75
            };

            var lostSeries = new ColumnSeries
            {
                Title = "Lost",
                Values = new ChartValues<float>(DataLoad2.Select(d => d.totalLost * -1)),
                Fill = Brushes.Orange,
                MaxColumnWidth = 75
            };

            ColumnSeries1 = new SeriesCollection { winSeries, lossSeries};

            ColumnSeries2 = new SeriesCollection { earnedSeries, lostSeries };
        }
    }
}
