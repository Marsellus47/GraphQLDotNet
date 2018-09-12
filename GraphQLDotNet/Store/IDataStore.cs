using GraphQLDotNet.Models;
using System.Collections.Generic;

namespace GraphQLDotNet.Store
{
    public interface IDataStore
    {
        IEnumerable<Item> GetItems();
        Item GetItemByBarcode(string barcode);
    }
}
