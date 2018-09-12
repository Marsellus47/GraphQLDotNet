using GraphQL.Types;

namespace GraphQLDotNet.Types
{
    public class ItemInputType : InputObjectGraphType
    {
        public ItemInputType()
        {
            Name = "ItemInput";
            Field<NonNullGraphType<StringGraphType>>("barcode");
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<DecimalGraphType>>("sellingPrice");
        }
    }
}
