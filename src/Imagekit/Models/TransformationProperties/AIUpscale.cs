using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Upscales images beyond their original dimensions using AI. Not supported inside
/// overlay. See [AI Upscale](https://imagekit.io/docs/ai-transformations#upscale-e-upscale).
/// </summary>
[JsonConverter(typeof(AIUpscaleConverter))]
public enum AIUpscale
{
    True,
}

sealed class AIUpscaleConverter : JsonConverter<AIUpscale>
{
    public override AIUpscale Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIUpscale.True,
            _ => (AIUpscale)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIUpscale value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIUpscale.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
