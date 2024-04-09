using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public delegate void DriverDelegate(ArgsOfTaxiDriver argsOfTaxiDriver);
    public class TaxiDriver //класс-наблюдатель
    {
        public string Name { get; set; }
        public (double, double) CurrentLocation { get; set; }
        public double Ball { get; set; }
        public bool Free { get; set; }
        public Car Car { get; set; }

        public event DriverDelegate RespondedToOrder;

        public void GoToOrder(ArgsOfTaxiOrder order)
        {
            //Address address = new Address();
            double Distant = Math.Sqrt(Math.Pow((CurrentLocation.Item1 - order.TempOrder.Distination.Сoordinates.Item1), 2) + Math.Pow((CurrentLocation.Item2 - order.TempOrder.Distination.Сoordinates.Item2), 2));
            if ((Free == true) && (Car.ChildSeat == order.TempOrder.ChildSeat) && (Distant < 100))
            {
                RespondedToOrder?.Invoke(new ArgsOfTaxiDriver(this));
                Ball += Distant;
                //Free = false;
            }
        }
    }
}
