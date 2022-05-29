using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class ClientDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public List<Order> orders { get; set; }
        public ClientDTO(Client client)
        {
            this.id = client.id;
            this.name = client.name;
            this.phone = client.phone;
            this.email = client.email;
            this.address = client.address;
            this.orders = new List<Order>();

        }
    }
}
