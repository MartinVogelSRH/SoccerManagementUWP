using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using SoccerManagementUWP.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SoccerManagementUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerList : Page
    {
        public PlayerList()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var collection = App._IMongoDB.GetCollection<BsonDocument>("people");

            var pl = App._IMongoDB.GetCollection<Player>("people").AsQueryable<Player>();
            var players = (from play in pl where play.lastName != null select play).ToList();
            var ev = App._IMongoDB.GetCollection<Event>("statistics").AsQueryable<Event>();
            var cards = (from card in ev where card.eventType == "Yellow Card" select card).ToList();

            foreach (var player in players)
            {
                player.yellowCards = cards.Count(b => b.playerId == player.Id);
            }


            //var playerz = players.All(b => cards.Count(a => a.playerId == b.Id));
            
            //var playerz = players.Select(a => cards.Count(b => b.playerId == a.Id)).ToList();

            var zz = players;
            //var count = players.Where(p => p.Equals(cards.Any))
            //        .Select(temp => temp)
            //        .Count();

            //players.Where(y => cards.Count(y => x.Id== y.playerId));

            //var new2 = cards.Count(n => n.playerId == );

            //foreach (var player in pl)
            //{
            //    foreach (var card in cards)
            //    {
            //        if (player.Id == card.playerId)
            //        {
            //            player.yellowCards += 1;
            //        }                    
            //    }
            //    Debug.WriteLine("Player: " + player.firstName + " " + player.lastName + ". Yellow Cards = " + player.yellowCards);
            //}


            var findFluent = collection.Find(_ => true).ToList();
            var x = findFluent;

            //var filter = Builders<BsonDocument>.Filter.Eq("lastName", "Mertesacker");
           // var document = collection.Find(filter).First();
            

            var temp =
            from p in collection.AsQueryable() 
            select p;

            //var players = BsonSerializer.Deserialize<List<Player>(temp.ToJson());






            //for (int i = 0; i < 100; i++)
            //{
            //    lb_playerListBox.Items.Add(y[i]);
            //    //lb_playerListBox.Items.Add((findFluent[i].GetValue("firstName").ToString()));
            //}

            //collection = App._IMongoDB.GetCollection<BsonDocument>("games");
            //var documnt = new BsonDocument
            //{
            //    {"Brand","Dell"},
            //    {"Price","400"},
            //    {"Ram","8GB"},
            //    {"HardDisk","1TB"},
            //    {"Screen","16inch"}
            //};

            //collection.InsertOne(documnt);
            //var xdsa = documnt._id;


        }


        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
