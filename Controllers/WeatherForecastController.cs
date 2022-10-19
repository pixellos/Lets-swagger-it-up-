using System;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace openapi_clients.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet]
    public IResult Get() => Ok<object>(new Dog(""));

    [HttpPost]
    public IResult Post(KnownType payload) => Ok(payload);

    [HttpPost("Form")]
    public IResult PostForm([FromForm] KnownType payload) => Ok(payload);

    [HttpPost("Inheritance")]
    public IResult PostInheritance([FromBody] Animal payload) => Ok(payload);

    [HttpPost("HeaderComplexType")]
    public IResult PostHeader([FromHeader] KnownType payload) => Ok(payload);

    [HttpPost("HeaderString")]
    public IResult PostHeaderString([FromHeader] string payload) => Ok(payload);

    /// <param name="animal" example="{type: &quot;openapi_clients.Controllers.Dog&quot;, bark: &quot;&quot;}" />
    [HttpPatch()]
    [ProducesResponseType(typeof(Animal), (int)HttpStatusCode.OK)]
    public IResult Patch(Animal animal) => Ok(animal);

    private IResult Ok<T>(
        T? o = default,
        [CallerArgumentExpression("o")] string? name = default)
        => Results.Ok(new { name, o, type = o?.GetType() });
}


public record KnownType(string SomeString);

// Interfaces
[SwaggerDiscriminator("$type")]
[SwaggerSubType(typeof(Dog), DiscriminatorValue = Dog.TypeConst)]
[SwaggerSubType(typeof(Cat), DiscriminatorValue = Cat.TypeConst)]
[SwaggerSubType(typeof(Wolf), DiscriminatorValue = Wolf.TypeConst)]
public abstract record Animal
{
    internal const string Assembly = "openapi_clients.Controllers";
    internal const string Namespace = "openapi_clients.Controllers";
}

public record Cat(string Meow) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Cat)}, openapi-clients";
}

/// <example>{type: &quot;openapi_clients.Controllers.Dog&quot;, bark: &quot;&quot;}</example>
public record Dog(string Bark) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Dog)}, openapi-clients";
}

public record Wolf(string Woof) : Animal
{

    public const string TypeConst = $"{Animal.Namespace}.{nameof(Wolf)}, openapi-clients";
}
