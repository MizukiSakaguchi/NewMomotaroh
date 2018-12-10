﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class ItemDao
    {

        SqlConnection connection = new SqlConnection();

        

        //商品を一覧するDao
        public List<ItemDto> DisplayItem()
        {
            connection.ConnectionString
                = System.Configuration
                .ConfigurationManager
                .ConnectionStrings["SalesManagementApp.Properties.Settings.connectDB"]
                .ConnectionString;
            //DB接続
            connection.Open();
            List<ItemDao> list = new List<ItemDao>();
            SqlCommand command = new SqlCommand();

            try
            {
                
                //実行するプロシージャの登録
                command.CommandText = "SELECT * FROM ItemTable;";
                command.CommandType = CommandType.Text;
                //Connection情報の登録
                command.Connection = connection;

                //検索結果取得用のオブジェクトを用意
                SqlDataReader reader;
                //クエリの実行
                reader = command.ExecuteReader();

                //値の取得
                while (reader.Read())
                {
                    list.Add(reader["ItemID"].ToString());
                    list.Add(reader["Name"].ToString());
                    list.Add(reader["Price"].ToInt32());
                    list.Add(reader["CategoryID"].ToString());

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
                command.Close();
            }

            return list;
        }


        public ItemDto UpdateItem(ItemDto item)
        {
            connection.ConnectionString
                = System.Configuration
                .ConfigurationManager
                .ConnectionStrings["SalesManagementApp.Properties.Settings.connectDB"]
                .ConnectionString;
            //DB接続
            connection.Open();

            SqlCommand command = new SqlCommand();
            //実行するsql文の登録
            command.CommandText = $"UPDATE ItemTable " +
                $"SET Name = @name, Price = @price, CategoryID = @categoryId " +
                $"WHERE ItemID = @item_id; ";
            command.CommandType = CommandType.Text;

            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = item.Name;

            command.Parameters.Add("@price", SqlDbType.Int);
            command.Parameters["@price"].Value = item.Price;


            //Connection情報の登録
            command.Connection = connection;

            int num = command.ExecuteNonQuery();

            if (num > 0)
            {
                label2.Text = "更新しました";
            }
            else
            {
                label2.Text = "更新できませんでした";
            }
        }
    }
}
