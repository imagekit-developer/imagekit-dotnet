namespace Imagekit.Models.TransformationProperties.YCenterVariants;

public sealed record class Double(double Value) : YCenter, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : YCenter, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
