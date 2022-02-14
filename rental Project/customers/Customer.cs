using System;

namespace rental_Project.customers
{
    internal class Customer
    {
        public string car_model { get; set; }
        public int car_model_year { get; set; }
        public double car_base_price { get; set; }
        public int rentalCode { get; set; }

        public static double CalculateDailyPrice(int model_year, double base_price)
        {
            return base_price / (2022 - model_year);
        }
        public static int CreateRentalCode()
        {
            var rnd = new Random();
            int rentalCode = rnd.Next(1000000, 9999999);
            return rentalCode;
        }
    }
}