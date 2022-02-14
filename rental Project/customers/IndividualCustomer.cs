namespace rental_Project.customers
{
    internal class IndividualCustomer : Customer
    {
        public IndividualCustomer(string ID, int numberOfDays, string theCarModel, int theCarModelYear, double theBasePrice)
        {
            this.ID = ID;
            this.numberOfDays = numberOfDays;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            isMember = checkMember();
            rentalCode = CreateRentalCode();
        }

        public string ID { get; }
        public int numberOfDays { get; }

        public bool isMember { get; }

        public double IndividualTotalPrice()
        {
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * numberOfDays;
            return totalPrice;
        }

        private bool checkMember()
        {
            if (ID[0].Equals('M'))
                return true;
            return false;
        }
    }
}