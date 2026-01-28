namespace Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent6Variants;

public sealed record class String(string Value)
    : UnnamedSchemaWithArrayParent6,
        IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value)
    : UnnamedSchemaWithArrayParent6,
        IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : UnnamedSchemaWithArrayParent6, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}
