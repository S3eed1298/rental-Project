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
        public int numberOfDays { get;}

        public bool member { get; }
        public IndividualCustomer(T ID, int numberOfDays, string theCarModel, int theCarModelYear, int theBasePrice)
        {

            this.ID = ID;
            this.numberOfDays = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            this.member = checkMember();
            rentalCode = CreateRentalCode();
        }
        public double IndividualTotalPrice()
        {
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * this.numberOfDays;
            return totalPrice;
        }

        private bool checkMember()
        {
            if (ID.GetType() == typeof(string))
                return true;
            else
                return false;
        }
    }
}
