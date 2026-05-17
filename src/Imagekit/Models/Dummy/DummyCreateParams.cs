using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Imagekit.Core;
using Text = System.Text;

namespace Imagekit.Models.Dummy;

/// <summary>
/// Internal test endpoint for SDK generation purposes only. This endpoint demonstrates
/// usage of all shared models defined in the Stainless configuration and is not
/// intended for public consumption.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DummyCreateParams : ParamsBase
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
    public IReadOnlyList<ExtensionItem>? Extensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ExtensionItem>>("extensions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ExtensionItem>?>(
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
    public SharedSavedExtension? SavedExtensions
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SharedSavedExtension>("savedExtensions");
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
    /// parameter to pass the transformation string directly. See the [Transformations
    /// documentation](https://imagekit.io/docs/transformations).
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
    /// in the path of the URL, set this to `path`. Learn more in the [Transformations
    /// guide](https://imagekit.io/docs/transformations).
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

    public DummyCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DummyCreateParams(DummyCreateParams dummyCreateParams)
        : base(dummyCreateParams)
    {
        this._rawBodyData = new(dummyCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public DummyCreateParams(
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
    DummyCreateParams(
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
    public static DummyCreateParams FromRawUnchecked(
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

    public virtual bool Equals(DummyCreateParams? other)
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
            Text::Encoding.UTF8,
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
