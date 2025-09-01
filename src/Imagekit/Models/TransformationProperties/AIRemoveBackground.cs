using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Applies ImageKit's in-house background removal.  Supported inside overlay. See
/// [AI Background Removal](https://imagekit.io/docs/ai-transformations#imagekit-background-removal-e-bgremove).
/// </summary>
[JsonConverter(typeof(AIRemoveBackgroundConverter))]
public enum AIRemoveBackground
{
    True,
}

sealed class AIRemoveBackgroundConverter : JsonConverter<AIRemoveBackground>
{
    public override AIRemoveBackground Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRemoveBackground.True,
            _ => (AIRemoveBackground)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRemoveBackground value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRemoveBackground.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
