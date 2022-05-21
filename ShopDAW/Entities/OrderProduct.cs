using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities
{
    public class OrderProduct
    {
        public int productId { get; set; }
        public int orderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
