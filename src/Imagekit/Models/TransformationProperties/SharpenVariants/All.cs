using System.Text.Json;

namespace Imagekit.Models.TransformationProperties.SharpenVariants;

public sealed record class True(JsonElement Value) : Sharpen, IVariant<True, JsonElement>
{
    public static True From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : Sharpen, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}
