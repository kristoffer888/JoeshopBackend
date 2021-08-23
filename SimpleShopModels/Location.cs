using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Location
    {
        public int LocationId { get; set; }

        public string LocationCity { get; set; }

        public int LocationZipCode  { get; set; }

        // Constructor, takes name and price
        public Location(string City, int ZipCode) 
        {
            LocationCity = City;
            LocationZipCode = ZipCode;
        }

        // Constructor, takes: id
        public Location(int id)
        {
            LocationId = id;
        }
    }
}
