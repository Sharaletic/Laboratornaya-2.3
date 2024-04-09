using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public class ArgsOfTaxiOrder : EventArgs //параметризация
    {
        public Order TempOrder { get; set; }
        public ArgsOfTaxiOrder(Order tempOrder)
        {
            TempOrder = tempOrder;
        }
    }
}
