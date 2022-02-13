namespace rental_Project.customers
{
    internal class PlatinumeMember : IMember
    {
        public PlatinumeMember()
        {
            DiscountRate = 30;
        }

        public int DiscountRate { get; }
    }
}