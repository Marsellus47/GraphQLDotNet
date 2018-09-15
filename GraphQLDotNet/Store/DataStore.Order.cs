using GraphQLDotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public partial class DataStore : IDataStore
    {
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _applicationDbContext.Orders.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _applicationDbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var addedOrder = await _applicationDbContext.Orders.AddAsync(order);
            await _applicationDbContext.SaveChangesAsync();
            return addedOrder.Entity;
        }
    }
}
