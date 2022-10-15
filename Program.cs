using openapi_clients.Controllers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Important !!!

builder.Services.AddSwaggerGen(c => 
{
    c.UseOneOfForPolymorphism();
    c.UseAllOfForInheritance();
    c.UseAllOfToExtendReferenceSchemas();
    c.EnableAnnotations(
        enableAnnotationsForInheritance: true,
        enableAnnotationsForPolymorphism: true
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseReDoc(x => {
        x.IndexStream = () => 
            typeof(WeatherForecastController)
            .GetTypeInfo()
            .Assembly
            .GetManifestResourceStream("openapi_clients.index.html");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
