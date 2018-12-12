using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp
{
    /**
     * テキストボックスのバリデーションチェックを行うクラス.
     */
    public class Validator
    {
        public int Num { get; set; }
        public string Word { get; set; }

        public bool SetOn(string str)
        {
            if(str.Length == 0)
            {
                return false;
            }
            return true;
        }

        public bool IsMinus(int val)
        {
            if(val < 0)
            {
                return false;
            }
            return true;
        }

        public bool IsPoint(int val)
        {
            if(val%1 != 0)
            {
                return false;
            }
            return true;
        }

        public bool IsNumeric(string str)
        {
            int i = 0;
            if (!int.TryParse(str, out i))
            { 
                return false;
            }
            return true;
        }

        public bool StockOver(int val, ItemDto item)
        {
            if(item.Stock.Num < val)
            {
                return false;
            }
            return true;
        }
    }
}
