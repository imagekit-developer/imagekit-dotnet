using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Beta.V2.Files.FileUploadResponseProperties.ExtensionStatusProperties;

[JsonConverter(typeof(AwsAutoTaggingConverter))]
public enum AwsAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class AwsAutoTaggingConverter : JsonConverter<AwsAutoTagging>
{
    public override AwsAutoTagging Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AwsAutoTagging.Success,
            "pending" => AwsAutoTagging.Pending,
            "failed" => AwsAutoTagging.Failed,
            _ => (AwsAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AwsAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AwsAutoTagging.Success => "success",
                AwsAutoTagging.Pending => "pending",
                AwsAutoTagging.Failed => "failed",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
