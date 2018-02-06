using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagementUWP.Model
{
    [BsonIgnoreExtraElements]
    public class Teams
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
    }
}
