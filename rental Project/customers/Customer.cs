using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class Customer
    {
        protected string car_model { get; set; }
        protected int car_model_year { get; set; }
        protected int car_base_price { get; set; }

        public static double CalculateDailyPrice(int model_year, double base_price)
        {
            return base_price / (2022 - model_year);
        }

        public static int CreateRentalCode()
        {
            Random rnd = new Random();
            int rentalCode = rnd.Next(9999999);
            return rentalCode;
        }
    }
}

