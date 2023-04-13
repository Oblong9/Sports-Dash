
using SportsDash.Models.UserPack;
using SportsDash.ViewModel;
using System.Windows.Controls;


namespace SportsDash.View
{
    /// <summary>
    /// Interaction logic for BetView.xaml
    /// </summary>
    public partial class BetView : UserControl
    {
        public Account currentUser { get; set; }

        public BetView()
        {
            InitializeComponent();
            this.DataContext = new BetVM(currentUser);

        }

    }
}
