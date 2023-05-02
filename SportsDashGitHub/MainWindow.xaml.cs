using SportsDash.Models.UserPack;
using SportsDash.ViewModel;
using System.Windows;

namespace SportsDash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Account currentUser {get;set;}

        public MainWindow(Account loggedInUser)
        {
            currentUser = loggedInUser;
            InitializeComponent();
            this.DataContext = new MainVM(currentUser);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e ) 
        {
            Application.Current.Shutdown();
        }


    }
}
