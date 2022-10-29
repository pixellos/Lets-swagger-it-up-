using System.DirectoryServices;
using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace openapi_clients.Controllers;

internal class PolymorphicExampleSchemaFilter : ISchemaFilter
{
    internal const string ExamplesSchema = "x-examples";
    internal const string DefaultExamplesSchema = "Default";
    internal const string Path = $"/{ExamplesSchema}/{DefaultExamplesSchema}";

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var result = new OpenApiObject();
        var currentTypeDescriptor = context.Type.GetCustomAttributes<SwaggerSubTypeAttribute>().SingleOrDefault(x => x.SubType == context.Type);
        var discriminator = context.Type.GetCustomAttribute<SwaggerDiscriminatorAttribute>(inherit: true);
        if (currentTypeDescriptor is not null && discriminator is not null)
        {
            var discriminatorValue = new OpenApiString(currentTypeDescriptor.DiscriminatorValue);
            schema.Properties.Add(discriminator.PropertyName, new OpenApiSchema
            {
                Type = "string",
                Nullable = false,
                Example = discriminatorValue
            });
            var value = new OpenApiObject()
            {
                [discriminator.PropertyName] = discriminatorValue
            };
            foreach (var item in schema.Properties)
            {
                var example = item.Value.Example;
                if (example is not null)
                {
                    value[item.Key] = item.Value.Example;
                }
            }
            schema.Example = value;
            schema.Extensions[ExamplesSchema] = new OpenApiObject()
            {
                [DefaultExamplesSchema] = new OpenApiObject()
                {
                    [nameof(value)] = value
                }
            };
        }
    }
}
