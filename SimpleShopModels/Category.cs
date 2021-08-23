using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }


        // Constructor, takes name and price
        public Category(string name) 
        {
            CategoryName = name;
        }

        // Constructor, takes: id
        public Category(int id)
        {
            CategoryId = id;
        }
    }
}
