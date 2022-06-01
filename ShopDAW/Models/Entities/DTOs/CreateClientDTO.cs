using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class CreateClientDTO
    {
        public string name { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
    }
}
