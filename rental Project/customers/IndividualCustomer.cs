using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class IndividualCustomer<T> : Customer
    {
        private T ID { get; }
        private int numberOfDays { get;}
        public IndividualCustomer(T ID, int numberOfDays, string theCarModel, int theCarModelYear, int theBasePrice)
        {
            this.ID = ID;
            this.numberOfDays = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
        }
        public static double IndividualTotalPrice()
        {
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * this.numberOfDays;
            return totalPrice;
        }
    }
}
