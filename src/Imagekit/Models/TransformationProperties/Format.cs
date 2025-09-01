using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the output format for images or videos, e.g., `jpg`, `png`, `webp`,
/// `mp4`, or `auto`.  You can also pass `orig` for images to return the original
/// format. ImageKit automatically delivers images and videos in the optimal format
/// based on device support unless overridden by the dashboard settings or the format
/// parameter. See [Image format](https://imagekit.io/docs/image-optimization#format---f)
/// and [Video format](https://imagekit.io/docs/video-optimization#format---f).
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Auto,
    Webp,
    Jpg,
    Jpeg,
    Png,
    Gif,
    Svg,
    MP4,
    Webm,
    Avif,
    Orig,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Format.Auto,
            "webp" => Format.Webp,
            "jpg" => Format.Jpg,
            "jpeg" => Format.Jpeg,
            "png" => Format.Png,
            "gif" => Format.Gif,
            "svg" => Format.Svg,
            "mp4" => Format.MP4,
            "webm" => Format.Webm,
            "avif" => Format.Avif,
            "orig" => Format.Orig,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Auto => "auto",
                Format.Webp => "webp",
                Format.Jpg => "jpg",
                Format.Jpeg => "jpeg",
                Format.Png => "png",
                Format.Gif => "gif",
                Format.Svg => "svg",
                Format.MP4 => "mp4",
                Format.Webm => "webm",
                Format.Avif => "avif",
                Format.Orig => "orig",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
