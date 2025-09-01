using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationAcceptedEventProperties.DataProperties.TransformationProperties.OptionsProperties;

/// <summary>
/// Output format for the transformed video or thumbnail.
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    MP4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" => Format.MP4,
            "webm" => Format.Webm,
            "jpg" => Format.Jpg,
            "png" => Format.Png,
            "webp" => Format.Webp,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.MP4 => "mp4",
                Format.Webm => "webm",
                Format.Jpg => "jpg",
                Format.Png => "png",
                Format.Webp => "webp",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
