using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.TransformationProperties;

namespace Imagekit.Models;

/// <summary>
/// The SDK provides easy-to-use names for transformations. These names are converted
/// to the corresponding transformation string before being added to the URL. SDKs
/// are updated regularly to support new transformations. If you want to use a transformation
/// that is not supported by the SDK,  You can use the `raw` parameter to pass the
/// transformation string directly. See the [Transformations documentation](https://imagekit.io/docs/transformations).
/// </summary>
[JsonConverter(typeof(ModelConverter<Transformation>))]
public sealed record class Transformation : ModelBase, IFromRaw<Transformation>
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
            if (!this.Properties.TryGetValue("aiChangeBackground", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["aiChangeBackground"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Adds an AI-based drop shadow around a foreground object on a transparent or
    /// removed background.  Optionally, control the direction, elevation, and saturation
    /// of the light source (e.g., `az-45` to change light direction). Pass `true`
    /// for the default drop shadow, or provide a string for a custom drop shadow.
    /// Supported inside overlay. See [AI Drop Shadow](https://imagekit.io/docs/ai-transformations#ai-drop-shadow-e-dropshadow).
    /// </summary>
    public AIDropShadow? AIDropShadow
    {
        get
        {
            if (!this.Properties.TryGetValue("aiDropShadow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AIDropShadow?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["aiDropShadow"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("aiEdit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["aiEdit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("aiRemoveBackground", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackground>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aiRemoveBackground"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("aiRemoveBackgroundExternal", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AIRemoveBackgroundExternal>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aiRemoveBackgroundExternal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("aiRetouch", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AIRetouch>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aiRetouch"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Upscales images beyond their original dimensions using AI. Not supported inside
    /// overlay. See [AI Upscale](https://imagekit.io/docs/ai-transformations#upscale-e-upscale).
    /// </summary>
    public ApiEnum<bool, AIUpscale>? AIUpscale
    {
        get
        {
            if (!this.Properties.TryGetValue("aiUpscale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AIUpscale>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aiUpscale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Generates a variation of an image using AI. This produces a new image with
    /// slight variations from the original,  such as changes in color, texture,
    /// and other visual elements, while preserving the structure and essence of the
    /// original image. Not supported inside overlay. See [AI Generate Variations](https://imagekit.io/docs/ai-transformations#generate-variations-of-an-image-e-genvar).
    /// </summary>
    public ApiEnum<bool, AIVariation>? AIVariation
    {
        get
        {
            if (!this.Properties.TryGetValue("aiVariation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, AIVariation>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["aiVariation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("aspectRatio", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<AspectRatio?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["aspectRatio"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the audio codec, e.g., `aac`, `opus`, or `none`. See [Audio codec](https://imagekit.io/docs/video-optimization#audio-codec---ac).
    /// </summary>
    public ApiEnum<string, AudioCodec>? AudioCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("audioCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["audioCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the background to be used in conjunction with certain cropping
    /// strategies when resizing an image.  - A solid color: e.g., `red`, `F3F3F3`,
    /// `AAFF0010`. See [Solid color background](https://imagekit.io/docs/effects-and-enhancements#solid-color-background).
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
    /// Specifies the Gaussian blur level. Accepts an integer value between 1 and
    /// 100, or an expression like `bl-10`. See [Blur](https://imagekit.io/docs/effects-and-enhancements#blur---bl).
    /// </summary>
    public double? Blur
    {
        get
        {
            if (!this.Properties.TryGetValue("blur", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["blur"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Adds a border to the output media. Accepts a string in the format `<border-width>_<hex-code>`
    ///  (e.g., `5_FFF000` for a 5px yellow border), or an expression like `ih_div_20_FF00FF`.
    /// See [Border](https://imagekit.io/docs/effects-and-enhancements#border---b).
    /// </summary>
    public string? Border
    {
        get
        {
            if (!this.Properties.TryGetValue("border", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["border"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("colorProfile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["colorProfile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("contrastStretch", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, ContrastStretch>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["contrastStretch"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Crop modes for image resizing. See [Crop modes & focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
    /// </summary>
    public ApiEnum<string, Crop>? Crop
    {
        get
        {
            if (!this.Properties.TryGetValue("crop", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Crop>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["crop"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Additional crop modes for image resizing. See [Crop modes & focus](https://imagekit.io/docs/image-resize-and-crop#crop-crop-modes--focus).
    /// </summary>
    public ApiEnum<string, CropMode>? CropMode
    {
        get
        {
            if (!this.Properties.TryGetValue("cropMode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, CropMode>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cropMode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("defaultImage", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["defaultImage"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Accepts values between 0.1 and 5, or `auto` for automatic device pixel ratio
    /// (DPR) calculation. See [DPR](https://imagekit.io/docs/image-resize-and-crop#dpr---dpr).
    /// </summary>
    public double? Dpr
    {
        get
        {
            if (!this.Properties.TryGetValue("dpr", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["dpr"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the duration (in seconds) for trimming videos, e.g., `5` or `10.5`.
    ///  Typically used with startOffset to indicate the length from the start offset.
    /// Arithmetic expressions are supported. See [Trim videos – Duration](https://imagekit.io/docs/trim-videos#duration---du).
    /// </summary>
    public Duration? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Duration?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("endOffset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EndOffset?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["endOffset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Flips or mirrors an image either horizontally, vertically, or both.  Acceptable
    /// values: `h` (horizontal), `v` (vertical), `h_v` (horizontal and vertical),
    /// or `v_h`. See [Flip](https://imagekit.io/docs/effects-and-enhancements#flip---fl).
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
            if (!this.Properties.TryGetValue("focus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["focus"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the output format for images or videos, e.g., `jpg`, `png`, `webp`,
    /// `mp4`, or `auto`.  You can also pass `orig` for images to return the original
    /// format. ImageKit automatically delivers images and videos in the optimal format
    /// based on device support unless overridden by the dashboard settings or the
    /// format parameter. See [Image format](https://imagekit.io/docs/image-optimization#format---f)
    /// and [Video format](https://imagekit.io/docs/video-optimization#format---f).
    /// </summary>
    public ApiEnum<string, Format>? Format
    {
        get
        {
            if (!this.Properties.TryGetValue("format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Format>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["format"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Creates a linear gradient with two colors. Pass `true` for a default gradient,
    /// or provide a string for a custom gradient. See [Gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
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
    /// Enables a grayscale effect for images. See [Grayscale](https://imagekit.io/docs/effects-and-enhancements#grayscale---e-grayscale).
    /// </summary>
    public ApiEnum<bool, Grayscale>? Grayscale
    {
        get
        {
            if (!this.Properties.TryGetValue("grayscale", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<bool, Grayscale>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["grayscale"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the height of the output. If a value between 0 and 1 is provided,
    /// it is treated as a percentage (e.g., `0.5` represents 50% of the original
    /// height).  You can also supply arithmetic expressions (e.g., `ih_mul_0.5`).
    /// Height transformation – [Images](https://imagekit.io/docs/image-resize-and-crop#height---h)
    /// · [Videos](https://imagekit.io/docs/video-resize-and-crop#height---h)
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
    /// Specifies whether the output image (in JPEG or PNG) should be compressed losslessly.
    /// See [Lossless compression](https://imagekit.io/docs/image-optimization#lossless-webp-and-png---lo).
    /// </summary>
    public bool? Lossless
    {
        get
        {
            if (!this.Properties.TryGetValue("lossless", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["lossless"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Named transformation reference. See [Named transformations](https://imagekit.io/docs/transformations#named-transformations).
    /// </summary>
    public string? Named
    {
        get
        {
            if (!this.Properties.TryGetValue("named", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["named"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the opacity level of the output image. See [Opacity](https://imagekit.io/docs/effects-and-enhancements#opacity---o).
    /// </summary>
    public double? Opacity
    {
        get
        {
            if (!this.Properties.TryGetValue("opacity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["opacity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("original", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["original"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("overlay", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Overlay?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["overlay"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Extracts a specific page or frame from multi-page or layered files (PDF, PSD,
    /// AI).  For example, specify by number (e.g., `2`), a range (e.g., `3-4` for
    /// the 2nd and 3rd layers), or by name (e.g., `name-layer-4` for a PSD layer).
    /// See [Thumbnail extraction](https://imagekit.io/docs/vector-and-animated-images#get-thumbnail-from-psd-pdf-ai-eps-and-animated-files).
    /// </summary>
    public Page? Page
    {
        get
        {
            if (!this.Properties.TryGetValue("page", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Page?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["page"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies whether the output JPEG image should be rendered progressively.
    /// Progressive loading begins with a low-quality,  pixelated version of the full
    /// image, which gradually improves to provide a faster perceived load time. See
    /// [Progressive images](https://imagekit.io/docs/image-optimization#progressive-image---pr).
    /// </summary>
    public bool? Progressive
    {
        get
        {
            if (!this.Properties.TryGetValue("progressive", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["progressive"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("quality", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quality"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the corner radius for rounded corners (e.g., 20) or `max` for circular
    /// or oval shape. See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
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
    /// Pass any transformation not directly supported by the SDK.  This transformation
    /// string is appended to the URL as provided.
    /// </summary>
    public string? Raw
    {
        get
        {
            if (!this.Properties.TryGetValue("raw", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["raw"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the rotation angle in degrees. Positive values rotate the image
    /// clockwise; you can also use, for example, `N40` for counterclockwise rotation
    ///  or `auto` to use the orientation specified in the image's EXIF data. For
    /// videos, only the following values are supported: 0, 90, 180, 270, or 360.
    /// See [Rotate](https://imagekit.io/docs/effects-and-enhancements#rotate---rt).
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
    /// Adds a shadow beneath solid objects in an image with a transparent background.
    ///  For AI-based drop shadows, refer to aiDropShadow. Pass `true` for a default
    /// shadow, or provide a string for a custom shadow. See [Shadow](https://imagekit.io/docs/effects-and-enhancements#shadow---e-shadow).
    /// </summary>
    public Shadow? Shadow
    {
        get
        {
            if (!this.Properties.TryGetValue("shadow", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Shadow?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["shadow"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("sharpen", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Sharpen?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["sharpen"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("startOffset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<StartOffset?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["startOffset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of resolutions for adaptive bitrate streaming, e.g., [`240`, `360`,
    /// `480`, `720`, `1080`]. See [Adaptive Bitrate Streaming](https://imagekit.io/docs/adaptive-bitrate-streaming).
    /// </summary>
    public List<ApiEnum<string, StreamingResolution>>? StreamingResolutions
    {
        get
        {
            if (!this.Properties.TryGetValue("streamingResolutions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<ApiEnum<string, StreamingResolution>>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["streamingResolutions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Useful for images with a solid or nearly solid background and a central object.
    /// This parameter trims the background,  leaving only the central object in
    /// the output image. See [Trim edges](https://imagekit.io/docs/effects-and-enhancements#trim-edges---t).
    /// </summary>
    public Trim? Trim
    {
        get
        {
            if (!this.Properties.TryGetValue("trim", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Trim?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trim"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("unsharpMask", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<UnsharpMask?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["unsharpMask"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the video codec, e.g., `h264`, `vp9`, `av1`, or `none`. See [Video codec](https://imagekit.io/docs/video-optimization#video-codec---vc).
    /// </summary>
    public ApiEnum<string, VideoCodec>? VideoCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("videoCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["videoCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the width of the output. If a value between 0 and 1 is provided,
    /// it is treated as a percentage (e.g., `0.4` represents 40% of the original
    /// width).  You can also supply arithmetic expressions (e.g., `iw_div_2`). Width
    /// transformation – [Images](https://imagekit.io/docs/image-resize-and-crop#width---w)
    /// · [Videos](https://imagekit.io/docs/video-resize-and-crop#width---w)
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

    /// <summary>
    /// Focus using cropped image coordinates - X coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public X? X
    {
        get
        {
            if (!this.Properties.TryGetValue("x", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<X?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["x"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - X center coordinate. See [Focus using
    /// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public XCenter? XCenter
    {
        get
        {
            if (!this.Properties.TryGetValue("xCenter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<XCenter?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["xCenter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - Y coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public Y? Y
    {
        get
        {
            if (!this.Properties.TryGetValue("y", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Y?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["y"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Focus using cropped image coordinates - Y center coordinate. See [Focus using
    /// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
    /// </summary>
    public YCenter? YCenter
    {
        get
        {
            if (!this.Properties.TryGetValue("yCenter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<YCenter?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["yCenter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Accepts a numeric value that determines how much to zoom in or out of the
    /// cropped area.  It should be used in conjunction with fo-face or fo-<object_name>.
    /// See [Zoom](https://imagekit.io/docs/image-resize-and-crop#zoom---z).
    /// </summary>
    public double? Zoom
    {
        get
        {
            if (!this.Properties.TryGetValue("zoom", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["zoom"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        this.ContrastStretch?.Validate();
        this.Crop?.Validate();
        this.CropMode?.Validate();
        _ = this.DefaultImage;
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
    Transformation(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Transformation FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
