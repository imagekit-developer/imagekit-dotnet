using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.GetImageAttributesOptionsProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    /// <summary>
    /// Custom list of **device-width breakpoints** in pixels. These define common
    /// screen widths for responsive image generation.
    ///
    /// Defaults to `[640, 750, 828, 1080, 1200, 1920, 2048, 3840]`. Sorted automatically.
    /// </summary>
    public List<double>? DeviceBreakpoints
    {
        get
        {
            if (!this.Properties.TryGetValue("deviceBreakpoints", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<double>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["deviceBreakpoints"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Custom list of **image-specific breakpoints** in pixels. Useful for generating
    /// small variants (e.g., placeholders or thumbnails).
    ///
    /// Merged with `deviceBreakpoints` before calculating `srcSet`. Defaults to `[16,
    /// 32, 48, 64, 96, 128, 256, 384]`. Sorted automatically.
    /// </summary>
    public List<double>? ImageBreakpoints
    {
        get
        {
            if (!this.Properties.TryGetValue("imageBreakpoints", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<double>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["imageBreakpoints"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The value for the HTML `sizes` attribute  (e.g., `"100vw"` or `"(min-width:768px)
    /// 50vw, 100vw"`).
    ///
    /// - If it includes one or more `vw` units, breakpoints smaller than the corresponding
    /// percentage of the smallest device width are excluded. - If it contains no
    /// `vw` units, the full breakpoint list is used.
    ///
    /// Enables a width-based strategy and generates `w` descriptors in `srcSet`.
    /// </summary>
    public string? Sizes
    {
        get
        {
            if (!this.Properties.TryGetValue("sizes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sizes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The intended display width of the image in pixels,  used **only when the
    /// `sizes` attribute is not provided**.
    ///
    /// Triggers a DPR-based strategy (1x and 2x variants) and generates `x` descriptors
    /// in `srcSet`.
    ///
    /// Ignored if `sizes` is present.
    /// </summary>
    public double? Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
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
        foreach (var item in this.DeviceBreakpoints ?? [])
        {
            _ = item;
        }
        foreach (var item in this.ImageBreakpoints ?? [])
        {
            _ = item;
        }
        _ = this.Sizes;
        _ = this.Width;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
