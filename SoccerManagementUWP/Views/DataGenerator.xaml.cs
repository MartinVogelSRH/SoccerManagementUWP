using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
    public sealed partial class DataGenerator : Page
    {
        public DataGenerator()
        {
            this.InitializeComponent();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            var client = new MongoClient(Config.Configuration.mongoConnectionString);
            var db = client.GetDatabase("football-data-dummy");
            client.DropDatabase("football-data-dummy");
            var collPeople = db.GetCollection<BsonDocument>("people");
            var collMvUpdate = db.GetCollection<BsonDocument>("marketvalueupdate");
            var collTeams = db.GetCollection<BsonDocument>("teams");
            var collContracts = db.GetCollection<BsonDocument>("contracts");
            var collCompetitions = db.GetCollection<BsonDocument>("competitions");
            var collGames = db.GetCollection<BsonDocument>("games");
            var collStatistics = db.GetCollection<BsonDocument>("statistics");


            var player1 = new BsonDocument
            {
                {"type","player" },
                {"firstName", "Max" },
                {"lastName", "Mustermann" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1990,08,15,00,00,00) }
            };
            var player2 = new BsonDocument
            {
                {"type","player" },
                {"firstName", "Lorenz" },
                {"lastName", "Weiz" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1991,03,18,00,00,00) }
            };
            var player3 = new BsonDocument
            {
                {"type","player" },
                {"firstName", "Georg" },
                {"lastName", "Grossman" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1994,12,05,00,00,00) }
            };
            var player4 = new BsonDocument
            {
                {"type","player" },
                {"firstName", "Lennard" },
                {"lastName", "Schuster" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1998,08,01,00,00,00) }
            };
            collPeople.InsertOne(player1);
            collPeople.InsertOne(player2);
            collPeople.InsertOne(player3);
            collPeople.InsertOne(player4);
            var mvupdatepl1 = new BsonDocument
            {
                {"timestamp", new DateTime(2017,01,01,00,00,00) },
                {"value",1500000 },
                {"playerId", player1["_id"]}
            };
            var mvupdatepl2 = new BsonDocument
            {
                {"timestamp", new DateTime(2016,01,01,00,00,00) },
                {"value",1000000 },
                {"playerId", player1["_id"]}
            };
            var mvupdatepl3 = new BsonDocument
            {
                {"timestamp", new DateTime(2015,01,01,00,00,00) },
                {"value",500000 },
                {"playerId", player1["_id"]}
            };
            var mvupdatepl4 = new BsonDocument
            {
                {"timestamp", new DateTime(2018,01,01,00,00,00) },
                {"value",2000000 },
                {"playerId", player1["_id"]}
            };
            collMvUpdate.InsertOne(mvupdatepl1);
            collMvUpdate.InsertOne(mvupdatepl2);
            collMvUpdate.InsertOne(mvupdatepl3);
            collMvUpdate.InsertOne(mvupdatepl4);
            var team1 = new BsonDocument
            {
                {"name","AFC Bournemouth" },
                {"type","club" },
                {"country","England" },
                {"city","Bournemouth" }
            };
            var team2 = new BsonDocument
            {
                {"name","Arsenal FC" },
                {"type","club" },
                {"country","England" },
                {"city","London" }
            };
            collTeams.InsertOne(team1);
            collTeams.InsertOne(team2);
            var contract1 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player1["_id"] },
                {"startDate",new DateTime(2015,01,01,00,00,00) },
                {"endDate",new DateTime(2016,12,31,00,00,00) },
                {"wage",750000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contract2 = new BsonDocument
            {
                {"teamId",team2["_id"] },
                {"playerId",player1["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",78000000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contract3 = new BsonDocument
            {
                {"teamId",team2["_id"] },
                {"playerId",player2["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",104000000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contract4 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player3["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",78000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contract5 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player4["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",39000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };

            collContracts.InsertOne(contract1);
            collContracts.InsertOne(contract2);
            collContracts.InsertOne(contract3);
            collContracts.InsertOne(contract4);
            collContracts.InsertOne(contract5);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
