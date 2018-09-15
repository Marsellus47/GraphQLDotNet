using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;

namespace GraphQLDotNet.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(IDataStore dataStore)
        {
            Field(o => o.Tag);
            Field(o => o.CreatedAt);
            Field<CustomerType, Customer>()
                .Name("Customer")
                .ResolveAsync(ctx => dataStore.GetCustomerByIdAsync(ctx.Source.CustomerId));
        }
    }
}
