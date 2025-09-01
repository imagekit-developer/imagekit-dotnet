using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties;

[JsonConverter(typeof(RemoveBgConverter))]
public enum RemoveBg
{
    Success,
    Pending,
    Failed,
}

sealed class RemoveBgConverter : JsonConverter<RemoveBg>
{
    public override RemoveBg Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => RemoveBg.Success,
            "pending" => RemoveBg.Pending,
            "failed" => RemoveBg.Failed,
            _ => (RemoveBg)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, RemoveBg value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RemoveBg.Success => "success",
                RemoveBg.Pending => "pending",
                RemoveBg.Failed => "failed",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
