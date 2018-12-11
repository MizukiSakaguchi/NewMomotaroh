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
        public string CreateSaleID()
        {
            string result = null;

            //DB接続
            DBHelper connectDB = new DBHelper();
            SqlConnection connection = connectDB.ConnectDB();
            
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

            //DB接続
            DBHelper connectDB = new DBHelper();
            SqlConnection connection = connectDB.ConnectDB();

            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            //検索結果取得用のオブジェクトを用意
            SqlDataReader reader = null;
            try
            {

                //実行するプロシージャの登録
                command.CommandText = "SELECT * FROM StockTable ORDER BY DESC;";
                command.CommandType = CommandType.Text;
                //Connection情報の登録
                command.Connection = connection;

                //sqlの実行
                reader = command.ExecuteReader();

                //値の取得
                if (reader.Read())
                {
                    //IDの一番値が大きいものを取得
                    result = reader["StockID"].ToString();
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
                reader.Close();
                connection.Close();
            }
            return result;
        }

    }
}
