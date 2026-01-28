using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.ErrorProperties;

/// <summary>
/// Specific reason for the transformation failure: - `encoding_failed`: Error during
/// video encoding process - `download_failed`: Could not download source video -
/// `internal_server_error`: Unexpected server error
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    EncodingFailed,
    DownloadFailed,
    InternalServerError,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "encoding_failed" => Reason.EncodingFailed,
            "download_failed" => Reason.DownloadFailed,
            "internal_server_error" => Reason.InternalServerError,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.EncodingFailed => "encoding_failed",
                Reason.DownloadFailed => "download_failed",
                Reason.InternalServerError => "internal_server_error",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
