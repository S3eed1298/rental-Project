namespace rental_Project.customers
{
    internal class SilverMember : IMember
    {
        public SilverMember()
        {
            DiscountRate = 20;
        }

        public int DiscountRate { get; }
    }
}