namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent0Variants;

public sealed record class String(string Value)
    : UnnamedSchemaWithArrayParent0,
        IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value)
    : UnnamedSchemaWithArrayParent0,
        IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : UnnamedSchemaWithArrayParent0, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
