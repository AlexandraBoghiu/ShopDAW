using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public List<OrderProduct> orderProducts { get; set; }
        public ProductDTO(Product product)
        {
            this.id = product.id;
            this.name = product.name;
            this.price = product.price;
            this.orderProducts = new List<OrderProduct>();
        }
    }
}
