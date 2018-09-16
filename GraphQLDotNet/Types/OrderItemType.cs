using GraphQL.Types;
using GraphQLDotNet.Models;
using GraphQLDotNet.Store;

namespace GraphQLDotNet.Types
{
    public class OrderItemType : ObjectGraphType<OrderItem>
    {
        public OrderItemType(IDataStore dataStore)
        {
            Field(i => i.Barcode);

            Field<ItemType, Item>()
                .Name("Item")
                .ResolveAsync(ctx => dataStore.GetItemByBarcodeAsync(ctx.Source.Barcode));

            Field(i => i.Quantity);

            Field(i => i.OrderId);

            Field<OrderType, Order>()
                .Name("Order")
                .ResolveAsync(ctx => dataStore.GetOrderByIdAsync(ctx.Source.OrderId));
        }
    }
}
