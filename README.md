# SoccerManagementUWP
This Repository contains code developed during the course "Advanced Information Systems" at SRH Heidelberg in January and February 2018.

In order to use the code, you have to create a configuration file and adjust it per your need:
/Config/Configuration.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagementUWP.Config
{
    public static class Configuration
    {
        public static string mongoConnectionString = "mongodb://172.27.1.184:27017";
        public static string mongoDatabaseName = "bundesliga-database";
    }
}
