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


            List<ItemDto> list = new List<ItemDto>();
            SqlCommand command = new SqlCommand();

            //Connection情報の登録
            command.Connection = connection;

            //検索結果取得用のオブジェクトを用意
            SqlDataReader reader = null;
            try
            {                
                //実行するプロシージャの登録
                command.CommandText = "SELECT ItemTable.ItemID, ItemTable.Name, ItemTable.CategoryID, " +
                                        "CategoriesTable.CategoryName, ItemTable.Price FROM ItemTable " +
                                        "INNER JOIN CategoriesTable ON ItemTable.CategoryID = CategoriesTable.CategoryID;";
                command.CommandType = CommandType.Text;

                //クエリの実行
                reader = command.ExecuteReader();

                //値の取得
                while (reader.Read())
                {
                    CategoryDto category = new CategoryDto(reader["ItemTable.CategoryID"].ToString(), reader["CategoriesTable.CategoryName"].ToString());
                    ItemDto dto = new ItemDto
                        (reader["ItemID"].ToString(), reader["ItemTable.Name"].ToString(), category, Convert.ToInt32(reader["ItemTable.Price"]));
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
