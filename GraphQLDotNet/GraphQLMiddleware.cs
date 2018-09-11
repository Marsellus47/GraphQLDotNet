using GraphQL.Http;
using GraphQL.Types;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System;

namespace GraphQLDotNet
{
    public class GraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDocumentWriter _writer;
        private readonly IDocumentExecuter _executor;
        private readonly ISchema _schema;

        public GraphQLMiddleware(
            RequestDelegate next,
            IDocumentWriter writer,
            IDocumentExecuter executor,
            ISchema schema)
        {
            _next = next;
            _writer = writer;
            _executor = executor;
            _schema = schema;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/api/graphql/")
                && string.Equals(httpContext.Request.Method, "POST", StringComparison.OrdinalIgnoreCase))
            {
                using (var streamReader = new StreamReader(httpContext.Request.Body))
                {
                    var body = await streamReader.ReadToEndAsync();

                    var request = JsonConvert.DeserializeObject<GraphQLRequest>(body);

                    var result = await _executor.ExecuteAsync(doc =>
                    {
                        doc.Schema = _schema;
                        doc.Query = request.Query;
                    }).ConfigureAwait(false);

                    var json = _writer.Write(result);
                    await httpContext.Response.WriteAsync(json);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
