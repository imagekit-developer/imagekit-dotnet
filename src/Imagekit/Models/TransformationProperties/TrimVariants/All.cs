using System.Text.Json;

namespace Imagekit.Models.TransformationProperties.TrimVariants;

public sealed record class True(JsonElement Value) : Trim, IVariant<True, JsonElement>
{
    public static True From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : Trim, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}
