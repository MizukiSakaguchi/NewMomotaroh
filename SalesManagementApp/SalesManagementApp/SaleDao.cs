using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    public class SaleDao
    {

        /**
         * DBに商品を登録するDao.
         * @param 登録する商品情報
         */
        public bool InsertSale(SaleDto sale)
        {
            //ID生成
            CreateID create = new CreateID();
            string createId = null;
            createId = create.CreateSaleID();

            SqlConnection con = new SqlConnection();

            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings
               ["SalesManagementApp.Properties.Settings.connectDB"].ConnectionString;
            //con.ConnectionString =
              //         "Data Source = 192.168.100.108\SQLEXPRESS; Initial Catalog = Momotaroh; Integrated Security = True";
            
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand();

                com.CommandText = $"INSERT INTO SalesTable (SalesID, CustID, Number, ItemID) " +
                                    $"VALUES(@id, @customerId, @num, @itemId)";

                com.Parameters.Add("@id", SqlDbType.NVarChar, 5);
                com.Parameters["@id"].Value = createId;
                com.Parameters.Add("@customerId", SqlDbType.NVarChar, 4);
                com.Parameters["@customerId"].Value = sale.Customer.Id;
                com.Parameters.Add("@num", SqlDbType.Int);
                com.Parameters["@num"].Value = sale.Num;
                com.Parameters.Add("@itemId", SqlDbType.NVarChar, 5);
                com.Parameters["@itemId"].Value = sale.Item.Id;

                com.Connection = con;

                int result = com.ExecuteNonQuery();

                if(result > 0)
                {
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
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
            return false;
        }
    }
}
