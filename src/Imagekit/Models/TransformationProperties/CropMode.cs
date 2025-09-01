using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Additional crop modes for image resizing. See [Crop modes & focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
/// </summary>
[JsonConverter(typeof(CropModeConverter))]
public enum CropMode
{
    PadResize,
    Extract,
    PadExtract,
}

sealed class CropModeConverter : JsonConverter<CropMode>
{
    public override CropMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pad_resize" => CropMode.PadResize,
            "extract" => CropMode.Extract,
            "pad_extract" => CropMode.PadExtract,
            _ => (CropMode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, CropMode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CropMode.PadResize => "pad_resize",
                CropMode.Extract => "extract",
                CropMode.PadExtract => "pad_extract",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
