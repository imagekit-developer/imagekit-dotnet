using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models;

/// <summary>
/// By default, the transformation string is added as a query parameter in the URL,
/// e.g., `?tr=w-100,h-100`.  If you want to add the transformation string in the
/// path of the URL, set this to `path`. Learn more in the [Transformations guide](https://imagekit.io/docs/transformations).
/// </summary>
[JsonConverter(typeof(TransformationPositionConverter))]
public enum TransformationPosition
{
    Path,
    Query,
}

sealed class TransformationPositionConverter : JsonConverter<TransformationPosition>
{
    public override TransformationPosition Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "path" => TransformationPosition.Path,
            "query" => TransformationPosition.Query,
            _ => (TransformationPosition)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationPosition value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransformationPosition.Path => "path",
                TransformationPosition.Query => "query",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
