using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Automatically enhances the contrast of an image (contrast stretch). See [Contrast
/// Stretch](https://imagekit.io/docs/effects-and-enhancements#contrast-stretch---e-contrast).
/// </summary>
[JsonConverter(typeof(ContrastStretchConverter))]
public enum ContrastStretch
{
    True,
}

sealed class ContrastStretchConverter : JsonConverter<ContrastStretch>
{
    public override ContrastStretch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => ContrastStretch.True,
            _ => (ContrastStretch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContrastStretch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContrastStretch.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
