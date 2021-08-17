using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Product
    {
        public int ProductId { get; private set; }

        public string ProductName { get; set; }

        public decimal ProductPrice  { get; set; }

        // Constructor, takes name and price
        [JsonConstructor]
        public Product(string productname, decimal productprice)
        {
            ProductName = productname;
            ProductPrice = productprice;
        }

        // Constructor, takes: id, name, price
        public Product(int id, string name, decimal price)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
        }

        public void SetId(int id)
        {
            ProductId = id;
        }
    }
}
