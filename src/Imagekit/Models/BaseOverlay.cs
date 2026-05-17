using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(typeof(JsonModelConverter<BaseOverlay, BaseOverlayFromRaw>))]
public sealed record class BaseOverlay : JsonModel
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

    /// <summary>
    /// Specifies the overlay's position relative to the parent asset. See [Position
    /// of Layer](https://imagekit.io/docs/transformations#position-of-layer).
    /// </summary>
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

    /// <summary>
    /// Specifies timing information for the overlay (only applicable if the base
    /// asset is a video). See [Position of Layer](https://imagekit.io/docs/transformations#position-of-layer).
    /// </summary>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
    }

    public BaseOverlay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BaseOverlay(BaseOverlay baseOverlay)
        : base(baseOverlay) { }
#pragma warning restore CS8618

    public BaseOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BaseOverlayFromRaw.FromRawUnchecked"/>
    public static BaseOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BaseOverlayFromRaw : IFromRawJson<BaseOverlay>
{
    /// <inheritdoc/>
    public BaseOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BaseOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// Controls how the layer blends with the base image or underlying content. Maps
/// to `lm` in the URL. By default, layers completely cover the base image beneath
/// them. Layer modes change this behavior: - `multiply`: Multiplies the pixel values
/// of the layer with the base image. The result is always darker than the original
/// images. This is ideal for applying shadows or color tints. - `displace`: Uses
/// the layer as a displacement map to distort pixels in the base image. The red
/// channel controls horizontal displacement, and the green channel controls vertical
/// displacement. Requires `x` or `y` parameter to control displacement magnitude.
/// - `cutout`: Acts as an inverse mask where opaque areas of the layer turn the base
/// image transparent, while transparent areas leave the base image unchanged. This
/// mode functions like a hole-punch, effectively cutting the shape of the layer out
/// of the underlying image. - `cutter`: Acts as a shape mask where only the parts
/// of the base image that fall inside the opaque area of the layer are preserved.
/// This mode functions like a cookie-cutter, trimming the base image to match the
/// specific dimensions and shape of the layer. See [Layer modes](https://imagekit.io/docs/add-overlays-on-images#layer-modes).
/// </summary>
[JsonConverter(typeof(LayerModeConverter))]
public enum LayerMode
{
    Multiply,
    Cutter,
    Cutout,
    Displace,
}

sealed class LayerModeConverter : JsonConverter<LayerMode>
{
    public override LayerMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "multiply" => LayerMode.Multiply,
            "cutter" => LayerMode.Cutter,
            "cutout" => LayerMode.Cutout,
            "displace" => LayerMode.Displace,
            _ => (LayerMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LayerMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                LayerMode.Multiply => "multiply",
                LayerMode.Cutter => "cutter",
                LayerMode.Cutout => "cutout",
                LayerMode.Displace => "displace",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
