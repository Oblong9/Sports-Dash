using MongoDB.Bson;
using MongoDB.Driver;
using SportsDash.Models.UserPack;
using SportsDash.View;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SportsDash.ViewModel
{
    class SigninVM : ObservableObject
    {
        private readonly IMongoCollection<Account> collection;

        public static string userId { get; set; }

        MainWindow main;
        SignupView signUp;

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

        private String tempUserName { get; set; }

        private Account loggedInUser { get; set; }

        public RelayCommand SubmitSignupButton { get; }

        public RelayCommand SubmitLoginButton { get; }

        public SigninVM()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("sportsDash");

            collection = database.GetCollection<Account>("Users");

            /*Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Current Account: ", loggedInUser);
                    Thread.Sleep(1500);
                }
            });
            */

            SubmitSignupButton = new RelayCommand(GoToSignup);
            SubmitLoginButton = new RelayCommand(SubmitLogin);
        }

        private void GoToSignup(object parameter)
        {
            if(signUp == null)
            {
                signUp = new SignupView();
            }
            signUp.Show();
            Application.Current.MainWindow.Close();
        }
        private async void SubmitLogin(object parameter)
        {
            var filter1 = Builders<Account>.Filter.Eq("username", Username);
            var filter2 = Builders<Account>.Filter.Eq("password", Password);
            var filter = Builders<Account>.Filter.And(filter1, filter2);

            var result = await collection.Find(filter).FirstOrDefaultAsync();

            if(result != null)
            {
                // logged in user is not being created
                //userId = result.id;
                Account.GLOBALUSERNAME = Username;
                string[] resultString = result.ToString().Split(' ');
                loggedInUser = new Account(Username);
                
                if (main == null)
                {
                    main = new MainWindow(loggedInUser);
                }
                main.Show();
                Application.Current.MainWindow.Close();
            }
            else
            {
                //Setup popup that password and username are incorrect
            }

        }
    }
}
