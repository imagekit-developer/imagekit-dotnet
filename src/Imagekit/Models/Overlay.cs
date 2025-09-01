using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using OverlayVariants = Imagekit.Models.OverlayVariants;

namespace Imagekit.Models;

/// <summary>
/// Specifies an overlay to be applied on the parent image or video.  ImageKit supports
/// overlays including images, text, videos, subtitles, and solid colors. See [Overlay
/// using layers](https://imagekit.io/docs/transformations#overlay-using-layers).
/// </summary>
[JsonConverter(typeof(OverlayConverter))]
public abstract record class Overlay
{
    internal Overlay() { }

    public static implicit operator Overlay(TextOverlay value) =>
        new OverlayVariants::TextOverlay(value);

    public static implicit operator Overlay(ImageOverlay value) =>
        new OverlayVariants::ImageOverlay(value);

    public static implicit operator Overlay(VideoOverlay value) =>
        new OverlayVariants::VideoOverlay(value);

    public static implicit operator Overlay(SubtitleOverlay value) =>
        new OverlayVariants::SubtitleOverlay(value);

    public static implicit operator Overlay(SolidColorOverlay value) =>
        new OverlayVariants::SolidColorOverlay(value);

    public bool TryPickText([NotNullWhen(true)] out TextOverlay? value)
    {
        value = (this as OverlayVariants::TextOverlay)?.Value;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out ImageOverlay? value)
    {
        value = (this as OverlayVariants::ImageOverlay)?.Value;
        return value != null;
    }

    public bool TryPickVideo([NotNullWhen(true)] out VideoOverlay? value)
    {
        value = (this as OverlayVariants::VideoOverlay)?.Value;
        return value != null;
    }

    public bool TryPickSubtitle([NotNullWhen(true)] out SubtitleOverlay? value)
    {
        value = (this as OverlayVariants::SubtitleOverlay)?.Value;
        return value != null;
    }

    public bool TryPickSolidColor([NotNullWhen(true)] out SolidColorOverlay? value)
    {
        value = (this as OverlayVariants::SolidColorOverlay)?.Value;
        return value != null;
    }

    public void Switch(
        Action<OverlayVariants::TextOverlay> text,
        Action<OverlayVariants::ImageOverlay> image,
        Action<OverlayVariants::VideoOverlay> video,
        Action<OverlayVariants::SubtitleOverlay> subtitle,
        Action<OverlayVariants::SolidColorOverlay> solidColor
    )
    {
        switch (this)
        {
            case OverlayVariants::TextOverlay inner:
                text(inner);
                break;
            case OverlayVariants::ImageOverlay inner:
                image(inner);
                break;
            case OverlayVariants::VideoOverlay inner:
                video(inner);
                break;
            case OverlayVariants::SubtitleOverlay inner:
                subtitle(inner);
                break;
            case OverlayVariants::SolidColorOverlay inner:
                solidColor(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<OverlayVariants::TextOverlay, T> text,
        Func<OverlayVariants::ImageOverlay, T> image,
        Func<OverlayVariants::VideoOverlay, T> video,
        Func<OverlayVariants::SubtitleOverlay, T> subtitle,
        Func<OverlayVariants::SolidColorOverlay, T> solidColor
    )
    {
        return this switch
        {
            OverlayVariants::TextOverlay inner => text(inner),
            OverlayVariants::ImageOverlay inner => image(inner),
            OverlayVariants::VideoOverlay inner => video(inner),
            OverlayVariants::SubtitleOverlay inner => subtitle(inner),
            OverlayVariants::SolidColorOverlay inner => solidColor(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class OverlayConverter : JsonConverter<Overlay>
{
    public override Overlay? Read(
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
            case "text":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextOverlay>(json, options);
                    if (deserialized != null)
                    {
                        return new OverlayVariants::TextOverlay(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "image":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<ImageOverlay>(json, options);
                    if (deserialized != null)
                    {
                        return new OverlayVariants::ImageOverlay(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "video":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoOverlay>(json, options);
                    if (deserialized != null)
                    {
                        return new OverlayVariants::VideoOverlay(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "subtitle":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SubtitleOverlay>(json, options);
                    if (deserialized != null)
                    {
                        return new OverlayVariants::SubtitleOverlay(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "solidColor":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<SolidColorOverlay>(json, options);
                    if (deserialized != null)
                    {
                        return new OverlayVariants::SolidColorOverlay(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Overlay value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            OverlayVariants::TextOverlay(var text) => text,
            OverlayVariants::ImageOverlay(var image) => image,
            OverlayVariants::VideoOverlay(var video) => video,
            OverlayVariants::SubtitleOverlay(var subtitle) => subtitle,
            OverlayVariants::SolidColorOverlay(var solidColor) => solidColor,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
