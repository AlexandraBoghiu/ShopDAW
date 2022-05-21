using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.OrderRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context) { }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.Where(o => o.id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<Order> GetByPayType(string payType)
        {
            return await _context.Orders.Where(c => c.payType.Equals(payType)).FirstOrDefaultAsync();
        }
    }
}
