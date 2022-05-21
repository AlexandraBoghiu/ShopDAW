using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities.DTOs
{
    public class CreateOrderDTO
    {
        public int value { get; set; }
        public int userId { get; set; }
        public string payType { get; set; } //cash sau card
        public string date { get; set; }
    }
}
