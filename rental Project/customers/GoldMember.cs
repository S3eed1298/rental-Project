namespace rental_Project.customers
{
    internal class GoldMember : IMember
    {
        public GoldMember()
        {
            DiscountRate = 25;
            MemberString = "Gold";
        }

        public int DiscountRate { get; }
        public string MemberString { get; }
    }
}