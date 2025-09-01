namespace Imagekit.Models.TransformationProperties.StartOffsetVariants;

public sealed record class Double(double Value) : StartOffset, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : StartOffset, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
