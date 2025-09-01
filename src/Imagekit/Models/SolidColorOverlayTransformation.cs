using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.SolidColorOverlayTransformationProperties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<SolidColorOverlayTransformation>))]
public sealed record class SolidColorOverlayTransformation
    : ModelBase,
        IFromRaw<SolidColorOverlayTransformation>
{
    /// <summary>
    /// Specifies the transparency level of the solid color overlay. Accepts integers
    /// from `1` to `9`.
    /// </summary>
    public double? Alpha
    {
        get
        {
            if (!this.Properties.TryGetValue("alpha", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["alpha"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the background color of the solid color overlay. Accepts an RGB
    /// hex code (e.g., `FF0000`), an RGBA code (e.g., `FFAABB50`), or a color name.
    /// </summary>
    public string? Background
    {
        get
        {
            if (!this.Properties.TryGetValue("background", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["background"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Creates a linear gradient with two colors. Pass `true` for a default gradient,
    /// or provide a string for a custom gradient. Only works if the base asset is
    /// an image. See [gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
    /// </summary>
    public Gradient? Gradient
    {
        get
        {
            if (!this.Properties.TryGetValue("gradient", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Gradient?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["gradient"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Controls the height of the solid color overlay. Accepts a numeric value or
    /// an arithmetic expression. Learn about [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Height? Height
    {
        get
        {
            if (!this.Properties.TryGetValue("height", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Height?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["height"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the corner radius of the solid color overlay. Set to `max` for
    /// circular or oval shape. See [radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
    /// </summary>
    public Radius? Radius
    {
        get
        {
            if (!this.Properties.TryGetValue("radius", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Radius?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["radius"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Controls the width of the solid color overlay. Accepts a numeric value or
    /// an arithmetic expression (e.g., `bw_mul_0.2` or `bh_div_2`). Learn about [arithmetic
    /// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Width? Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Width?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Alpha;
        _ = this.Background;
        this.Gradient?.Validate();
        this.Height?.Validate();
        this.Radius?.Validate();
        this.Width?.Validate();
    }

    public SolidColorOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SolidColorOverlayTransformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SolidColorOverlayTransformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
