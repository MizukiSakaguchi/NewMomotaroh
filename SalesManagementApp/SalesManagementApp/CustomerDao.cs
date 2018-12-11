using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class CustomerDao
    {
        List<CustomerDto> list = new List<CustomerDto>();

        //データベースから顧客の一覧のリストを取ってきて返却するメソッド.
        public List<CustomerDto> DisplayCustomer()
        {
            //データベースの接続開始  
            SqlConnection con = new SqlConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
                ["SalesManagementApp.Properties.Settings.connectDB"].ConnectionString;

            try
            {
                con.Open();

                SqlCommand com = new SqlCommand();

                //実行するSQL文の準備
                com.CommandText = $"SELECT * FROM CustomerTable";

                com.Connection = con;

                SqlDataReader reader;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new CustomerDto(reader["CustID"].ToString(), reader["Name"].ToString(),
                    reader["TEL"].ToString()));
                    reader.Close();
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                try
                {
                    con.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            return list;

        }
    }
}
