using System.Collections.Generic;
using Imagekit.Models.Files.FileUploadParamsProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueVariants;

public sealed record class String(string Value) : DefaultValue, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Double(double Value) : DefaultValue, IVariant<Double, double>
{
    public static Double From(double value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Bool(bool Value) : DefaultValue, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}

/// <summary>
/// Default value should be of type array when custom metadata field type is set to
/// `MultiSelect`.
/// </summary>
public sealed record class Mixed(List<UnnamedSchemaWithArrayParent5> Value)
    : DefaultValue,
        IVariant<Mixed, List<UnnamedSchemaWithArrayParent5>>
{
    public static Mixed From(List<UnnamedSchemaWithArrayParent5> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
