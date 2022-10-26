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
    internal const string Assembly = "openapi-clients";
    internal const string Namespace = "openapi_clients.Controllers";
}

/// <param name="Meow" example="Meow! Meow!">Some meow description</param>
public record Cat(string Meow) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Cat)}, {Animal.Assembly}";
}

/// <param name="Bark" example="Bark! Bark!">Some bark desc</param>
public record Dog(string Bark) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Dog)}, {Animal.Assembly}";
}

/// <param name="Woof" example="Woof! Woof!">Some woof desc</param>
public record Wolf(string Woof) : Animal
{
    public const string TypeConst = $"{Animal.Namespace}.{nameof(Wolf)}, {Animal.Assembly}";
}
