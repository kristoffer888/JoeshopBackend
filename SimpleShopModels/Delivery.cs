using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }

        // Constructor, takes name
        public Delivery(DateTime date, string status)
        {
            DeliveryDate = date;
            DeliveryStatus = status;
        }

        // Constructor overload, takes id, name
        public Delivery(int id)
        {
            DeliveryId = id;
        }

    }
}
