using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.ClientRepository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context) { }
        public async Task<List<Client>> GetAllClientsWithAddress()
        {
            return await _context.Clients.Include(u => u.address).ToListAsync();
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await _context.Clients.Where(u => u.email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}
