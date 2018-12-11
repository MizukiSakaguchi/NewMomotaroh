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
        public ItemDto Item { get; set; }
        public int Num { get; set; }
        public DateTime LastUpDate { get; set; }

        public StockDto(string id, ItemDto item, int num, DateTime lastUpDate)
        {
            this.Id = id;
            this.Item = item;
            this.Num = num;
            this.LastUpDate = lastUpDate;
        }
    }
}
