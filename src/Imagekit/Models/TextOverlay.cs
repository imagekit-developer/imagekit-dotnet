using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(typeof(JsonModelConverter<TextOverlay, TextOverlayFromRaw>))]
public sealed record class TextOverlay : JsonModel
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
    /// to ensure it is URL-safe. </para>
    /// </summary>
    public ApiEnum<string, TextOverlayTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
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

    public static implicit operator BaseOverlay(TextOverlay textOverlay) =>
        new()
        {
            LayerMode = textOverlay.LayerMode,
            Position = textOverlay.Position,
            Timing = textOverlay.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextOverlay(TextOverlay textOverlay)
        : base(textOverlay) { }
#pragma warning restore CS8618

    public TextOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextOverlayFromRaw.FromRawUnchecked"/>
    public static TextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextOverlayFromRaw : IFromRawJson<TextOverlay>
{
    /// <inheritdoc/>
    public TextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextOverlay.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TextOverlayTextOverlay, TextOverlayTextOverlayFromRaw>))]
public sealed record class TextOverlayTextOverlay : JsonModel
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
    /// to ensure it is URL-safe. </para>
    /// </summary>
    public ApiEnum<string, TextOverlayTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
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
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextOverlayTextOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextOverlayTextOverlay(TextOverlayTextOverlay textOverlayTextOverlay)
        : base(textOverlayTextOverlay) { }
#pragma warning restore CS8618

    public TextOverlayTextOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlayTextOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextOverlayTextOverlayFromRaw.FromRawUnchecked"/>
    public static TextOverlayTextOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextOverlayTextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextOverlayTextOverlayFromRaw : IFromRawJson<TextOverlayTextOverlay>
{
    /// <inheritdoc/>
    public TextOverlayTextOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextOverlayTextOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
/// (base64).  By default, the SDK selects the appropriate format based on the input
/// text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
///  To always use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method, the input text is always percent-encoded
/// to ensure it is URL-safe. </para>
/// </summary>
[JsonConverter(typeof(TextOverlayTextOverlayEncodingConverter))]
public enum TextOverlayTextOverlayEncoding
{
    Auto,
    Plain,
    Base64,
}

sealed class TextOverlayTextOverlayEncodingConverter : JsonConverter<TextOverlayTextOverlayEncoding>
{
    public override TextOverlayTextOverlayEncoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => TextOverlayTextOverlayEncoding.Auto,
            "plain" => TextOverlayTextOverlayEncoding.Plain,
            "base64" => TextOverlayTextOverlayEncoding.Base64,
            _ => (TextOverlayTextOverlayEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextOverlayTextOverlayEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextOverlayTextOverlayEncoding.Auto => "auto",
                TextOverlayTextOverlayEncoding.Plain => "plain",
                TextOverlayTextOverlayEncoding.Base64 => "base64",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
