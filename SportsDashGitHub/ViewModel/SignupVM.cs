using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SportsDash.Models.UserPack;
using MongoDB.Driver;
using System.Configuration;
using System.Windows;
using SportsDash.View;
using Amazon.Runtime.Internal;
using System.Windows.Input;

namespace SportsDash.ViewModel
{
    class SignupVM : ObservableObject
    {
        private readonly IMongoCollection<Account> collection;

        MainWindow main;
        LoginView login;

        //private readonly MongoDriver driver = new MongoDriver();

        private Account newAccount { get; set; }

        private String _email;
        public String Email
        {
            get { return _email; }

            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private String _username;
        public String Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        // Potentially change to Passsword Box
        private String _password;
        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SubmitSignupButton { get; }

        public RelayCommand SubmitLoginButton { get; }

        public SignupVM()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            collection = database.GetCollection<Account>("Users");

            SubmitSignupButton = new RelayCommand(SubmitSignup);
            SubmitLoginButton = new RelayCommand(SubmitLogin);
        }

        private void SubmitSignup(object parameter)
        {
            newAccount = new Account(_username, _password, _email);
            addAccount(newAccount);
            /*if(main == null)
            {
                main = new MainWindow();
            }*/
            main = new MainWindow(newAccount);
            main.Show();
            Application.Current.MainWindow.Close();
        }

        private void SubmitLogin(object parameter)
        {
            if (login == null)
            {
                login = new LoginView();
            }
            login.Show();
            Application.Current.MainWindow.Close();
        }

        public async Task addAccount(Account account)
        {
            await collection.InsertOneAsync(account);
        }

    }
}
