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
    public class Event
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId playerId { get; set; }
        public string eventType { get; set; }
    }
}
