using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public class Order
    {
        public Address Distination { get; set; }
        public Address Departure { get; set; }
        public bool ChildSeat { get; set; }
        public double Distance { get; set; }
    }
}
