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
        public static void mongoConnect()
        {
            var client = new MongoClient(Config.Configuration.mongoConnectionString);
            var db = client.GetDatabase(Config.Configuration.mongoDatabaseName);
            var collection = db.GetCollection<BsonDocument>("balls");

            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "bla", "bert" },
                        { "bla2", "bert2" }
                    }}
            };
            collection.InsertOne(document);
        }
    }
}
