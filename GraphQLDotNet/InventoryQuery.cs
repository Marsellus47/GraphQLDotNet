using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;
using GraphQLDotNet.Types;
using System.Collections.Generic;

namespace GraphQLDotNet
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(IDataStore dataStore, IDataLoaderContextAccessor accessor)
        {
            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "barcode" }),
                resolve: context =>
                {
                    var barcode = context.GetArgument<string>("barcode");
                    return dataStore.GetItemByBarcode(barcode);
                });

            Field<ListGraphType<ItemType>, IEnumerable<Item>>()
                .Name("Items")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddLoader("GetAllItems", () => dataStore.GetItemsAsync());
                    return loader.LoadAsync();
                });

            Field<ListGraphType<OrderType>, IEnumerable<Order>>()
                .Name("Orders")
                .ResolveAsync(ctx => dataStore.GetOrdersAsync());

            Field<ListGraphType<CustomerType>, IEnumerable<Customer>>()
                .Name("Customers")
                .ResolveAsync(ctx => dataStore.GetCustomersAsync());

            Field<ListGraphType<OrderItemType>, IEnumerable<OrderItem>>()
                .Name("OrderItems")
                .ResolveAsync(ctx => dataStore.GetOrderItemsAsync());
        }
    }
}
