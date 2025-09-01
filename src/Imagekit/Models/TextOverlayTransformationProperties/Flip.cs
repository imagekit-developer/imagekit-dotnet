using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TextOverlayTransformationProperties;

/// <summary>
/// Flip the text overlay horizontally, vertically, or both.
/// </summary>
[JsonConverter(typeof(FlipConverter))]
public enum Flip
{
    H,
    V,
    HV,
    VH,
}

sealed class FlipConverter : JsonConverter<Flip>
{
    public override Flip Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h" => Flip.H,
            "v" => Flip.V,
            "h_v" => Flip.HV,
            "v_h" => Flip.VH,
            _ => (Flip)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Flip value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Flip.H => "h",
                Flip.V => "v",
                Flip.HV => "h_v",
                Flip.VH => "v_h",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
