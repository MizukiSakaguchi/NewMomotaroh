using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class DBHelper
    {
        public SqlConnection ConnectDB()
        {
            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString
                    = System.Configuration
                    .ConfigurationManager
                    .ConnectionStrings["SalesManagementApp.Properties.Settings.connectDB"]
                    .ConnectionString;
                //DB接続
                connection.Open();
                return connection;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
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
