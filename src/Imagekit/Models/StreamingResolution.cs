using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models;

/// <summary>
/// Available streaming resolutions for [adaptive bitrate streaming](https://imagekit.io/docs/adaptive-bitrate-streaming)
/// </summary>
[JsonConverter(typeof(StreamingResolutionConverter))]
public enum StreamingResolution
{
    v240,
    v360,
    v480,
    v720,
    v1080,
    v1440,
    v2160,
}

sealed class StreamingResolutionConverter : JsonConverter<StreamingResolution>
{
    public override StreamingResolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "240" => StreamingResolution.v240,
            "360" => StreamingResolution.v360,
            "480" => StreamingResolution.v480,
            "720" => StreamingResolution.v720,
            "1080" => StreamingResolution.v1080,
            "1440" => StreamingResolution.v1440,
            "2160" => StreamingResolution.v2160,
            _ => (StreamingResolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamingResolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamingResolution.v240 => "240",
                StreamingResolution.v360 => "360",
                StreamingResolution.v480 => "480",
                StreamingResolution.v720 => "720",
                StreamingResolution.v1080 => "1080",
                StreamingResolution.v1440 => "1440",
                StreamingResolution.v2160 => "2160",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
