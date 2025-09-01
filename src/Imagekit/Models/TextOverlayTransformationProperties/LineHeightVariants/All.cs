namespace Imagekit.Models.TextOverlayTransformationProperties.LineHeightVariants;

public sealed record class Double(double Value) : LineHeight, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : LineHeight, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
