using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Dummy;

/// <summary>
/// Specifies an overlay to be applied on the parent image or video.  ImageKit supports
/// overlays including images, text, videos, subtitles, and solid colors. See [Overlay
/// using layers](https://imagekit.io/docs/transformations#overlay-using-layers).
/// </summary>
[JsonConverter(typeof(OverlayConverter))]
public record class Overlay : ModelBase
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

    public ApiEnum<string, LayerMode>? LayerMode
    {
        get
        {
            return Match<ApiEnum<string, LayerMode>?>(
                text: (x) => x.LayerMode,
                image: (x) => x.LayerMode,
                video: (x) => x.LayerMode,
                subtitle: (x) => x.LayerMode,
                solidColor: (x) => x.LayerMode
            );
        }
    }

    public OverlayPosition? Position
    {
        get
        {
            return Match<OverlayPosition?>(
                text: (x) => x.Position,
                image: (x) => x.Position,
                video: (x) => x.Position,
                subtitle: (x) => x.Position,
                solidColor: (x) => x.Position
            );
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            return Match<OverlayTiming?>(
                text: (x) => x.Timing,
                image: (x) => x.Timing,
                video: (x) => x.Timing,
                subtitle: (x) => x.Timing,
                solidColor: (x) => x.Timing
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                image: (x) => x.Type,
                video: (x) => x.Type,
                subtitle: (x) => x.Type,
                solidColor: (x) => x.Type
            );
        }
    }

    public string? Input
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                image: (x) => x.Input,
                video: (x) => x.Input,
                subtitle: (x) => x.Input,
                solidColor: (_) => null
            );
        }
    }

    public Overlay(Text value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(ImageOverlay value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(VideoOverlay value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(Subtitle value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(SolidColor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Text"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `Text`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out Text? value)
    {
        value = this.Value as Text;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ImageOverlay"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImage(out var value)) {
    ///     // `value` is of type `ImageOverlay`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImage([NotNullWhen(true)] out ImageOverlay? value)
    {
        value = this.Value as ImageOverlay;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoOverlay"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideo(out var value)) {
    ///     // `value` is of type `VideoOverlay`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideo([NotNullWhen(true)] out VideoOverlay? value)
    {
        value = this.Value as VideoOverlay;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Subtitle"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubtitle(out var value)) {
    ///     // `value` is of type `Subtitle`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubtitle([NotNullWhen(true)] out Subtitle? value)
    {
        value = this.Value as Subtitle;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SolidColor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSolidColor(out var value)) {
    ///     // `value` is of type `SolidColor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSolidColor([NotNullWhen(true)] out SolidColor? value)
    {
        value = this.Value as SolidColor;
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
    ///     (Text value) =&gt; {...},
    ///     (ImageOverlay value) =&gt; {...},
    ///     (VideoOverlay value) =&gt; {...},
    ///     (Subtitle value) =&gt; {...},
    ///     (SolidColor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Text> text,
        Action<ImageOverlay> image,
        Action<VideoOverlay> video,
        Action<Subtitle> subtitle,
        Action<SolidColor> solidColor
    )
    {
        switch (this.Value)
        {
            case Text value:
                text(value);
                break;
            case ImageOverlay value:
                image(value);
                break;
            case VideoOverlay value:
                video(value);
                break;
            case Subtitle value:
                subtitle(value);
                break;
            case SolidColor value:
                solidColor(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of Overlay"
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
    ///     (Text value) =&gt; {...},
    ///     (ImageOverlay value) =&gt; {...},
    ///     (VideoOverlay value) =&gt; {...},
    ///     (Subtitle value) =&gt; {...},
    ///     (SolidColor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<Text, T> text,
        Func<ImageOverlay, T> image,
        Func<VideoOverlay, T> video,
        Func<Subtitle, T> subtitle,
        Func<SolidColor, T> solidColor
    )
    {
        return this.Value switch
        {
            Text value => text(value),
            ImageOverlay value => image(value),
            VideoOverlay value => video(value),
            Subtitle value => subtitle(value),
            SolidColor value => solidColor(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Overlay"
            ),
        };
    }

    public static implicit operator Overlay(Text value) => new(value);

    public static implicit operator Overlay(ImageOverlay value) => new(value);

    public static implicit operator Overlay(VideoOverlay value) => new(value);

    public static implicit operator Overlay(Subtitle value) => new(value);

    public static implicit operator Overlay(SolidColor value) => new(value);

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
                "Data did not match any variant of Overlay"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (image) => image.Validate(),
            (video) => video.Validate(),
            (subtitle) => subtitle.Validate(),
            (solidColor) => solidColor.Validate()
        );
    }

    public virtual bool Equals(Overlay? other) =>
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
            Text _ => 0,
            ImageOverlay _ => 1,
            VideoOverlay _ => 2,
            Subtitle _ => 3,
            SolidColor _ => 4,
            _ => -1,
        };
    }
}

sealed class OverlayConverter : JsonConverter<Overlay>
{
    public override Overlay? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Text>(element, options);
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
            case "image":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageOverlay>(element, options);
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
            case "video":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoOverlay>(element, options);
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
            case "subtitle":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Subtitle>(element, options);
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
            case "solidColor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SolidColor>(element, options);
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
                return new Overlay(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Overlay value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Text, TextFromRaw>))]
public sealed record class Text : JsonModel
{
    /// <summary>
    /// Controls how the layer blends with the base image or underlying content.
    /// Maps to `lm` in the URL. By default, layers completely cover the base image
    /// beneath them. Layer modes change this behavior: - `multiply`: Multiplies
    /// the pixel values of the layer with the base image. The result is always darker
    /// than the original images. This is ideal for applying shadows or color tints.
    /// - `displace`: Uses the layer as a displacement map to distort pixels in the
    /// base image. The red channel controls horizontal displacement, and the green
    /// channel controls vertical displacement. Requires `x` or `y` parameter to control
    /// displacement magnitude. - `cutout`: Acts as an inverse mask where opaque areas
    /// of the layer turn the base image transparent, while transparent areas leave
    /// the base image unchanged. This mode functions like a hole-punch, effectively
    /// cutting the shape of the layer out of the underlying image. - `cutter`: Acts
    /// as a shape mask where only the parts of the base image that fall inside the
    /// opaque area of the layer are preserved. This mode functions like a cookie-cutter,
    /// trimming the base image to match the specific dimensions and shape of the
    /// layer. See [Layer modes](https://imagekit.io/docs/add-overlays-on-images#layer-modes).
    /// </summary>
    public ApiEnum<string, LayerMode>? LayerMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LayerMode>>("layerMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("layerMode", value);
        }
    }

    public OverlayPosition? Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayPosition>("position");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayTiming>("timing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timing", value);
        }
    }

    /// <summary>
    /// Specifies the text to be displayed in the overlay. The SDK automatically
    /// handles special characters and encoding.
    /// </summary>
    public required string TextValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

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
    /// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
    /// (base64).  By default, the SDK selects the appropriate format based on the
    /// input text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method, the input text is always percent-encoded
    /// to ensure it is URL-safe.</para>
    /// </summary>
    public ApiEnum<string, TextTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextTextOverlayEncoding>>(
                "encoding"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// Control styling of the text overlay. See [Text overlays](https://imagekit.io/docs/add-overlays-on-images#text-overlay).
    /// </summary>
    public IReadOnlyList<TextOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TextOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TextOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator BaseOverlay(Text text) =>
        new()
        {
            LayerMode = text.LayerMode,
            Position = text.Position,
            Timing = text.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.TextValue;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public Text()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Text(Text text)
        : base(text) { }
#pragma warning restore CS8618

    public Text(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Text(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextFromRaw.FromRawUnchecked"/>
    public static Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Text(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextFromRaw : IFromRawJson<Text>
{
    /// <inheritdoc/>
    public Text FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Text.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TextTextOverlay, TextTextOverlayFromRaw>))]
public sealed record class TextTextOverlay : JsonModel
{
    /// <summary>
    /// Specifies the text to be displayed in the overlay. The SDK automatically
    /// handles special characters and encoding.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

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
    /// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
    /// (base64).  By default, the SDK selects the appropriate format based on the
    /// input text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method, the input text is always percent-encoded
    /// to ensure it is URL-safe.</para>
    /// </summary>
    public ApiEnum<string, TextTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextTextOverlayEncoding>>(
                "encoding"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// Control styling of the text overlay. See [Text overlays](https://imagekit.io/docs/add-overlays-on-images#text-overlay).
    /// </summary>
    public IReadOnlyList<TextOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TextOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TextOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextTextOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextTextOverlay(TextTextOverlay textTextOverlay)
        : base(textTextOverlay) { }
#pragma warning restore CS8618

    public TextTextOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextTextOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextTextOverlayFromRaw.FromRawUnchecked"/>
    public static TextTextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextTextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextTextOverlayFromRaw : IFromRawJson<TextTextOverlay>
{
    /// <inheritdoc/>
    public TextTextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextTextOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
/// (base64).  By default, the SDK selects the appropriate format based on the input
/// text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
///  To always use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method, the input text is always percent-encoded
/// to ensure it is URL-safe.</para>
/// </summary>
[JsonConverter(typeof(TextTextOverlayEncodingConverter))]
public enum TextTextOverlayEncoding
{
    Auto,
    Plain,
    Base64,
}

sealed class TextTextOverlayEncodingConverter : JsonConverter<TextTextOverlayEncoding>
{
    public override TextTextOverlayEncoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => TextTextOverlayEncoding.Auto,
            "plain" => TextTextOverlayEncoding.Plain,
            "base64" => TextTextOverlayEncoding.Base64,
            _ => (TextTextOverlayEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextTextOverlayEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextTextOverlayEncoding.Auto => "auto",
                TextTextOverlayEncoding.Plain => "plain",
                TextTextOverlayEncoding.Base64 => "base64",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Subtitle, SubtitleFromRaw>))]
public sealed record class Subtitle : JsonModel
{
    /// <summary>
    /// Controls how the layer blends with the base image or underlying content.
    /// Maps to `lm` in the URL. By default, layers completely cover the base image
    /// beneath them. Layer modes change this behavior: - `multiply`: Multiplies
    /// the pixel values of the layer with the base image. The result is always darker
    /// than the original images. This is ideal for applying shadows or color tints.
    /// - `displace`: Uses the layer as a displacement map to distort pixels in the
    /// base image. The red channel controls horizontal displacement, and the green
    /// channel controls vertical displacement. Requires `x` or `y` parameter to control
    /// displacement magnitude. - `cutout`: Acts as an inverse mask where opaque areas
    /// of the layer turn the base image transparent, while transparent areas leave
    /// the base image unchanged. This mode functions like a hole-punch, effectively
    /// cutting the shape of the layer out of the underlying image. - `cutter`: Acts
    /// as a shape mask where only the parts of the base image that fall inside the
    /// opaque area of the layer are preserved. This mode functions like a cookie-cutter,
    /// trimming the base image to match the specific dimensions and shape of the
    /// layer. See [Layer modes](https://imagekit.io/docs/add-overlays-on-images#layer-modes).
    /// </summary>
    public ApiEnum<string, LayerMode>? LayerMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LayerMode>>("layerMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("layerMode", value);
        }
    }

    public OverlayPosition? Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayPosition>("position");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayTiming>("timing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timing", value);
        }
    }

    /// <summary>
    /// Specifies the relative path to the subtitle file used as an overlay.
    /// </summary>
    public required string Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input");
        }
        init { this._rawData.Set("input", value); }
    }

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
    /// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
    ///  By default, the SDK determines the appropriate format automatically.  To
    /// always use base64 encoding (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method: - Leading and trailing slashes are
    /// removed. - Remaining slashes within the path are replaced with `@@` when using
    /// plain text.</para>
    /// </summary>
    public ApiEnum<string, SubtitleSubtitleOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubtitleSubtitleOverlayEncoding>>(
                "encoding"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// Control styling of the subtitle. See [Styling subtitles](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer).
    /// </summary>
    public IReadOnlyList<SubtitleOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubtitleOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubtitleOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator BaseOverlay(Subtitle subtitle) =>
        new()
        {
            LayerMode = subtitle.LayerMode,
            Position = subtitle.Position,
            Timing = subtitle.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Input;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("subtitle")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public Subtitle()
    {
        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subtitle(Subtitle subtitle)
        : base(subtitle) { }
#pragma warning restore CS8618

    public Subtitle(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subtitle(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubtitleFromRaw.FromRawUnchecked"/>
    public static Subtitle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Subtitle(string input)
        : this()
    {
        this.Input = input;
    }
}

class SubtitleFromRaw : IFromRawJson<Subtitle>
{
    /// <inheritdoc/>
    public Subtitle FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subtitle.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SubtitleSubtitleOverlay, SubtitleSubtitleOverlayFromRaw>))]
public sealed record class SubtitleSubtitleOverlay : JsonModel
{
    /// <summary>
    /// Specifies the relative path to the subtitle file used as an overlay.
    /// </summary>
    public required string Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("input");
        }
        init { this._rawData.Set("input", value); }
    }

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
    /// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
    ///  By default, the SDK determines the appropriate format automatically.  To
    /// always use base64 encoding (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method: - Leading and trailing slashes are
    /// removed. - Remaining slashes within the path are replaced with `@@` when using
    /// plain text.</para>
    /// </summary>
    public ApiEnum<string, SubtitleSubtitleOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SubtitleSubtitleOverlayEncoding>>(
                "encoding"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding", value);
        }
    }

    /// <summary>
    /// Control styling of the subtitle. See [Styling subtitles](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer).
    /// </summary>
    public IReadOnlyList<SubtitleOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SubtitleOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SubtitleOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Input;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("subtitle")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SubtitleSubtitleOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubtitleSubtitleOverlay(SubtitleSubtitleOverlay subtitleSubtitleOverlay)
        : base(subtitleSubtitleOverlay) { }
#pragma warning restore CS8618

    public SubtitleSubtitleOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubtitleSubtitleOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubtitleSubtitleOverlayFromRaw.FromRawUnchecked"/>
    public static SubtitleSubtitleOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubtitleSubtitleOverlay(string input)
        : this()
    {
        this.Input = input;
    }
}

class SubtitleSubtitleOverlayFromRaw : IFromRawJson<SubtitleSubtitleOverlay>
{
    /// <inheritdoc/>
    public SubtitleSubtitleOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubtitleSubtitleOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
///  By default, the SDK determines the appropriate format automatically.  To always
/// use base64 encoding (`ie-{base64}`), set this parameter to `base64`.  To always
/// use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method: - Leading and trailing slashes are removed.
/// - Remaining slashes within the path are replaced with `@@` when using plain text.</para>
/// </summary>
[JsonConverter(typeof(SubtitleSubtitleOverlayEncodingConverter))]
public enum SubtitleSubtitleOverlayEncoding
{
    Auto,
    Plain,
    Base64,
}

sealed class SubtitleSubtitleOverlayEncodingConverter
    : JsonConverter<SubtitleSubtitleOverlayEncoding>
{
    public override SubtitleSubtitleOverlayEncoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => SubtitleSubtitleOverlayEncoding.Auto,
            "plain" => SubtitleSubtitleOverlayEncoding.Plain,
            "base64" => SubtitleSubtitleOverlayEncoding.Base64,
            _ => (SubtitleSubtitleOverlayEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubtitleSubtitleOverlayEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubtitleSubtitleOverlayEncoding.Auto => "auto",
                SubtitleSubtitleOverlayEncoding.Plain => "plain",
                SubtitleSubtitleOverlayEncoding.Base64 => "base64",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<SolidColor, SolidColorFromRaw>))]
public sealed record class SolidColor : JsonModel
{
    /// <summary>
    /// Controls how the layer blends with the base image or underlying content.
    /// Maps to `lm` in the URL. By default, layers completely cover the base image
    /// beneath them. Layer modes change this behavior: - `multiply`: Multiplies
    /// the pixel values of the layer with the base image. The result is always darker
    /// than the original images. This is ideal for applying shadows or color tints.
    /// - `displace`: Uses the layer as a displacement map to distort pixels in the
    /// base image. The red channel controls horizontal displacement, and the green
    /// channel controls vertical displacement. Requires `x` or `y` parameter to control
    /// displacement magnitude. - `cutout`: Acts as an inverse mask where opaque areas
    /// of the layer turn the base image transparent, while transparent areas leave
    /// the base image unchanged. This mode functions like a hole-punch, effectively
    /// cutting the shape of the layer out of the underlying image. - `cutter`: Acts
    /// as a shape mask where only the parts of the base image that fall inside the
    /// opaque area of the layer are preserved. This mode functions like a cookie-cutter,
    /// trimming the base image to match the specific dimensions and shape of the
    /// layer. See [Layer modes](https://imagekit.io/docs/add-overlays-on-images#layer-modes).
    /// </summary>
    public ApiEnum<string, LayerMode>? LayerMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LayerMode>>("layerMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("layerMode", value);
        }
    }

    public OverlayPosition? Position
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayPosition>("position");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OverlayTiming>("timing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timing", value);
        }
    }

    /// <summary>
    /// Specifies the color of the block using an RGB hex code (e.g., `FF0000`), an
    /// RGBA code (e.g., `FFAABB50`), or a color name (e.g., `red`). If an 8-character
    /// value is provided, the last two characters represent the opacity level (from
    /// `00` for 0.00 to `99` for 0.99).
    /// </summary>
    public required string Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("color");
        }
        init { this._rawData.Set("color", value); }
    }

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
    /// Control width and height of the solid color overlay. Supported transformations
    /// depend on the base/parent asset. See overlays on [Images](https://imagekit.io/docs/add-overlays-on-images#apply-transformation-on-solid-color-overlay)
    /// and [Videos](https://imagekit.io/docs/add-overlays-on-videos#apply-transformations-on-solid-color-block-overlay).
    /// </summary>
    public IReadOnlyList<SolidColorOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SolidColorOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SolidColorOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator BaseOverlay(SolidColor solidColor) =>
        new()
        {
            LayerMode = solidColor.LayerMode,
            Position = solidColor.Position,
            Timing = solidColor.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Color;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("solidColor")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SolidColor()
    {
        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SolidColor(SolidColor solidColor)
        : base(solidColor) { }
#pragma warning restore CS8618

    public SolidColor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SolidColorFromRaw.FromRawUnchecked"/>
    public static SolidColor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SolidColor(string color)
        : this()
    {
        this.Color = color;
    }
}

class SolidColorFromRaw : IFromRawJson<SolidColor>
{
    /// <inheritdoc/>
    public SolidColor FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SolidColor.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SolidColorSolidColorOverlay, SolidColorSolidColorOverlayFromRaw>)
)]
public sealed record class SolidColorSolidColorOverlay : JsonModel
{
    /// <summary>
    /// Specifies the color of the block using an RGB hex code (e.g., `FF0000`), an
    /// RGBA code (e.g., `FFAABB50`), or a color name (e.g., `red`). If an 8-character
    /// value is provided, the last two characters represent the opacity level (from
    /// `00` for 0.00 to `99` for 0.99).
    /// </summary>
    public required string Color
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("color");
        }
        init { this._rawData.Set("color", value); }
    }

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
    /// Control width and height of the solid color overlay. Supported transformations
    /// depend on the base/parent asset. See overlays on [Images](https://imagekit.io/docs/add-overlays-on-images#apply-transformation-on-solid-color-overlay)
    /// and [Videos](https://imagekit.io/docs/add-overlays-on-videos#apply-transformations-on-solid-color-block-overlay).
    /// </summary>
    public IReadOnlyList<SolidColorOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SolidColorOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SolidColorOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Color;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("solidColor")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SolidColorSolidColorOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SolidColorSolidColorOverlay(SolidColorSolidColorOverlay solidColorSolidColorOverlay)
        : base(solidColorSolidColorOverlay) { }
#pragma warning restore CS8618

    public SolidColorSolidColorOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorSolidColorOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SolidColorSolidColorOverlayFromRaw.FromRawUnchecked"/>
    public static SolidColorSolidColorOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SolidColorSolidColorOverlay(string color)
        : this()
    {
        this.Color = color;
    }
}

class SolidColorSolidColorOverlayFromRaw : IFromRawJson<SolidColorSolidColorOverlay>
{
    /// <inheritdoc/>
    public SolidColorSolidColorOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SolidColorSolidColorOverlay.FromRawUnchecked(rawData);
}
