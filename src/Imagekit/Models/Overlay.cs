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
public record class Overlay
{
    public object Value { get; private init; }

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

    public Overlay(TextOverlay value)
    {
        Value = value;
    }

    public Overlay(ImageOverlay value)
    {
        Value = value;
    }

    public Overlay(VideoOverlay value)
    {
        Value = value;
    }

    public Overlay(SubtitleOverlay value)
    {
        Value = value;
    }

    public Overlay(SolidColorOverlay value)
    {
        Value = value;
    }

    Overlay(UnknownVariant value)
    {
        Value = value;
    }

    public static Overlay CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickText([NotNullWhen(true)] out TextOverlay? value)
    {
        value = this.Value as TextOverlay;
        return value != null;
    }

    public bool TryPickImage([NotNullWhen(true)] out ImageOverlay? value)
    {
        value = this.Value as ImageOverlay;
        return value != null;
    }

    public bool TryPickVideo([NotNullWhen(true)] out VideoOverlay? value)
    {
        value = this.Value as VideoOverlay;
        return value != null;
    }

    public bool TryPickSubtitle([NotNullWhen(true)] out SubtitleOverlay? value)
    {
        value = this.Value as SubtitleOverlay;
        return value != null;
    }

    public bool TryPickSolidColor([NotNullWhen(true)] out SolidColorOverlay? value)
    {
        value = this.Value as SolidColorOverlay;
        return value != null;
    }

    public void Switch(
        Action<TextOverlay> text,
        Action<ImageOverlay> image,
        Action<VideoOverlay> video,
        Action<SubtitleOverlay> subtitle,
        Action<SolidColorOverlay> solidColor
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
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextOverlay, T> text,
        Func<ImageOverlay, T> image,
        Func<VideoOverlay, T> video,
        Func<SubtitleOverlay, T> subtitle,
        Func<SolidColorOverlay, T> solidColor
    )
    {
        return this.Value switch
        {
            OverlayVariants::TextOverlay inner => text(inner),
            OverlayVariants::ImageOverlay inner => image(inner),
            OverlayVariants::VideoOverlay inner => video(inner),
            OverlayVariants::SubtitleOverlay inner => subtitle(inner),
            OverlayVariants::SolidColorOverlay inner => solidColor(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Overlay");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
                        deserialized.Validate();
                        return new Overlay(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Overlay(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Overlay(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Overlay(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
                        deserialized.Validate();
                        return new Overlay(deserialized);
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
