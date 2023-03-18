using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SportsDash.Models.UserPack;


namespace SportsDash.ViewModel
{
    class SignupVM : ObservableObject
    {

        private Account newAccount;

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

        public SignupVM()
        {

            SubmitSignupButton = new RelayCommand(o =>
            {
                newAccount = new Account(_username, _password, _email);
            });

            Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Account: {newAccount}");
                    Thread.Sleep(1500);
                }
            });
        }

    }
}
