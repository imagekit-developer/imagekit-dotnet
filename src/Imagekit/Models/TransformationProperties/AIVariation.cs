using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Generates a variation of an image using AI. This produces a new image with slight
/// variations from the original,  such as changes in color, texture, and other visual
/// elements, while preserving the structure and essence of the original image. Not
/// supported inside overlay. See [AI Generate Variations](https://imagekit.io/docs/ai-transformations#generate-variations-of-an-image-e-genvar).
/// </summary>
[JsonConverter(typeof(AIVariationConverter))]
public enum AIVariation
{
    True,
}

sealed class AIVariationConverter : JsonConverter<AIVariation>
{
    public override AIVariation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIVariation.True,
            _ => (AIVariation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIVariation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIVariation.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
