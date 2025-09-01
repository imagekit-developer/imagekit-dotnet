namespace Imagekit.Models.TransformationProperties.EndOffsetVariants;

public sealed record class Double(double Value) : EndOffset, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : EndOffset, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
