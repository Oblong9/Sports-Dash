using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash.ViewModel
{
    class MainVM : ObservableObject
    {

        public RelayCommand DashboardViewCommand { get; set; }

        public RelayCommand BetViewCommand { get; set; }

        public RelayCommand StatsViewCommand { get; set; }

        public DashboardVM DashboardVM { get; set; }

        public BetVM BetVM { get; set; }

        public StatsVM StatsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainVM()
        {
            BetVM = new BetVM();
            DashboardVM = new DashboardVM();
            StatsVM = new StatsVM();

            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
            });

            BetViewCommand = new RelayCommand(o =>
            {
                CurrentView = BetVM;
            });

            StatsViewCommand = new RelayCommand(o =>
            {
                CurrentView = StatsVM;
            });

        }
    }
}
