using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment_OOP_05
{
    public class DeliveryAddress
    {
        public string City { get; set; }
        public string Country { get; set; }

        public DeliveryAddress(string city, string country)
        {
            City = city;
            Country = country;
        }
    }
}
