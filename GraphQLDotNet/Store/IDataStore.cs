using GraphQLDotNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public interface IDataStore
    {
        // Item
        IEnumerable<Item> GetItems();
        Task<IEnumerable<Item>> GetItemsAsync();
        Item GetItemByBarcode(string barcode);
        Task<Item> GetItemByBarcodeAsync(string barcode);
        Task<Item> AddItemAsync(Item item);

        // Order
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<ILookup<int, Order>> GetOrdersByCustomerIdAsync(IEnumerable<int> customerIds);

        // Customer
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<IDictionary<int, Customer>> GetCustomersByIdAsync(IEnumerable<int> customerIds, CancellationToken token);

        // OrderItem
        Task<IEnumerable<OrderItem>> GetOrderItemsAsync();
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
    }
}
