using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.AddressRepository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ShopContext context) : base(context) { }
        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Addresses.Where(a => a.id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
