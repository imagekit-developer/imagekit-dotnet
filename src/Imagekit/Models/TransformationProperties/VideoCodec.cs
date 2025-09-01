using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the video codec, e.g., `h264`, `vp9`, `av1`, or `none`. See [Video codec](https://imagekit.io/docs/video-optimization#video-codec---vc).
/// </summary>
[JsonConverter(typeof(VideoCodecConverter))]
public enum VideoCodec
{
    H264,
    Vp9,
    Av1,
    None,
}

sealed class VideoCodecConverter : JsonConverter<VideoCodec>
{
    public override VideoCodec Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" => VideoCodec.H264,
            "vp9" => VideoCodec.Vp9,
            "av1" => VideoCodec.Av1,
            "none" => VideoCodec.None,
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
                VideoCodec.None => "none",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
