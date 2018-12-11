using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class ItemDao
    {

        //商品を一覧するDao
        public List<ItemDto> DisplayItem()
        {
            //DB接続
            DBHelper connectDB = new DBHelper();
            SqlConnection connection = connectDB.ConnectDB();
            
            List<ItemDto> list = new List<ItemDto>();
            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            //検索結果取得用のオブジェクトを用意
            SqlDataReader reader = null;
            try
            {
                
                //実行するプロシージャの登録
                command.CommandText = "SELECT * FROM ItemTable;";
                command.CommandType = CommandType.Text;
                //Connection情報の登録
                command.Connection = connection;

                //クエリの実行
                reader = command.ExecuteReader();

                //値の取得
                while (reader.Read())
                {
                    ItemDto dto = new ItemDto
                        (reader["ItemID"].ToString(), reader["Name"].ToString(), (CategoryDto)reader["CategoryID"], Convert.ToInt32(reader["Price"]));
                    list.Add(dto);
                }

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

            return list;
        }


        public ItemDto UpdateItem(ItemDto item)
        {
            //DB接続
            DBHelper connectDB = new DBHelper();
            SqlConnection connection = connectDB.ConnectDB();

            SqlCommand command = new SqlCommand();

            try
            {
                //実行するsql文の登録
                command.CommandText = $"UPDATE ItemTable " +
                    $"SET Name = @name, Price = @price, CategoryID = @categoryId " +
                    $"WHERE ItemID = @item_id; ";
                command.CommandType = CommandType.Text;

                command.Parameters.Add("@name", SqlDbType.NVarChar, 20);
                command.Parameters["@name"].Value = item.Name;

                command.Parameters.Add("@price", SqlDbType.Int);
                command.Parameters["@price"].Value = item.Price;

                command.Parameters.Add("@categoryId", SqlDbType.NVarChar, 5);
                command.Parameters["@categoryId"].Value = item.Category.Id;
                
                //Connection情報の登録
                command.Connection = connection;

                int num = command.ExecuteNonQuery();

                if (num < 0)
                {
                    return null;
                }
            }catch(SqlException e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                connection.Close();
            }
            return item;
        }
    }
}
