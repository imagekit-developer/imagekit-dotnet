using Imagekit.Core;

namespace Imagekit.Models.Files.FileProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.MaxValueVariants;

public sealed record class String(string Value) : MaxValue, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : MaxValue, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}
