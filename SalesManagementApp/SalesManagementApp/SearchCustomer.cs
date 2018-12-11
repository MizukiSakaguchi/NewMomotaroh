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
        public List<CustomerDto> customerList { get; private set; }

        public SearchCustomer()
        {
            InitializeComponent();

        }
        CustomerDao customerDao = new CustomerDao();

        //ロードした時の表示
        private void SearchCustomer_Load(object sender, EventArgs e)
        {

            var CustomerList = new List<CustomerDto>();
            customerList = customerDao.DisplayCustomer();
            foreach (var b in customerList)
            {
                listBox1.Items.Add($"b.Id.ToString() : b.Name.ToString()");
            }
        }

        //顧客の選択
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //キャンセル
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //顧客リスト内の顧客をクリックしたとき
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
