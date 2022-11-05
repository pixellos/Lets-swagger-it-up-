using openapi_clients.Controllers;
using System.IO;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All;
        x.SerializerSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "openapi-clients.xml");
    options.IncludeXmlComments(filePath, true);
    options.EnableAnnotations(
        enableAnnotationsForInheritance: false,
        enableAnnotationsForPolymorphism: true
    );
    
    options.SchemaFilter<ExampleByConventionFilter>();
    options.RequestBodyFilter<ExampleReferenceRequestBodyFilter>();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.IndexStream = () => 
            typeof(WeatherForecastController)
            .GetTypeInfo()
            .Assembly
            .GetManifestResourceStream("openapi_clients.index-swagger.html"));
    app.UseReDoc(x => {
        x.IndexStream = () => 
            typeof(WeatherForecastController)
            .GetTypeInfo()
            .Assembly
            .GetManifestResourceStream("openapi_clients.index.html");
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();