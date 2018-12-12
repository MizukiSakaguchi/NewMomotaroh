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
            CreateID create = new CreateID();
            string stockId = create.CreateStrockID();
            string id = "i0002";
            string name = "ちゃおちゅーる";
            int price = 300;
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = new ItemDto(id, name, category, price);
            DateTime update = new DateTime(2018, 12, 13, 15, 00, 00);
            StockDto dto = new StockDto(stockId, itemDto, 3, update);
            StockDao dao = new StockDao();

            Assert.IsTrue(dao.InsertStock(dto));
        }

        [TestMethod()]
        public void InsertStockTest2()
        {
            CreateID create = new CreateID();
            string stockId = create.CreateStrockID();
            ItemDto itemDto = null;
            DateTime update = new DateTime(2018, 12, 14, 15, 00, 00);
            StockDto dto = new StockDto(stockId, itemDto, 3, update);
            StockDao dao = new StockDao();            

            Assert.IsFalse(dao.InsertStock(dto));
        }

        [TestMethod()]
        public void InsertStockTest3()
        {
            CreateID create = new CreateID();
            string stockId = create.CreateStrockID();
            string id = null;
            string name = "ちゃおちゅーる";
            int price = 300;
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = new ItemDto(id, name, category, price);
            DateTime update = new DateTime(2018, 12, 15, 15, 00, 00);
            StockDto dto = new StockDto(stockId, itemDto, 3, update);
            StockDao dao = new StockDao();

            Assert.IsFalse(dao.InsertStock(dto));
        }

        [TestMethod()]
        public void InsertStockTest4()
        {
            StockDao dao = new StockDao();

            Assert.IsTrue(dao.InsertStock(null));
        }
    }
}