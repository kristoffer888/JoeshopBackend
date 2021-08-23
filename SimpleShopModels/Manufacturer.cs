using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }


        // Constructor, takes name and price
        public Manufacturer(string name) 
        {
            ManufacturerName = name;
        }

        // Constructor, takes: id
        public Manufacturer(int id)
        {
            ManufacturerId = id;
        }
    }
}
