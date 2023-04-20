using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SportsDash.Models.UserPack
{
    public class Account
    {


        // For some reason this does not work when just setting up account try looking through VM
        public static string GLOBALUSERNAME = "";

        // Setup for Account class to connect to db
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        
        [BsonElement("username")]
        public string userName { get; set; }

        [BsonElement("password")]
        private string password { get; set; }

        [BsonElement("email")]
        private string email { get; set; }

        public Account(string userName)
        {
            this.userName = userName;
            password = "None";
            email = "None";
        }

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
