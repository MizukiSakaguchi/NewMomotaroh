using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementApp
{
    /**
     * label5.商品ID　6.商品名　7.カテゴリ　8.単価　12.エラーメッセージ
     * textBox1.顧客　2.注文
     */
    public partial class AddOrder : Form
    {
        private ItemList itemList;
        private SearchCustomer searchCustomer;
        public AddOrder(ItemList itemList)
        {
            InitializeComponent();
            this.itemList = itemList;
        }

        //顧客選択
        private void button1_Click(object sender, EventArgs e)
        {
            searchCustomer = new SearchCustomer();
            searchCustomer.ShowDialog();
            textBox1.Text = searchCustomer.sendData.Name;
        }

        //注文
        private void button2_Click(object sender, EventArgs e)
        {
            //注文処理を行うためにsaleDaoのインスタンス作成
            SaleDao saleDao = new SaleDao();

            //商品情報
            string itemId = label5.Text;
            string name = label6.Text;
            int price = int.Parse(label8.Text);

            //顧客情報
            string customer = textBox1.Text;
            int number = int.Parse(textBox2.Text);

            //CategoryDtoのインスタンス作成
            CategoryDto categoryDto = new CategoryDto(itemList.ItemDto.Category.Id , itemList.ItemDto.Category.Name);
            ItemDto itemDto = new ItemDto(itemId , name , categoryDto , price);

            //CustomerDaoのインスタンス作成
            CustomerDto customerDto = searchCustomer.sendData;
            
            //SaleDtoのインスタンス作成
            SaleDto saleDto = new SaleDto(null , customerDto , number , itemDto);

            //注文処理の実行
            bool frag = saleDao.InsertSale(saleDto);
            if (frag)
            {
                MessageBox.Show("登録に成功しました");
                this.Close();
            }
            else
            {
                label12.Text = "登録できませんでした";
                label12.Visible = true;
            }
            

        }

        //キャンセル
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            ItemDto itemDto = new ItemDto(null , null , null , 0);
            itemDto = itemList.ItemDto;
            label5.Text = itemDto.Id.ToString();
            label5.Visible = true;
            label6.Text = itemDto.Name.ToString();
            label6.Visible = true;
            label7.Text = itemDto.Category.Name.ToString();
            label7.Visible = true;
            label8.Text = itemDto.Price.ToString();
            label8.Visible = true;
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
