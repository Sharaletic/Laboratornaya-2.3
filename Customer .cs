using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public delegate void CustomerDelegate(ArgsOfTaxiOrder argsOfTaxiOrder);
    public class Customer //класс-источник
    {
        public string Name { get; set; }
        public Order TempOrder { get; set; }
        public event CustomerDelegate IWantToTakeATaxi;

        public void TakeATaxi()
        {
            IWantToTakeATaxi?.Invoke(new ArgsOfTaxiOrder(TempOrder));
        }
    }
}
