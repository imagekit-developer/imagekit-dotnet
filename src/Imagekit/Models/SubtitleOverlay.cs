using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models;

[JsonConverter(typeof(JsonModelConverter<SubtitleOverlay, SubtitleOverlayFromRaw>))]
public sealed record class SubtitleOverlay : JsonModel
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
    /// plain text. </para>
    /// </summary>
    public ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
            >("encoding");
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

    public static implicit operator BaseOverlay(SubtitleOverlay subtitleOverlay) =>
        new()
        {
            LayerMode = subtitleOverlay.LayerMode,
            Position = subtitleOverlay.Position,
            Timing = subtitleOverlay.Timing,
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
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SubtitleOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubtitleOverlay(SubtitleOverlay subtitleOverlay)
        : base(subtitleOverlay) { }
#pragma warning restore CS8618

    public SubtitleOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubtitleOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubtitleOverlayFromRaw.FromRawUnchecked"/>
    public static SubtitleOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubtitleOverlay(string input)
        : this()
    {
        this.Input = input;
    }
}

class SubtitleOverlayFromRaw : IFromRawJson<SubtitleOverlay>
{
    /// <inheritdoc/>
    public SubtitleOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubtitleOverlay.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SubtitleOverlaySubtitleOverlay,
        SubtitleOverlaySubtitleOverlayFromRaw
    >)
)]
public sealed record class SubtitleOverlaySubtitleOverlay : JsonModel
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
    /// plain text. </para>
    /// </summary>
    public ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, SubtitleOverlaySubtitleOverlayEncoding>
            >("encoding");
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
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SubtitleOverlaySubtitleOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubtitleOverlaySubtitleOverlay(
        SubtitleOverlaySubtitleOverlay subtitleOverlaySubtitleOverlay
    )
        : base(subtitleOverlaySubtitleOverlay) { }
#pragma warning restore CS8618

    public SubtitleOverlaySubtitleOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("subtitle");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubtitleOverlaySubtitleOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubtitleOverlaySubtitleOverlayFromRaw.FromRawUnchecked"/>
    public static SubtitleOverlaySubtitleOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SubtitleOverlaySubtitleOverlay(string input)
        : this()
    {
        this.Input = input;
    }
}

class SubtitleOverlaySubtitleOverlayFromRaw : IFromRawJson<SubtitleOverlaySubtitleOverlay>
{
    /// <inheritdoc/>
    public SubtitleOverlaySubtitleOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SubtitleOverlaySubtitleOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
///  By default, the SDK determines the appropriate format automatically.  To always
/// use base64 encoding (`ie-{base64}`), set this parameter to `base64`.  To always
/// use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method: - Leading and trailing slashes are removed.
/// - Remaining slashes within the path are replaced with `@@` when using plain text. </para>
/// </summary>
[JsonConverter(typeof(SubtitleOverlaySubtitleOverlayEncodingConverter))]
public enum SubtitleOverlaySubtitleOverlayEncoding
{
    Auto,
    Plain,
    Base64,
}

sealed class SubtitleOverlaySubtitleOverlayEncodingConverter
    : JsonConverter<SubtitleOverlaySubtitleOverlayEncoding>
{
    public override SubtitleOverlaySubtitleOverlayEncoding Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => SubtitleOverlaySubtitleOverlayEncoding.Auto,
            "plain" => SubtitleOverlaySubtitleOverlayEncoding.Plain,
            "base64" => SubtitleOverlaySubtitleOverlayEncoding.Base64,
            _ => (SubtitleOverlaySubtitleOverlayEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubtitleOverlaySubtitleOverlayEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubtitleOverlaySubtitleOverlayEncoding.Auto => "auto",
                SubtitleOverlaySubtitleOverlayEncoding.Plain => "plain",
                SubtitleOverlaySubtitleOverlayEncoding.Base64 => "base64",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
