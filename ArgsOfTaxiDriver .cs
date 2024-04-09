using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public class ArgsOfTaxiDriver : EventArgs
    {
        public TaxiDriver TaxiDriver { get; set; }
        public ArgsOfTaxiDriver(TaxiDriver taxiDriver)
        {
            TaxiDriver = taxiDriver;
        }
    }
}
