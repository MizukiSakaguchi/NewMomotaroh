using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    public class StockDto
    {
        public string Id { get; set; }
        public string Item { get; set; }
        public int Num { get; set; }
        public DateTime LastUpDate { get; set; }

        public StockDto(string id, string name, int num, DateTime lastUpDate)
        {
            this.Id = id;
            this.Item = Item;
            this.Num = num;
            this.LastUpDate = lastUpDate;
        }
    }
}
