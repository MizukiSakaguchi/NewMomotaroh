using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesManagementApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.Tests
{
    [TestClass()]
    public class CustomerDaoTests
    {
        [TestMethod()]
        public void DisplayCustomerTest()
        {
            List<CustomerDto> customerDto = new List<CustomerDto>();
            CustomerDao customerDao = new CustomerDao();
            customerDto = customerDao.DisplayCustomer();
            Assert.AreEqual(7, customerDto.Count);

        }
    }
}