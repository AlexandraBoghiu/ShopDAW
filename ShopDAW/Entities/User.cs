using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}