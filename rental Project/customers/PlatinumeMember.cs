using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class PlatinumeMember : IMember
    {
        public int DiscountRate { get; }

        public PlatinumeMember()
        {
            DiscountRate = 30;
        }
    }
}
