using GraphQLDotNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public partial class DataStore : IDataStore
    {
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _applicationDbContext.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _applicationDbContext.Customers.FindAsync(customerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var addedCustomer = await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
            return addedCustomer.Entity;
        }
    }
}
