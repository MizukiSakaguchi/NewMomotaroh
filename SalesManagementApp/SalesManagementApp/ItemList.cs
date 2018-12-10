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
     * label1.商品ID　2.商品名　3.カテゴリ　4.単価　11.在庫数     * 
     */
    public partial class ItemList : Form
    {
        public ItemList()
        {
            InitializeComponent();

            ItemDao dao = new ItemDao();
            dao.DisplayItem();
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
            ChangeItem item = new ChangeItem();
            item.Show();
        }

        //在庫数追加
        private void button1_Click(object sender, EventArgs e)
        {
            AddStock stock = new AddStock();
            stock.Show();
        }

        //商品リスト内のアイテムを選択したとき
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
