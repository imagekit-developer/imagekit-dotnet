using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models;

/// <summary>
/// Options for generating responsive image attributes including `src`, `srcSet`,
/// and `sizes` for HTML `&lt;img&gt;` elements.  This schema extends `SrcOptions`
/// to add support for responsive image generation with breakpoints.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<GetImageAttributesOptions, GetImageAttributesOptionsFromRaw>)
)]
public sealed record class GetImageAttributesOptions : JsonModel
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
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("src");
        }
        init { this._rawData.Set("src", value); }
    }

    /// <summary>
    /// Get your urlEndpoint from the [ImageKit dashboard](https://imagekit.io/dashboard/url-endpoints).
    /// </summary>
    public required string UrlEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("urlEndpoint");
        }
        init { this._rawData.Set("urlEndpoint", value); }
    }

    /// <summary>
    /// When you want the signed URL to expire, specified in seconds. If `expiresIn`
    /// is anything above 0,  the URL will always be signed even if `signed` is set
    /// to false. If not specified and `signed` is `true`, the signed URL will not
    /// expire (valid indefinitely).
    ///
    /// <para>Example: Setting `expiresIn: 3600` will make the URL expire 1 hour from
    /// generation time. After the expiry time, the signed URL will no longer be valid
    /// and ImageKit will return  a 401 Unauthorized status code.</para>
    ///
    /// <para>[Learn more](https://imagekit.io/docs/media-delivery-basic-security#how-to-generate-signed-urls). </para>
    /// </summary>
    public double? ExpiresIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("expiresIn");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("expiresIn", value);
        }
    }

    /// <summary>
    /// These are additional query parameters that you want to add to the final URL.
    /// They can be any query parameters and not necessarily related to ImageKit.
    /// This is especially useful if you want to add a versioning parameter to your
    /// URLs.
    /// </summary>
    public IReadOnlyDictionary<string, string>? QueryParameters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "queryParameters"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "queryParameters",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Whether to sign the URL or not. Set this to `true` if you want to generate
    /// a signed URL.  If `signed` is `true` and `expiresIn` is not specified, the
    /// signed URL will not expire (valid indefinitely). Note: If `expiresIn` is
    /// set to any value above 0, the URL will always be signed regardless of this
    /// setting. [Learn more](https://imagekit.io/docs/media-delivery-basic-security#how-to-generate-signed-urls).
    /// </summary>
    public bool? Signed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("signed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("signed", value);
        }
    }

    /// <summary>
    /// An array of objects specifying the transformations to be applied in the URL.
    /// If more than one transformation is specified, they are applied in the order
    /// they are specified as chained transformations. See [Chained transformations](https://imagekit.io/docs/transformations#chained-transformations).
    /// </summary>
    public IReadOnlyList<Transformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Transformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Transformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransformationPosition>>(
                "transformationPosition"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformationPosition", value);
        }
    }

    /// <summary>
    /// Custom list of **device-width breakpoints** in pixels. These define common
    /// screen widths for responsive image generation.
    ///
    /// <para>Defaults to `[640, 750, 828, 1080, 1200, 1920, 2048, 3840]`. Sorted
    /// automatically. </para>
    /// </summary>
    public IReadOnlyList<double>? DeviceBreakpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("deviceBreakpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "deviceBreakpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom list of **image-specific breakpoints** in pixels. Useful for generating
    /// small variants (e.g., placeholders or thumbnails).
    ///
    /// <para>Merged with `deviceBreakpoints` before calculating `srcSet`. Defaults
    /// to `[16, 32, 48, 64, 96, 128, 256, 384]`. Sorted automatically. </para>
    /// </summary>
    public IReadOnlyList<double>? ImageBreakpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("imageBreakpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "imageBreakpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The value for the HTML `sizes` attribute  (e.g., `"100vw"` or `"(min-width:768px)
    /// 50vw, 100vw"`).
    ///
    /// <para>- If it includes one or more `vw` units, breakpoints smaller than the
    /// corresponding percentage of the smallest device width are excluded. - If
    /// it contains no `vw` units, the full breakpoint list is used.</para>
    ///
    /// <para>Enables a width-based strategy and generates `w` descriptors in `srcSet`. </para>
    /// </summary>
    public string? Sizes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sizes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizes", value);
        }
    }

    /// <summary>
    /// The intended display width of the image in pixels,  used **only when the `sizes`
    /// attribute is not provided**.
    ///
    /// <para>Triggers a DPR-based strategy (1x and 2x variants) and generates `x`
    /// descriptors in `srcSet`.</para>
    ///
    /// <para>Ignored if `sizes` is present. </para>
    /// </summary>
    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    public static implicit operator SrcOptions(
        GetImageAttributesOptions getImageAttributesOptions
    ) =>
        new()
        {
            Src = getImageAttributesOptions.Src,
            UrlEndpoint = getImageAttributesOptions.UrlEndpoint,
            ExpiresIn = getImageAttributesOptions.ExpiresIn,
            QueryParameters = getImageAttributesOptions.QueryParameters,
            Signed = getImageAttributesOptions.Signed,
            Transformation = getImageAttributesOptions.Transformation,
            TransformationPosition = getImageAttributesOptions.TransformationPosition,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Src;
        _ = this.UrlEndpoint;
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
    public GetImageAttributesOptions(GetImageAttributesOptions getImageAttributesOptions)
        : base(getImageAttributesOptions) { }
#pragma warning restore CS8618

    public GetImageAttributesOptions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GetImageAttributesOptions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GetImageAttributesOptionsFromRaw.FromRawUnchecked"/>
    public static GetImageAttributesOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GetImageAttributesOptionsFromRaw : IFromRawJson<GetImageAttributesOptions>
{
    /// <inheritdoc/>
    public GetImageAttributesOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GetImageAttributesOptions.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// Custom list of **device-width breakpoints** in pixels. These define common
    /// screen widths for responsive image generation.
    ///
    /// <para>Defaults to `[640, 750, 828, 1080, 1200, 1920, 2048, 3840]`. Sorted
    /// automatically. </para>
    /// </summary>
    public IReadOnlyList<double>? DeviceBreakpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("deviceBreakpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "deviceBreakpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom list of **image-specific breakpoints** in pixels. Useful for generating
    /// small variants (e.g., placeholders or thumbnails).
    ///
    /// <para>Merged with `deviceBreakpoints` before calculating `srcSet`. Defaults
    /// to `[16, 32, 48, 64, 96, 128, 256, 384]`. Sorted automatically. </para>
    /// </summary>
    public IReadOnlyList<double>? ImageBreakpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("imageBreakpoints");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "imageBreakpoints",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The value for the HTML `sizes` attribute  (e.g., `"100vw"` or `"(min-width:768px)
    /// 50vw, 100vw"`).
    ///
    /// <para>- If it includes one or more `vw` units, breakpoints smaller than the
    /// corresponding percentage of the smallest device width are excluded. - If
    /// it contains no `vw` units, the full breakpoint list is used.</para>
    ///
    /// <para>Enables a width-based strategy and generates `w` descriptors in `srcSet`. </para>
    /// </summary>
    public string? Sizes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sizes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sizes", value);
        }
    }

    /// <summary>
    /// The intended display width of the image in pixels,  used **only when the `sizes`
    /// attribute is not provided**.
    ///
    /// <para>Triggers a DPR-based strategy (1x and 2x variants) and generates `x`
    /// descriptors in `srcSet`.</para>
    ///
    /// <para>Ignored if `sizes` is present. </para>
    /// </summary>
    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeviceBreakpoints;
        _ = this.ImageBreakpoints;
        _ = this.Sizes;
        _ = this.Width;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}
