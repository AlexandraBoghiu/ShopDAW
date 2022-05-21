using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.OrderRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetById(int id);
        Task<Order> GetByPayType(string payType);

    }
}
