namespace Imagekit.Models.Files.FileProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent4Variants;

public sealed record class String(string Value)
    : UnnamedSchemaWithArrayParent4,
        IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value)
    : UnnamedSchemaWithArrayParent4,
        IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : UnnamedSchemaWithArrayParent4, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
