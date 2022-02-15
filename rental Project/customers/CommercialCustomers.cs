using System.Reflection;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
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
            this.NumberOfMonths = numberOfMonths;
            car_model = theCarModel;
            car_model_year = theCarModelYear;
            car_base_price = theBasePrice;
            DiscountType = memberType;
            rentalCode = CreateRentalCode();
        }
        public string ID { get; }
        public int NumberOfMonths { get; set; }
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public IMember DiscountType { get; set; }

        public double CommercialTotalPrice()
        {
            int discount = DiscountType.DiscountRate;
            int days = NumberOfMonths * 30;
            double dailyPrice = CalculateDailyPrice(car_model_year, car_base_price);
            double totalPrice = dailyPrice * days * (1 - (discount / 100.0));
            return totalPrice;
        }
    }
}