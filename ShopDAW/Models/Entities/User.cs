using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
