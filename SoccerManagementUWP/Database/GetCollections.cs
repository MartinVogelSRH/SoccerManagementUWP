using MongoDB.Bson;
using MongoDB.Driver;
using SoccerManagementUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagementUWP.Database
{
    public class GetCollections
    {
        public static List<Player> getPlayerCollection()
        {
            var pl = App._IMongoDB.GetCollection<Player>("people").AsQueryable<Player>();
            return (from play in pl where play.lastName != null select play).ToList();
        }

        public static List<Event> getEventCollection()
        {
            var ev = App._IMongoDB.GetCollection<Event>("statistics").AsQueryable<Event>();
            return (from eve in ev where eve.type == "event" select eve).ToList();
        }

        public static List<Event> getYellowCardCollection()
        {
            var ev = App._IMongoDB.GetCollection<Event>("statistics").AsQueryable<Event>();
            return (from card in ev where card.eventType == "Yellow Card" select card).ToList();
        }

        
    }
}
