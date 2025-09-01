using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationErrorEventProperties.DataProperties.TransformationProperties.OptionsProperties;

/// <summary>
/// Streaming protocol for adaptive bitrate streaming.
/// </summary>
[JsonConverter(typeof(StreamProtocolConverter))]
public enum StreamProtocol
{
    Hls,
    Dash,
}

sealed class StreamProtocolConverter : JsonConverter<StreamProtocol>
{
    public override StreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" => StreamProtocol.Hls,
            "DASH" => StreamProtocol.Dash,
            _ => (StreamProtocol)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamProtocol.Hls => "HLS",
                StreamProtocol.Dash => "DASH",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
