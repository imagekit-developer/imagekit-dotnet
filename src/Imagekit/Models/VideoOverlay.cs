using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models;

[JsonConverter(typeof(JsonModelConverter<VideoOverlay, VideoOverlayFromRaw>))]
public sealed record class VideoOverlay : JsonModel
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
    /// Specifies the relative path to the video used as an overlay.
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
    /// plain text. </para>
    /// </summary>
    public ApiEnum<string, VideoOverlayIntersectionMember1Encoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VideoOverlayIntersectionMember1Encoding>
            >("encoding");
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
    /// Array of transformation to be applied to the overlay video. Except `streamingResolutions`,
    /// all other video transformations are supported. See [Video transformations](https://imagekit.io/docs/video-transformation).
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

    public static implicit operator BaseOverlay(VideoOverlay videoOverlay) =>
        new()
        {
            LayerMode = videoOverlay.LayerMode,
            Position = videoOverlay.Position,
            Timing = videoOverlay.Timing,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        this.LayerMode?.Validate();
        this.Position?.Validate();
        this.Timing?.Validate();
        _ = this.Input;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("video")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public VideoOverlay()
    {
        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoOverlay(VideoOverlay videoOverlay)
        : base(videoOverlay) { }
#pragma warning restore CS8618

    public VideoOverlay(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoOverlay(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoOverlayFromRaw.FromRawUnchecked"/>
    public static VideoOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoOverlay(string input)
        : this()
    {
        this.Input = input;
    }
}

class VideoOverlayFromRaw : IFromRawJson<VideoOverlay>
{
    /// <inheritdoc/>
    public VideoOverlay FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VideoOverlay.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoOverlayIntersectionMember1,
        VideoOverlayIntersectionMember1FromRaw
    >)
)]
public sealed record class VideoOverlayIntersectionMember1 : JsonModel
{
    /// <summary>
    /// Specifies the relative path to the video used as an overlay.
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
    /// plain text. </para>
    /// </summary>
    public ApiEnum<string, VideoOverlayIntersectionMember1Encoding>? Encoding
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VideoOverlayIntersectionMember1Encoding>
            >("encoding");
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
    /// Array of transformation to be applied to the overlay video. Except `streamingResolutions`,
    /// all other video transformations are supported. See [Video transformations](https://imagekit.io/docs/video-transformation).
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Input;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("video")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Encoding?.Validate();
        foreach (var item in this.Transformation ?? [])
        {
            item.Validate();
        }
    }

    public VideoOverlayIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoOverlayIntersectionMember1(
        VideoOverlayIntersectionMember1 videoOverlayIntersectionMember1
    )
        : base(videoOverlayIntersectionMember1) { }
#pragma warning restore CS8618

    public VideoOverlayIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoOverlayIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoOverlayIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static VideoOverlayIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoOverlayIntersectionMember1(string input)
        : this()
    {
        this.Input = input;
    }
}

class VideoOverlayIntersectionMember1FromRaw : IFromRawJson<VideoOverlayIntersectionMember1>
{
    /// <inheritdoc/>
    public VideoOverlayIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoOverlayIntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The input path can be included in the layer as either `i-{input}` or `ie-{base64_encoded_input}`.
///  By default, the SDK determines the appropriate format automatically.  To always
/// use base64 encoding (`ie-{base64}`), set this parameter to `base64`.  To always
/// use plain text (`i-{input}`), set it to `plain`.
///
/// <para>Regardless of the encoding method: - Leading and trailing slashes are removed.
/// - Remaining slashes within the path are replaced with `@@` when using plain text. </para>
/// </summary>
[JsonConverter(typeof(VideoOverlayIntersectionMember1EncodingConverter))]
public enum VideoOverlayIntersectionMember1Encoding
{
    Auto,
    Plain,
    Base64,
}

sealed class VideoOverlayIntersectionMember1EncodingConverter
    : JsonConverter<VideoOverlayIntersectionMember1Encoding>
{
    public override VideoOverlayIntersectionMember1Encoding Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => VideoOverlayIntersectionMember1Encoding.Auto,
            "plain" => VideoOverlayIntersectionMember1Encoding.Plain,
            "base64" => VideoOverlayIntersectionMember1Encoding.Base64,
            _ => (VideoOverlayIntersectionMember1Encoding)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoOverlayIntersectionMember1Encoding value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoOverlayIntersectionMember1Encoding.Auto => "auto",
                VideoOverlayIntersectionMember1Encoding.Plain => "plain",
                VideoOverlayIntersectionMember1Encoding.Base64 => "base64",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
