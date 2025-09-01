using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties;

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
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
            "video-transformation" => TransformationProperties.Type.VideoTransformation,
            "gif-to-video" => TransformationProperties.Type.GifToVideo,
            "video-thumbnail" => TransformationProperties.Type.VideoThumbnail,
            _ => (Type)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Type value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransformationProperties.Type.VideoTransformation => "video-transformation",
                TransformationProperties.Type.GifToVideo => "gif-to-video",
                TransformationProperties.Type.VideoThumbnail => "video-thumbnail",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
