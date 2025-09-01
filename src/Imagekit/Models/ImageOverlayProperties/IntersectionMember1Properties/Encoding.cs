using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.ImageOverlayProperties.IntersectionMember1Properties;

/// <summary>
/// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
///  By default, the SDK determines the appropriate format automatically.  To always
/// use base64 encoding (`ie-{base64}`), set this parameter to `base64`.  To always
/// use plain text (`i-{input}`), set it to `plain`.
/// </summary>
[JsonConverter(typeof(EncodingConverter))]
public enum Encoding
{
    Auto,
    Plain,
    Base64,
}

sealed class EncodingConverter : JsonConverter<Encoding>
{
    public override Encoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Encoding.Auto,
            "plain" => Encoding.Plain,
            "base64" => Encoding.Base64,
            _ => (Encoding)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Encoding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Encoding.Auto => "auto",
                Encoding.Plain => "plain",
                Encoding.Base64 => "base64",
                _ => throw new ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
