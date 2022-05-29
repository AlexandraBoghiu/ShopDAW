using ShopDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class Order
    {
        public int id { get; set; }
        public int value { get; set; }
        public int clientId { get; set; }
        public string payType { get; set; } //cash sau card
        public string date { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }

    }
}