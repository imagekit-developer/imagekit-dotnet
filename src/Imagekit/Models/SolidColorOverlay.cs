using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<SolidColorOverlay>))]
public sealed record class SolidColorOverlay : ModelBase, IFromRaw<SolidColorOverlay>
{
    public OverlayPosition? Position
    {
        get
        {
            if (!this.Properties.TryGetValue("position", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayPosition?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["position"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            if (!this.Properties.TryGetValue("timing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayTiming?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the color of the block using an RGB hex code (e.g., `FF0000`),
    /// an RGBA code (e.g., `FFAABB50`), or a color name (e.g., `red`). If an 8-character
    /// value is provided, the last two characters represent the opacity level (from
    /// `00` for 0.00 to `99` for 0.99).
    /// </summary>
    public required string Color
    {
        get
        {
            if (!this.Properties.TryGetValue("color", out JsonElement element))
                throw new ArgumentOutOfRangeException("color", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("color");
        }
        set
        {
            this.Properties["color"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Control width and height of the solid color overlay. Supported transformations
    /// depend on the base/parent asset. See overlays on [Images](https://imagekit.io/docs/add-overlays-on-images#apply-transformation-on-solid-color-overlay)
    /// and [Videos](https://imagekit.io/docs/add-overlays-on-videos#apply-transformations-on-solid-color-block-overlay).
    /// </summary>
    public List<SolidColorOverlayTransformation>? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<SolidColorOverlayTransformation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["transformation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator BaseOverlay(SolidColorOverlay solidColorOverlay) =>
        new() { Position = solidColorOverlay.Position, Timing = solidColorOverlay.Timing };

    public override void Validate()
    {
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Color;
        _ = this.Type;
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public SolidColorOverlay()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"solidColor\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorOverlay(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SolidColorOverlay FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SolidColorOverlay(string color)
        : this()
    {
        this.Color = color;
    }
}
