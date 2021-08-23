using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Variant
    {
        public int VariantId { get; set; }
        public string VariantName { get; set; }
        public decimal VariantPrice { get; set; }


        // Constructor, takes name and price
        public Variant(string name, decimal price) 
        {
            VariantName = name;
            VariantPrice = price;
        }

        // Constructor, takes: id
        public Variant(int id)
        {
            VariantId = id;
        }
    }
}
