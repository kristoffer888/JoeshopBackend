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
        public Location(int locationid, int ZipCode) 
        {
            LocationId = locationid;
            LocationZipCode = ZipCode;
        }

    }
}
