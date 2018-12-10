using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    class ItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public int Price { get; set; }
        public CustomerDto Customer { get; set; }
        public StockDto Strock { get; set; }

        public ItemDto(string id, string name, CategoryDto category, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }


    }
}
