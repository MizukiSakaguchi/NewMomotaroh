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
     * label5.商品ID　7.エラーメッセージ
     * textBox1.商品名　2.単価
     * comboBox1.カテゴリ
     */
    public partial class ChangeItem : Form
    {
        ItemList f1;

        public ChangeItem(ItemList f1)
        {
            this.f1 = f1;
            InitializeComponent();
        }

        //変更
        private void button1_Click(object sender, EventArgs e)
        {
            string id = label5.Text;
            string name = textBox1.Text;
            int price = Convert.ToInt32(textBox2.Text);
            string strCategory = comboBox1.SelectedText;

            
            
            


            ItemDao itemDao = new ItemDao();
            
        }

        //キャンセル
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeItem_Load(object sender, EventArgs e)
        {
            ItemList itemList = new ItemList();

        }
    }
}
