using GraphQL;
using GraphQL.Types;

namespace GraphQLDotNet
{
    public class InventorySchema : Schema
    {
        public InventorySchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<InventoryQuery>();
            Mutation = resolver.Resolve<InventoryMutation>();
        }
    }
}
