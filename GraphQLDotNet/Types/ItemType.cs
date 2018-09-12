using GraphQL.Types;
using GraphQLDotNet.Models;

namespace GraphQLDotNet.Types
{
    public class ItemType: ObjectGraphType<Item>
    {
        public ItemType()
        {
            Field(i => i.Barcode);
            Field(i => i.Title);
            Field(i => i.SellingPrice);
        }
    }
}
