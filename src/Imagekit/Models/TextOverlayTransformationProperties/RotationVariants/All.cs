namespace Imagekit.Models.TextOverlayTransformationProperties.RotationVariants;

public sealed record class Double(double Value) : Rotation, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : Rotation, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
