using MongoDB.Bson;
using SoccerManagementUWP.Database;
using SoccerManagementUWP.Model;
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
    public sealed partial class Queries : Page
    {
        string playerLastName = "Alonso Olana";
        string playerFirstName = "Xabier ";

        public Queries()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tb_firstName.Text = playerFirstName;
            tb_lastName.Text = playerLastName;
        }

        private void b_go_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_firstName.Text) || string.IsNullOrWhiteSpace(tb_lastName.Text)) return;
            tb_output.Text = "";
            playerFirstName = tb_firstName.Text;
            playerLastName = tb_lastName.Text;
            var id = getPlayerId(tb_firstName.Text, tb_lastName.Text);
            getYellowAndRedCardsForPlayer(id);
        }

        public static ObjectId getPlayerId(string firstNamePlayer, string lastName)
        {
            var players = GetCollections.getPlayerCollection();
            return (players.First(e => e.firstName == firstNamePlayer && e.lastName == lastName)).Id;
        }

        public void getYellowAndRedCardsForPlayer(ObjectId id)
        {
            var events = GetCollections.getEventCollection();
            var yellow = (from card in events where card.playerId == id && card.eventType == "Yellow Card" select card).ToList().Count();
            var red = (from card in events where card.playerId == id && card.eventType == "Yellow Red Card" select card).ToList().Count();

            tb_output.Text = "Surname: " + playerFirstName + Environment.NewLine + "Name: " + playerLastName + Environment.NewLine + "Yellow Cards: " + yellow + Environment.NewLine + "Yellow-Red Cards: " + red;
        }

        public List<Player> getYellowCardsForAllPlayer()
        {
            var players = GetCollections.getPlayerCollection();
            var yCards = GetCollections.getYellowCardCollection();

            return (players.Select(p => { p.yellowCards = yCards.Count(b => b.playerId == p.Id); return p; })).OrderByDescending(pp => pp.yellowCards).ToList();
        }

        private void b_goAll_Click(object sender, RoutedEventArgs e)
        {
            lv_outputAll.Items.Clear();
            var list = getYellowCardsForAllPlayer();
            for (int i = 0; i < 50; i++)
            {
                lv_outputAll.Items.Add(list[i].firstName + " " + list[i].lastName + ": " + list[i].yellowCards);
            }
        }
    }
}
