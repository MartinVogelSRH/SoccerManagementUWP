using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagementUWP.Config
{
    public static class Configuration
    {
        public static string mongoConnectionString = "mongodb://localhost:27017,localhost:27018,localhost:27019";
        public static string mongoDatabaseName = "soccer";
    }
}
