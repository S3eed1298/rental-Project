namespace rental_Project.customers
{
    internal interface IMember
    {
        public int DiscountRate { get; }
        public string MemberString { get; }
    }
}