namespace Imagekit.Models.TransformationProperties.YVariants;

public sealed record class Double(double Value) : Y, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : Y, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
