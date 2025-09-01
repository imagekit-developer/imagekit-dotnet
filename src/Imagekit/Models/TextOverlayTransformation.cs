using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.TextOverlayTransformationProperties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<TextOverlayTransformation>))]
public sealed record class TextOverlayTransformation
    : ModelBase,
        IFromRaw<TextOverlayTransformation>
{
    /// <summary>
    /// Specifies the transparency level of the text overlay. Accepts integers from
    /// `1` to `9`.
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
    /// Specifies the background color of the text overlay. Accepts an RGB hex code,
    /// an RGBA code, or a color name.
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
    /// Flip the text overlay horizontally, vertically, or both.
    /// </summary>
    public ApiEnum<string, Flip>? Flip
    {
        get
        {
            if (!this.Properties.TryGetValue("flip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Flip>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["flip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the font color of the overlaid text. Accepts an RGB hex code (e.g.,
    /// `FF0000`), an RGBA code (e.g., `FFAABB50`), or a color name.
    /// </summary>
    public string? FontColor
    {
        get
        {
            if (!this.Properties.TryGetValue("fontColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fontColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the font family of the overlaid text. Choose from the supported
    /// fonts list or use a custom font. See [Supported fonts](https://imagekit.io/docs/add-overlays-on-images#supported-text-font-list)
    /// and [Custom font](https://imagekit.io/docs/add-overlays-on-images#change-font-family-in-text-overlay).
    /// </summary>
    public string? FontFamily
    {
        get
        {
            if (!this.Properties.TryGetValue("fontFamily", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fontFamily"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the font size of the overlaid text. Accepts a numeric value or
    /// an arithmetic expression.
    /// </summary>
    public FontSize? FontSize
    {
        get
        {
            if (!this.Properties.TryGetValue("fontSize", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FontSize?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fontSize"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the inner alignment of the text when width is more than the text
    /// length.
    /// </summary>
    public ApiEnum<string, InnerAlignment>? InnerAlignment
    {
        get
        {
            if (!this.Properties.TryGetValue("innerAlignment", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, InnerAlignment>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["innerAlignment"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the line height of the text overlay.  Accepts integer values representing
    /// line height in points. It can also accept [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations)
    /// such as `bw_mul_0.2`, or `bh_div_20`.
    /// </summary>
    public LineHeight? LineHeight
    {
        get
        {
            if (!this.Properties.TryGetValue("lineHeight", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<LineHeight?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["lineHeight"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the padding around the overlaid text. Can be provided as a single
    /// positive integer or multiple values separated by underscores (following CSS
    /// shorthand order). Arithmetic expressions are also accepted.
    /// </summary>
    public Padding? Padding
    {
        get
        {
            if (!this.Properties.TryGetValue("padding", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Padding?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["padding"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the corner radius of the text overlay. Set to `max` to achieve
    /// a circular or oval shape.
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
    /// Specifies the rotation angle of the text overlay. Accepts a numeric value
    /// for clockwise rotation or a string prefixed with "N" for counter-clockwise
    /// rotation.
    /// </summary>
    public Rotation? Rotation
    {
        get
        {
            if (!this.Properties.TryGetValue("rotation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Rotation?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["rotation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the typography style of the text. Supported values:    - Single
    /// styles: `b` (bold), `i` (italic), `strikethrough`.   - Combinations: Any combination
    /// separated by underscores, e.g., `b_i`, `b_i_strikethrough`.
    /// </summary>
    public string? Typography
    {
        get
        {
            if (!this.Properties.TryGetValue("typography", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["typography"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the maximum width (in pixels) of the overlaid text. The text wraps
    /// automatically, and arithmetic expressions (e.g., `bw_mul_0.2` or `bh_div_2`)
    /// are supported. Useful when used in conjunction with the `background`. Learn
    /// about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
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
        this.Flip?.Validate();
        _ = this.FontColor;
        _ = this.FontFamily;
        this.FontSize?.Validate();
        this.InnerAlignment?.Validate();
        this.LineHeight?.Validate();
        this.Padding?.Validate();
        this.Radius?.Validate();
        this.Rotation?.Validate();
        _ = this.Typography;
        this.Width?.Validate();
    }

    public TextOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlayTransformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static TextOverlayTransformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
