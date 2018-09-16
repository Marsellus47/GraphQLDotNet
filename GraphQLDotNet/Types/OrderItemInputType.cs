using GraphQL.Types;

namespace GraphQLDotNet.Types
{
    public class OrderItemInputType: InputObjectGraphType
    {
        public OrderItemInputType()
        {
            Name = "OrderItemInput";
            Field<NonNullGraphType<IntGraphType>>("quantity");
            Field<NonNullGraphType<StringGraphType>>("barcode");
            Field<NonNullGraphType<IntGraphType>>("orderId");
        }
    }
}
