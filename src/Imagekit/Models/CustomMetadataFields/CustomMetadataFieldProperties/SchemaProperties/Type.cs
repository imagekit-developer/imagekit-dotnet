using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties;

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
            "Text" => SchemaProperties.Type.Text,
            "Textarea" => SchemaProperties.Type.Textarea,
            "Number" => SchemaProperties.Type.Number,
            "Date" => SchemaProperties.Type.Date,
            "Boolean" => SchemaProperties.Type.Boolean,
            "SingleSelect" => SchemaProperties.Type.SingleSelect,
            "MultiSelect" => SchemaProperties.Type.MultiSelect,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SchemaProperties.Type.Text => "Text",
                SchemaProperties.Type.Textarea => "Textarea",
                SchemaProperties.Type.Number => "Number",
                SchemaProperties.Type.Date => "Date",
                SchemaProperties.Type.Boolean => "Boolean",
                SchemaProperties.Type.SingleSelect => "SingleSelect",
                SchemaProperties.Type.MultiSelect => "MultiSelect",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
