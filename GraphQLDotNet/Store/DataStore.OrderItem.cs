using GraphQLDotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public partial class DataStore : IDataStore
    {
        public async Task<IEnumerable<OrderItem>> GetOrderItemsAsync()
        {
            return await _applicationDbContext.OrderItems.AsNoTracking().ToListAsync();
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            var addedOrderItem = await _applicationDbContext.OrderItems.AddAsync(orderItem);
            await _applicationDbContext.SaveChangesAsync();
            return addedOrderItem.Entity;
        }
    }
}
