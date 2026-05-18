using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models;

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

    public Overlay(TextOverlay value, JsonElement? element = null)
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

    public Overlay(SubtitleOverlay value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Overlay(SolidColorOverlay value, JsonElement? element = null)
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
    /// type <see cref="TextOverlay"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextOverlay`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextOverlay? value)
    {
        value = this.Value as TextOverlay;
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
    /// type <see cref="SubtitleOverlay"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSubtitle(out var value)) {
    ///     // `value` is of type `SubtitleOverlay`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSubtitle([NotNullWhen(true)] out SubtitleOverlay? value)
    {
        value = this.Value as SubtitleOverlay;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SolidColorOverlay"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSolidColor(out var value)) {
    ///     // `value` is of type `SolidColorOverlay`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSolidColor([NotNullWhen(true)] out SolidColorOverlay? value)
    {
        value = this.Value as SolidColorOverlay;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (TextOverlay value) =&gt; {...},
    ///     (ImageOverlay value) =&gt; {...},
    ///     (VideoOverlay value) =&gt; {...},
    ///     (SubtitleOverlay value) =&gt; {...},
    ///     (SolidColorOverlay value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextOverlay> text,
        System::Action<ImageOverlay> image,
        System::Action<VideoOverlay> video,
        System::Action<SubtitleOverlay> subtitle,
        System::Action<SolidColorOverlay> solidColor
    )
    {
        switch (this.Value)
        {
            case TextOverlay value:
                text(value);
                break;
            case ImageOverlay value:
                image(value);
                break;
            case VideoOverlay value:
                video(value);
                break;
            case SubtitleOverlay value:
                subtitle(value);
                break;
            case SolidColorOverlay value:
                solidColor(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Overlay");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (TextOverlay value) =&gt; {...},
    ///     (ImageOverlay value) =&gt; {...},
    ///     (VideoOverlay value) =&gt; {...},
    ///     (SubtitleOverlay value) =&gt; {...},
    ///     (SolidColorOverlay value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TextOverlay, T> text,
        System::Func<ImageOverlay, T> image,
        System::Func<VideoOverlay, T> video,
        System::Func<SubtitleOverlay, T> subtitle,
        System::Func<SolidColorOverlay, T> solidColor
    )
    {
        return this.Value switch
        {
            TextOverlay value => text(value),
            ImageOverlay value => image(value),
            VideoOverlay value => video(value),
            SubtitleOverlay value => subtitle(value),
            SolidColorOverlay value => solidColor(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of Overlay"
            ),
        };
    }

    public static implicit operator Overlay(TextOverlay value) => new(value);

    public static implicit operator Overlay(ImageOverlay value) => new(value);

    public static implicit operator Overlay(VideoOverlay value) => new(value);

    public static implicit operator Overlay(SubtitleOverlay value) => new(value);

    public static implicit operator Overlay(SolidColorOverlay value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Overlay");
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
            TextOverlay _ => 0,
            ImageOverlay _ => 1,
            VideoOverlay _ => 2,
            SubtitleOverlay _ => 3,
            SolidColorOverlay _ => 4,
            _ => -1,
        };
    }
}

sealed class OverlayConverter : JsonConverter<Overlay>
{
    public override Overlay? Read(
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
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextOverlay>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<SubtitleOverlay>(
                        element,
                        options
                    );
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
                    var deserialized = JsonSerializer.Deserialize<SolidColorOverlay>(
                        element,
                        options
                    );
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
