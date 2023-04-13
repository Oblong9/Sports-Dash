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
            // SignupView stays open after signup when loginwindow is primary window please fix
            // Something about the window opening anew window and the button does not close the right window Probablly because of MainWindow but idk
            // Still not working fix it later - 3/20
            LoginView Login = new()
            {
                DataContext = new SigninVM()
            };
            Login.Show();

            base.OnStartup(e);
        }
    }
}
