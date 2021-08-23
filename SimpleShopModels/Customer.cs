using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public List<Order> Orders { get; set; }


        // Constructor 
        public Customer(int id)
        {
            CustomerId = id;
        }

        // Constructor overload
        public Customer(string name, string address, string location, string email, string password)    
        {
            CustomerName = name;
            CustomerAddress = address;
            CustomerLocation = location;
            CustomerEmail = email;
            CustomerPassword = password;
        }
    }
}
