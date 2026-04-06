using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models;

/// <summary>
/// The SDK provides easy-to-use names for transformations. These names are converted
/// to the corresponding transformation string before being added to the URL. SDKs
/// are updated regularly to support new transformations. If you want to use a transformation
/// that is not supported by the SDK,  You can use the `raw` parameter to pass the
/// transformation string directly. See the [Transformations documentation](https://imagekit.io/docs/transformations).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transformation, TransformationFromRaw>))]
public sealed record class Transformation : JsonModel
{
    /// <summary>
    /// Uses AI to change the background. Provide a text prompt or a base64-encoded
    /// prompt,  e.g., `prompt-snow road` or `prompte-[urlencoded_base64_encoded_text]`.
    /// Not supported inside overlay. See [AI Change Background](https://imagekit.io/docs/ai-transformations#change-background-e-changebg).
    /// </summary>
    public string? AIChangeBackground
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aiChangeBackground");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiChangeBackground", value);
        }
    }

    /// <summary>
    /// Adds an AI-based drop shadow around a foreground object on a transparent
    /// or removed background.  Optionally, control the direction, elevation, and
    /// saturation of the light source (e.g., `az-45` to change light direction).
    /// Pass `true` for the default drop shadow, or provide a string for a custom
    /// drop shadow. Supported inside overlay. See [AI Drop Shadow](https://imagekit.io/docs/ai-transformations#ai-drop-shadow-e-dropshadow).
    /// </summary>
    public AIDropShadow? AIDropShadow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AIDropShadow>("aiDropShadow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiDropShadow", value);
        }
    }

    /// <summary>
    /// Uses AI to edit images based on a text prompt. Provide a text prompt or a
    /// base64-encoded prompt,  e.g., `prompt-snow road` or `prompte-[urlencoded_base64_encoded_text]`.
    /// Not supported inside overlay.     See [AI Edit](https://imagekit.io/docs/ai-transformations#edit-image-e-edit).
    /// </summary>
    public string? AIEdit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("aiEdit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiEdit", value);
        }
    }

    /// <summary>
    /// Applies ImageKit's in-house background removal.  Supported inside overlay.
    /// See [AI Background Removal](https://imagekit.io/docs/ai-transformations#imagekit-background-removal-e-bgremove).
    /// </summary>
    public ApiEnum<bool, AIRemoveBackground>? AIRemoveBackground
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AIRemoveBackground>>(
                "aiRemoveBackground"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiRemoveBackground", value);
        }
    }

    /// <summary>
    /// Uses third-party background removal.  Note: It is recommended to use aiRemoveBackground,
    /// ImageKit's in-house solution, which is more cost-effective. Supported inside
    /// overlay. See [External Background Removal](https://imagekit.io/docs/ai-transformations#background-removal-e-removedotbg).
    /// </summary>
    public ApiEnum<bool, AIRemoveBackgroundExternal>? AIRemoveBackgroundExternal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AIRemoveBackgroundExternal>>(
                "aiRemoveBackgroundExternal"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiRemoveBackgroundExternal", value);
        }
    }

    /// <summary>
    /// Performs AI-based retouching to improve faces or product shots. Not supported
    /// inside overlay. See [AI Retouch](https://imagekit.io/docs/ai-transformations#retouch-e-retouch).
    /// </summary>
    public ApiEnum<bool, AIRetouch>? AIRetouch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AIRetouch>>("aiRetouch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiRetouch", value);
        }
    }

    /// <summary>
    /// Upscales images beyond their original dimensions using AI. Not supported
    /// inside overlay. See [AI Upscale](https://imagekit.io/docs/ai-transformations#upscale-e-upscale).
    /// </summary>
    public ApiEnum<bool, AIUpscale>? AIUpscale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AIUpscale>>("aiUpscale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiUpscale", value);
        }
    }

    /// <summary>
    /// Generates a variation of an image using AI. This produces a new image with
    /// slight variations from the original,  such as changes in color, texture, and
    /// other visual elements, while preserving the structure and essence of the original
    /// image. Not supported inside overlay. See [AI Generate Variations](https://imagekit.io/docs/ai-transformations#generate-variations-of-an-image-e-genvar).
    /// </summary>
    public ApiEnum<bool, AIVariation>? AIVariation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, AIVariation>>("aiVariation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aiVariation", value);
        }
    }

    /// <summary>
    /// Specifies the aspect ratio for the output, e.g., "ar-4-3". Typically used
    /// with either width or height (but not both).  For example: aspectRatio = `4:3`,
    /// `4_3`, or an expression like `iar_div_2`. See [Image resize and crop – Aspect
    /// ratio](https://imagekit.io/docs/image-resize-and-crop#aspect-ratio---ar).
    /// </summary>
    public AspectRatio? AspectRatio
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AspectRatio>("aspectRatio");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aspectRatio", value);
        }
    }

    /// <summary>
    /// Specifies the audio codec, e.g., `aac`, `opus`, or `none`. See [Audio codec](https://imagekit.io/docs/video-optimization#audio-codec---ac).
    /// </summary>
    public ApiEnum<string, AudioCodec>? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudioCodec>>("audioCodec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audioCodec", value);
        }
    }

    /// <summary>
    /// Specifies the background to be used in conjunction with certain cropping strategies
    /// when resizing an image.  - A solid color: e.g., `red`, `F3F3F3`, `AAFF0010`.
    /// See [Solid color background](https://imagekit.io/docs/effects-and-enhancements#solid-color-background).
    /// - Dominant color: `dominant` extracts the dominant color from the image. See
    /// [Dominant color background](https://imagekit.io/docs/effects-and-enhancements#dominant-color-background).
    /// - Gradient: `gradient_dominant` or `gradient_dominant_2` creates a gradient
    /// using the dominant colors. Optionally specify palette size (2 or 4), e.g.,
    /// `gradient_dominant_4`. See [Gradient background](https://imagekit.io/docs/effects-and-enhancements#gradient-background).
    /// - A blurred background: e.g., `blurred`, `blurred_25_N15`, etc. See [Blurred
    /// background](https://imagekit.io/docs/effects-and-enhancements#blurred-background).
    /// - Expand the image boundaries using generative fill: `genfill`. Not supported
    /// inside overlay. Optionally, control the background scene by passing a text
    /// prompt:   `genfill[:-prompt-${text}]` or `genfill[:-prompte-${urlencoded_base64_encoded_text}]`.
    /// See [Generative fill background](https://imagekit.io/docs/ai-transformations#generative-fill-bg-genfill).
    /// </summary>
    public string? Background
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("background");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("background", value);
        }
    }

    /// <summary>
    /// Specifies the Gaussian blur level. Accepts an integer value between 1 and
    /// 100, or an expression like `bl-10`. See [Blur](https://imagekit.io/docs/effects-and-enhancements#blur---bl).
    /// </summary>
    public double? Blur
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("blur");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("blur", value);
        }
    }

    /// <summary>
    /// Adds a border to the output media. Accepts a string in the format `&lt;border-width&gt;_&lt;hex-code&gt;`
    ///  (e.g., `5_FFF000` for a 5px yellow border), or an expression like `ih_div_20_FF00FF`.
    /// See [Border](https://imagekit.io/docs/effects-and-enhancements#border---b).
    /// </summary>
    public string? Border
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("border");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("border", value);
        }
    }

    /// <summary>
    /// Indicates whether the output image should retain the original color profile.
    /// See [Color profile](https://imagekit.io/docs/image-optimization#color-profile---cp).
    /// </summary>
    public bool? ColorProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("colorProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("colorProfile", value);
        }
    }

    /// <summary>
    /// Replaces colors in the image. Supports three formats: - `toColor` - Replace
    /// dominant color with the specified color. - `toColor_tolerance` - Replace
    /// dominant color with specified tolerance (0-100). - `toColor_tolerance_fromColor`
    /// - Replace a specific color with another within tolerance range. Colors can
    /// be hex codes (e.g., `FF0022`) or names (e.g., `red`, `blue`). See [Color
    /// replacement](https://imagekit.io/docs/effects-and-enhancements#color-replace---cr).
    /// </summary>
    public string? ColorReplace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("colorReplace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("colorReplace", value);
        }
    }

    /// <summary>
    /// Automatically enhances the contrast of an image (contrast stretch). See [Contrast
    /// Stretch](https://imagekit.io/docs/effects-and-enhancements#contrast-stretch---e-contrast).
    /// </summary>
    public ApiEnum<bool, ContrastStretch>? ContrastStretch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, ContrastStretch>>(
                "contrastStretch"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contrastStretch", value);
        }
    }

    /// <summary>
    /// Crop modes for image resizing. See [Crop modes &amp; focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
    /// </summary>
    public ApiEnum<string, Crop>? Crop
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Crop>>("crop");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("crop", value);
        }
    }

    /// <summary>
    /// Additional crop modes for image resizing. See [Crop modes &amp; focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
    /// </summary>
    public ApiEnum<string, CropMode>? CropMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CropMode>>("cropMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cropMode", value);
        }
    }

    /// <summary>
    /// Specifies a fallback image if the resource is not found, e.g., a URL or file
    /// path. See [Default image](https://imagekit.io/docs/image-transformation#default-image---di).
    /// </summary>
    public string? DefaultImage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("defaultImage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultImage", value);
        }
    }

    /// <summary>
    /// Distorts the shape of an image. Supports two modes: - Perspective distortion:
    /// `p-x1_y1_x2_y2_x3_y3_x4_y4` changes the position of the four corners starting
    /// clockwise from top-left. - Arc distortion: `a-degrees` curves the image upwards
    /// (positive values) or downwards (negative values). See [Distort effect](https://imagekit.io/docs/effects-and-enhancements#distort---e-distort).
    /// </summary>
    public string? Distort
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("distort");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("distort", value);
        }
    }

    /// <summary>
    /// Accepts values between 0.1 and 5, or `auto` for automatic device pixel ratio
    /// (DPR) calculation. Also accepts arithmetic expressions. - Learn about [Arithmetic
    /// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// - See [DPR](https://imagekit.io/docs/image-resize-and-crop#dpr---dpr).
    /// </summary>
    public double? Dpr
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("dpr");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dpr", value);
        }
    }

    /// <summary>
    /// Specifies the duration (in seconds) for trimming videos, e.g., `5` or `10.5`.
    ///  Typically used with startOffset to indicate the length from the start offset.
    /// Arithmetic expressions are supported. See [Trim videos – Duration](https://imagekit.io/docs/trim-videos#duration---du).
    /// </summary>
    public TransformationDuration? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationDuration>("duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// Specifies the end offset (in seconds) for trimming videos, e.g., `5` or `10.5`.
    ///  Typically used with startOffset to define a time window. Arithmetic expressions
    /// are supported. See [Trim videos – End offset](https://imagekit.io/docs/trim-videos#end-offset---eo).
    /// </summary>
    public EndOffset? EndOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EndOffset>("endOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("endOffset", value);
        }
    }

    /// <summary>
    /// Flips or mirrors an image either horizontally, vertically, or both.  Acceptable
    /// values: `h` (horizontal), `v` (vertical), `h_v` (horizontal and vertical),
    /// or `v_h`. See [Flip](https://imagekit.io/docs/effects-and-enhancements#flip---fl).
    /// </summary>
    public ApiEnum<string, TransformationFlip>? Flip
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TransformationFlip>>("flip");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("flip", value);
        }
    }

    /// <summary>
    /// Refines padding and cropping behavior for pad resize, maintain ratio, and
    /// extract crop modes.  Supports manual positions and coordinate-based focus.
    /// With AI-based cropping, you can automatically keep key subjects in frame—such
    /// as faces or detected objects (e.g., `fo-face`, `fo-person`, `fo-car`)— while
    /// resizing. - See [Focus](https://imagekit.io/docs/image-resize-and-crop#focus---fo).
    /// - [Object aware cropping](https://imagekit.io/docs/image-resize-and-crop#object-aware-cropping---fo-object-name)
    /// </summary>
    public string? Focus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("focus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("focus", value);
        }
    }

    /// <summary>
    /// Specifies the output format for images or videos, e.g., `jpg`, `png`, `webp`,
    /// `mp4`, or `auto`.  You can also pass `orig` for images to return the original
    /// format. ImageKit automatically delivers images and videos in the optimal
    /// format based on device support unless overridden by the dashboard settings
    /// or the format parameter. See [Image format](https://imagekit.io/docs/image-optimization#format---f)
    /// and [Video format](https://imagekit.io/docs/video-optimization#format---f).
    /// </summary>
    public ApiEnum<string, Format>? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Format>>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// Creates a linear gradient with two colors. Pass `true` for a default gradient,
    /// or provide a string for a custom gradient. See [Gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
    /// </summary>
    public TransformationGradient? Gradient
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationGradient>("gradient");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gradient", value);
        }
    }

    /// <summary>
    /// Enables a grayscale effect for images. See [Grayscale](https://imagekit.io/docs/effects-and-enhancements#grayscale---e-grayscale).
    /// </summary>
    public ApiEnum<bool, Grayscale>? Grayscale
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<bool, Grayscale>>("grayscale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("grayscale", value);
        }
    }

    /// <summary>
    /// Specifies the height of the output. If a value between 0 and 1 is provided,
    /// it is treated as a percentage (e.g., `0.5` represents 50% of the original
    /// height).  You can also supply arithmetic expressions (e.g., `ih_mul_0.5`).
    /// Height transformation – [Images](https://imagekit.io/docs/image-resize-and-crop#height---h)
    /// · [Videos](https://imagekit.io/docs/video-resize-and-crop#height---h)
    /// </summary>
    public TransformationHeight? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationHeight>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Specifies whether the output image (in JPEG or PNG) should be compressed
    /// losslessly. See [Lossless compression](https://imagekit.io/docs/image-optimization#lossless-webp-and-png---lo).
    /// </summary>
    public bool? Lossless
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("lossless");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lossless", value);
        }
    }

    /// <summary>
    /// By default, ImageKit removes all metadata during automatic image compression.
    ///  Set this to true to preserve metadata. See [Image metadata](https://imagekit.io/docs/image-optimization#image-metadata---md).
    /// </summary>
    public bool? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metadata", value);
        }
    }

    /// <summary>
    /// Named transformation reference. See [Named transformations](https://imagekit.io/docs/transformations#named-transformations).
    /// </summary>
    public string? Named
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("named");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("named", value);
        }
    }

    /// <summary>
    /// Specifies the opacity level of the output image. See [Opacity](https://imagekit.io/docs/effects-and-enhancements#opacity---o).
    /// </summary>
    public double? Opacity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("opacity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("opacity", value);
        }
    }

    /// <summary>
    /// If set to true, serves the original file without applying any transformations.
    /// See [Deliver original file as-is](https://imagekit.io/docs/core-delivery-features#deliver-original-file-as-is---orig-true).
    /// </summary>
    public bool? Original
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("original");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("original", value);
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Overlay>("overlay");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("overlay", value);
        }
    }

    /// <summary>
    /// Extracts a specific page or frame from multi-page or layered files (PDF,
    /// PSD, AI).  For example, specify by number (e.g., `2`), a range (e.g., `3-4`
    /// for the 2nd and 3rd layers), or by name (e.g., `name-layer-4` for a PSD layer).
    /// See [Thumbnail extraction](https://imagekit.io/docs/vector-and-animated-images#get-thumbnail-from-psd-pdf-ai-eps-and-animated-files).
    /// </summary>
    public Page? Page
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Page>("page");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// Specifies whether the output JPEG image should be rendered progressively.
    /// Progressive loading begins with a low-quality,  pixelated version of the
    /// full image, which gradually improves to provide a faster perceived load time.
    /// See [Progressive images](https://imagekit.io/docs/image-optimization#progressive-image---pr).
    /// </summary>
    public bool? Progressive
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("progressive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("progressive", value);
        }
    }

    /// <summary>
    /// Specifies the quality of the output image for lossy formats such as JPEG,
    /// WebP, and AVIF.  A higher quality value results in a larger file size with
    /// better quality, while a lower value produces a smaller file size with reduced
    /// quality. See [Quality](https://imagekit.io/docs/image-optimization#quality---q).
    /// </summary>
    public double? Quality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("quality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quality", value);
        }
    }

    /// <summary>
    /// Specifies the corner radius for rounded corners. - Single value (positive
    /// integer): Applied to all corners (e.g., `20`). - `max`: Creates a circular
    /// or oval shape. - Per-corner array: Provide four underscore-separated values
    /// representing top-left, top-right, bottom-right, and bottom-left corners respectively
    /// (e.g., `10_20_30_40`). See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
    /// </summary>
    public TransformationRadius? Radius
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationRadius>("radius");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("radius", value);
        }
    }

    /// <summary>
    /// Pass any transformation not directly supported by the SDK.  This transformation
    /// string is appended to the URL as provided.
    /// </summary>
    public string? Raw
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("raw");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("raw", value);
        }
    }

    /// <summary>
    /// Specifies the rotation angle in degrees. Positive values rotate the image
    /// clockwise; you can also use, for example, `N40` for counterclockwise rotation
    ///  or `auto` to use the orientation specified in the image's EXIF data. For
    /// videos, only the following values are supported: 0, 90, 180, 270, or 360.
    /// See [Rotate](https://imagekit.io/docs/effects-and-enhancements#rotate---rt).
    /// </summary>
    public TransformationRotation? Rotation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationRotation>("rotation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rotation", value);
        }
    }

    /// <summary>
    /// Adds a shadow beneath solid objects in an image with a transparent background.
    ///  For AI-based drop shadows, refer to aiDropShadow. Pass `true` for a default
    /// shadow, or provide a string for a custom shadow. See [Shadow](https://imagekit.io/docs/effects-and-enhancements#shadow---e-shadow).
    /// </summary>
    public Shadow? Shadow
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Shadow>("shadow");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("shadow", value);
        }
    }

    /// <summary>
    /// Sharpens the input image, highlighting edges and finer details.  Pass `true`
    /// for default sharpening, or provide a numeric value for custom sharpening.
    /// See [Sharpen](https://imagekit.io/docs/effects-and-enhancements#sharpen---e-sharpen).
    /// </summary>
    public Sharpen? Sharpen
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Sharpen>("sharpen");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sharpen", value);
        }
    }

    /// <summary>
    /// Specifies the start offset (in seconds) for trimming videos, e.g., `5` or
    /// `10.5`.  Arithmetic expressions are also supported. See [Trim videos – Start
    /// offset](https://imagekit.io/docs/trim-videos#start-offset---so).
    /// </summary>
    public StartOffset? StartOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<StartOffset>("startOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startOffset", value);
        }
    }

    /// <summary>
    /// An array of resolutions for adaptive bitrate streaming, e.g., [`240`, `360`,
    /// `480`, `720`, `1080`]. See [Adaptive Bitrate Streaming](https://imagekit.io/docs/adaptive-bitrate-streaming).
    /// </summary>
    public IReadOnlyList<ApiEnum<string, StreamingResolution>>? StreamingResolutions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, StreamingResolution>>
            >("streamingResolutions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, StreamingResolution>>?>(
                "streamingResolutions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Useful for images with a solid or nearly solid background and a central object.
    /// This parameter trims the background,  leaving only the central object in the
    /// output image. See [Trim edges](https://imagekit.io/docs/effects-and-enhancements#trim-edges---t).
    /// </summary>
    public Trim? Trim
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Trim>("trim");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("trim", value);
        }
    }

    /// <summary>
    /// Applies Unsharp Masking (USM), an image sharpening technique.  Pass `true`
    /// for a default unsharp mask, or provide a string for a custom unsharp mask.
    /// See [Unsharp Mask](https://imagekit.io/docs/effects-and-enhancements#unsharp-mask---e-usm).
    /// </summary>
    public UnsharpMask? UnsharpMask
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UnsharpMask>("unsharpMask");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("unsharpMask", value);
        }
    }

    /// <summary>
    /// Specifies the video codec, e.g., `h264`, `vp9`, `av1`, or `none`. See [Video codec](https://imagekit.io/docs/video-optimization#video-codec---vc).
    /// </summary>
    public ApiEnum<string, VideoCodec>? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoCodec>>("videoCodec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("videoCodec", value);
        }
    }

    /// <summary>
    /// Specifies the width of the output. If a value between 0 and 1 is provided,
    /// it is treated as a percentage (e.g., `0.4` represents 40% of the original
    /// width).  You can also supply arithmetic expressions (e.g., `iw_div_2`). Width
    /// transformation – [Images](https://imagekit.io/docs/image-resize-and-crop#width---w)
    /// · [Videos](https://imagekit.io/docs/video-resize-and-crop#width---w)
    /// </summary>
    public TransformationWidth? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationWidth>("width");
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

    /// <summary>
    /// Focus using cropped image coordinates - X coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public TransformationX? X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationX>("x");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("x", value);
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - X center coordinate. See [Focus using
    /// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public TransformationXCenter? XCenter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationXCenter>("xCenter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("xCenter", value);
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - Y coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public TransformationY? Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationY>("y");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("y", value);
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - Y center coordinate. See [Focus using
    /// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public TransformationYCenter? YCenter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TransformationYCenter>("yCenter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("yCenter", value);
        }
    }

    /// <summary>
    /// Accepts a numeric value that determines how much to zoom in or out of the
    /// cropped area.  It should be used in conjunction with fo-face or fo-&lt;object_name&gt;.
    /// See [Zoom](https://imagekit.io/docs/image-resize-and-crop#zoom---z).
    /// </summary>
    public double? Zoom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("zoom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("zoom", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AIChangeBackground;
        this.AIDropShadow?.Validate();
        _ = this.AIEdit;
        this.AIRemoveBackground?.Validate();
        this.AIRemoveBackgroundExternal?.Validate();
        this.AIRetouch?.Validate();
        this.AIUpscale?.Validate();
        this.AIVariation?.Validate();
        this.AspectRatio?.Validate();
        this.AudioCodec?.Validate();
        _ = this.Background;
        _ = this.Blur;
        _ = this.Border;
        _ = this.ColorProfile;
        _ = this.ColorReplace;
        this.ContrastStretch?.Validate();
        this.Crop?.Validate();
        this.CropMode?.Validate();
        _ = this.DefaultImage;
        _ = this.Distort;
        _ = this.Dpr;
        this.Duration?.Validate();
        this.EndOffset?.Validate();
        this.Flip?.Validate();
        _ = this.Focus;
        this.Format?.Validate();
        this.Gradient?.Validate();
        this.Grayscale?.Validate();
        this.Height?.Validate();
        _ = this.Lossless;
        _ = this.Metadata;
        _ = this.Named;
        _ = this.Opacity;
        _ = this.Original;
        this.Overlay?.Validate();
        this.Page?.Validate();
        _ = this.Progressive;
        _ = this.Quality;
        this.Radius?.Validate();
        _ = this.Raw;
        this.Rotation?.Validate();
        this.Shadow?.Validate();
        this.Sharpen?.Validate();
        this.StartOffset?.Validate();
        foreach (var item in this.StreamingResolutions ?? [])
        {
            item.Validate();
        }
        this.Trim?.Validate();
        this.UnsharpMask?.Validate();
        this.VideoCodec?.Validate();
        this.Width?.Validate();
        this.X?.Validate();
        this.XCenter?.Validate();
        this.Y?.Validate();
        this.YCenter?.Validate();
        _ = this.Zoom;
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transformation(Transformation transformation)
        : base(transformation) { }
#pragma warning restore CS8618

    public Transformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformationFromRaw.FromRawUnchecked"/>
    public static Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TransformationFromRaw : IFromRawJson<Transformation>
{
    /// <inheritdoc/>
    public Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Adds an AI-based drop shadow around a foreground object on a transparent or removed
/// background.  Optionally, control the direction, elevation, and saturation of the
/// light source (e.g., `az-45` to change light direction). Pass `true` for the default
/// drop shadow, or provide a string for a custom drop shadow. Supported inside overlay.
/// See [AI Drop Shadow](https://imagekit.io/docs/ai-transformations#ai-drop-shadow-e-dropshadow).
/// </summary>
[JsonConverter(typeof(AIDropShadowConverter))]
public record class AIDropShadow : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AIDropShadow(AIDropShadowUnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AIDropShadow(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AIDropShadow(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AIDropShadowUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `AIDropShadowUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out AIDropShadowUnionMember0? value)
    {
        value = this.Value as AIDropShadowUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (AIDropShadowUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<AIDropShadowUnionMember0> true_, Action<string> @string)
    {
        switch (this.Value)
        {
            case AIDropShadowUnionMember0 value:
                true_(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of AIDropShadow"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (AIDropShadowUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<AIDropShadowUnionMember0, T> true_, Func<string, T> @string)
    {
        return this.Value switch
        {
            AIDropShadowUnionMember0 value => true_(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of AIDropShadow"
            ),
        };
    }

    public static implicit operator AIDropShadow(AIDropShadowUnionMember0 value) => new(value);

    public static implicit operator AIDropShadow(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of AIDropShadow"
            );
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(AIDropShadow? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            AIDropShadowUnionMember0 _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class AIDropShadowConverter : JsonConverter<AIDropShadow>
{
    public override AIDropShadow? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<AIDropShadowUnionMember0>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIDropShadow value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(AIDropShadowUnionMember0Converter))]
public record class AIDropShadowUnionMember0
{
    public JsonElement Element { get; private init; }

    public AIDropShadowUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal AIDropShadowUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new AIDropShadowUnionMember0())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'AIDropShadowUnionMember0'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(AIDropShadowUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class AIDropShadowUnionMember0Converter : JsonConverter<AIDropShadowUnionMember0>
{
    public override AIDropShadowUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIDropShadowUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Applies ImageKit's in-house background removal.  Supported inside overlay. See
/// [AI Background Removal](https://imagekit.io/docs/ai-transformations#imagekit-background-removal-e-bgremove).
/// </summary>
[JsonConverter(typeof(AIRemoveBackgroundConverter))]
public enum AIRemoveBackground
{
    True,
}

sealed class AIRemoveBackgroundConverter : JsonConverter<AIRemoveBackground>
{
    public override AIRemoveBackground Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRemoveBackground.True,
            _ => (AIRemoveBackground)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRemoveBackground value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRemoveBackground.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Uses third-party background removal.  Note: It is recommended to use aiRemoveBackground,
/// ImageKit's in-house solution, which is more cost-effective. Supported inside
/// overlay. See [External Background Removal](https://imagekit.io/docs/ai-transformations#background-removal-e-removedotbg).
/// </summary>
[JsonConverter(typeof(AIRemoveBackgroundExternalConverter))]
public enum AIRemoveBackgroundExternal
{
    True,
}

sealed class AIRemoveBackgroundExternalConverter : JsonConverter<AIRemoveBackgroundExternal>
{
    public override AIRemoveBackgroundExternal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRemoveBackgroundExternal.True,
            _ => (AIRemoveBackgroundExternal)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRemoveBackgroundExternal value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRemoveBackgroundExternal.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Performs AI-based retouching to improve faces or product shots. Not supported
/// inside overlay. See [AI Retouch](https://imagekit.io/docs/ai-transformations#retouch-e-retouch).
/// </summary>
[JsonConverter(typeof(AIRetouchConverter))]
public enum AIRetouch
{
    True,
}

sealed class AIRetouchConverter : JsonConverter<AIRetouch>
{
    public override AIRetouch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIRetouch.True,
            _ => (AIRetouch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIRetouch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIRetouch.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Upscales images beyond their original dimensions using AI. Not supported inside
/// overlay. See [AI Upscale](https://imagekit.io/docs/ai-transformations#upscale-e-upscale).
/// </summary>
[JsonConverter(typeof(AIUpscaleConverter))]
public enum AIUpscale
{
    True,
}

sealed class AIUpscaleConverter : JsonConverter<AIUpscale>
{
    public override AIUpscale Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIUpscale.True,
            _ => (AIUpscale)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIUpscale value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIUpscale.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Generates a variation of an image using AI. This produces a new image with slight
/// variations from the original,  such as changes in color, texture, and other visual
/// elements, while preserving the structure and essence of the original image. Not
/// supported inside overlay. See [AI Generate Variations](https://imagekit.io/docs/ai-transformations#generate-variations-of-an-image-e-genvar).
/// </summary>
[JsonConverter(typeof(AIVariationConverter))]
public enum AIVariation
{
    True,
}

sealed class AIVariationConverter : JsonConverter<AIVariation>
{
    public override AIVariation Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => AIVariation.True,
            _ => (AIVariation)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIVariation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIVariation.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the aspect ratio for the output, e.g., "ar-4-3". Typically used with
/// either width or height (but not both).  For example: aspectRatio = `4:3`, `4_3`,
/// or an expression like `iar_div_2`. See [Image resize and crop – Aspect ratio](https://imagekit.io/docs/image-resize-and-crop#aspect-ratio---ar).
/// </summary>
[JsonConverter(typeof(AspectRatioConverter))]
public record class AspectRatio : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AspectRatio(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AspectRatio(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AspectRatio(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of AspectRatio"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of AspectRatio"
            ),
        };
    }

    public static implicit operator AspectRatio(double value) => new(value);

    public static implicit operator AspectRatio(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of AspectRatio");
        }
    }

    public virtual bool Equals(AspectRatio? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class AspectRatioConverter : JsonConverter<AspectRatio>
{
    public override AspectRatio? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AspectRatio value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the audio codec, e.g., `aac`, `opus`, or `none`. See [Audio codec](https://imagekit.io/docs/video-optimization#audio-codec---ac).
/// </summary>
[JsonConverter(typeof(AudioCodecConverter))]
public enum AudioCodec
{
    Aac,
    Opus,
    None,
}

sealed class AudioCodecConverter : JsonConverter<AudioCodec>
{
    public override AudioCodec Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" => AudioCodec.Aac,
            "opus" => AudioCodec.Opus,
            "none" => AudioCodec.None,
            _ => (AudioCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudioCodec.Aac => "aac",
                AudioCodec.Opus => "opus",
                AudioCodec.None => "none",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Automatically enhances the contrast of an image (contrast stretch). See [Contrast
/// Stretch](https://imagekit.io/docs/effects-and-enhancements#contrast-stretch---e-contrast).
/// </summary>
[JsonConverter(typeof(ContrastStretchConverter))]
public enum ContrastStretch
{
    True,
}

sealed class ContrastStretchConverter : JsonConverter<ContrastStretch>
{
    public override ContrastStretch Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => ContrastStretch.True,
            _ => (ContrastStretch)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContrastStretch value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContrastStretch.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Crop modes for image resizing. See [Crop modes &amp; focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
/// </summary>
[JsonConverter(typeof(CropConverter))]
public enum Crop
{
    Force,
    AtMax,
    AtMaxEnlarge,
    AtLeast,
    MaintainRatio,
}

sealed class CropConverter : JsonConverter<Crop>
{
    public override Crop Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "force" => Crop.Force,
            "at_max" => Crop.AtMax,
            "at_max_enlarge" => Crop.AtMaxEnlarge,
            "at_least" => Crop.AtLeast,
            "maintain_ratio" => Crop.MaintainRatio,
            _ => (Crop)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Crop value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Crop.Force => "force",
                Crop.AtMax => "at_max",
                Crop.AtMaxEnlarge => "at_max_enlarge",
                Crop.AtLeast => "at_least",
                Crop.MaintainRatio => "maintain_ratio",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Additional crop modes for image resizing. See [Crop modes &amp; focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
/// </summary>
[JsonConverter(typeof(CropModeConverter))]
public enum CropMode
{
    PadResize,
    Extract,
    PadExtract,
}

sealed class CropModeConverter : JsonConverter<CropMode>
{
    public override CropMode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pad_resize" => CropMode.PadResize,
            "extract" => CropMode.Extract,
            "pad_extract" => CropMode.PadExtract,
            _ => (CropMode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, CropMode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CropMode.PadResize => "pad_resize",
                CropMode.Extract => "extract",
                CropMode.PadExtract => "pad_extract",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the duration (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Typically used with startOffset to indicate the length from the start offset.
/// Arithmetic expressions are supported. See [Trim videos – Duration](https://imagekit.io/docs/trim-videos#duration---du).
/// </summary>
[JsonConverter(typeof(TransformationDurationConverter))]
public record class TransformationDuration : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationDuration(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationDuration(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationDuration(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationDuration"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationDuration"
            ),
        };
    }

    public static implicit operator TransformationDuration(double value) => new(value);

    public static implicit operator TransformationDuration(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationDuration"
            );
        }
    }

    public virtual bool Equals(TransformationDuration? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationDurationConverter : JsonConverter<TransformationDuration>
{
    public override TransformationDuration? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationDuration value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the end offset (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Typically used with startOffset to define a time window. Arithmetic expressions
/// are supported. See [Trim videos – End offset](https://imagekit.io/docs/trim-videos#end-offset---eo).
/// </summary>
[JsonConverter(typeof(EndOffsetConverter))]
public record class EndOffset : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EndOffset(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EndOffset(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public EndOffset(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of EndOffset"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of EndOffset"
            ),
        };
    }

    public static implicit operator EndOffset(double value) => new(value);

    public static implicit operator EndOffset(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of EndOffset");
        }
    }

    public virtual bool Equals(EndOffset? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class EndOffsetConverter : JsonConverter<EndOffset>
{
    public override EndOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        EndOffset value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Flips or mirrors an image either horizontally, vertically, or both.  Acceptable
/// values: `h` (horizontal), `v` (vertical), `h_v` (horizontal and vertical), or
/// `v_h`. See [Flip](https://imagekit.io/docs/effects-and-enhancements#flip---fl).
/// </summary>
[JsonConverter(typeof(TransformationFlipConverter))]
public enum TransformationFlip
{
    H,
    V,
    HV,
    VH,
}

sealed class TransformationFlipConverter : JsonConverter<TransformationFlip>
{
    public override TransformationFlip Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h" => TransformationFlip.H,
            "v" => TransformationFlip.V,
            "h_v" => TransformationFlip.HV,
            "v_h" => TransformationFlip.VH,
            _ => (TransformationFlip)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationFlip value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TransformationFlip.H => "h",
                TransformationFlip.V => "v",
                TransformationFlip.HV => "h_v",
                TransformationFlip.VH => "v_h",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the output format for images or videos, e.g., `jpg`, `png`, `webp`,
/// `mp4`, or `auto`.  You can also pass `orig` for images to return the original
/// format. ImageKit automatically delivers images and videos in the optimal format
/// based on device support unless overridden by the dashboard settings or the format
/// parameter. See [Image format](https://imagekit.io/docs/image-optimization#format---f)
/// and [Video format](https://imagekit.io/docs/video-optimization#format---f).
/// </summary>
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Auto,
    Webp,
    Jpg,
    Jpeg,
    Png,
    Gif,
    Svg,
    Mp4,
    Webm,
    Avif,
    Orig,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => Format.Auto,
            "webp" => Format.Webp,
            "jpg" => Format.Jpg,
            "jpeg" => Format.Jpeg,
            "png" => Format.Png,
            "gif" => Format.Gif,
            "svg" => Format.Svg,
            "mp4" => Format.Mp4,
            "webm" => Format.Webm,
            "avif" => Format.Avif,
            "orig" => Format.Orig,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Auto => "auto",
                Format.Webp => "webp",
                Format.Jpg => "jpg",
                Format.Jpeg => "jpeg",
                Format.Png => "png",
                Format.Gif => "gif",
                Format.Svg => "svg",
                Format.Mp4 => "mp4",
                Format.Webm => "webm",
                Format.Avif => "avif",
                Format.Orig => "orig",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Creates a linear gradient with two colors. Pass `true` for a default gradient,
/// or provide a string for a custom gradient. See [Gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
/// </summary>
[JsonConverter(typeof(TransformationGradientConverter))]
public record class TransformationGradient : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationGradient(
        TransformationGradientUnionMember0 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationGradient(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationGradient(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TransformationGradientUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `TransformationGradientUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out TransformationGradientUnionMember0? value)
    {
        value = this.Value as TransformationGradientUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (TransformationGradientUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<TransformationGradientUnionMember0> true_, Action<string> @string)
    {
        switch (this.Value)
        {
            case TransformationGradientUnionMember0 value:
                true_(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationGradient"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (TransformationGradientUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<TransformationGradientUnionMember0, T> true_, Func<string, T> @string)
    {
        return this.Value switch
        {
            TransformationGradientUnionMember0 value => true_(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationGradient"
            ),
        };
    }

    public static implicit operator TransformationGradient(
        TransformationGradientUnionMember0 value
    ) => new(value);

    public static implicit operator TransformationGradient(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationGradient"
            );
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(TransformationGradient? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            TransformationGradientUnionMember0 _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationGradientConverter : JsonConverter<TransformationGradient>
{
    public override TransformationGradient? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TransformationGradientUnionMember0>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationGradient value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TransformationGradientUnionMember0Converter))]
public record class TransformationGradientUnionMember0
{
    public JsonElement Element { get; private init; }

    public TransformationGradientUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal TransformationGradientUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new TransformationGradientUnionMember0())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'TransformationGradientUnionMember0'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(TransformationGradientUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TransformationGradientUnionMember0Converter
    : JsonConverter<TransformationGradientUnionMember0>
{
    public override TransformationGradientUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationGradientUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Enables a grayscale effect for images. See [Grayscale](https://imagekit.io/docs/effects-and-enhancements#grayscale---e-grayscale).
/// </summary>
[JsonConverter(typeof(GrayscaleConverter))]
public enum Grayscale
{
    True,
}

sealed class GrayscaleConverter : JsonConverter<Grayscale>
{
    public override Grayscale Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<bool>(ref reader, options) switch
        {
            true => Grayscale.True,
            _ => (Grayscale)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Grayscale value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Grayscale.True => true,
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the height of the output. If a value between 0 and 1 is provided, it
/// is treated as a percentage (e.g., `0.5` represents 50% of the original height).
///  You can also supply arithmetic expressions (e.g., `ih_mul_0.5`). Height transformation
/// – [Images](https://imagekit.io/docs/image-resize-and-crop#height---h) · [Videos](https://imagekit.io/docs/video-resize-and-crop#height---h)
/// </summary>
[JsonConverter(typeof(TransformationHeightConverter))]
public record class TransformationHeight : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationHeight(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationHeight(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationHeight(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationHeight"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationHeight"
            ),
        };
    }

    public static implicit operator TransformationHeight(double value) => new(value);

    public static implicit operator TransformationHeight(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationHeight"
            );
        }
    }

    public virtual bool Equals(TransformationHeight? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationHeightConverter : JsonConverter<TransformationHeight>
{
    public override TransformationHeight? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationHeight value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Extracts a specific page or frame from multi-page or layered files (PDF, PSD,
/// AI).  For example, specify by number (e.g., `2`), a range (e.g., `3-4` for the
/// 2nd and 3rd layers), or by name (e.g., `name-layer-4` for a PSD layer). See [Thumbnail
/// extraction](https://imagekit.io/docs/vector-and-animated-images#get-thumbnail-from-psd-pdf-ai-eps-and-animated-files).
/// </summary>
[JsonConverter(typeof(PageConverter))]
public record class Page : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Page(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Page(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Page(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Page");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Page"),
        };
    }

    public static implicit operator Page(double value) => new(value);

    public static implicit operator Page(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Page");
        }
    }

    public virtual bool Equals(Page? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class PageConverter : JsonConverter<Page>
{
    public override Page? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Page value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Specifies the corner radius for rounded corners. - Single value (positive integer):
/// Applied to all corners (e.g., `20`). - `max`: Creates a circular or oval shape.
/// - Per-corner array: Provide four underscore-separated values representing top-left,
/// top-right, bottom-right, and bottom-left corners respectively (e.g., `10_20_30_40`).
/// See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
/// </summary>
[JsonConverter(typeof(TransformationRadiusConverter))]
public record class TransformationRadius : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationRadius(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationRadius(TransformationRadiusUnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationRadius(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationRadius(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TransformationRadiusUnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMax(out var value)) {
    ///     // `value` is of type `TransformationRadiusUnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMax([NotNullWhen(true)] out TransformationRadiusUnionMember1? value)
    {
        value = this.Value as TransformationRadiusUnionMember1;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (TransformationRadiusUnionMember1 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<double> @double,
        Action<TransformationRadiusUnionMember1> max,
        Action<string> @string
    )
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case TransformationRadiusUnionMember1 value:
                max(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationRadius"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (TransformationRadiusUnionMember1 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<double, T> @double,
        Func<TransformationRadiusUnionMember1, T> max,
        Func<string, T> @string
    )
    {
        return this.Value switch
        {
            double value => @double(value),
            TransformationRadiusUnionMember1 value => max(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationRadius"
            ),
        };
    }

    public static implicit operator TransformationRadius(double value) => new(value);

    public static implicit operator TransformationRadius(TransformationRadiusUnionMember1 value) =>
        new(value);

    public static implicit operator TransformationRadius(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationRadius"
            );
        }
        this.Switch((_) => { }, (max) => max.Validate(), (_) => { });
    }

    public virtual bool Equals(TransformationRadius? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            TransformationRadiusUnionMember1 _ => 1,
            string _ => 2,
            _ => -1,
        };
    }
}

sealed class TransformationRadiusConverter : JsonConverter<TransformationRadius>
{
    public override TransformationRadius? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TransformationRadiusUnionMember1>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationRadius value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TransformationRadiusUnionMember1Converter))]
public record class TransformationRadiusUnionMember1
{
    public JsonElement Element { get; private init; }

    public TransformationRadiusUnionMember1()
    {
        Element = JsonSerializer.SerializeToElement("max");
    }

    internal TransformationRadiusUnionMember1(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new TransformationRadiusUnionMember1())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'TransformationRadiusUnionMember1'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(TransformationRadiusUnionMember1? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TransformationRadiusUnionMember1Converter : JsonConverter<TransformationRadiusUnionMember1>
{
    public override TransformationRadiusUnionMember1? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationRadiusUnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Specifies the rotation angle in degrees. Positive values rotate the image clockwise;
/// you can also use, for example, `N40` for counterclockwise rotation  or `auto`
/// to use the orientation specified in the image's EXIF data. For videos, only the
/// following values are supported: 0, 90, 180, 270, or 360. See [Rotate](https://imagekit.io/docs/effects-and-enhancements#rotate---rt).
/// </summary>
[JsonConverter(typeof(TransformationRotationConverter))]
public record class TransformationRotation : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationRotation(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationRotation(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationRotation(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationRotation"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationRotation"
            ),
        };
    }

    public static implicit operator TransformationRotation(double value) => new(value);

    public static implicit operator TransformationRotation(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationRotation"
            );
        }
    }

    public virtual bool Equals(TransformationRotation? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationRotationConverter : JsonConverter<TransformationRotation>
{
    public override TransformationRotation? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationRotation value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Adds a shadow beneath solid objects in an image with a transparent background.
///  For AI-based drop shadows, refer to aiDropShadow. Pass `true` for a default shadow,
/// or provide a string for a custom shadow. See [Shadow](https://imagekit.io/docs/effects-and-enhancements#shadow---e-shadow).
/// </summary>
[JsonConverter(typeof(ShadowConverter))]
public record class Shadow : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Shadow(ShadowUnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Shadow(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Shadow(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ShadowUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `ShadowUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out ShadowUnionMember0? value)
    {
        value = this.Value as ShadowUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (ShadowUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<ShadowUnionMember0> true_, Action<string> @string)
    {
        switch (this.Value)
        {
            case ShadowUnionMember0 value:
                true_(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Shadow");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (ShadowUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<ShadowUnionMember0, T> true_, Func<string, T> @string)
    {
        return this.Value switch
        {
            ShadowUnionMember0 value => true_(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Shadow"),
        };
    }

    public static implicit operator Shadow(ShadowUnionMember0 value) => new(value);

    public static implicit operator Shadow(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Shadow");
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(Shadow? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            ShadowUnionMember0 _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class ShadowConverter : JsonConverter<Shadow>
{
    public override Shadow? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ShadowUnionMember0>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Shadow value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(ShadowUnionMember0Converter))]
public record class ShadowUnionMember0
{
    public JsonElement Element { get; private init; }

    public ShadowUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal ShadowUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new ShadowUnionMember0())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'ShadowUnionMember0'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(ShadowUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class ShadowUnionMember0Converter : JsonConverter<ShadowUnionMember0>
{
    public override ShadowUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        ShadowUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Sharpens the input image, highlighting edges and finer details.  Pass `true` for
/// default sharpening, or provide a numeric value for custom sharpening. See [Sharpen](https://imagekit.io/docs/effects-and-enhancements#sharpen---e-sharpen).
/// </summary>
[JsonConverter(typeof(SharpenConverter))]
public record class Sharpen : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Sharpen(SharpenUnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Sharpen(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Sharpen(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SharpenUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `SharpenUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out SharpenUnionMember0? value)
    {
        value = this.Value as SharpenUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (SharpenUnionMember0 value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<SharpenUnionMember0> true_, Action<double> @double)
    {
        switch (this.Value)
        {
            case SharpenUnionMember0 value:
                true_(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Sharpen");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (SharpenUnionMember0 value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<SharpenUnionMember0, T> true_, Func<double, T> @double)
    {
        return this.Value switch
        {
            SharpenUnionMember0 value => true_(value),
            double value => @double(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of Sharpen"
            ),
        };
    }

    public static implicit operator Sharpen(SharpenUnionMember0 value) => new(value);

    public static implicit operator Sharpen(double value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Sharpen");
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(Sharpen? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            SharpenUnionMember0 _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class SharpenConverter : JsonConverter<Sharpen>
{
    public override Sharpen? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<SharpenUnionMember0>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Sharpen value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SharpenUnionMember0Converter))]
public record class SharpenUnionMember0
{
    public JsonElement Element { get; private init; }

    public SharpenUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal SharpenUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new SharpenUnionMember0())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'SharpenUnionMember0'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(SharpenUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class SharpenUnionMember0Converter : JsonConverter<SharpenUnionMember0>
{
    public override SharpenUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        SharpenUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Specifies the start offset (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Arithmetic expressions are also supported. See [Trim videos – Start offset](https://imagekit.io/docs/trim-videos#start-offset---so).
/// </summary>
[JsonConverter(typeof(StartOffsetConverter))]
public record class StartOffset : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public StartOffset(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StartOffset(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public StartOffset(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of StartOffset"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of StartOffset"
            ),
        };
    }

    public static implicit operator StartOffset(double value) => new(value);

    public static implicit operator StartOffset(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of StartOffset");
        }
    }

    public virtual bool Equals(StartOffset? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class StartOffsetConverter : JsonConverter<StartOffset>
{
    public override StartOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartOffset value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Useful for images with a solid or nearly solid background and a central object.
/// This parameter trims the background,  leaving only the central object in the
/// output image. See [Trim edges](https://imagekit.io/docs/effects-and-enhancements#trim-edges---t).
/// </summary>
[JsonConverter(typeof(TrimConverter))]
public record class Trim : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Trim(TrimUnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Trim(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Trim(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TrimUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `TrimUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out TrimUnionMember0? value)
    {
        value = this.Value as TrimUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (TrimUnionMember0 value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<TrimUnionMember0> true_, Action<double> @double)
    {
        switch (this.Value)
        {
            case TrimUnionMember0 value:
                true_(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new ImageKitInvalidDataException("Data did not match any variant of Trim");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (TrimUnionMember0 value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<TrimUnionMember0, T> true_, Func<double, T> @double)
    {
        return this.Value switch
        {
            TrimUnionMember0 value => true_(value),
            double value => @double(value),
            _ => throw new ImageKitInvalidDataException("Data did not match any variant of Trim"),
        };
    }

    public static implicit operator Trim(TrimUnionMember0 value) => new(value);

    public static implicit operator Trim(double value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Trim");
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(Trim? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            TrimUnionMember0 _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<TrimUnionMember0>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Trim value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TrimUnionMember0Converter))]
public record class TrimUnionMember0
{
    public JsonElement Element { get; private init; }

    public TrimUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal TrimUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new TrimUnionMember0())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'TrimUnionMember0'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(TrimUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class TrimUnionMember0Converter : JsonConverter<TrimUnionMember0>
{
    public override TrimUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrimUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Applies Unsharp Masking (USM), an image sharpening technique.  Pass `true` for
/// a default unsharp mask, or provide a string for a custom unsharp mask. See [Unsharp
/// Mask](https://imagekit.io/docs/effects-and-enhancements#unsharp-mask---e-usm).
/// </summary>
[JsonConverter(typeof(UnsharpMaskConverter))]
public record class UnsharpMask : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public UnsharpMask(UnsharpMaskUnionMember0 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsharpMask(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsharpMask(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnsharpMaskUnionMember0"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrue(out var value)) {
    ///     // `value` is of type `UnsharpMaskUnionMember0`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrue([NotNullWhen(true)] out UnsharpMaskUnionMember0? value)
    {
        value = this.Value as UnsharpMaskUnionMember0;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (UnsharpMaskUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<UnsharpMaskUnionMember0> true_, Action<string> @string)
    {
        switch (this.Value)
        {
            case UnsharpMaskUnionMember0 value:
                true_(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnsharpMask"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (UnsharpMaskUnionMember0 value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<UnsharpMaskUnionMember0, T> true_, Func<string, T> @string)
    {
        return this.Value switch
        {
            UnsharpMaskUnionMember0 value => true_(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnsharpMask"
            ),
        };
    }

    public static implicit operator UnsharpMask(UnsharpMaskUnionMember0 value) => new(value);

    public static implicit operator UnsharpMask(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of UnsharpMask");
        }
        this.Switch((true_) => true_.Validate(), (_) => { });
    }

    public virtual bool Equals(UnsharpMask? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            UnsharpMaskUnionMember0 _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class UnsharpMaskConverter : JsonConverter<UnsharpMask>
{
    public override UnsharpMask? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnsharpMaskUnionMember0>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsharpMask value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnsharpMaskUnionMember0Converter))]
public record class UnsharpMaskUnionMember0
{
    public JsonElement Element { get; private init; }

    public UnsharpMaskUnionMember0()
    {
        Element = JsonSerializer.SerializeToElement(true);
    }

    internal UnsharpMaskUnionMember0(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UnsharpMaskUnionMember0())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UnsharpMaskUnionMember0'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UnsharpMaskUnionMember0? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UnsharpMaskUnionMember0Converter : JsonConverter<UnsharpMaskUnionMember0>
{
    public override UnsharpMaskUnionMember0? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsharpMaskUnionMember0 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

/// <summary>
/// Specifies the video codec, e.g., `h264`, `vp9`, `av1`, or `none`. See [Video codec](https://imagekit.io/docs/video-optimization#video-codec---vc).
/// </summary>
[JsonConverter(typeof(VideoCodecConverter))]
public enum VideoCodec
{
    H264,
    Vp9,
    Av1,
    None,
}

sealed class VideoCodecConverter : JsonConverter<VideoCodec>
{
    public override VideoCodec Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" => VideoCodec.H264,
            "vp9" => VideoCodec.Vp9,
            "av1" => VideoCodec.Av1,
            "none" => VideoCodec.None,
            _ => (VideoCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoCodec.H264 => "h264",
                VideoCodec.Vp9 => "vp9",
                VideoCodec.Av1 => "av1",
                VideoCodec.None => "none",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Specifies the width of the output. If a value between 0 and 1 is provided, it
/// is treated as a percentage (e.g., `0.4` represents 40% of the original width).
///  You can also supply arithmetic expressions (e.g., `iw_div_2`). Width transformation
/// – [Images](https://imagekit.io/docs/image-resize-and-crop#width---w) · [Videos](https://imagekit.io/docs/video-resize-and-crop#width---w)
/// </summary>
[JsonConverter(typeof(TransformationWidthConverter))]
public record class TransformationWidth : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationWidth(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationWidth(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationWidth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationWidth"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationWidth"
            ),
        };
    }

    public static implicit operator TransformationWidth(double value) => new(value);

    public static implicit operator TransformationWidth(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationWidth"
            );
        }
    }

    public virtual bool Equals(TransformationWidth? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationWidthConverter : JsonConverter<TransformationWidth>
{
    public override TransformationWidth? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationWidth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Focus using cropped image coordinates - X coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(TransformationXConverter))]
public record class TransformationX : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationX(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationX(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationX(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationX"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationX"
            ),
        };
    }

    public static implicit operator TransformationX(double value) => new(value);

    public static implicit operator TransformationX(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationX"
            );
        }
    }

    public virtual bool Equals(TransformationX? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationXConverter : JsonConverter<TransformationX>
{
    public override TransformationX? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationX value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Focus using cropped image coordinates - X center coordinate. See [Focus using
/// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(TransformationXCenterConverter))]
public record class TransformationXCenter : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationXCenter(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationXCenter(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationXCenter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationXCenter"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationXCenter"
            ),
        };
    }

    public static implicit operator TransformationXCenter(double value) => new(value);

    public static implicit operator TransformationXCenter(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationXCenter"
            );
        }
    }

    public virtual bool Equals(TransformationXCenter? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationXCenterConverter : JsonConverter<TransformationXCenter>
{
    public override TransformationXCenter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationXCenter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Focus using cropped image coordinates - Y coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(TransformationYConverter))]
public record class TransformationY : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationY(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationY(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationY(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationY"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationY"
            ),
        };
    }

    public static implicit operator TransformationY(double value) => new(value);

    public static implicit operator TransformationY(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationY"
            );
        }
    }

    public virtual bool Equals(TransformationY? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationYConverter : JsonConverter<TransformationY>
{
    public override TransformationY? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationY value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Focus using cropped image coordinates - Y center coordinate. See [Focus using
/// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(TransformationYCenterConverter))]
public record class TransformationYCenter : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public TransformationYCenter(double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationYCenter(string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public TransformationYCenter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="double"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDouble(out var value)) {
    ///     // `value` is of type `double`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="string"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickString(out var value)) {
    ///     // `value` is of type `string`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of TransformationYCenter"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (double value) =&gt; {...},
    ///     (string value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            double value => @double(value),
            string value => @string(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationYCenter"
            ),
        };
    }

    public static implicit operator TransformationYCenter(double value) => new(value);

    public static implicit operator TransformationYCenter(string value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of TransformationYCenter"
            );
        }
    }

    public virtual bool Equals(TransformationYCenter? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            double _ => 0,
            string _ => 1,
            _ => -1,
        };
    }
}

sealed class TransformationYCenterConverter : JsonConverter<TransformationYCenter>
{
    public override TransformationYCenter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransformationYCenter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
