using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ShopContext context) : base(context) { }
        public async Task<List<User>> GetAllUsersWithAddress()
        {
            return await _context.Users.Include(u => u.address).ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.Where(u => u.email.Equals(email)).FirstOrDefaultAsync();
        }
    }
}
