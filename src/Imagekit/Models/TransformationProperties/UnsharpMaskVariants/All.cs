using System.Text.Json;

namespace Imagekit.Models.TransformationProperties.UnsharpMaskVariants;

public sealed record class True(JsonElement Value) : UnsharpMask, IVariant<True, JsonElement>
{
    public static True From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : UnsharpMask, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
