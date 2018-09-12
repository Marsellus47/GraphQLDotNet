using Newtonsoft.Json.Linq;

namespace GraphQLDotNet.Middleware
{
    public class GraphQLRequest
    {
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
