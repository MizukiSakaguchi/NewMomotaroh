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
    public partial class ItemList : Form
    {
        public ItemList()
        {
            InitializeComponent();
        }
                
        //注文
        private void button3_Click(object sender, EventArgs e)
        {
            AddOrder order = new AddOrder();
            order.Show();
        }

        //変更
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //在庫数追加
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //商品リスト内のアイテムを選択したとき
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
