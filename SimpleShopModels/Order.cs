using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderAmount { get; set; }
        public decimal OrderPrice { get; set; }
        public List<Product> Products { get; set; }

        // Constructor, takes name
        public Order(int amount, decimal price)
        {
            OrderAmount = amount;
            OrderPrice = price;
        }

        // Constructor overload, takes id, name
        public Order(int id)
        {
            OrderId = id;
        }

    }
}
