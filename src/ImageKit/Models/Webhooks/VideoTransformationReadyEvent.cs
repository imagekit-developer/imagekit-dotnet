using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Webhooks;

/// <summary>
/// Triggered when video encoding is finished and the transformed resource is ready
/// to be served. This is the key event to listen for - update your database or CMS
/// flags when you receive this so your application can start showing the transformed
/// video to users.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VideoTransformationReadyEvent, VideoTransformationReadyEventFromRaw>)
)]
public sealed record class VideoTransformationReadyEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The type of webhook event.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp when the event was created in ISO8601 format.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required VideoTransformationReadyEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1Request>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Performance metrics for the transformation process.
    /// </summary>
    public Timings? Timings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timings>("timings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timings", value);
        }
    }

    public static implicit operator BaseWebhookEvent(
        VideoTransformationReadyEvent videoTransformationReadyEvent
    ) => new() { ID = videoTransformationReadyEvent.ID, Type = videoTransformationReadyEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
        this.Timings?.Validate();
    }

    public VideoTransformationReadyEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEvent(
        VideoTransformationReadyEvent videoTransformationReadyEvent
    )
        : base(videoTransformationReadyEvent) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventFromRaw : IFromRawJson<VideoTransformationReadyEvent>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when video encoding is finished and the transformed resource is ready
/// to be served. This is the key event to listen for - update your database or CMS
/// flags when you receive this so your application can start showing the transformed
/// video to users.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1,
        VideoTransformationReadyEventIntersectionMember1FromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1 : JsonModel
{
    /// <summary>
    /// Timestamp when the event was created in ISO8601 format.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required VideoTransformationReadyEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1Request>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
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
    /// Performance metrics for the transformation process.
    /// </summary>
    public Timings? Timings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timings>("timings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timings", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("video.transformation.ready")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Timings?.Validate();
    }

    public VideoTransformationReadyEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1(
        VideoTransformationReadyEventIntersectionMember1 videoTransformationReadyEventIntersectionMember1
    )
        : base(videoTransformationReadyEventIntersectionMember1) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventIntersectionMember1FromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1Data,
        VideoTransformationReadyEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1Data : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required VideoTransformationReadyEventIntersectionMember1DataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1DataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required VideoTransformationReadyEventIntersectionMember1DataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventIntersectionMember1DataTransformation>(
                "transformation"
            );
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Asset.Validate();
        this.Transformation.Validate();
    }

    public VideoTransformationReadyEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1Data(
        VideoTransformationReadyEventIntersectionMember1Data videoTransformationReadyEventIntersectionMember1Data
    )
        : base(videoTransformationReadyEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventIntersectionMember1DataFromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventIntersectionMember1Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1DataAsset,
        VideoTransformationReadyEventIntersectionMember1DataAssetFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1DataAsset : JsonModel
{
    /// <summary>
    /// URL to download or access the source video file.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
    }

    public VideoTransformationReadyEventIntersectionMember1DataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1DataAsset(
        VideoTransformationReadyEventIntersectionMember1DataAsset videoTransformationReadyEventIntersectionMember1DataAsset
    )
        : base(videoTransformationReadyEventIntersectionMember1DataAsset) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1DataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1DataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1DataAssetFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1DataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1DataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class VideoTransformationReadyEventIntersectionMember1DataAssetFromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1DataAsset>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1DataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventIntersectionMember1DataAsset.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1DataTransformation,
        VideoTransformationReadyEventIntersectionMember1DataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1DataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<
        string,
        VideoTransformationReadyEventIntersectionMember1DataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventIntersectionMember1DataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration options for video transformations.
    /// </summary>
    public VideoTransformationReadyEventIntersectionMember1DataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationReadyEventIntersectionMember1DataTransformationOptions>(
                "options"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("options", value);
        }
    }

    /// <summary>
    /// Information about the transformed output video.
    /// </summary>
    public Output? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Output>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("output", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Options?.Validate();
        this.Output?.Validate();
    }

    public VideoTransformationReadyEventIntersectionMember1DataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1DataTransformation(
        VideoTransformationReadyEventIntersectionMember1DataTransformation videoTransformationReadyEventIntersectionMember1DataTransformation
    )
        : base(videoTransformationReadyEventIntersectionMember1DataTransformation) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1DataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1DataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1DataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1DataTransformation(
        ApiEnum<string, VideoTransformationReadyEventIntersectionMember1DataTransformationType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationReadyEventIntersectionMember1DataTransformationFromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1DataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventIntersectionMember1DataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventIntersectionMember1DataTransformationTypeConverter)
)]
public enum VideoTransformationReadyEventIntersectionMember1DataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationReadyEventIntersectionMember1DataTransformationTypeConverter
    : JsonConverter<VideoTransformationReadyEventIntersectionMember1DataTransformationType>
{
    public override VideoTransformationReadyEventIntersectionMember1DataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation,
            "gif-to-video" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoThumbnail,
            _ => (VideoTransformationReadyEventIntersectionMember1DataTransformationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventIntersectionMember1DataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationReadyEventIntersectionMember1DataTransformationType.VideoThumbnail =>
                    "video-thumbnail",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Configuration options for video transformations.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1DataTransformationOptions
    : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
    >? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
                >
            >("audio_codec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audio_codec", value);
        }
    }

    /// <summary>
    /// Whether to automatically rotate the video based on metadata.
    /// </summary>
    public bool? AutoRotate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("auto_rotate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("auto_rotate", value);
        }
    }

    /// <summary>
    /// Output format for the transformed video or thumbnail.
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
    >? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
                >
            >("format");
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
    /// Quality setting for the output video.
    /// </summary>
    public long? Quality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quality");
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
    /// Streaming protocol for adaptive bitrate streaming.
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
    >? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
                >
            >("stream_protocol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("stream_protocol", value);
        }
    }

    /// <summary>
    /// Array of quality representations for adaptive bitrate streaming.
    /// </summary>
    public IReadOnlyList<string>? Variants
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("variants");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "variants",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Video codec used for encoding (h264, vp9, or av1).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
    >? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
                >
            >("video_codec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("video_codec", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AudioCodec?.Validate();
        _ = this.AutoRotate;
        this.Format?.Validate();
        _ = this.Quality;
        this.StreamProtocol?.Validate();
        _ = this.Variants;
        this.VideoCodec?.Validate();
    }

    public VideoTransformationReadyEventIntersectionMember1DataTransformationOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1DataTransformationOptions(
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions videoTransformationReadyEventIntersectionMember1DataTransformationOptions
    )
        : base(videoTransformationReadyEventIntersectionMember1DataTransformationOptions) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1DataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1DataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1DataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1DataTransformationOptions>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1DataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodecConverter)
)]
public enum VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec
{
    Aac,
    Opus,
}

sealed class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodecConverter
    : JsonConverter<VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec>
{
    public override VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            "opus" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus,
            _ =>
                (VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac =>
                    "aac",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus =>
                    "opus",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Output format for the transformed video or thumbnail.
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormatConverter)
)]
public enum VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormatConverter
    : JsonConverter<VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat>
{
    public override VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            "webm" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webm,
            "jpg" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Jpg,
            "png" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Png,
            "webp" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webp,
            _ => (VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Mp4 =>
                    "mp4",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webm =>
                    "webm",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Jpg =>
                    "jpg",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Png =>
                    "png",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsFormat.Webp =>
                    "webp",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Streaming protocol for adaptive bitrate streaming.
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocolConverter)
)]
public enum VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol
{
    Hls,
    Dash,
}

sealed class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocolConverter
    : JsonConverter<VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol>
{
    public override VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            "DASH" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash,
            _ =>
                (VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls =>
                    "HLS",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash =>
                    "DASH",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Video codec used for encoding (h264, vp9, or av1).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodecConverter)
)]
public enum VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodecConverter
    : JsonConverter<VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec>
{
    public override VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            "vp9" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9,
            "av1" =>
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1,
            _ =>
                (VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.H264 =>
                    "h264",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9 =>
                    "vp9",
                VideoTransformationReadyEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1 =>
                    "av1",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the transformed output video.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Output, OutputFromRaw>))]
public sealed record class Output : JsonModel
{
    /// <summary>
    /// URL to access the transformed video.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Metadata of the output video file.
    /// </summary>
    public VideoMetadata? VideoMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoMetadata>("video_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("video_metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        this.VideoMetadata?.Validate();
    }

    public Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Output(Output output)
        : base(output) { }
#pragma warning restore CS8618

    public Output(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Output(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputFromRaw.FromRawUnchecked"/>
    public static Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Output(string url)
        : this()
    {
        this.Url = url;
    }
}

class OutputFromRaw : IFromRawJson<Output>
{
    /// <inheritdoc/>
    public Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Output.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata of the output video file.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VideoMetadata, VideoMetadataFromRaw>))]
public sealed record class VideoMetadata : JsonModel
{
    /// <summary>
    /// Bitrate of the output video in bits per second.
    /// </summary>
    public required long Bitrate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bitrate");
        }
        init { this._rawData.Set("bitrate", value); }
    }

    /// <summary>
    /// Duration of the output video in seconds.
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
    }

    /// <summary>
    /// Height of the output video in pixels.
    /// </summary>
    public required long Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("height");
        }
        init { this._rawData.Set("height", value); }
    }

    /// <summary>
    /// Width of the output video in pixels.
    /// </summary>
    public required long Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("width");
        }
        init { this._rawData.Set("width", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bitrate;
        _ = this.Duration;
        _ = this.Height;
        _ = this.Width;
    }

    public VideoMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoMetadata(VideoMetadata videoMetadata)
        : base(videoMetadata) { }
#pragma warning restore CS8618

    public VideoMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoMetadataFromRaw.FromRawUnchecked"/>
    public static VideoMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoMetadataFromRaw : IFromRawJson<VideoMetadata>
{
    /// <inheritdoc/>
    public VideoMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VideoMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the original request that triggered the video transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventIntersectionMember1Request,
        VideoTransformationReadyEventIntersectionMember1RequestFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventIntersectionMember1Request : JsonModel
{
    /// <summary>
    /// Full URL of the transformation request that was submitted.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Unique identifier for the originating transformation request.
    /// </summary>
    public required string XRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("x_request_id");
        }
        init { this._rawData.Set("x_request_id", value); }
    }

    /// <summary>
    /// User-Agent header from the original request that triggered the transformation.
    /// </summary>
    public string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_agent", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.XRequestID;
        _ = this.UserAgent;
    }

    public VideoTransformationReadyEventIntersectionMember1Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventIntersectionMember1Request(
        VideoTransformationReadyEventIntersectionMember1Request videoTransformationReadyEventIntersectionMember1Request
    )
        : base(videoTransformationReadyEventIntersectionMember1Request) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventIntersectionMember1Request(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventIntersectionMember1Request(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventIntersectionMember1RequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventIntersectionMember1RequestFromRaw
    : IFromRawJson<VideoTransformationReadyEventIntersectionMember1Request>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventIntersectionMember1Request.FromRawUnchecked(rawData);
}

/// <summary>
/// Performance metrics for the transformation process.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Timings, TimingsFromRaw>))]
public sealed record class Timings : JsonModel
{
    /// <summary>
    /// Time spent downloading the source video from your origin or media library,
    /// in milliseconds.
    /// </summary>
    public long? DownloadDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("download_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("download_duration", value);
        }
    }

    /// <summary>
    /// Time spent encoding the video, in milliseconds.
    /// </summary>
    public long? EncodingDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("encoding_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("encoding_duration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadDuration;
        _ = this.EncodingDuration;
    }

    public Timings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timings(Timings timings)
        : base(timings) { }
#pragma warning restore CS8618

    public Timings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimingsFromRaw.FromRawUnchecked"/>
    public static Timings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimingsFromRaw : IFromRawJson<Timings>
{
    /// <inheritdoc/>
    public Timings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timings.FromRawUnchecked(rawData);
}
