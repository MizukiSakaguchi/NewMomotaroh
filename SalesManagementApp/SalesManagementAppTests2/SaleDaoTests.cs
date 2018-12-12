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
    public class SaleDaoTests
    {
        [TestMethod()]
        public void InsertSaleTest()
        {
            SaleDao saleDao = new SaleDao();
            CustomerDto customerDto = new CustomerDto("c002" , "例え" , "電話番号");
            CategoryDto categoryDto = new CategoryDto("c001" , "犬");
            ItemDto itemDto = new ItemDto("i0001" , "なんか" , categoryDto , 1200);
            SaleDto saleDto = new SaleDto(null , customerDto , 2 , itemDto);
            bool frag = saleDao.InsertSale(saleDto);
            Assert.AreEqual(true, frag);
        }
    }
}