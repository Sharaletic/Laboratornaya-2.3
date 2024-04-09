using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_2._3
{
    public class TaxiAggregator
    {
        private List<Customer> customerList { get; set; }
        private List<TaxiDriver> driversList { get; set; }
        private List<TaxiDriver> taxiDriversTemp { get; set; }

        public TaxiAggregator()
        {
            customerList = new List<Customer>();
            driversList = new List<TaxiDriver>();
            taxiDriversTemp = new List<TaxiDriver>();
        }
        public void AddNewTaxiDriver(TaxiDriver driver)
        {
            driversList.Add(driver);
            driver.RespondedToOrder += AddReadyDriverInTempList;
        }

        public void RemoveTaxiDriver(TaxiDriver driver)
        {
            driversList.Remove(driver);
            driver.RespondedToOrder -= AddReadyDriverInTempList;
        }

        private void AddReadyDriverInTempList(ArgsOfTaxiDriver driver)
        {
            taxiDriversTemp.Add(driver.TaxiDriver);
        }

        public TaxiDriver FindBestDriver()
        {
            double max = 0;
            TaxiDriver bestDriver = null;
            foreach (TaxiDriver driver in taxiDriversTemp)
            {
                if (driver.Ball > max)
                {
                    max = driver.Ball;
                    bestDriver = driver;
                }
            }
            return bestDriver;
        }
        public string CreateAnOrder(Customer customer, Address departure, Address distination, bool ChildSeat)
        {

            if (!customerList.Contains(customer))
            {
                foreach (TaxiDriver driver in driversList)
                {
                    customer.IWantToTakeATaxi += driver.GoToOrder; //подписка
                }

                customerList.Add(customer);
            }

            Order order = new Order()
            {
                Departure = departure,
                Distination = distination,
                ChildSeat = ChildSeat
            };
            customer.TempOrder = order;

            customer.TakeATaxi();
            TaxiDriver bestDriver = FindBestDriver();
            taxiDriversTemp.Clear();

            if (bestDriver != null)
            {
                //bestDriver.CurrentLocation = customer.TempOrder.Distination.Сoordinates;
                bestDriver.Free = false;

                return $"Водитель {bestDriver.Name} на {bestDriver.Car.Brand} с гос. номером {bestDriver.Car.Number} отправился на заказ: от {customer.TempOrder.Departure.Street}, {customer.TempOrder.Departure.House} до {customer.TempOrder.Distination.Street}, {customer.TempOrder.Distination.House}.";
            }
            else
            {
                return "Попробуйте позже";
            }
        }
    }
}
