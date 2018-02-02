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
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using System.Data;
using System.Text;

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
            var initialCommand = new JsonCommand<BsonDocument>(tbx_command.Text);
            try
            {
                StringBuilder resultText = new StringBuilder();
                var result = App._IMongoDB.RunCommand(initialCommand).ToJson(new JsonWriterSettings {OutputMode = JsonOutputMode.Strict});

                var firstResultStructure = new { cursor = new { firstBatch = "", id = "", ns = "" }, ok = "" };
                //var firstResObject = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(result.ToString(),firstResultStructure);
                var resultObject = Newtonsoft.Json.Linq.JObject.Parse(result.ToString());
                resultText.Append(resultObject["cursor"]["firstBatch"]);

                while (cbx_getAll.IsChecked == true && (resultObject["cursor"]["id"].ToString() != "0"))
                {
                    resultText.Remove(resultText.Length - 1, 1);
                    resultText.Append(",");
                    var getMoreCommand = new JsonCommand<BsonDocument>("{getMore : NumberLong(\"" + resultObject["cursor"]["id"].ToString() + "\"), collection : \"" + resultObject["cursor"]["ns"].ToString().Replace(Config.Configuration.mongoDatabaseName + ".","") + "\" }");
                    var nextResult = App._IMongoDB.RunCommand(getMoreCommand).ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.Strict });
                    resultObject = Newtonsoft.Json.Linq.JObject.Parse(nextResult.ToString());
                    resultText.Append(resultObject["cursor"]["nextBatch"].ToString().Remove(0,3));
                }
                    var prettyResult = Newtonsoft.Json.Linq.JToken.Parse(result.ToString()).ToString(Formatting.Indented);
                tbx_Results.Text = resultText.ToString();
            }
            catch (Exception ex)
            {

                tbx_Results.Text = ex.ToString();
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbx_command.Text = "{ aggregate:'teams', pipeline: [ {$match: {city:'London'}} ] ,cursor:{batchSize:773} } ";
        }
    }
}
