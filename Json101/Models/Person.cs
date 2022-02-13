using System.Collections.Generic;

namespace Json101.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAlive { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<object> Children { get; set; }
        public object Spouse { get; set; }
    }
}