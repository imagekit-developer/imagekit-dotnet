using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Enables a grayscale effect for images. See [Grayscale](https://imagekit.io/docs/effects-and-enhancements#grayscale---e-grayscale).
/// </summary>
[JsonConverter(typeof(GrayscaleConverter))]
public enum Grayscale
{
    True,
}

sealed class GrayscaleConverter : JsonConverter<Grayscale>
{
    public override Grayscale Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => Grayscale.True,
            _ => (Grayscale)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Grayscale value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Grayscale.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
