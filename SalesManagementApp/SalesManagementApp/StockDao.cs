using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class StockDao
    {
        public bool StockDto(StockDto stock)
        {
            //DB接続
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

            SqlCommand command = new SqlCommand();

            try
            {
                //実行するsql文の登録
                command.CommandText = $"INSERT INTO StockTable (StockID, ItemID, Number, Date) " +
                                        $"VALUES(@id, @itemId, @num, @lastUpdate)";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("@id", SqlDbType.NVarChar, 5);
                command.Parameters["@id"].Value = stock.Id;

                command.Parameters.Add("@itemId", SqlDbType.NVarChar, 5);
                
                command.Parameters["@itemID"].Value = stock.Item.Id;

                command.Parameters.Add("@num", SqlDbType.Int);
                command.Parameters["@num"].Value = stock.Num;

                command.Parameters.Add("@lastUpdate", SqlDbType.Date);
                command.Parameters["@lastUpdate"].Value = stock.LastUpDate.Date;

                //Connection情報の登録
                command.Connection = connection;

                int num = command.ExecuteNonQuery();

                if (num < 0)
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
