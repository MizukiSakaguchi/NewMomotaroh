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
                label13.Visible = true;
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            label6.Text = $"{item.Id}";
            label6.Visible = true;
            label7.Text = $"{item.Name}";
            label7.Visible = true;
            label8.Text = $"{item.Category.Name}";
            label8.Visible = true;
            label9.Text = $"{item.Price}";
            label9.Visible = true;
        }

        //追加
        private void button1_Click(object sender, EventArgs e)
        {
            int stockNum = Convert.ToInt32(textBox1.Text);

            StockDto dto = new StockDto(null, itemDto, stockNum, DateTime.Now);

            StockDao dao = new StockDao();

            //Dao実行結果を確認する変数を用意
            bool result;
            result = dao.InsertStock(dto);

            if(result)
            {
                label13.ForeColor = Color.Black;
                label13.Text = "追加に成功しました。";
                label13.Visible = true;
            }
            label13.Text = "追加に失敗しました。";
            label13.Visible = true;
        }

        //キャンセル
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
