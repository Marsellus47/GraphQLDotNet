using GraphQL.Types;

namespace GraphQLDotNet
{
    public class InventorySchema : Schema
    {
        public InventorySchema(InventoryQuery query, InventoryMutation mutation)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
