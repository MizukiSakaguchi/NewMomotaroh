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
     * label4.顧客ID　5.顧客名　6.tel
     */
    public partial class SearchCustomer : Form
    {
        public List<CustomerDto> CustomerList { get; private set; }

        public SearchCustomer()
        {
            InitializeComponent();

        }
        CustomerDao customerDao = new CustomerDao();
        string name = null;

        //ロードした時の表示
        private void SearchCustomer_Load(object sender, EventArgs e)
        {

            var CustomerList = new List<CustomerDto>();
            this.CustomerList = customerDao.DisplayCustomer();
            foreach (var b in this.CustomerList)
            {
                listBox1.Items.Add($"{b.Id.ToString()} : {b.Name.ToString()}");
            }
        }

        //顧客の選択
        private void button1_Click(object sender, EventArgs e)
        {
            
            AddOrder addOrder = new AddOrder();
            name = CustomerList[listBox1.SelectedIndex].Name;
            addOrder.Show();

        }

        //キャンセル
        private void button2_Click(object sender, EventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.Show();
        }

        //顧客リスト内の顧客をクリックしたとき
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = $"{CustomerList[listBox1.SelectedIndex].Id}";
            label1.Visible = true;
            label2.Text = $"{CustomerList[listBox1.SelectedIndex].Name}";
            label2.Visible = true;
            label3.Text = $"{CustomerList[listBox1.SelectedIndex].Tel}";
            label3.Visible = true;
        }

        //顧客の名前を返却するメソッド.
        public string sendData
        {
            get
            {
                return name;
            }
        }

    
    }
}
