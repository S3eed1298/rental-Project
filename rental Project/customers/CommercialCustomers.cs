namespace rental_Project.customers
{
    internal class CommercialCustomers : Customer
    {
        public CommercialCustomers(
            string ID,
            int numberOfMonths,
            string theCarModel,
            int theCarModelYear,
            double theBasePrice,
            IMember memberType)
        {
            this.ID = ID;
            this.numberOfMonths = numberOfMonths;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            discountType = memberType;
            rentalCode = CreateRentalCode();
        }

        private string ID { get; }
        public int numberOfMonths { get; set; }
        public IMember discountType { get; set; }

        public double CommercialTotalPrice()
        {
            int discount = discountType.DiscountRate;
            int days = numberOfMonths * 30;
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * days;
            return totalPrice;
        }
    }
}