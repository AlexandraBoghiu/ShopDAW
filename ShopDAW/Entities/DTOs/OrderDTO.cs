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
        public int userId { get; set; }
        public string payType { get; set; } //cash sau card
        public string date { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct> orderProducts { get; set; }
        public OrderDTO(Order order)
        {
            this.id = order.id;
            this.value = order.value;
            this.userId = order.userId;
            this.payType = order.payType;
            this.date = order.date;
            this.User = order.User;
            this.orderProducts = new List<OrderProduct>();

        }
    }
}
