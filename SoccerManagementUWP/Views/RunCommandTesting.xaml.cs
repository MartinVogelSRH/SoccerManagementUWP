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
    public sealed partial class RunCommandTesting : Page
    {
        public RunCommandTesting()
        {
            this.InitializeComponent();
        }

        private void btn_Execute_Click(object sender, RoutedEventArgs e)
        {
            var command = new JsonCommand<BsonDocument>(tbx_command.Text);
            try
            {
                var result = App._IMongoDB.RunCommand(command);
                tbx_Results.Text =  result.ToString();
            }
            catch (Exception ex)
            {

                tbx_Results.Text = ex.ToString();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbx_command.Text = "{ aggregate:'teams', pipeline: [ {$match: {city:'London'}} ] ,cursor:{} } ";
        }
    }
}
