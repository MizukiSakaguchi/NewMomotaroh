﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    public class ItemDao
    {

        //商品を一覧するDao
        public List<ItemDto> DisplayItem()
        {

            CreateID create = new CreateID();
            string resultID = null;
            resultID = create.CreateStrockID();

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
                command.CommandText = $"SELECT * FROM ItemTable " +
                                        $" INNER JOIN CategoriesTable " +
                                        $" ON ItemTable.CategoryID = CategoriesTable.CategoryID " +
                                        $" INNER JOIN (SELECT MAX(Date) AS maxDate,ItemID" +
                                            $" FROM StockTable group by StockTable.ItemID) AS Stocks " +
                                            $" ON ItemTable.ItemID = Stocks.ItemID" +
                                            $" INNER JOIN  (SELECT Number, ItemID FROM StockTable) AS NumberTable " +
                                            $" ON ItemTable.ItemID = NumberTable.ItemID " +
                                            $" ";
                command.CommandType = CommandType.Text;
                
                //クエリの実行
                reader = command.ExecuteReader();

                //値の取得
                while (reader.Read())
                {
                    CategoryDto category = new CategoryDto(reader["CategoryID"].ToString(), reader["CategoryName"].ToString());
                    
                    ItemDto dto = new ItemDto
                        (reader["ItemID"].ToString(), reader["Name"].ToString(), category, Convert.ToInt32(reader["Price"]));

                    DateTime date = DateTime.Parse(reader["maxDate"].ToString());
                    StockDto stock = new StockDto(resultID, dto, Convert.ToInt32(reader["Number"]), date);
                    dto.Stock = stock;
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

                command.Parameters.Add("@item_id", SqlDbType.NVarChar, 20);
                command.Parameters["@item_id"].Value = item.Id;

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
