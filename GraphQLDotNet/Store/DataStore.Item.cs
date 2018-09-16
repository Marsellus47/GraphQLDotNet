using GraphQLDotNet.Data;
using GraphQLDotNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet.Store
{
    public partial class DataStore : IDataStore
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DataStore(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Item> GetItemByBarcodeAsync(string barcode)
        {
            return await _applicationDbContext.Items.FindAsync(barcode);
        }

        public Item GetItemByBarcode(string barcode)
        {
            return _applicationDbContext.Items.FirstOrDefault(i => i.Barcode.Equals(barcode));
        }

        public IEnumerable<Item> GetItems()
        {
            return _applicationDbContext.Items;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            var addedItem = await _applicationDbContext.Items.AddAsync(item);
            await _applicationDbContext.SaveChangesAsync();
            return addedItem.Entity;
        }
    }
}
