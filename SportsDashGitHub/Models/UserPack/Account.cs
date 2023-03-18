using System.ComponentModel;
using System.Security.Principal;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportsDash.Models.UserPack
{
    public class Account
    {
        // Setup for Account class to connect to db
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string id { get; set; }
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
            return "\nAccount: \nUsername: " + userName + "\nPassword: " + password + "\nEmail: " + email;
        }

    }
}
