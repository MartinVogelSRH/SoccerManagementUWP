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
            var db = client.GetDatabase(Config.Configuration.mongoDatabaseName);
            if (db.RunCommandAsync(new JsonCommand<BsonDocument>("{ping:1}")).Wait(1000) == true)
            {
                return db;
            }
            return db;
        }
    }
}
