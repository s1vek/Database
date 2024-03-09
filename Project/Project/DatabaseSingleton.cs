using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DatabaseSingleton
    {

        private static SqlConnection connection = null;

        public static SqlConnection GetInstance()
        {
            if (connection == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("Name");
                consStringBuilder.Password = ReadSetting("Password");
                consStringBuilder.InitialCatalog = ReadSetting("Database");
                consStringBuilder.DataSource = ReadSetting("DataSource");
                consStringBuilder.ConnectTimeout = 30;
                connection = new SqlConnection(consStringBuilder.ConnectionString);
                connection.Open();
            }
            return connection;
        }

        private static string ReadSetting(string v)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[v] ?? "Not Found";
            return result;
        }
    }
}
