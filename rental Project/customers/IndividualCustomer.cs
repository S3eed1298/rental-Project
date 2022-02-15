namespace rental_Project.customers
{
    internal class IndividualCustomer<T> : Customer
    {
        public IndividualCustomer(T ID, int numberOfDays, string theCarModel, int theCarModelYear, double theBasePrice)
        {
            this.ID = ID;
            this.NumberOfDays = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            rentalCode = CreateRentalCode();
        }

        public T ID { get; }
        public int NumberOfDays { get; }

        public double IndividualTotalPrice()
        {
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * NumberOfDays;
            return totalPrice;
        }

    }
}