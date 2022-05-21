using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context) { }
        public async Task<Product> GetByName(string name)
        {
            return await _context.Products.Where(c => c.name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
