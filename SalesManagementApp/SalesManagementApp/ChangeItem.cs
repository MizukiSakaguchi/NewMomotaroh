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
            string id = label5.Text;
            string name = textBox1.Text;
            int price = Convert.ToInt32(textBox2.Text);

            string selectCategory = comboBox1.SelectedItem.ToString();
            string[] categoryNameList = selectCategory.Split(':');
            string categoryId = categoryNameList[0];
            string categoryName = categoryNameList[1];
            CategoryDto category = new CategoryDto(categoryId,categoryName);

            ItemDto item = new ItemDto(id, name, category, price);

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
            label5.Text = item.Id;
            label5.Visible = true;
            textBox1.Text = item.Name;
            textBox2.Text = item.Price.ToString();

        }
    }
}
