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
        ItemDto item = null;

        public ChangeItem(ItemDto itemDto)
        {
            this.item = itemDto;
            InitializeComponent();
        }

        //変更
        private void button1_Click(object sender, EventArgs e)
        {
            ItemDao itemDao = new ItemDao();
            ItemDto changeItem = itemDao.UpdateItem(item);
            if(changeItem != null)
            {
                MessageBox.Show("更新に成功しました");
                this.Close();
            }
            else
            {
                label7.Text = "更新に失敗しました";
                label7.Visible = true;
            }
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
