using SportsDash.View;
using SportsDash.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SportsDash
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            // Change to Sign in View After testing
            SignupView Signup = new()
            {
                DataContext = new SignupVM()
            };
            Signup.Show();

            base.OnStartup(e);
        }
    }
}
