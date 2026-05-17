using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(typeof(JsonModelConverter<SolidColorOverlay, SolidColorOverlayFromRaw>))]
public sealed record class SolidColorOverlay : JsonModel
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

    public static implicit operator BaseOverlay(SolidColorOverlay solidColorOverlay) =>
        new()
        {
            LayerMode = solidColorOverlay.LayerMode,
            Position = solidColorOverlay.Position,
            Timing = solidColorOverlay.Timing,
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
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SolidColorOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SolidColorOverlay(SolidColorOverlay solidColorOverlay)
        : base(solidColorOverlay) { }
#pragma warning restore CS8618

    public SolidColorOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SolidColorOverlayFromRaw.FromRawUnchecked"/>
    public static SolidColorOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SolidColorOverlay(string color)
        : this()
    {
        this.Color = color;
    }
}

class SolidColorOverlayFromRaw : IFromRawJson<SolidColorOverlay>
{
    /// <inheritdoc/>
    public SolidColorOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SolidColorOverlay.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        SolidColorOverlaySolidColorOverlay,
        SolidColorOverlaySolidColorOverlayFromRaw
    >)
)]
public sealed record class SolidColorOverlaySolidColorOverlay : JsonModel
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
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SolidColorOverlaySolidColorOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SolidColorOverlaySolidColorOverlay(
        SolidColorOverlaySolidColorOverlay solidColorOverlaySolidColorOverlay
    )
        : base(solidColorOverlaySolidColorOverlay) { }
#pragma warning restore CS8618

    public SolidColorOverlaySolidColorOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("solidColor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorOverlaySolidColorOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SolidColorOverlaySolidColorOverlayFromRaw.FromRawUnchecked"/>
    public static SolidColorOverlaySolidColorOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SolidColorOverlaySolidColorOverlay(string color)
        : this()
    {
        this.Color = color;
    }
}

class SolidColorOverlaySolidColorOverlayFromRaw : IFromRawJson<SolidColorOverlaySolidColorOverlay>
{
    /// <inheritdoc/>
    public SolidColorOverlaySolidColorOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SolidColorOverlaySolidColorOverlay.FromRawUnchecked(rawData);
}
