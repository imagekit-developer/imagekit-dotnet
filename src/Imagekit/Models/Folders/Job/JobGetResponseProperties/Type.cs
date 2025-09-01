using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Folders.Job.JobGetResponseProperties;

/// <summary>
/// Type of the bulk job.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    CopyFolder,
    MoveFolder,
    RenameFolder,
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
            "COPY_FOLDER" => JobGetResponseProperties.Type.CopyFolder,
            "MOVE_FOLDER" => JobGetResponseProperties.Type.MoveFolder,
            "RENAME_FOLDER" => JobGetResponseProperties.Type.RenameFolder,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JobGetResponseProperties.Type.CopyFolder => "COPY_FOLDER",
                JobGetResponseProperties.Type.MoveFolder => "MOVE_FOLDER",
                JobGetResponseProperties.Type.RenameFolder => "RENAME_FOLDER",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
