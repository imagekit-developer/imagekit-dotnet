using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.SubtitleOverlayTransformationProperties;

namespace Imagekit.Models;

/// <summary>
/// Subtitle styling options. [Learn more](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
/// from the docs.
/// </summary>
[JsonConverter(typeof(ModelConverter<SubtitleOverlayTransformation>))]
public sealed record class SubtitleOverlayTransformation
    : ModelBase,
        IFromRaw<SubtitleOverlayTransformation>
{
    /// <summary>
    /// Specifies the subtitle background color using a standard color name, an RGB
    /// color code (e.g., FF0000), or an RGBA color code (e.g., FFAABB50).
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
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
    /// Sets the font color of the subtitle text using a standard color name, an RGB
    /// color code (e.g., FF0000), or an RGBA color code (e.g., FFAABB50).
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// </summary>
    public string? Color
    {
        get
        {
            if (!this.Properties.TryGetValue("color", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["color"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Font family for subtitles. Refer to the [supported fonts](https://imagekit.io/docs/add-overlays-on-images#supported-text-font-list).
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
    /// Sets the font outline of the subtitle text.  Requires the outline width (an
    /// integer) and the outline color (as an RGB color code, RGBA color code, or
    /// standard web color name) separated by an underscore.  Example: `fol-2_blue`
    /// (outline width of 2px and outline color blue), `fol-2_A1CCDD` (outline width
    /// of 2px and outline color `#A1CCDD`) and `fol-2_A1CCDD50` (outline width of
    /// 2px and outline color `#A1CCDD` at 50% opacity).
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// </summary>
    public string? FontOutline
    {
        get
        {
            if (!this.Properties.TryGetValue("fontOutline", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fontOutline"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sets the font shadow for the subtitle text.  Requires the shadow color (as
    /// an RGB color code, RGBA color code, or standard web color name) and shadow
    /// indent (an integer) separated by an underscore.  Example: `fsh-blue_2` (shadow
    /// color blue, indent of 2px), `fsh-A1CCDD_3` (shadow color `#A1CCDD`, indent
    /// of 3px), `fsh-A1CCDD50_3` (shadow color `#A1CCDD` at 50% opacity, indent
    /// of 3px).
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// </summary>
    public string? FontShadow
    {
        get
        {
            if (!this.Properties.TryGetValue("fontShadow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fontShadow"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sets the font size of subtitle text.
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// </summary>
    public double? FontSize
    {
        get
        {
            if (!this.Properties.TryGetValue("fontSize", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
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
    /// Sets the typography style of the subtitle text. Supports values are `b` for
    /// bold, `i` for italics, and `b_i` for bold with italics.
    ///
    /// [Subtitle styling options](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// </summary>
    public ApiEnum<string, Typography>? Typography
    {
        get
        {
            if (!this.Properties.TryGetValue("typography", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Typography>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["typography"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Background;
        _ = this.Color;
        _ = this.FontFamily;
        _ = this.FontOutline;
        _ = this.FontShadow;
        _ = this.FontSize;
        this.Typography?.Validate();
    }

    public SubtitleOverlayTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubtitleOverlayTransformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SubtitleOverlayTransformation FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
