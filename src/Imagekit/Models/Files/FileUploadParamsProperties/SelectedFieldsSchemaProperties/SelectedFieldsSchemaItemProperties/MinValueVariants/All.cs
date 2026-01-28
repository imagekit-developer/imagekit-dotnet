namespace Imagekit.Models.Files.FileUploadParamsProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.MinValueVariants;

public sealed record class String(string Value) : MinValue, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : MinValue, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}
