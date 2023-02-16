using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SportsDash
{
    public class Account
    {
        private String userName { get; set; }
        private String password { get; set; }
        private String email { get; set; }

        public Account(String userName, String password, String email)
        {
            this.userName = userName;
            this.password = password;
            this.email = email;
        }

        public override String ToString() 
        {
            return "Account: \nUsername: " + userName + "\nPassword: " + password + "\nEmail: " + email;
        }

    }
}
