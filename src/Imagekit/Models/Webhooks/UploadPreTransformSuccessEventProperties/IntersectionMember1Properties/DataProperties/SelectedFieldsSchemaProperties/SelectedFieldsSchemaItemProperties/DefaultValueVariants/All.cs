using System.Collections.Generic;
using Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;

namespace Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueVariants;

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
public sealed record class Mixed(List<UnnamedSchemaWithArrayParent7> Value)
    : DefaultValue,
        IVariant<Mixed, List<UnnamedSchemaWithArrayParent7>>
{
    public static Mixed From(List<UnnamedSchemaWithArrayParent7> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
