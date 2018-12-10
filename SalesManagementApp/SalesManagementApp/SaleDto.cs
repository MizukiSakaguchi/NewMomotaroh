using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    public class SaleDto
    {
        public string Id { get; set; }
        public CustomerDto Customer { get; set; }
        public int Num { get; set; }
        public ItemDto Item { get; set; }

        public SaleDto(string id, CustomerDto customer, int num, ItemDto item)
        {
            this.Id = id;
            this.Customer = customer;
            this.Num = num;
            this.Item = item;
        }
    }
}
