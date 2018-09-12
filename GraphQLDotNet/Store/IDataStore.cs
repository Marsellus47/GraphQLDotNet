using GraphQLDotNet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public interface IDataStore
    {
        IEnumerable<Item> GetItems();
        Item GetItemByBarcode(string barcode);
        Task<Item> AddItemAsync(Item item);
    }
}
