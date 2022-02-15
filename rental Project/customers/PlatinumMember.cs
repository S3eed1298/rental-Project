namespace rental_Project.customers
{
    internal class PlatinumMember : IMember
    {
        public PlatinumMember()
        {
            DiscountRate = 30;
            MemberString = "Platinum";
        }

        public int DiscountRate { get; }
        public string MemberString { get; }
    }
}