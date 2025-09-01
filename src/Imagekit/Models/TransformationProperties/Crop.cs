using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Crop modes for image resizing. See [Crop modes & focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
/// </summary>
[JsonConverter(typeof(CropConverter))]
public enum Crop
{
    Force,
    AtMax,
    AtMaxEnlarge,
    AtLeast,
    MaintainRatio,
}

sealed class CropConverter : JsonConverter<Crop>
{
    public override Crop Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "force" => Crop.Force,
            "at_max" => Crop.AtMax,
            "at_max_enlarge" => Crop.AtMaxEnlarge,
            "at_least" => Crop.AtLeast,
            "maintain_ratio" => Crop.MaintainRatio,
            _ => (Crop)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Crop value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Crop.Force => "force",
                Crop.AtMax => "at_max",
                Crop.AtMaxEnlarge => "at_max_enlarge",
                Crop.AtLeast => "at_least",
                Crop.MaintainRatio => "maintain_ratio",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
