using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PostProperties = Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostProperties;
using PostVariants = Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties.PostVariants;

namespace Imagekit.Models.Files.FileUploadParamsProperties.TransformationProperties;

[JsonConverter(typeof(PostConverter))]
public abstract record class Post
{
    internal Post() { }

    public static implicit operator Post(PostProperties::Transformation value) =>
        new PostVariants::Transformation(value);

    public static implicit operator Post(PostProperties::GifToVideo value) =>
        new PostVariants::GifToVideo(value);

    public static implicit operator Post(PostProperties::Thumbnail value) =>
        new PostVariants::Thumbnail(value);

    public static implicit operator Post(PostProperties::Abs value) => new PostVariants::Abs(value);

    public bool TryPickTransformation([NotNullWhen(true)] out PostProperties::Transformation? value)
    {
        value = (this as PostVariants::Transformation)?.Value;
        return value != null;
    }

    public bool TryPickGifToVideo([NotNullWhen(true)] out PostProperties::GifToVideo? value)
    {
        value = (this as PostVariants::GifToVideo)?.Value;
        return value != null;
    }

    public bool TryPickThumbnail([NotNullWhen(true)] out PostProperties::Thumbnail? value)
    {
        value = (this as PostVariants::Thumbnail)?.Value;
        return value != null;
    }

    public bool TryPickAbs([NotNullWhen(true)] out PostProperties::Abs? value)
    {
        value = (this as PostVariants::Abs)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PostVariants::Transformation> transformation,
        Action<PostVariants::GifToVideo> gifToVideo,
        Action<PostVariants::Thumbnail> thumbnail,
        Action<PostVariants::Abs> abs
    )
    {
        switch (this)
        {
            case PostVariants::Transformation inner:
                transformation(inner);
                break;
            case PostVariants::GifToVideo inner:
                gifToVideo(inner);
                break;
            case PostVariants::Thumbnail inner:
                thumbnail(inner);
                break;
            case PostVariants::Abs inner:
                abs(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PostVariants::Transformation, T> transformation,
        Func<PostVariants::GifToVideo, T> gifToVideo,
        Func<PostVariants::Thumbnail, T> thumbnail,
        Func<PostVariants::Abs, T> abs
    )
    {
        return this switch
        {
            PostVariants::Transformation inner => transformation(inner),
            PostVariants::GifToVideo inner => gifToVideo(inner),
            PostVariants::Thumbnail inner => thumbnail(inner),
            PostVariants::Abs inner => abs(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class PostConverter : JsonConverter<Post>
{
    public override Post? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "transformation":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PostProperties::Transformation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PostVariants::Transformation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "gif-to-video":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PostProperties::GifToVideo>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PostVariants::GifToVideo(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "thumbnail":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PostProperties::Thumbnail>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PostVariants::Thumbnail(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "abs":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<PostProperties::Abs>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new PostVariants::Abs(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Post value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PostVariants::Transformation(var transformation) => transformation,
            PostVariants::GifToVideo(var gifToVideo) => gifToVideo,
            PostVariants::Thumbnail(var thumbnail) => thumbnail,
            PostVariants::Abs(var abs) => abs,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
