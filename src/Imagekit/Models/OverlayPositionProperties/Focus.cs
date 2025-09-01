using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.OverlayPositionProperties;

/// <summary>
/// Specifies the position of the overlay relative to the parent image or video.
/// Maps to `lfo` in the URL.
/// </summary>
[JsonConverter(typeof(FocusConverter))]
public enum Focus
{
    Center,
    Top,
    Left,
    Bottom,
    Right,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight,
}

sealed class FocusConverter : JsonConverter<Focus>
{
    public override Focus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "center" => Focus.Center,
            "top" => Focus.Top,
            "left" => Focus.Left,
            "bottom" => Focus.Bottom,
            "right" => Focus.Right,
            "top_left" => Focus.TopLeft,
            "top_right" => Focus.TopRight,
            "bottom_left" => Focus.BottomLeft,
            "bottom_right" => Focus.BottomRight,
            _ => (Focus)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Focus value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Focus.Center => "center",
                Focus.Top => "top",
                Focus.Left => "left",
                Focus.Bottom => "bottom",
                Focus.Right => "right",
                Focus.TopLeft => "top_left",
                Focus.TopRight => "top_right",
                Focus.BottomLeft => "bottom_left",
                Focus.BottomRight => "bottom_right",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
