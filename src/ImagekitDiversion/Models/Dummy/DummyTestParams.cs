using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using SavedExtensions = ImagekitDiversion.Models.SavedExtensions;
using SystemText = System.Text;

namespace ImagekitDiversion.Models.Dummy;

/// <summary>
/// Internal test endpoint for SDK generation purposes only. This endpoint demonstrates
/// usage of all shared models defined in the Stainless configuration and is not
/// intended for public consumption.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DummyTestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public BaseOverlay? BaseOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<BaseOverlay>("baseOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("baseOverlay", value);
        }
    }

    /// <summary>
    /// Configuration object for an extension (base extensions only, not saved extension references).
    /// </summary>
    public ExtensionConfig? ExtensionConfig
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ExtensionConfig>("extensionConfig");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("extensionConfig", value);
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public IReadOnlyList<ExtensionsItem>? Extensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ExtensionsItem>>(
                "extensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ExtensionsItem>?>(
                "extensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Options for generating responsive image attributes including `src`, `srcSet`,
    /// and `sizes` for HTML `&lt;img&gt;` elements.  This schema extends `SrcOptions`
    /// to add support for responsive image generation with breakpoints.
    /// </summary>
    public GetImageAttributesOptions? GetImageAttributesOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<GetImageAttributesOptions>(
                "getImageAttributesOptions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("getImageAttributesOptions", value);
        }
    }

    public ImageOverlay? ImageOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ImageOverlay>("imageOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("imageOverlay", value);
        }
    }

    /// <summary>
    /// Specifies an overlay to be applied on the parent image or video.  ImageKit
    /// supports overlays including images, text, videos, subtitles, and solid colors.
    /// See [Overlay using layers](https://imagekit.io/docs/transformations#overlay-using-layers).
    /// </summary>
    public Overlay? Overlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Overlay>("overlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overlay", value);
        }
    }

    public OverlayPosition? OverlayPosition
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OverlayPosition>("overlayPosition");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overlayPosition", value);
        }
    }

    public OverlayTiming? OverlayTiming
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<OverlayTiming>("overlayTiming");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("overlayTiming", value);
        }
    }

    /// <summary>
    /// Resulting set of attributes suitable for an HTML `&lt;img&gt;` element. Useful
    /// for enabling responsive image loading with `srcSet` and `sizes`.
    /// </summary>
    public ResponsiveImageAttributes? ResponsiveImageAttributes
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ResponsiveImageAttributes>(
                "responsiveImageAttributes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("responsiveImageAttributes", value);
        }
    }

    /// <summary>
    /// Saved extension object containing extension configuration.
    /// </summary>
    public SavedExtensions::SavedExtension? SavedExtensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SavedExtensions::SavedExtension>(
                "savedExtensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("savedExtensions", value);
        }
    }

    public SolidColorOverlay? SolidColorOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SolidColorOverlay>("solidColorOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("solidColorOverlay", value);
        }
    }

    public SolidColorOverlayTransformation? SolidColorOverlayTransformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SolidColorOverlayTransformation>(
                "solidColorOverlayTransformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("solidColorOverlayTransformation", value);
        }
    }

    /// <summary>
    /// Options for generating ImageKit URLs with transformations. See the [Transformations guide](https://imagekit.io/docs/transformations).
    /// </summary>
    public SrcOptions? SrcOptions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SrcOptions>("srcOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("srcOptions", value);
        }
    }

    /// <summary>
    /// Available streaming resolutions for [adaptive bitrate streaming](https://imagekit.io/docs/adaptive-bitrate-streaming)
    /// </summary>
    public ApiEnum<string, StreamingResolution>? StreamingResolution
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, StreamingResolution>>(
                "streamingResolution"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("streamingResolution", value);
        }
    }

    public SubtitleOverlay? SubtitleOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubtitleOverlay>("subtitleOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("subtitleOverlay", value);
        }
    }

    /// <summary>
    /// Subtitle styling options. [Learn more](https://imagekit.io/docs/add-overlays-on-videos#styling-controls-for-subtitles-layer)
    /// from the docs.
    /// </summary>
    public SubtitleOverlayTransformation? SubtitleOverlayTransformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SubtitleOverlayTransformation>(
                "subtitleOverlayTransformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("subtitleOverlayTransformation", value);
        }
    }

    public TextOverlay? TextOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TextOverlay>("textOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("textOverlay", value);
        }
    }

    public TextOverlayTransformation? TextOverlayTransformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<TextOverlayTransformation>(
                "textOverlayTransformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("textOverlayTransformation", value);
        }
    }

    /// <summary>
    /// The SDK provides easy-to-use names for transformations. These names are converted
    /// to the corresponding transformation string before being added to the URL.
    /// SDKs are updated regularly to support new transformations. If you want to
    /// use a transformation that is not supported by the SDK,  You can use the `raw`
    /// parameter to pass the transformation string directly. See the [Transformations documentation](https://imagekit.io/docs/transformations).
    /// </summary>
    public Transformation? Transformation
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Transformation>("transformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transformation", value);
        }
    }

    /// <summary>
    /// By default, the transformation string is added as a query parameter in the
    /// URL, e.g., `?tr=w-100,h-100`.  If you want to add the transformation string
    /// in the path of the URL, set this to `path`. Learn more in the [Transformations guide](https://imagekit.io/docs/transformations).
    /// </summary>
    public ApiEnum<string, TransformationPosition>? TransformationPosition
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TransformationPosition>>(
                "transformationPosition"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("transformationPosition", value);
        }
    }

    public VideoOverlay? VideoOverlay
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<VideoOverlay>("videoOverlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("videoOverlay", value);
        }
    }

    public DummyTestParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DummyTestParams(DummyTestParams dummyTestParams)
        : base(dummyTestParams)
    {
        this._rawBodyData = new(dummyTestParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DummyTestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DummyTestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DummyTestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DummyTestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/dummy/test")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            SystemText::Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

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
    /// <para>[Learn more](https://imagekit.io/docs/media-delivery-basic-security#how-to-generate-signed-urls).</para>
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
    /// This is especially useful if you want to add a versioning parameter to your URLs.
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
    /// in the path of the URL, set this to `path`. Learn more in the [Transformations guide](https://imagekit.io/docs/transformations).
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
    /// <para>Defaults to `[640, 750, 828, 1080, 1200, 1920, 2048, 3840]`. Sorted automatically.</para>
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
    /// to `[16, 32, 48, 64, 96, 128, 256, 384]`. Sorted automatically.</para>
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
    /// <para>Enables a width-based strategy and generates `w` descriptors in `srcSet`.</para>
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
    /// <para>Ignored if `sizes` is present.</para>
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

[JsonConverter(
    typeof(JsonModelConverter<
        GetImageAttributesOptionsGetImageAttributesOptions,
        GetImageAttributesOptionsGetImageAttributesOptionsFromRaw
    >)
)]
public sealed record class GetImageAttributesOptionsGetImageAttributesOptions : JsonModel
{
    /// <summary>
    /// Custom list of **device-width breakpoints** in pixels. These define common
    /// screen widths for responsive image generation.
    ///
    /// <para>Defaults to `[640, 750, 828, 1080, 1200, 1920, 2048, 3840]`. Sorted automatically.</para>
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
    /// to `[16, 32, 48, 64, 96, 128, 256, 384]`. Sorted automatically.</para>
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
    /// <para>Enables a width-based strategy and generates `w` descriptors in `srcSet`.</para>
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
    /// <para>Ignored if `sizes` is present.</para>
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

    public GetImageAttributesOptionsGetImageAttributesOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GetImageAttributesOptionsGetImageAttributesOptions(
        GetImageAttributesOptionsGetImageAttributesOptions getImageAttributesOptionsGetImageAttributesOptions
    )
        : base(getImageAttributesOptionsGetImageAttributesOptions) { }
#pragma warning restore CS8618

    public GetImageAttributesOptionsGetImageAttributesOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GetImageAttributesOptionsGetImageAttributesOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GetImageAttributesOptionsGetImageAttributesOptionsFromRaw.FromRawUnchecked"/>
    public static GetImageAttributesOptionsGetImageAttributesOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GetImageAttributesOptionsGetImageAttributesOptionsFromRaw
    : IFromRawJson<GetImageAttributesOptionsGetImageAttributesOptions>
{
    /// <inheritdoc/>
    public GetImageAttributesOptionsGetImageAttributesOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GetImageAttributesOptionsGetImageAttributesOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Resulting set of attributes suitable for an HTML `&lt;img&gt;` element. Useful
/// for enabling responsive image loading with `srcSet` and `sizes`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ResponsiveImageAttributes, ResponsiveImageAttributesFromRaw>)
)]
public sealed record class ResponsiveImageAttributes : JsonModel
{
    /// <summary>
    /// URL for the *largest* candidate (assigned to plain `src`).
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
    /// `sizes` returned (or synthesised as `100vw`).  The value for the HTML `sizes` attribute.
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
    /// Candidate set with `w` or `x` descriptors.  Multiple image URLs separated
    /// by commas, each with a descriptor.
    /// </summary>
    public string? SrcSet
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("srcSet");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("srcSet", value);
        }
    }

    /// <summary>
    /// Width as a number (if `width` was provided in the input options).
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
        _ = this.Src;
        _ = this.Sizes;
        _ = this.SrcSet;
        _ = this.Width;
    }

    public ResponsiveImageAttributes() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResponsiveImageAttributes(ResponsiveImageAttributes responsiveImageAttributes)
        : base(responsiveImageAttributes) { }
#pragma warning restore CS8618

    public ResponsiveImageAttributes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ResponsiveImageAttributes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ResponsiveImageAttributesFromRaw.FromRawUnchecked"/>
    public static ResponsiveImageAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ResponsiveImageAttributes(string src)
        : this()
    {
        this.Src = src;
    }
}

class ResponsiveImageAttributesFromRaw : IFromRawJson<ResponsiveImageAttributes>
{
    /// <inheritdoc/>
    public ResponsiveImageAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ResponsiveImageAttributes.FromRawUnchecked(rawData);
}

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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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

/// <summary>
/// Available streaming resolutions for [adaptive bitrate streaming](https://imagekit.io/docs/adaptive-bitrate-streaming)
/// </summary>
[JsonConverter(typeof(StreamingResolutionConverter))]
public enum StreamingResolution
{
    V240,
    V360,
    V480,
    V720,
    V1080,
    V1440,
    V2160,
}

sealed class StreamingResolutionConverter : JsonConverter<StreamingResolution>
{
    public override StreamingResolution Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "240" => StreamingResolution.V240,
            "360" => StreamingResolution.V360,
            "480" => StreamingResolution.V480,
            "720" => StreamingResolution.V720,
            "1080" => StreamingResolution.V1080,
            "1440" => StreamingResolution.V1440,
            "2160" => StreamingResolution.V2160,
            _ => (StreamingResolution)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamingResolution value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamingResolution.V240 => "240",
                StreamingResolution.V360 => "360",
                StreamingResolution.V480 => "480",
                StreamingResolution.V720 => "720",
                StreamingResolution.V1080 => "1080",
                StreamingResolution.V1440 => "1440",
                StreamingResolution.V2160 => "2160",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

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
    /// plain text.</para>
    /// </summary>
    public ApiEnum<string, Encoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Encoding>>("encoding");
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
    /// plain text.</para>
    /// </summary>
    public ApiEnum<string, Encoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Encoding>>("encoding");
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
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
/// - Remaining slashes within the path are replaced with `@@` when using plain text.</para>
/// </summary>
[JsonConverter(typeof(EncodingConverter))]
public enum Encoding
{
    Auto,
    Plain,
    Base64,
}

sealed class EncodingConverter : JsonConverter<Encoding>
{
    public override Encoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Encoding.Auto,
            "plain" => Encoding.Plain,
            "base64" => Encoding.Base64,
            _ => (Encoding)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Encoding value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Encoding.Auto => "auto",
                Encoding.Plain => "plain",
                Encoding.Base64 => "base64",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<TextOverlay, TextOverlayFromRaw>))]
public sealed record class TextOverlay : JsonModel
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
    /// Specifies the text to be displayed in the overlay. The SDK automatically
    /// handles special characters and encoding.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
    /// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
    /// (base64).  By default, the SDK selects the appropriate format based on the
    /// input text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method, the input text is always percent-encoded
    /// to ensure it is URL-safe.</para>
    /// </summary>
    public ApiEnum<string, TextOverlayTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
                "encoding"
            );
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
    /// Control styling of the text overlay. See [Text overlays](https://imagekit.io/docs/add-overlays-on-images#text-overlay).
    /// </summary>
    public IReadOnlyList<TextOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TextOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TextOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public static implicit operator BaseOverlay(TextOverlay textOverlay) =>
        new()
        {
            LayerMode = textOverlay.LayerMode,
            Position = textOverlay.Position,
            Timing = textOverlay.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextOverlay(TextOverlay textOverlay)
        : base(textOverlay) { }
#pragma warning restore CS8618

    public TextOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextOverlayFromRaw.FromRawUnchecked"/>
    public static TextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextOverlayFromRaw : IFromRawJson<TextOverlay>
{
    /// <inheritdoc/>
    public TextOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TextOverlay.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TextOverlayTextOverlay, TextOverlayTextOverlayFromRaw>))]
public sealed record class TextOverlayTextOverlay : JsonModel
{
    /// <summary>
    /// Specifies the text to be displayed in the overlay. The SDK automatically
    /// handles special characters and encoding.
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
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
    /// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
    /// (base64).  By default, the SDK selects the appropriate format based on the
    /// input text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
    ///  To always use plain text (`i-{input}`), set it to `plain`.
    ///
    /// <para>Regardless of the encoding method, the input text is always percent-encoded
    /// to ensure it is URL-safe.</para>
    /// </summary>
    public ApiEnum<string, TextOverlayTextOverlayEncoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TextOverlayTextOverlayEncoding>>(
                "encoding"
            );
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
    /// Control styling of the text overlay. See [Text overlays](https://imagekit.io/docs/add-overlays-on-images#text-overlay).
    /// </summary>
    public IReadOnlyList<TextOverlayTransformation>? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TextOverlayTransformation>>(
                "transformation"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TextOverlayTransformation>?>(
                "transformation",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public TextOverlayTextOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextOverlayTextOverlay(TextOverlayTextOverlay textOverlayTextOverlay)
        : base(textOverlayTextOverlay) { }
#pragma warning restore CS8618

    public TextOverlayTextOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextOverlayTextOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextOverlayTextOverlayFromRaw.FromRawUnchecked"/>
    public static TextOverlayTextOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextOverlayTextOverlay(string text)
        : this()
    {
        this.Text = text;
    }
}

class TextOverlayTextOverlayFromRaw : IFromRawJson<TextOverlayTextOverlay>
{
    /// <inheritdoc/>
    public TextOverlayTextOverlay FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextOverlayTextOverlay.FromRawUnchecked(rawData);
}

/// <summary>
/// Text can be included in the layer as either `i-{input}` (plain text) or `ie-{base64_encoded_input}`
/// (base64).  By default, the SDK selects the appropriate format based on the input
/// text.  To always use base64 (`ie-{base64}`), set this parameter to `base64`.
///  To always use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method, the input text is always percent-encoded
/// to ensure it is URL-safe.</para>
/// </summary>
[JsonConverter(typeof(TextOverlayTextOverlayEncodingConverter))]
public enum TextOverlayTextOverlayEncoding
{
    Auto,
    Plain,
    Base64,
}

sealed class TextOverlayTextOverlayEncodingConverter : JsonConverter<TextOverlayTextOverlayEncoding>
{
    public override TextOverlayTextOverlayEncoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => TextOverlayTextOverlayEncoding.Auto,
            "plain" => TextOverlayTextOverlayEncoding.Plain,
            "base64" => TextOverlayTextOverlayEncoding.Base64,
            _ => (TextOverlayTextOverlayEncoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TextOverlayTextOverlayEncoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TextOverlayTextOverlayEncoding.Auto => "auto",
                TextOverlayTextOverlayEncoding.Plain => "plain",
                TextOverlayTextOverlayEncoding.Base64 => "base64",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
