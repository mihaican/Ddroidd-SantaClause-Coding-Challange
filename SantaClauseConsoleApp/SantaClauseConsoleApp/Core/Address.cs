using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaClauseConsoleApp.Core
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public Address(string city, string street, int number)
        {
            City = city;
            Street = street;
            Number = number;
        }

        public override string ToString()
        {
            return City + ", " + Street + " No " + Number;
        }
    }
}
