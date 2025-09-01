using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.SubtitleOverlayTransformationProperties;

/// <summary>
/// Sets the typography style of the subtitle text. Supports values are `b` for bold,
/// `i` for italics, and `b_i` for bold with italics.
///
/// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
/// </summary>
[JsonConverter(typeof(TypographyConverter))]
public enum Typography
{
    B,
    I,
    BI,
}

sealed class TypographyConverter : JsonConverter<Typography>
{
    public override Typography Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "b" => Typography.B,
            "i" => Typography.I,
            "b_i" => Typography.BI,
            _ => (Typography)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Typography value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Typography.B => "b",
                Typography.I => "i",
                Typography.BI => "b_i",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
