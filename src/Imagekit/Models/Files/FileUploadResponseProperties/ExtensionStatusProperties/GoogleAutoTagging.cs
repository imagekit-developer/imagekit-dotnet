using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadResponseProperties.ExtensionStatusProperties;

[JsonConverter(typeof(GoogleAutoTaggingConverter))]
public enum GoogleAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class GoogleAutoTaggingConverter : JsonConverter<GoogleAutoTagging>
{
    public override GoogleAutoTagging Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => GoogleAutoTagging.Success,
            "pending" => GoogleAutoTagging.Pending,
            "failed" => GoogleAutoTagging.Failed,
            _ => (GoogleAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GoogleAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GoogleAutoTagging.Success => "success",
                GoogleAutoTagging.Pending => "pending",
                GoogleAutoTagging.Failed => "failed",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
