using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class CreateID
    {
        public string CreateSaleID(SqlConnection connection)
        {
            string result = null;
            
            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            //検索結果取得用のオブジェクトを用意
            SqlDataReader reader = null;
            try
            {

                //実行するプロシージャの登録
                command.CommandText = "SELECT * FROM SalesTable ORDER BY DESC;";
                command.CommandType = CommandType.Text;
                //Connection情報の登録
                command.Connection = connection;

                //sqlの実行
                reader = command.ExecuteReader();

                //値の取得
                if (reader.Read())
                {
                    //IDの一番値が大きいものを取得
                    result = reader["SalesID"].ToString();
                }
                //数字部分だけ抜き取り
                result = result.Substring(0, 4);
                //数字に変換
                int idNum = Convert.ToInt32(result);
                idNum++;
                //0埋め
                result =  idNum.ToString().PadLeft(5, '0');
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //close処理
                reader.Close();
                connection.Close();
            }
            return result;
        }

        public string CreateStrockID()
        {
            string result = null;

            SqlCommand command = new SqlCommand();
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
            
            
            //検索結果取得用のオブジェクトを用意
            SqlDataReader sqlReader = null;
            try
            {
                
                //実行するプロシージャの登録
                command.CommandText = "SELECT * FROM StockTable ORDER BY StockID DESC;";
                command.CommandType = CommandType.Text;
                //Connection情報の登録
                command.Connection = connection;
                //sqlの実行
                sqlReader = command.ExecuteReader();

                //値の取得
                if (sqlReader.Read())
                {
                    //IDの一番値が大きいものを取得
                    result = sqlReader["StockID"].ToString();
                }
                //数字部分だけ抜き取り
                result = result.Substring(1, 4);
                //数字に変換
                int idNum = Convert.ToInt32(result);
                idNum++;
                //0埋め
                result = "s" + idNum.ToString().PadLeft(4, '0');

            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //close処理
                sqlReader.Close();
                connection.Close();
            }
            return result;
        }

    }
}
