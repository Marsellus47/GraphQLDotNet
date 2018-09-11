using GraphQL.Types;

namespace GraphQLDotNet
{
    public class HelloWorldSchema : Schema
    {
        public HelloWorldSchema(HelloWorldQuery query)
        {
            Query = query;
        }
    }
}
