using System;
using System.Collections.Generic;

namespace SimpleShopModels
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public List<Order> Orders { get; set; }

        // Constructor, takes name
        public Customer(string name)    
        {
            CustomerName = name;
        }

        // Constructor overload, takes id, name
        public Customer(int id, string name)
        {
            CustomerId = id;
            CustomerName = name;
        }
    }
}
