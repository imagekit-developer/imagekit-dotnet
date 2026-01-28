using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties;

/// <summary>
/// Type of the custom metadata field.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Text,
    Textarea,
    Number,
    Date,
    Boolean,
    SingleSelect,
    MultiSelect,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Text" => SelectedFieldsSchemaItemProperties.Type.Text,
            "Textarea" => SelectedFieldsSchemaItemProperties.Type.Textarea,
            "Number" => SelectedFieldsSchemaItemProperties.Type.Number,
            "Date" => SelectedFieldsSchemaItemProperties.Type.Date,
            "Boolean" => SelectedFieldsSchemaItemProperties.Type.Boolean,
            "SingleSelect" => SelectedFieldsSchemaItemProperties.Type.SingleSelect,
            "MultiSelect" => SelectedFieldsSchemaItemProperties.Type.MultiSelect,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SelectedFieldsSchemaItemProperties.Type.Text => "Text",
                SelectedFieldsSchemaItemProperties.Type.Textarea => "Textarea",
                SelectedFieldsSchemaItemProperties.Type.Number => "Number",
                SelectedFieldsSchemaItemProperties.Type.Date => "Date",
                SelectedFieldsSchemaItemProperties.Type.Boolean => "Boolean",
                SelectedFieldsSchemaItemProperties.Type.SingleSelect => "SingleSelect",
                SelectedFieldsSchemaItemProperties.Type.MultiSelect => "MultiSelect",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
