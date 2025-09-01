using System.Text.Json;

namespace Imagekit.Models.TextOverlayTransformationProperties.RadiusVariants;

public sealed record class Double(double Value) : Radius, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Max(JsonElement Value) : Radius, IVariant<Max, JsonElement>
{
    public static Max From(JsonElement value)
    {
        return new(value);
    }

    public override void Validate() { }
}
