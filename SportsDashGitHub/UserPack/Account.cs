
namespace SportsDash.UserPack
{
    public class Account
    {
        private string userName { get; set; }
        private string password { get; set; }
        private string email { get; set; }

        public Account(string userName, string password, string email)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
        }

        public override string ToString()
        {
            return "Account: \nUsername: " + userName + "\nPassword: " + password + "\nEmail: " + email;
        }

    }
}
