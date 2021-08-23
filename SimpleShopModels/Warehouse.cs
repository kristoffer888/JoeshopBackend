using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }

        public string WarehouseLocation { get; set; }


        // Constructor, takes name and price
        public Warehouse(string name) 
        {
            WarehouseLocation = name;
        }

        // Constructor, takes: id
        public Warehouse(int id)
        {
            WarehouseId = id;
        }
    }
}
