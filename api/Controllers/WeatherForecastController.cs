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

    [HttpPost("post")]
    public IResult Post(KnownType payload) => Ok(payload);

    [HttpPost("Form")]
    public IResult PostForm([FromForm] KnownType payload) => Ok(payload);

    [HttpPost("Inheritance")]
    [ProducesResponseType(typeof(OkObjectResult<Animal>), 200)]
    [SwaggerOperation(
        Summary = "Inheritance sample",
        Description = "Some longer explaination",
        OperationId = "MyCustomOpId",
        Tags = new [] {"Inheritance", "Swagger"} )]
    public IResult PostInheritance(
        [SwaggerParameter(
            Description = "Body description",
            Required = true
        )]
        [FromBody] Animal payload) => Ok(payload);

    [HttpPost("HeaderComplexType")]
    public IResult PostHeader([FromHeader] KnownType payload) => Ok(payload);

    [HttpPost("HeaderComplexTypeRce")]
    public IResult PostHeader(KnownTypeWithRce payload) => Ok(payload);

    [HttpPost("HeaderString")]
    public IResult PostHeaderString([FromHeader] string payload) => Ok(payload);

    /// <param name="animal" example="{type: &quot;openapi_clients.Controllers.Dog&quot;, bark: &quot;&quot;}" />
    [HttpPatch("patch")]
    [ProducesResponseType(typeof(Animal), (int)HttpStatusCode.OK)]
    public IResult Patch(Animal animal) => Ok(animal);

    private IResult Ok<T>(
        T? value = default,
        [CallerArgumentExpression("value")] string? name = default)
        => Results.Ok(value);
}
