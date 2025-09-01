using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the audio codec, e.g., `aac`, `opus`, or `none`. See [Audio codec](https://imagekit.io/docs/video-optimization#audio-codec---ac).
/// </summary>
[JsonConverter(typeof(AudioCodecConverter))]
public enum AudioCodec
{
    Aac,
    Opus,
    None,
}

sealed class AudioCodecConverter : JsonConverter<AudioCodec>
{
    public override AudioCodec Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" => AudioCodec.Aac,
            "opus" => AudioCodec.Opus,
            "none" => AudioCodec.None,
            _ => (AudioCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudioCodec.Aac => "aac",
                AudioCodec.Opus => "opus",
                AudioCodec.None => "none",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
