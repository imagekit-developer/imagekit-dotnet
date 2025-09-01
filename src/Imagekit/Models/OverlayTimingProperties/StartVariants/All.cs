namespace Imagekit.Models.OverlayTimingProperties.StartVariants;

public sealed record class Double(double Value) : Start, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : Start, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
