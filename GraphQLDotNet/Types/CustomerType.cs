using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;
using System.Collections.Generic;

namespace GraphQLDotNet.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IDataStore dataStore, IDataLoaderContextAccessor accessor)
        {
            Field(c => c.Name);
            Field(c => c.BillingAddress);
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .ResolveAsync(ctx =>
                {
                    var ordersLoader = accessor.Context.GetOrAddCollectionBatchLoader<int, Order>("GetOrdersByCustomerId", dataStore.GetOrdersByCustomerIdAsync);
                    return ordersLoader.LoadAsync(ctx.Source.CustomerId);
                });
        }
    }
}
