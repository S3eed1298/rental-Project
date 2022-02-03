using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental_Project.customers
{
    class IndividualCustomer<T> : Customer
    {
        private T ID;
        private int numberOfDays;
        public IndividualCustomer(T ID , int numberOfDays , string theCarModel , int CarModelYear , int basePrice  )
        {
            this.ID = ID;
            this.numberOfDays = numberOfDays;
            carModel = theCarModel

        }
    }
}
