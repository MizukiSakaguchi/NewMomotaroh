using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    public class DBHelper
    {
        public SqlConnection ConnectDB()
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString
                    = System.Configuration
                    .ConfigurationManager
                    .ConnectionStrings["SalesManagementApp.Properties.Settings.connectDB"]
                    .ConnectionString;
                //DB接続
                connection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            return connection;
        }

        public void CloseDB(SqlConnection connection)
        {
            try
            {
                //DBとの接続を解除
                connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
