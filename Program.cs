using openapi_clients.Controllers;
using System.IO;
using System.Reflection;
using System.Xml.XPath;
using NJsonSchema.Converters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.CustomOperationIds(x => x.RelativePath);
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "openapi-clients.xml");
    options.IncludeXmlComments(() =>
    {
        var result = new XPathDocument(filePath);
        options.SchemaFilter<RecordXmlCommentSchemaFilter>(result);
        return result;
    }, true);
    options.EnableAnnotations(
        enableAnnotationsForInheritance: true,
        enableAnnotationsForPolymorphism: true
    );

    options.SchemaFilter<PolymorphicExampleSchemaFilter>();
    options.RequestBodyFilter<ExampleReferenceRequestBodyFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.ShowCommonExtensions();
        x.ShowExtensions();
        x.DisplayOperationId();
        x.DisplayRequestDuration();
        x.EnableDeepLinking();
        x.EnableFilter();

        x.IndexStream = () =>
                    typeof(WeatherForecastController)
                    .GetTypeInfo()
                    .Assembly
                    .GetManifestResourceStream("openapi_clients.index-swagger.html");
    });
    app.UseReDoc(x => x.IndexStream = () =>
            typeof(WeatherForecastController)
            .GetTypeInfo()
            .Assembly
            .GetManifestResourceStream("openapi_clients.index.html"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();