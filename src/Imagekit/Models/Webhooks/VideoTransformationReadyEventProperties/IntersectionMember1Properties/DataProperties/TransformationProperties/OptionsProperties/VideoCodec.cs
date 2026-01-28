using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties;

/// <summary>
/// Video codec used for encoding (h264, vp9, or av1).
/// </summary>
[JsonConverter(typeof(VideoCodecConverter))]
public enum VideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoCodecConverter : JsonConverter<VideoCodec>
{
    public override VideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" => VideoCodec.H264,
            "vp9" => VideoCodec.Vp9,
            "av1" => VideoCodec.Av1,
            _ => (VideoCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoCodec.H264 => "h264",
                VideoCodec.Vp9 => "vp9",
                VideoCodec.Av1 => "av1",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
