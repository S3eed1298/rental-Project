using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class CommercialCustomers : Customer
    {
        private string ID { get; }
        private int numberOfMonths { get; }
        private IMember discountType { get; }

        public CommercialCustomers(string ID, int numberOfMonths, string theCarModel, int theCarModelYear, int theBasePrice)
        {
            this.ID = ID;
            this.numberOfMonths = numberOfMonths;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
        }

        public double CommercialTotalPrice()
        {
            int discount = discountType.DiscountRate;
            int days = this.numberOfMonths * 30;
            double dailyPrice = CalculateDailyPrice(days, car_base_price);
            double totalPrice = dailyPrice * days;
            return totalPrice;
        }
    }
}
