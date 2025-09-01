namespace Imagekit.Models.TransformationProperties.XCenterVariants;

public sealed record class Double(double Value) : XCenter, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class String(string Value) : XCenter, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}
