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
        public void InsertSaleTest1()
        {
            CreateID create = new CreateID();
            string saleId = create.CreateSaleID();
            string custId = "c001";
            CustomerDto custDto = new CustomerDto(custId, "RMK", "080-***");
            string itemId = "i0002";
            string name = "ちゃおちゅーる";
            int price = 300;
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = new ItemDto(itemId, name, category, price);
            SaleDto dto = new SaleDto(saleId, custDto, 3, itemDto);
            SaleDao dao = new SaleDao();

            Assert.IsTrue(dao.InsertSale(dto));
        }

        [TestMethod()]
        public void InsertSaleTest2()
        {
            CreateID create = new CreateID();
            string saleId = create.CreateSaleID();
            CustomerDto custDto = null;
            string itemId = "i0002";
            string name = "ちゃおちゅーる";
            int price = 300;
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = new ItemDto(itemId, name, category, price);
            SaleDto dto = new SaleDto(saleId, custDto, 3, itemDto);
            SaleDao dao = new SaleDao();

            Assert.IsFalse(dao.InsertSale(dto));
        }

        [TestMethod()]
        public void InsertSaleTest3()
        {
            CreateID create = new CreateID();
            string saleId = create.CreateSaleID();
            string custId = null;
            CustomerDto custDto = new CustomerDto(custId, "RMK", "080-***");
            string itemId = "i0002";
            string name = "ちゃおちゅーる";
            int price = 300;
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = new ItemDto(itemId, name, category, price);
            SaleDto dto = new SaleDto(saleId, custDto, 3, itemDto);
            SaleDao dao = new SaleDao();

            Assert.IsFalse(dao.InsertSale(dto));
        }

        [TestMethod()]
        public void InsertSaleTest4()
        {
            CreateID create = new CreateID();
            string saleId = create.CreateSaleID();
            string custId = null;
            CustomerDto custDto = new CustomerDto(custId, "RMK", "080-***");
            CategoryDto category = new CategoryDto("c0002", "猫用");
            ItemDto itemDto = null;
            SaleDto dto = new SaleDto(saleId, custDto, 3, itemDto);
            SaleDao dao = new SaleDao();

            Assert.IsFalse(dao.InsertSale(dto));
        }

        [TestMethod()]
        public void InsertSaleTest5()
        {
            Assert.Fail();
        }
    }
}