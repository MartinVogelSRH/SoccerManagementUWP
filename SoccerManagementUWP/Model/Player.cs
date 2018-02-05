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
    public class Player
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nationality { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int yellowCards { get; set; }
    }
}
