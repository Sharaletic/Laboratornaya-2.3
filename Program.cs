using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaxiDriver driver1 = new TaxiDriver { Name = "Иванов Иван", CurrentLocation = (56.02319, 92.752024), Ball = 5, Free = true, Car = new Car { Number = "А755МТ", Brand = "Lexus", ChildSeat = true } };
            TaxiDriver driver2 = new TaxiDriver { Name = "Борисов Борис", CurrentLocation = (56.025049, 92.826508), Ball = 4, Free = true, Car = new Car { Number = "И310ЧС", Brand = "Chevrolet", ChildSeat = true } };
            TaxiDriver driver3 = new TaxiDriver { Name = "Алексей Алексеев", CurrentLocation = (56.008639, 92.799896), Ball = 4, Free = true, Car = new Car { Number = "Т104УП", Brand = "KIA", ChildSeat = true } };

            Customer customer1 = new Customer { Name = "Петр Петров", TempOrder = new Order { Departure = new Address { Сoordinates = (56.994637, 92.798755), Street = "Крещатик", House = 21 }, Distination = new Address { Сoordinates = (56.004256, 92.772263), Street = "Тверская", House = 16 }, ChildSeat = true, Distance = 0.5 } };
            Customer customer2 = new Customer { Name = "Иван Иванов", TempOrder = new Order { Departure = new Address { Сoordinates = (55.087369, 92.788785), Street = "Кловский спуск", House = 7 }, Distination = new Address { Сoordinates = (56.004256, 92.772263), Street = "Павелецкая", House = 30 }, ChildSeat = true, Distance = 0.7 } };

            TaxiAggregator taxiAggregator = new TaxiAggregator();
            taxiAggregator.AddNewTaxiDriver(driver1);
            taxiAggregator.AddNewTaxiDriver(driver2);
            taxiAggregator.AddNewTaxiDriver(driver3);

            Console.WriteLine(taxiAggregator.CreateAnOrder(customer1, customer1.TempOrder.Departure, customer1.TempOrder.Distination, customer1.TempOrder.ChildSeat));
            Console.WriteLine(taxiAggregator.CreateAnOrder(customer2, customer2.TempOrder.Departure, customer2.TempOrder.Distination, customer2.TempOrder.ChildSeat));
        }
    }
}
