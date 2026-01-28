using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties;

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(typeof(AudioCodecConverter))]
public enum AudioCodec
{
    Aac,
    Opus,
}

sealed class AudioCodecConverter : JsonConverter<AudioCodec>
{
    public override AudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" => AudioCodec.Aac,
            "opus" => AudioCodec.Opus,
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
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
