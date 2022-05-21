using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public List<Order> orders { get; set; }
        public UserDTO(User user)
        {
            this.id = user.id;
            this.name = user.name;
            this.phone = user.phone;
            this.email = user.email;
            this.address = user.address;
            this.orders = new List<Order>();

        }
    }
}
