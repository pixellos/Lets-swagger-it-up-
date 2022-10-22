using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace openapi_clients.Controllers;

internal class ExampleByConventionFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(Animal))
        {
            var result = new OpenApiObject();
            var subTypeAttributes = context.Type.GetCustomAttributes<SwaggerSubTypeAttribute>();
            var discriminator = context.Type.GetCustomAttribute<SwaggerDiscriminatorAttribute>();
            if (subTypeAttributes is not null && discriminator is not null)
            {
                foreach (var item in subTypeAttributes)
                {
                    if (context.SchemaRepository.TryLookupByType(item.SubType, out var sub))
                    {
                        result[sub.Reference.Id] = new OpenApiObject()
                        {
                            ["value"] = new OpenApiObject()
                            {
                                [discriminator.PropertyName] = new OpenApiString(item.DiscriminatorValue)
                            }
                        };

                    }
                }
            }

            schema.Extensions["examples"] = result;
        }
    }
}