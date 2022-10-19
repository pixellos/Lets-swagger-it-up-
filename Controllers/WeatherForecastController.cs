using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using Microsoft.OpenApi.Any;

namespace openapi_clients.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet]
    public IResult Get() => Ok<object>();

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
        => Results.Ok($"({o?.GetType()}) {name}: {o}");
}


public record KnownType(string SomeString);

// Interfaces
[SwaggerDiscriminator("type")]
[SwaggerSubType(typeof(Dog), DiscriminatorValue = Dog.TypeConst)]
[SwaggerSubType(typeof(Cat), DiscriminatorValue = Cat.TypeConst)]
[SwaggerSubType(typeof(Wolf), DiscriminatorValue = Wolf.TypeConst)]
public abstract record Animal
{
    internal const string Namespace = "openapi_clients.Controllers";
}

public record Cat(string Meow) : Animal
{
    /// <summary>
    /// The name of the product
    /// </summary>
    /// <example>openapi_clients.Controllers.Cat</example>
    public string Type => TypeConst; 
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Cat)}"; 
}

/// <example>{type: &quot;openapi_clients.Controllers.Dog&quot;, bark: &quot;&quot;}</example>
public record Dog(string Bark) : Animal
{
    /// <summary>
    /// The name of the product
    /// </summary>
    /// <example>openapi_clients.Controllers.Dog</example>
    public string Type => TypeConst; 
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Dog)}"; 
}

public record Wolf(string Woof) : Animal
{
    /// <summary>
    /// The name of the product
    /// </summary>
    /// <example>openapi_clients.Controllers.Wolf</example>
    public string Type => TypeConst; 
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Wolf)}"; 
}
