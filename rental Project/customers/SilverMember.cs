﻿namespace rental_Project.customers
{
    internal class SilverMember : IMember
    {
        public SilverMember()
        {
            DiscountRate = 20;
            MemberString = "Silver";
        }

        public int DiscountRate { get; }
        public string MemberString { get; }
    }
}