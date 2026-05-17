using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models;

/// <summary>
/// Available streaming resolutions for [adaptive bitrate streaming](https://imagekit.io/docs/adaptive-bitrate-streaming)
/// </summary>
[JsonConverter(typeof(StreamingResolutionConverter))]
public enum StreamingResolution
{
    V240,
    V360,
    V480,
    V720,
    V1080,
    V1440,
    V2160,
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
            "240" => StreamingResolution.V240,
            "360" => StreamingResolution.V360,
            "480" => StreamingResolution.V480,
            "720" => StreamingResolution.V720,
            "1080" => StreamingResolution.V1080,
            "1440" => StreamingResolution.V1440,
            "2160" => StreamingResolution.V2160,
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
                StreamingResolution.V240 => "240",
                StreamingResolution.V360 => "360",
                StreamingResolution.V480 => "480",
                StreamingResolution.V720 => "720",
                StreamingResolution.V1080 => "1080",
                StreamingResolution.V1440 => "1440",
                StreamingResolution.V2160 => "2160",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
