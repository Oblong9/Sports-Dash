using MongoDB.Driver;
using SportsDash.Models.UserPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDash
{
    public class MongoDriver
    {

        private readonly IMongoCollection<Account> collection;

        public MongoDriver() 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);

            if (client.Cluster.Description.State == MongoDB.Driver.Core.Clusters.ClusterState.Disconnected)
            {
                client = new MongoClient(connectionString);
            }

            var database = client.GetDatabase("sportsDash");
            var collection = database.GetCollection<Account>("Users");
        }

        public async Task addAccount(Account account)
        {
            await collection.InsertOneAsync(account);
        }
       
    }
}
