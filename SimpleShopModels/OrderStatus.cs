using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShopModels
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        // Constructor takes: id, name
        public OrderStatus(int id, string name)
        {
            OrderStatusId = id;
            OrderStatusName = name;
        }
    }
}
