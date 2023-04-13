using SportsDash.Models.UserPack;

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

        // Check for linking accounts
        private Account currentUser { get; set; }

        private object lastView;

        private object _currentView;

        // Ability to check last viewed pages
        // CREATE STACK TO SEE LAST PAGES

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainVM(Account loadedUser)
        {
            // Display the user then work from there to find here the username = a
            // username from the place and maybe use a second collection to have bet data and link by username
            currentUser = loadedUser;
            BetVM = new BetVM(currentUser);
            DashboardVM = new DashboardVM();
            StatsVM = new StatsVM();

            CurrentView = DashboardVM;
            lastView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o =>
            {
                //lastView = CurrentView;
                CurrentView = DashboardVM;
            });

            BetViewCommand = new RelayCommand(o =>
            {
                //lastView = CurrentView;
                CurrentView = BetVM;
            });

            StatsViewCommand = new RelayCommand(o =>
            {
                //lastView = CurrentView;
                CurrentView = StatsVM;
            });
        }
    }
}
