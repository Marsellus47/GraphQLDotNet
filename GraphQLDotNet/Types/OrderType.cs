using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;

namespace GraphQLDotNet.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IDataStore dataStore, IDataLoaderContextAccessor accessor)
        {
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .ResolveAsync(ctx =>
                {
                    var customersLoader = accessor.Context.GetOrAddBatchLoader<int, Customer>("GetCustomersById", dataStore.GetCustomersByIdAsync);
                    return customersLoader.LoadAsync(ctx.Source.CustomerId);
                });
        }
    }
}
