using GraphQL.Types;

namespace GraphQLDotNet
{
    public class HelloWorldQuery : ObjectGraphType
    {
        public HelloWorldQuery()
        {
            Field<StringGraphType>(
                name: "Hello",
                resolve: context => "World");

            Field<StringGraphType>(
                name: "Howdy",
                resolve: context => "Universe");
        }
    }
}
