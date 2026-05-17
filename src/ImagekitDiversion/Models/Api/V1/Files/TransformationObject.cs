using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using System = System;

namespace ImagekitDiversion.Models.Api.V1.Files;

/// <summary>
/// Configure pre-processing (`pre`) and post-processing (`post`) transformations.
///
/// <para>- `pre` — applied before the file is uploaded to the Media Library.
/// Useful for reducing file size or applying basic optimizations upfront (e.g.,
/// resize, compress).</para>
///
/// <para>- `post` — applied immediately after upload.     Ideal for generating transformed
/// versions (like video encodes or thumbnails) in advance, so they're ready for delivery
/// without delay.</para>
///
/// <para>You can mix and match any combination of post-processing types.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TransformationObject, TransformationObjectFromRaw>))]
public sealed record class TransformationObject : JsonModel
{
    /// <summary>
    /// List of transformations to apply *after* the file is uploaded.   Each item
    /// must match one of the following types: `transformation`, `gif-to-video`, `thumbnail`, `abs`.
    /// </summary>
    public IReadOnlyList<Post>? Post
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Post>>("post");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Post>?>(
                "post",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Transformation string to apply before uploading the file to the Media Library.
    /// Useful for optimizing files at ingestion.
    /// </summary>
    public string? Pre
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pre");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pre", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Post ?? [])
        {
            item.Validate();
        }
        _ = this.Pre;
    }

    public TransformationObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransformationObject(TransformationObject transformationObject)
        : base(transformationObject) { }
#pragma warning restore CS8618

    public TransformationObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TransformationObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformationObjectFromRaw.FromRawUnchecked"/>
    public static TransformationObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransformationObjectFromRaw : IFromRawJson<TransformationObject>
{
    /// <inheritdoc/>
    public TransformationObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TransformationObject.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(PostConverter))]
public record class Post : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                transformation: (x) => x.Type,
                gifToVideo: (x) => x.Type,
                thumbnail: (x) => x.Type,
                abs: (x) => x.Type
            );
        }
    }

    public string? ValueValue
    {
        get
        {
            return Match<string?>(
                transformation: (x) => x.ValueValue,
                gifToVideo: (x) => x.Value,
                thumbnail: (x) => x.Value,
                abs: (x) => x.Value
            );
        }
    }

    public Post(Transformation value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(GifToVideo value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(Thumbnail value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(Abs value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Post(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Transformation"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTransformation(out var value)) {
    ///     // `value` is of type `Transformation`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTransformation([NotNullWhen(true)] out Transformation? value)
    {
        value = this.Value as Transformation;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="GifToVideo"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGifToVideo(out var value)) {
    ///     // `value` is of type `GifToVideo`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGifToVideo([NotNullWhen(true)] out GifToVideo? value)
    {
        value = this.Value as GifToVideo;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Thumbnail"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThumbnail(out var value)) {
    ///     // `value` is of type `Thumbnail`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThumbnail([NotNullWhen(true)] out Thumbnail? value)
    {
        value = this.Value as Thumbnail;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Abs"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAbs(out var value)) {
    ///     // `value` is of type `Abs`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAbs([NotNullWhen(true)] out Abs? value)
    {
        value = this.Value as Abs;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (Transformation value) =&gt; {...},
    ///     (GifToVideo value) =&gt; {...},
    ///     (Thumbnail value) =&gt; {...},
    ///     (Abs value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<Transformation> transformation,
        System::Action<GifToVideo> gifToVideo,
        System::Action<Thumbnail> thumbnail,
        System::Action<Abs> abs
    )
    {
        switch (this.Value)
        {
            case Transformation value:
                transformation(value);
                break;
            case GifToVideo value:
                gifToVideo(value);
                break;
            case Thumbnail value:
                thumbnail(value);
                break;
            case Abs value:
                abs(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of Post"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (Transformation value) =&gt; {...},
    ///     (GifToVideo value) =&gt; {...},
    ///     (Thumbnail value) =&gt; {...},
    ///     (Abs value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<Transformation, T> transformation,
        System::Func<GifToVideo, T> gifToVideo,
        System::Func<Thumbnail, T> thumbnail,
        System::Func<Abs, T> abs
    )
    {
        return this.Value switch
        {
            Transformation value => transformation(value),
            GifToVideo value => gifToVideo(value),
            Thumbnail value => thumbnail(value),
            Abs value => abs(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Post"
            ),
        };
    }

    public static implicit operator Post(Transformation value) => new(value);

    public static implicit operator Post(GifToVideo value) => new(value);

    public static implicit operator Post(Thumbnail value) => new(value);

    public static implicit operator Post(Abs value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Post"
            );
        }
        this.Switch(
            (transformation) => transformation.Validate(),
            (gifToVideo) => gifToVideo.Validate(),
            (thumbnail) => thumbnail.Validate(),
            (abs) => abs.Validate()
        );
    }

    public virtual bool Equals(Post? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            Transformation _ => 0,
            GifToVideo _ => 1,
            Thumbnail _ => 2,
            Abs _ => 3,
            _ => -1,
        };
    }
}

sealed class PostConverter : JsonConverter<Post>
{
    public override Post? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "transformation":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Transformation>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "gif-to-video":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<GifToVideo>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thumbnail":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Thumbnail>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "abs":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Abs>(element, options);
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Post(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Post value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Transformation, TransformationFromRaw>))]
public sealed record class Transformation : JsonModel
{
    /// <summary>
    /// Transformation type.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Transformation string (e.g. `w-200,h-200`).   Same syntax as ImageKit URL-based transformations.
    /// </summary>
    public required string ValueValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("transformation")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValueValue;
    }

    public Transformation()
    {
        this.Type = JsonSerializer.SerializeToElement("transformation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transformation(Transformation transformation)
        : base(transformation) { }
#pragma warning restore CS8618

    public Transformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transformation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformationFromRaw.FromRawUnchecked"/>
    public static Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Transformation(string valueValue)
        : this()
    {
        this.ValueValue = valueValue;
    }
}

class TransformationFromRaw : IFromRawJson<Transformation>
{
    /// <inheritdoc/>
    public Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transformation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GifToVideo, GifToVideoFromRaw>))]
public sealed record class GifToVideo : JsonModel
{
    /// <summary>
    /// Converts an animated GIF into an MP4.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional transformation string to apply to the output video.   **Example**: `q-80`
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("gif-to-video")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public GifToVideo()
    {
        this.Type = JsonSerializer.SerializeToElement("gif-to-video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GifToVideo(GifToVideo gifToVideo)
        : base(gifToVideo) { }
#pragma warning restore CS8618

    public GifToVideo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gif-to-video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GifToVideo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GifToVideoFromRaw.FromRawUnchecked"/>
    public static GifToVideo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GifToVideoFromRaw : IFromRawJson<GifToVideo>
{
    /// <inheritdoc/>
    public GifToVideo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GifToVideo.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Thumbnail, ThumbnailFromRaw>))]
public sealed record class Thumbnail : JsonModel
{
    /// <summary>
    /// Generates a thumbnail image.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Optional transformation string.   **Example**: `w-150,h-150`
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("thumbnail")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public Thumbnail()
    {
        this.Type = JsonSerializer.SerializeToElement("thumbnail");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Thumbnail(Thumbnail thumbnail)
        : base(thumbnail) { }
#pragma warning restore CS8618

    public Thumbnail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("thumbnail");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThumbnailFromRaw.FromRawUnchecked"/>
    public static Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThumbnailFromRaw : IFromRawJson<Thumbnail>
{
    /// <inheritdoc/>
    public Thumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Thumbnail.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Abs, AbsFromRaw>))]
public sealed record class Abs : JsonModel
{
    /// <summary>
    /// Streaming protocol to use (`hls` or `dash`).
    /// </summary>
    public required ApiEnum<string, Protocol> Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Protocol>>("protocol");
        }
        init { this._rawData.Set("protocol", value); }
    }

    /// <summary>
    /// Adaptive Bitrate Streaming (ABS) setup.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// List of different representations you want to create separated by an underscore.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Protocol.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("abs")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public Abs()
    {
        this.Type = JsonSerializer.SerializeToElement("abs");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Abs(Abs abs)
        : base(abs) { }
#pragma warning restore CS8618

    public Abs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("abs");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Abs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AbsFromRaw.FromRawUnchecked"/>
    public static Abs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AbsFromRaw : IFromRawJson<Abs>
{
    /// <inheritdoc/>
    public Abs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Abs.FromRawUnchecked(rawData);
}

/// <summary>
/// Streaming protocol to use (`hls` or `dash`).
/// </summary>
[JsonConverter(typeof(ProtocolConverter))]
public enum Protocol
{
    Hls,
    Dash,
}

sealed class ProtocolConverter : JsonConverter<Protocol>
{
    public override Protocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" => Protocol.Hls,
            "dash" => Protocol.Dash,
            _ => (Protocol)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Protocol value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Protocol.Hls => "hls",
                Protocol.Dash => "dash",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
