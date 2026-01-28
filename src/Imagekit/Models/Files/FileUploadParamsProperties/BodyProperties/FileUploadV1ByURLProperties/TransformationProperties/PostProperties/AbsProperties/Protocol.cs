using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties.FileUploadV1ByURLProperties.TransformationProperties.PostProperties.AbsProperties;

/// <summary>
/// Streaming protocol to use (`hls` or `dash`).
/// </summary>
[JsonConverter(typeof(ProtocolConverter))]
public enum Protocol
{
    Hls,
    Dash,
}

sealed class ProtocolConverter : JsonConverter<Protocol>
{
    public override Protocol Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" => Protocol.Hls,
            "dash" => Protocol.Dash,
            _ => (Protocol)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Protocol value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Protocol.Hls => "hls",
                Protocol.Dash => "dash",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
