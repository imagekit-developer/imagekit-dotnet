namespace Imagekit.Models.TextOverlayTransformationProperties.WidthVariants;

public sealed record class Double(double Value) : Width, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : Width, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
