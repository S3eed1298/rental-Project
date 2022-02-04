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

        public CommercialCustomers(string ID, int numberOfDays, string theCarModel, int theCarModelYear, int theBasePrice)
        {
            this.ID = ID;
            this.numberOfMonths = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
        }

        public void sdsss()
        {
            int discount = discountType.DiscountRate;
            
        }
        
    }
}
