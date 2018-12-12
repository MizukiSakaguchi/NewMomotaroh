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
    public class StockDaoTests
    {
        [TestMethod()]
        public void InsertStockTest1()
        {
            string id = "i0002";
            string name = "ちゃおちゅーる";
            DateTime update = new DateTime(2018, 12, 14, 15, 00, 00);
            StockDto dto = new StockDto("i0001", , 3, update);

            Assert.Fail();
        }

        [TestMethod()]
        public void InsertStockTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertStockTest3()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertStockTest4()
        {
            Assert.Fail();
        }
    }
}