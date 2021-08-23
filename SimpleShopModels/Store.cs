using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Store
    {
        public int StoreId { get; set; }

        public string StoreName { get; set; }


        // Constructor, takes name and price
        public Store(string name) 
        {
            StoreName = name;
        }

        // Constructor, takes: id
        public Store(int id)
        {
            StoreId = id;
        }
    }
}
