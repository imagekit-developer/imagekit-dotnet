using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Uses third-party background removal.  Note: It is recommended to use aiRemoveBackground,
/// ImageKit's in-house solution, which is more cost-effective. Supported inside overlay.
/// See [External Background Removal](https://imagekit.io/docs/ai-transformations#background-removal-e-removedotbg).
/// </summary>
[JsonConverter(typeof(AIRemoveBackgroundExternalConverter))]
public enum AIRemoveBackgroundExternal
{
    True,
}

sealed class AIRemoveBackgroundExternalConverter : JsonConverter<AIRemoveBackgroundExternal>
{
    public override AIRemoveBackgroundExternal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRemoveBackgroundExternal.True,
            _ => (AIRemoveBackgroundExternal)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRemoveBackgroundExternal value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRemoveBackgroundExternal.True => true,
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
