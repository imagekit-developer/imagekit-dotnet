using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Files.FileProperties;

/// <summary>
/// Type of the asset.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    File,
    FileVersion,
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
            "file" => FileProperties.Type.File,
            "file-version" => FileProperties.Type.FileVersion,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileProperties.Type.File => "file",
                FileProperties.Type.FileVersion => "file-version",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
