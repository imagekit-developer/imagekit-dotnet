using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.UploadPostTransformSuccessEventProperties.RequestProperties.TransformationProperties;

/// <summary>
/// Type of the requested post-transformation.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Transformation,
    Abs,
    GifToVideo,
    Thumbnail,
}

sealed class TypeConverter : JsonConverter<Type>
{
    public override Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transformation" => TransformationProperties.Type.Transformation,
            "abs" => TransformationProperties.Type.Abs,
            "gif-to-video" => TransformationProperties.Type.GifToVideo,
            "thumbnail" => TransformationProperties.Type.Thumbnail,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransformationProperties.Type.Transformation => "transformation",
                TransformationProperties.Type.Abs => "abs",
                TransformationProperties.Type.GifToVideo => "gif-to-video",
                TransformationProperties.Type.Thumbnail => "thumbnail",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
