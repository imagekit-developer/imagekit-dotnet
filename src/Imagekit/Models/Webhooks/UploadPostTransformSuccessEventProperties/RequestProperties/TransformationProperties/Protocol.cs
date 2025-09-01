using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties.TransformationProperties;

/// <summary>
/// Only applicable if transformation type is 'abs'. Streaming protocol used.
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
        System::Type typeToConvert,
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
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
