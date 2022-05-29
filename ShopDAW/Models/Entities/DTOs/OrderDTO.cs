using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class OrderDTO
    {
        public int id { get; set; }
        public int value { get; set; }
        public int clientId { get; set; }
        public string payType { get; set; } //cash sau card
        public string date { get; set; }
        public Client Client { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }
        public OrderDTO(Order order)
        {
            this.id = order.id;
            this.value = order.value;
            this.clientId = order.clientId;
            this.payType = order.payType;
            this.date = order.date;
            this.Client = order.Client;
            this.orderProducts = new List<OrderProduct>();

        }
    }
}
