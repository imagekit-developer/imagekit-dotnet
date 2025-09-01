using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Performs AI-based retouching to improve faces or product shots. Not supported
/// inside overlay. See [AI Retouch](https://imagekit.io/docs/ai-transformations#retouch-e-retouch).
/// </summary>
[JsonConverter(typeof(AIRetouchConverter))]
public enum AIRetouch
{
    True,
}

sealed class AIRetouchConverter : JsonConverter<AIRetouch>
{
    public override AIRetouch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRetouch.True,
            _ => (AIRetouch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRetouch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRetouch.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
