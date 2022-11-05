using Swashbuckle.AspNetCore.Annotations;

namespace openapi_clients.Controllers;

public record KnownType(string SomeString);

public record KnownTypeWithRce(string SomeString, object someValueThatCanBeIntegerOrString);

[SwaggerDiscriminator("$type")]
[SwaggerSubType(typeof(Dog), DiscriminatorValue = Dog.TypeConst)]
[SwaggerSubType(typeof(Cat), DiscriminatorValue = Cat.TypeConst)]
[SwaggerSubType(typeof(Wolf), DiscriminatorValue = Wolf.TypeConst)]
public abstract record Animal
{
    internal const string Assembly = "openapi_clients.Controllers";
    internal const string Namespace = "openapi_clients.Controllers";
}

/// <param name="Meow" example="Meow, meow">Some desc</param>
public record Cat(string Meow) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Cat)}, openapi-clients";
}

public record Dog(string Bark) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Dog)}, openapi-clients";
}

public record Wolf(string Woof) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Wolf)}, openapi-clients";
}
