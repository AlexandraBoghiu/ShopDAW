using Shop.Entities;
using ShopDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Repositories.AddressRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Address> GetAddressById(int id);
    }
}
