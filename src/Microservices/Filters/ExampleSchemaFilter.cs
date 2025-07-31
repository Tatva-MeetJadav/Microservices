using Microservices.Models;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microservices.Filters
{
    /// <inheritdoc/>
    public class ExampleSchemaFilter : ISchemaFilter
    {
        /// <inheritdoc/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(EmailVerificationRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["email"] = new OpenApiString("user2@example.com")
                };
            }
            else if (context.Type == typeof(ProxyAndVpnDetectionRequest))
            {
                schema.Example = new OpenApiObject
                {
                    ["ipAddress"] = new OpenApiString("8.8.8.8")
                };
            }
         
        }
    }
}