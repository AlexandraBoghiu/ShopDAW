using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public class Address
    {
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public int clientId { get; set; }
        public Client Client { get; set; }
    }
}