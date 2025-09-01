using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TextOverlayTransformationProperties;

/// <summary>
/// Specifies the inner alignment of the text when width is more than the text length.
/// </summary>
[JsonConverter(typeof(InnerAlignmentConverter))]
public enum InnerAlignment
{
    Left,
    Right,
    Center,
}

sealed class InnerAlignmentConverter : JsonConverter<InnerAlignment>
{
    public override InnerAlignment Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "left" => InnerAlignment.Left,
            "right" => InnerAlignment.Right,
            "center" => InnerAlignment.Center,
            _ => (InnerAlignment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InnerAlignment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                InnerAlignment.Left => "left",
                InnerAlignment.Right => "right",
                InnerAlignment.Center => "center",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
