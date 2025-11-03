using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PostProperties = Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.TransformationProperties.PostProperties;

namespace Imagekit.Models.Beta.V2.Files.FileUploadParamsProperties.TransformationProperties;

[JsonConverter(typeof(PostConverter))]
public record class Post
{
    public object Value { get; private init; }

    public string? Value1
    {
        get
        {
            return Match<string?>(
                transformation: (x) => x.Value,
                gifToVideo: (x) => x.Value,
                thumbnail: (x) => x.Value,
                abs: (x) => x.Value
            );
        }
    }

    public Post(PostProperties::Transformation value)
    {
        Value = value;
    }

    public Post(PostProperties::GifToVideo value)
    {
        Value = value;
    }

    public Post(PostProperties::Thumbnail value)
    {
        Value = value;
    }

    public Post(PostProperties::Abs value)
    {
        Value = value;
    }

    Post(UnknownVariant value)
    {
        Value = value;
    }

    public static Post CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTransformation([NotNullWhen(true)] out PostProperties::Transformation? value)
    {
        value = this.Value as PostProperties::Transformation;
        return value != null;
    }

    public bool TryPickGifToVideo([NotNullWhen(true)] out PostProperties::GifToVideo? value)
    {
        value = this.Value as PostProperties::GifToVideo;
        return value != null;
    }

    public bool TryPickThumbnail([NotNullWhen(true)] out PostProperties::Thumbnail? value)
    {
        value = this.Value as PostProperties::Thumbnail;
        return value != null;
    }

    public bool TryPickAbs([NotNullWhen(true)] out PostProperties::Abs? value)
    {
        value = this.Value as PostProperties::Abs;
        return value != null;
    }

    public void Switch(
        Action<PostProperties::Transformation> transformation,
        Action<PostProperties::GifToVideo> gifToVideo,
        Action<PostProperties::Thumbnail> thumbnail,
        Action<PostProperties::Abs> abs
    )
    {
        switch (this.Value)
        {
            case PostProperties::Transformation value:
                transformation(value);
                break;
            case PostProperties::GifToVideo value:
                gifToVideo(value);
                break;
            case PostProperties::Thumbnail value:
                thumbnail(value);
                break;
            case PostProperties::Abs value:
                abs(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PostProperties::Transformation, T> transformation,
        Func<PostProperties::GifToVideo, T> gifToVideo,
        Func<PostProperties::Thumbnail, T> thumbnail,
        Func<PostProperties::Abs, T> abs
    )
    {
        return this.Value switch
        {
            PostVariants::Transformation inner => transformation(inner),
            PostVariants::GifToVideo inner => gifToVideo(inner),
            PostVariants::Thumbnail inner => thumbnail(inner),
            PostVariants::Abs inner => abs(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Post");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                        deserialized.Validate();
                        return new Post(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Post(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Post(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Post(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
