using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByName(string name);
    }
}
