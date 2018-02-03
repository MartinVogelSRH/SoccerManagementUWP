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
            var agent1 = new BsonDocument
            {
                {"type","agent" },
                {"firstName", "Marcel" },
                {"lastName", "Rosenbaum" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1970,03,18,00,00,00) }
            };
            var agent2 = new BsonDocument
            {
                {"type","agent" },
                {"firstName", "Severin" },
                {"lastName", "Steinitz" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1981,09,05,00,00,00) }
            };
            var agent3 = new BsonDocument
            {
                {"type","agent" },
                {"firstName", "Julian" },
                {"lastName", "Brockhaus" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1964,11,02,00,00,00) }
            };
            var trainer1 = new BsonDocument
            {
                {"type","trainer" },
                {"firstName", "Eggert" },
                {"lastName", "Oldenberg" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1964,10,19,00,00,00) }
            };
            var trainer2 = new BsonDocument
            {
                {"type","trainer" },
                {"firstName", "Per" },
                {"lastName", "Keller" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1970,12,13,00,00,00) }
            };
            var trainer3 = new BsonDocument
            {
                {"type","trainer" },
                {"firstName", "Helge" },
                {"lastName", "Kleinmann" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1975,11,27,00,00,00) }
            };
            var manager1 = new BsonDocument
            {
                {"type","manager" },
                {"firstName", "Florian" },
                {"lastName", "Eschenbach" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1960,01,28,00,00,00) }
            };
            var manager2 = new BsonDocument
            {
                {"type","manager" },
                {"firstName", "Peter" },
                {"lastName", "Gerson" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1964,07,12,00,00,00) }
            };
            var manager3 = new BsonDocument
            {
                {"type","manager" },
                {"firstName", "Albin" },
                {"lastName", "Neubauer" },
                {"nationality","Germany" },
                {"dateofbirth", new DateTime(1955,11,02,00,00,00) }
            };
            collPeople.InsertMany(new List<BsonDocument> {
                    player1,
                    player2,
                    player3,
                    player4,
                    agent1,
                    agent2,
                    agent3,
                    trainer1,
                    trainer2,
                    trainer3,
                    manager1,
                    manager2,
                    manager3
            });

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
            collMvUpdate.InsertMany(new List<BsonDocument> {
                mvupdatepl1,
                mvupdatepl2,
                mvupdatepl3,
                mvupdatepl4
            });

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
            collTeams.InsertMany(new List<BsonDocument>
            {
                team1,
                team2
            });

            var contractplayer1 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player1["_id"] },
                {"startDate",new DateTime(2015,01,01,00,00,00) },
                {"endDate",new DateTime(2016,12,31,00,00,00) },
                {"wage",750000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contractplayer2 = new BsonDocument
            {
                {"teamId",team2["_id"] },
                {"playerId",player1["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",78000000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contractplayer3 = new BsonDocument
            {
                {"teamId",team2["_id"] },
                {"playerId",player2["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",104000000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contractplayer4 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player3["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",78000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contractplayer5 = new BsonDocument
            {
                {"teamId",team1["_id"] },
                {"playerId",player4["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"wage",39000 },
                {"currency","EUR" },
                {"type","playerContract" }
            };
            var contractAgent1 = new BsonDocument
            {
                {"agentId",agent1["_id"] },
                {"playerId",player4["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractAgent2 = new BsonDocument
            {
                {"agentId",agent2["_id"] },
                {"playerId",player3["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractAgent3 = new BsonDocument
            {
                {"agentId",agent3["_id"] },
                {"playerId",player2["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractAgent4 = new BsonDocument
            {
                {"agentId",agent1["_id"] },
                {"playerId",player1["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractTrainer1 = new BsonDocument
            {
                {"trainerId",trainer1["_id"] },
                {"clubId",team1["_id"] },
                {"startDate",new DateTime(2015,01,01,00,00,00) },
                {"endDate",new DateTime(2016,12,31,00,00,00) },
                {"type","trainerContract" }
            };
            var contractTrainer2 = new BsonDocument
            {
                {"trainerId",trainer2["_id"] },
                {"clubId",team1["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","trainerContract" }
            };
            var contractTrainer3 = new BsonDocument
            {
                {"trainerId",trainer2["_id"] },
                {"clubId",team2["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","trainerContract" }
            };
            var contractManager1 = new BsonDocument
            {
                {"managerId",manager1["_id"] },
                {"clubId",team1["_id"] },
                {"startDate",new DateTime(2015,01,01,00,00,00) },
                {"endDate",new DateTime(2016,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractManager2 = new BsonDocument
            {
                {"managerId",manager2["_id"] },
                {"clubId",team1["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            var contractManager3 = new BsonDocument
            {
                {"managerId",manager3["_id"] },
                {"clubId",team2["_id"] },
                {"startDate",new DateTime(2017,01,01,00,00,00) },
                {"endDate",new DateTime(2019,12,31,00,00,00) },
                {"type","agentContract" }
            };
            collContracts.InsertMany(new List<BsonDocument> {
                contractplayer1,
                contractplayer2,
                contractplayer3,
                contractplayer4,
                contractplayer5,
                contractAgent1,
                contractAgent2,
                contractAgent3,
                contractAgent4,
                contractTrainer1,
                contractTrainer2,
                contractTrainer3,
                contractManager1,
                contractManager2,
                contractManager3
            });

            var awardManagerMonth1 = new BsonDocument {
                {"managerId", manager1["_id"] },
                {"awardType","managerOfTheMonthAward" },
                {"timestamp", new DateTime(2017,10,01)}
            };
            var awardManagerMonth2 = new BsonDocument {
                {"managerId", manager2["_id"] },
                {"awardType","managerOfTheMonthAward" },
                {"timestamp", new DateTime(2017,11,01)}
            };
            var awardManagerMonth3 = new BsonDocument {
                {"managerId", manager3["_id"] },
                {"awardType","managerOfTheMonthAward" },
                {"timestamp", new DateTime(2017,12,01)}
            };
            var awardManagerMonth4 = new BsonDocument {
                {"managerId", manager1["_id"] },
                {"awardType","managerOfTheMonthAward" },
                {"timestamp", new DateTime(2018,01,01)}
            };
            collPeople.InsertMany(new List<BsonDocument>
            {
                awardManagerMonth1,
                awardManagerMonth2,
                awardManagerMonth3,
                awardManagerMonth4
            });

            var competition1 = new BsonDocument
            {
                {"type","club" },
                {"format","Domestic League" },
                {"name", "Dummy League" },
                {"season","2017" },
                {"country","germany" },
                {"teams", new BsonArray{team1["_id"],team2["_id"] } }
            };
            collCompetitions.InsertMany(new List<BsonDocument>
            {
                competition1
            });

            var game1 = new BsonDocument {
                {"competitionId",competition1["_id"] },
                {"awayTeamId",team1["_id"] },
                {"homeTeamId",team2["_id"] },
                {"startTime", new DateTime(2017,03,26,15,30,00) }
            };
            var game2 = new BsonDocument {
                {"competitionId",competition1["_id"] },
                {"awayTeamId",team2["_id"] },
                {"homeTeamId",team1["_id"] },
                {"startTime", new DateTime(2017,09,03,20,45,00) }
            };
            collGames.InsertMany(new List<BsonDocument>
            {
                game1,
                game2
            });

            var awardManOfTheMatch1 = new BsonDocument {
                {"playerId", player1["_id"] },
                {"awardType","manOfTheMatchAward" },
                {"game", game1["_id"]}
            };
            var awardManOfTheMatch2 = new BsonDocument {
                {"playerId", player2["_id"] },
                {"awardType","manOfTheMatchAward" },
                {"game", game2["_id"]}
            };
            collPeople.InsertMany(new List<BsonDocument>
            {
                awardManOfTheMatch1,
                awardManOfTheMatch2,
            });

        }


        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
