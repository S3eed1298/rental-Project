namespace rental_Project.customers
{
    internal class IndividualCustomer<T> : Customer
    {
        public IndividualCustomer(T ID, int numberOfDays, string theCarModel, int theCarModelYear, double theBasePrice)
        {
            this.ID = ID;
            this.numberOfDays = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            member = checkMember();
            rentalCode = CreateRentalCode();
        }

        private T ID { get; }
        public int numberOfDays { get; }

        public bool member { get; }

        public double IndividualTotalPrice()
        {
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * numberOfDays;
            return totalPrice;
        }

        private bool checkMember()
        {
            if (ID.GetType() == typeof(string))
            {
                return true;
            }

            return false;
        }
    }
}