using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema.Converters;
using Swashbuckle.AspNetCore.Annotations;

namespace openapi_clients.Controllers;

public record KnownType(string SomeString);

public record KnownTypeWithRce(string SomeString, object someValueThatCanBeIntegerOrString);

[SwaggerDiscriminator("discriminator")]
[SwaggerSubType(typeof(Dog), DiscriminatorValue = nameof(Dog))]
[SwaggerSubType(typeof(Cat), DiscriminatorValue = nameof(Cat))]
[SwaggerSubType(typeof(Wolf), DiscriminatorValue = nameof(Wolf))]

[KnownType(typeof(Dog))]
[KnownType(typeof(Cat))]
[KnownType(typeof(Wolf))]
[JsonConverter(typeof(JsonInheritanceConverter), "discriminator")]
public abstract record Animal;

/// <param name="Meow" example="Meow! Meow!">Some meow description</param>
public record Cat(string Meow) : Animal;

/// <param name="Bark" example="Bark! Bark!">Some bark desc</param>
public record Dog(string Bark) : Animal;

/// <param name="Woof" example="Woof! Woof!">Some woof desc</param>
public record Wolf(string Woof) : Animal;
