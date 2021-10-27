using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }


        // Constructor, takes name
        [JsonConstructor]
        public Manufacturer(string manufacturerName) 
        {
            ManufacturerName = manufacturerName;
        }

        public Manufacturer(int manufacturerId, string manufacturerName)
        {
            ManufacturerId = manufacturerId;
            ManufacturerName = manufacturerName;
        }

        // Constructor, takes: id


        public void SetId(int manufacturerId)
        {
            ManufacturerId = manufacturerId;
        }
    }
}
