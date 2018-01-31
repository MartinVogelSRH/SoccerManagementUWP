using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SoccerManagementUWP.Database
{
    public class MongoConnection
    {
        public static IMongoDatabase mongoConnect()
        {
            var client = new MongoClient(Config.Configuration.mongoConnectionString);
            return client.GetDatabase(Config.Configuration.mongoDatabaseName);
        }
    }
}
