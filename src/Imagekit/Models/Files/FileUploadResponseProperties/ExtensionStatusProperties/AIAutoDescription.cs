using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadResponseProperties.ExtensionStatusProperties;

[JsonConverter(typeof(AIAutoDescriptionConverter))]
public enum AIAutoDescription
{
    Success,
    Pending,
    Failed,
}

sealed class AIAutoDescriptionConverter : JsonConverter<AIAutoDescription>
{
    public override AIAutoDescription Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AIAutoDescription.Success,
            "pending" => AIAutoDescription.Pending,
            "failed" => AIAutoDescription.Failed,
            _ => (AIAutoDescription)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIAutoDescription.Success => "success",
                AIAutoDescription.Pending => "pending",
                AIAutoDescription.Failed => "failed",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
