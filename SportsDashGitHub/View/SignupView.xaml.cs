using SportsDash.Models.UserPack;
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
