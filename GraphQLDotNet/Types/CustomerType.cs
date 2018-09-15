using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;
using System.Collections.Generic;

namespace GraphQLDotNet.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IDataStore dataStore)
        {
            Field(c => c.Name);
            Field(c => c.BillingAddress);
            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .ResolveAsync(ctx => dataStore.GetOrdersByCustomerIdAsync(ctx.Source.CustomerId));
        }
    }
}
