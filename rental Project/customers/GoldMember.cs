namespace rental_Project.customers
{
    internal class GoldMember : IMember
    {
        public GoldMember()
        {
            DiscountRate = 25;
        }

        public int DiscountRate { get; }
    }
}