using GraphQLDotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public interface IDataStore
    {
        // Item
        IEnumerable<Item> GetItems();
        Item GetItemByBarcode(string barcode);
        Task<Item> AddItemAsync(Item item);

        // Order
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Order> AddOrderAsync(Order order);

        // Customer
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> AddCustomerAsync(Customer customer);
    }
}
