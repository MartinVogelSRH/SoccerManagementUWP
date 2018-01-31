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
using Newtonsoft;
using MongoDB.Bson;
using MongoDB.Driver;
using SoccerManagementUWP.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SoccerManagementUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void b_showPlayerList_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayerList));
        }

        private void b_showPlayerProfile_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PlayerProfile));
        }

        private void btn_testRunCommand_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RunCommandTesting));
        }
    }
}
