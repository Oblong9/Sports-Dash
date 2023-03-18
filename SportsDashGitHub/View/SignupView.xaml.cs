using SportsDash.ViewModel;
using System.Windows;

namespace SportsDash.View
{

    public partial class SignupView : Window
    {
        public SignupView()
        {
            InitializeComponent();
        }

        private void SneakyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
