using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;
using GraphQLDotNet.Types;
using System.Collections.Generic;

namespace GraphQLDotNet
{
    public class InventoryQuery : ObjectGraphType
    {
        public InventoryQuery(IDataStore dataStore)
        {
            Field<ItemType>(
                "item",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "barcode" }),
                resolve: context =>
                {
                    var barcode = context.GetArgument<string>("barcode");
                    return dataStore.GetItemByBarcode(barcode);
                });

            Field<ListGraphType<ItemType>>(
                "items",
                resolve: context => dataStore.GetItems());

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
