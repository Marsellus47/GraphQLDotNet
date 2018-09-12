using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDotNet
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
