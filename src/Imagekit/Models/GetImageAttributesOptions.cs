using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

/// <summary>
/// Options for generating responsive image attributes including `src`, `srcSet`,
/// and `sizes` for HTML `<img>` elements.  This schema extends `SrcOptions` to add
/// support for responsive image generation with breakpoints.
/// </summary>
[JsonConverter(typeof(ModelConverter<GetImageAttributesOptions>))]
public sealed record class GetImageAttributesOptions
    : ModelBase,
        IFromRaw<GetImageAttributesOptions>
{
    /// <summary>
    /// Accepts a relative or absolute path of the resource. If a relative path is
    /// provided, it is appended to the `urlEndpoint`.  If an absolute path is provided,
    /// `urlEndpoint` is ignored.
    /// </summary>
    public required string Src
    {
        get
        {
            if (!this.Properties.TryGetValue("src", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'src' cannot be null",
                    new ArgumentOutOfRangeException("src", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'src' cannot be null",
                    new ArgumentNullException("src")
                );
        }
        set
        {
            this.Properties["src"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Get your urlEndpoint from the [ImageKit dashboard](https://imagekit.io/dashboard/url-endpoints).
    /// </summary>
    public required string URLEndpoint
    {
        get
        {
            if (!this.Properties.TryGetValue("urlEndpoint", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'urlEndpoint' cannot be null",
                    new ArgumentOutOfRangeException("urlEndpoint", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'urlEndpoint' cannot be null",
                    new ArgumentNullException("urlEndpoint")
                );
        }
        set
        {
            this.Properties["urlEndpoint"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// When you want the signed URL to expire, specified in seconds. If `expiresIn`
    /// is anything above 0,  the URL will always be signed even if `signed` is set
    /// to false. If not specified and `signed` is `true`, the signed URL will not
    /// expire (valid indefinitely).
    ///
    /// Example: Setting `expiresIn: 3600` will make the URL expire 1 hour from generation
    /// time. After the expiry time, the signed URL will no longer be valid and ImageKit
    /// will return  a 401 Unauthorized status code.
    ///
    /// [Learn more](https://imagekit.io/docs/media-delivery-basic-security#how-to-generate-signed-urls).
    /// </summary>
    public double? ExpiresIn
    {
        get
        {
            if (!this.Properties.TryGetValue("expiresIn", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expiresIn"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// These are additional query parameters that you want to add to the final URL.
    /// They can be any query parameters and not necessarily related to ImageKit.
    /// This is especially useful if you want to add a versioning parameter to your
    /// URLs.
    /// </summary>
    public Dictionary<string, string>? QueryParameters
    {
        get
        {
            if (!this.Properties.TryGetValue("queryParameters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, string>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["queryParameters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to sign the URL or not. Set this to `true` if you want to generate
    /// a signed URL.  If `signed` is `true` and `expiresIn` is not specified, the
    /// signed URL will not expire (valid indefinitely). Note: If `expiresIn` is set
    /// to any value above 0, the URL will always be signed regardless of this setting.
    /// [Learn more](https://imagekit.io/docs/media-delivery-basic-security#how-to-generate-signed-urls).
    /// </summary>
    public bool? Signed
    {
        get
        {
            if (!this.Properties.TryGetValue("signed", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["signed"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of objects specifying the transformations to be applied in the URL.
    /// If more than one transformation is specified, they are applied in the order
    /// they are specified as chained transformations. See [Chained transformations](https://imagekit.io/docs/transformations#chained-transformations).
    /// </summary>
    public List<Transformation>? Transformation
    {
        get
        {
            if (!this.Properties.TryGetValue("transformation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Transformation>?>(
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

    /// <summary>
    /// By default, the transformation string is added as a query parameter in the
    /// URL, e.g., `?tr=w-100,h-100`.  If you want to add the transformation string
    /// in the path of the URL, set this to `path`. Learn more in the [Transformations
    /// guide](https://imagekit.io/docs/transformations).
    /// </summary>
    public ApiEnum<string, TransformationPosition>? TransformationPosition
    {
        get
        {
            if (!this.Properties.TryGetValue("transformationPosition", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, TransformationPosition>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["transformationPosition"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public static implicit operator SrcOptions(
        GetImageAttributesOptions getImageAttributesOptions
    ) =>
        new()
        {
            Src = getImageAttributesOptions.Src,
            URLEndpoint = getImageAttributesOptions.URLEndpoint,
            ExpiresIn = getImageAttributesOptions.ExpiresIn,
            QueryParameters = getImageAttributesOptions.QueryParameters,
            Signed = getImageAttributesOptions.Signed,
            Transformation = getImageAttributesOptions.Transformation,
            TransformationPosition = getImageAttributesOptions.TransformationPosition,
        };

    public override void Validate()
    {
        _ = this.Src;
        _ = this.URLEndpoint;
        _ = this.ExpiresIn;
        _ = this.QueryParameters;
        _ = this.Signed;
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
        this.TransformationPosition?.Validate();
        _ = this.DeviceBreakpoints;
        _ = this.ImageBreakpoints;
        _ = this.Sizes;
        _ = this.Width;
    }

    public GetImageAttributesOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GetImageAttributesOptions(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static GetImageAttributesOptions FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
