using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace openapi_clients.Controllers;

internal class ExampleReferenceRequestBodyFilter : IRequestBodyFilter
{
    public void Apply(OpenApiRequestBody requestBody, RequestBodyFilterContext context)
    {
        var model = context?.BodyParameterDescription?.ModelMetadata;
        if (model is null)
            return;

        foreach (var (_, c) in requestBody.Content)
        {
            var references = c.Schema.OneOf.Select(x => x.Reference.ReferenceV3);
            c.Examples = model.ModelType.GetCustomAttributes<SwaggerSubTypeAttribute>().ToDictionary(
                x => x.SubType.Name,
                x => new OpenApiExample()
                {
                    Reference = new OpenApiReference()
                    {
                        Type = ReferenceType.Schema,
                        Id = x.SubType.Name + PolymorphicExampleSchemaFilter.Path
                    }
                });
        }
    }
}
