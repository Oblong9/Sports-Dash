using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using System.Threading;

namespace SportsDash.ViewModel
{
    class BetVM : ObservableObject
    {

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
        
        public ICommand SubmitBetButton { get;}

        public BetVM()
        {
            // Basically the property is never set nor changed

            Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Team 1: {Team1}");
                    Debug.WriteLine($"Team 2: {Team2}");
                    Thread.Sleep(1500);
                }
            });
            /*
            //SubmitBetButton = new RelayCommand(OnSubmit);
            // When setting the variables in here it hits the setter methods
        }
/*
        private void OnSubmit(object obj)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
            try
            {
                using (StreamWriter outputFile = new StreamWriter(path, false))
                {
                    outputFile.WriteLine($"League: {League}");
                    outputFile.WriteLine($"Team 1: {Team1}");
                    outputFile.WriteLine($"Team 2: {Team2}");
                    outputFile.WriteLine($"Wager: {Wager}");
                    outputFile.WriteLine($"Odds: {Odds}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while writing to the file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        */
        }

    }
}
