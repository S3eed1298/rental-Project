using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class Customer
    {
        protected string car_model;
        protected int car_model_year;
        protected int car_base_price;

        public static double CalculateDailyPrice(int model_year, double base_price)
        {
            double daily_price = base_price / (2022 - model_year);
            return daily_price;
        }
    }
}
