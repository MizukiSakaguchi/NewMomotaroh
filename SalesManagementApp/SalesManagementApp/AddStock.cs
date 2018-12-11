using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementApp
{
    /**
     * label6.商品ID　7.商品名　8.カテゴリ　
     * label9.単価　11.エラーメッセージ　13.最終更新日
     * textBox1.数量
     */
    public partial class AddStock : Form
    {
        public ItemDto itemDto;

        public AddStock()
        {
            InitializeComponent();
        }

        public AddStock(ItemDto item)
        {
            InitializeComponent();

            itemDto = item;

            DBHelper dBHelper = new DBHelper();
            SqlConnection connection = dBHelper.ConnectDB();

            SqlCommand command = new SqlCommand();

            command.CommandText = $"SELECT * FROM StockTable " +
                                    $"WHERE ItemID = '{item.Id}' ORDER BY Date DESC";

            command.Connection = connection;

            SqlDataReader reader;
            reader = command.ExecuteReader();
            try
            {
                reader.Read();

                DateTime lastUpDate = DateTime.Parse(reader["Date"].ToString());
                string upDate = lastUpDate.ToLongDateString();

                label13.Text = $"{upDate}";              
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            label6.Text = $"{item.Id}";
            label7.Text = $"{item.Name}";
            label8.Text = $"{item.Category.Name}";
            label9.Text = $"{item.Price}";
        }

        //追加
        private void button1_Click(object sender, EventArgs e)
        {
            int stockNum = Convert.ToInt32(textBox1.Text);

            StockDto dto = new StockDto(null, itemDto, stockNum, DateTime.Now);

            StockDao dao = new StockDao();
            dao.InsertStock(dto);
        }

        //キャンセル
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
