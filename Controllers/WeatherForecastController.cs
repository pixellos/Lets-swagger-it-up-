using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;

namespace openapi_clients.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController()
    {
    }

    [HttpGet]
    public IResult Get() => Ok();

    private IResult Ok(
        object? o = default, 
        [CallerArgumentExpression("o")] string? name = default) 
        => Results.Ok($"({o?.GetType()}) {name}: {o}");
}


public record KnownType(string SomeString);