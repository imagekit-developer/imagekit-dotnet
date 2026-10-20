using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Webhooks;

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

    public required VideoTransformationReadyEventVideoTransformationReadyEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventVideoTransformationReadyEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventRequest>(
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
        VideoTransformationReadyEventVideoTransformationReadyEvent,
        VideoTransformationReadyEventVideoTransformationReadyEventFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEvent : JsonModel
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

    public required VideoTransformationReadyEventVideoTransformationReadyEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventVideoTransformationReadyEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventRequest>(
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

    public VideoTransformationReadyEventVideoTransformationReadyEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEvent(
        VideoTransformationReadyEventVideoTransformationReadyEvent videoTransformationReadyEventVideoTransformationReadyEvent
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEvent) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEvent>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventVideoTransformationReadyEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventVideoTransformationReadyEventData,
        VideoTransformationReadyEventVideoTransformationReadyEventDataFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required VideoTransformationReadyEventVideoTransformationReadyEventDataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventDataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation>(
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

    public VideoTransformationReadyEventVideoTransformationReadyEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventData(
        VideoTransformationReadyEventVideoTransformationReadyEventData videoTransformationReadyEventVideoTransformationReadyEventData
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEventData) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventDataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventDataFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEventData>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventVideoTransformationReadyEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset,
        VideoTransformationReadyEventVideoTransformationReadyEventDataAssetFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEventDataAsset
    : JsonModel
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

    public VideoTransformationReadyEventVideoTransformationReadyEventDataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventDataAsset(
        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset videoTransformationReadyEventVideoTransformationReadyEventDataAsset
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEventDataAsset) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEventDataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEventDataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventDataAssetFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventDataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventDataAssetFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEventDataAsset>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventVideoTransformationReadyEventDataAsset.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<
        string,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration options for video transformations.
    /// </summary>
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions>(
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

    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation videoTransformationReadyEventVideoTransformationReadyEventDataTransformation
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEventDataTransformation) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation(
        ApiEnum<
            string,
            VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationTypeConverter)
)]
public enum VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationTypeConverter
    : JsonConverter<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType>
{
    public override VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation,
            "gif-to-video" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoThumbnail,
            _ => (VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationType.VideoThumbnail =>
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
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
    : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
    >? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
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
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
    >? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
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
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
    >? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
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
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
    >? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
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

    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions(
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions videoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions)
    { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodecConverter)
)]
public enum VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec
{
    Aac,
    Opus,
}

sealed class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodecConverter
    : JsonConverter<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec>
{
    public override VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac,
            "opus" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Opus,
            _ =>
                (VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Aac =>
                    "aac",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsAudioCodec.Opus =>
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
    typeof(VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormatConverter)
)]
public enum VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormatConverter
    : JsonConverter<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat>
{
    public override VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4,
            "webm" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webm,
            "jpg" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Jpg,
            "png" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Png,
            "webp" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webp,
            _ =>
                (VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Mp4 =>
                    "mp4",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webm =>
                    "webm",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Jpg =>
                    "jpg",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Png =>
                    "png",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsFormat.Webp =>
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
    typeof(VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocolConverter)
)]
public enum VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol
{
    Hls,
    Dash,
}

sealed class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocolConverter
    : JsonConverter<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol>
{
    public override VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls,
            "DASH" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Dash,
            _ =>
                (VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Hls =>
                    "HLS",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsStreamProtocol.Dash =>
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
    typeof(VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodecConverter)
)]
public enum VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodecConverter
    : JsonConverter<VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec>
{
    public override VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264,
            "vp9" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Vp9,
            "av1" =>
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Av1,
            _ =>
                (VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.H264 =>
                    "h264",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Vp9 =>
                    "vp9",
                VideoTransformationReadyEventVideoTransformationReadyEventDataTransformationOptionsVideoCodec.Av1 =>
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
        VideoTransformationReadyEventVideoTransformationReadyEventRequest,
        VideoTransformationReadyEventVideoTransformationReadyEventRequestFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventVideoTransformationReadyEventRequest
    : JsonModel
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

    public VideoTransformationReadyEventVideoTransformationReadyEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventVideoTransformationReadyEventRequest(
        VideoTransformationReadyEventVideoTransformationReadyEventRequest videoTransformationReadyEventVideoTransformationReadyEventRequest
    )
        : base(videoTransformationReadyEventVideoTransformationReadyEventRequest) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventVideoTransformationReadyEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventVideoTransformationReadyEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventVideoTransformationReadyEventRequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventVideoTransformationReadyEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventVideoTransformationReadyEventRequestFromRaw
    : IFromRawJson<VideoTransformationReadyEventVideoTransformationReadyEventRequest>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventVideoTransformationReadyEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationReadyEventVideoTransformationReadyEventRequest.FromRawUnchecked(rawData);
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
