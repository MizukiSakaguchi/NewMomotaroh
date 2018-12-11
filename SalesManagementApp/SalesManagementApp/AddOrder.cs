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
     * label5.商品ID　6.商品名　7.カテゴリ　8.単価　12.エラーメッセージ
     * textBox1.顧客　2.注文
     */
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
        }

        //顧客選択
        private void button1_Click(object sender, EventArgs e)
        {
            SearchCustomer searchCustomer = new SearchCustomer();
            searchCustomer.Show();
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
            ItemList itemList = new ItemList();
            CategoryDto categoryDto = new CategoryDto(itemList.sendData.Id , itemList.sendData.Name);
            ItemDto itemDto = new ItemDto(itemId , name , categoryDto , price);

            //CustomerDaoのインスタンス作成
            SearchCustomer searchCustomer = new SearchCustomer();
            CustomerDto customerDto = new CustomerDto(null , null , null);
            customerDto = searchCustomer.sendData;
            
            //SaleDtoのインスタンス作成
            SaleDto saleDto = new SaleDto(null , customerDto , number , itemDto);

            //注文処理の実行
            bool frag = saleDao.InsertSale(saleDto);

            if (frag == false)
            {
                label12.Text = "登録できませんでした";
                label12.Visible = true;
            } 
        }

        //キャンセル
        private void button3_Click(object sender, EventArgs e)
        {
            ItemList itemList = new ItemList();
            itemList.Show();
        }
    }
}
