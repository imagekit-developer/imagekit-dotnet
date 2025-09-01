namespace Imagekit.Models.TextOverlayTransformationProperties.FontSizeVariants;

public sealed record class Double(double Value) : FontSize, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : FontSize, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
