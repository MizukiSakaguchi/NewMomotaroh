﻿using System;
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
     * label1.商品ID　2.商品名　3.カテゴリ　4.単価　11.在庫数  
     */
    public partial class ItemList : Form
    {
        private List<ItemDto> list = new List<ItemDto>();
        CategoryDto category;

        public ItemList()
        {
            InitializeComponent();

            ItemDao dao = new ItemDao();
            list = dao.DisplayItem();

            list.ForEach(v => listBox1.Items.Add($"{v.Id}：{v.Name}"));
        }
                
        //注文ボタン
        private void button3_Click(object sender, EventArgs e)
        {
            AddOrder order = new AddOrder();
            order.Show();
        }

        //変更ボタン
        private void button4_Click(object sender, EventArgs e)
        {
            ChangeItem item = new ChangeItem();
            item.Show();
        }

        //在庫数追加
        private void button1_Click(object sender, EventArgs e)
        {
            string id = list[listBox1.SelectedIndex].Id;
            string name = list[listBox1.SelectedIndex].Name;
            category = list[listBox1.SelectedIndex].Category;
            int price = list[listBox1.SelectedIndex].Price;

            ItemDto dto = new ItemDto(id, name, category, price);

            AddStock stock = new AddStock(dto);
            stock.Show();
        }

        /**
         * リスト内の商品を選択したとき、選択された商品の情報を右側に表示するメソッド.         * 
         * 
         */
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = $"{list[listBox1.SelectedIndex].Id}";
            label1.Visible = true;
            label2.Text = $"{list[listBox1.SelectedIndex].Name}";
            label2.Visible = true;
            label3.Text = $"{list[listBox1.SelectedIndex].Category.Name}";
            label3.Visible = true;
            label4.Text = $"{list[listBox1.SelectedIndex].Price}";
            label4.Visible = true;
            label11.Text = $"{list[listBox1.SelectedIndex].Stock.Num}";
            label11.Visible = true;                        
        }

        private void ItemList_Load(object sender, EventArgs e)
        {
           
        }

        //カテゴリーの情報を返却するメソッド.
        public CategoryDto sendData
        {
            get
            {
                return category;
            }
        }
    }
}
