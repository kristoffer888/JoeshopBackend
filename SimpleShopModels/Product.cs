using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice  { get; set; }

        // Constructor, takes name and price
        public Product(string name, decimal price) 
        {
            ProductName = name;
            ProductPrice = price;
        }

        // Constructor, takes: id, name, price
        public Product(int id, string name, decimal price)
        {
            ProductId = id;
            ProductName = name;
            ProductPrice = price;
        }
    }
}
