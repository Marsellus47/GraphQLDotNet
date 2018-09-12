using GraphQLDotNet.Data;
using GraphQLDotNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQLDotNet.Store
{
    public class DataStore : IDataStore
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DataStore(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Item GetItemByBarcode(string barcode)
        {
            return _applicationDbContext.Items.FirstOrDefault(i => i.Barcode.Equals(barcode));
        }

        public IEnumerable<Item> GetItems()
        {
            return _applicationDbContext.Items;
        }
    }
}
