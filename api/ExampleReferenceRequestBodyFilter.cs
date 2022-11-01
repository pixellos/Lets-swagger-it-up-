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
        var modelType = model?.ModelType;
        if (model is null || modelType is null)
            return;
        var subTypes = modelType.GetCustomAttributes<SwaggerSubTypeAttribute>();
        var discriminator = modelType.GetCustomAttribute<SwaggerDiscriminatorAttribute>();
        if (discriminator is null || subTypes is null)
            return;

        foreach (var (_, c) in requestBody.Content)
        {
            // Either use proper `animal` schema
            //c.Schema = new OpenApiSchema
            //{
            //    Reference = new OpenApiReference
            //    {
            //        Type = ReferenceType.Schema,
            //        Id = modelType.Name
            //    }
            //};
            c.Schema.Discriminator = new OpenApiDiscriminator()
            {
                PropertyName = discriminator.PropertyName,
                Mapping = subTypes.ToDictionary(
               x => x.SubType.Name,
               x => new OpenApiReference()
               {
                   Type = ReferenceType.Schema,
                   Id = x.SubType.Name
               }.ReferenceV3)
            };
            var references = c.Schema.OneOf.Select(x => x.Reference.ReferenceV3);
            c.Examples = subTypes.ToDictionary(
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
