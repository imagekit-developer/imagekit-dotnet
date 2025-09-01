using System.Text.Json;

namespace Imagekit.Models.TransformationProperties.ShadowVariants;

public sealed record class True(JsonElement Value) : Shadow, IVariant<True, JsonElement>
{
    public static True From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : Shadow, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
