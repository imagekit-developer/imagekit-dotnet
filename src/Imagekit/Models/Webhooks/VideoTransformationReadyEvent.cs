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

    public required VideoTransformationReadyEventChangedData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventChangedRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedRequest>(
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
        VideoTransformationReadyEventChanged,
        VideoTransformationReadyEventChangedFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChanged : JsonModel
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

    public required VideoTransformationReadyEventChangedData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedData>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationReadyEventChangedRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedRequest>(
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

    public VideoTransformationReadyEventChanged()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChanged(
        VideoTransformationReadyEventChanged videoTransformationReadyEventChanged
    )
        : base(videoTransformationReadyEventChanged) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChanged(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChanged(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventChangedFromRaw
    : IFromRawJson<VideoTransformationReadyEventChanged>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChanged FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChanged.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventChangedData,
        VideoTransformationReadyEventChangedDataFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChangedData : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required VideoTransformationReadyEventChangedDataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedDataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required VideoTransformationReadyEventChangedDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationReadyEventChangedDataTransformation>(
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

    public VideoTransformationReadyEventChangedData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedData(
        VideoTransformationReadyEventChangedData videoTransformationReadyEventChangedData
    )
        : base(videoTransformationReadyEventChangedData) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChangedData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChangedData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedDataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChangedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventChangedDataFromRaw
    : IFromRawJson<VideoTransformationReadyEventChangedData>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChangedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChangedData.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventChangedDataAsset,
        VideoTransformationReadyEventChangedDataAssetFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChangedDataAsset : JsonModel
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

    public VideoTransformationReadyEventChangedDataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedDataAsset(
        VideoTransformationReadyEventChangedDataAsset videoTransformationReadyEventChangedDataAsset
    )
        : base(videoTransformationReadyEventChangedDataAsset) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChangedDataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChangedDataAsset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedDataAssetFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChangedDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedDataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class VideoTransformationReadyEventChangedDataAssetFromRaw
    : IFromRawJson<VideoTransformationReadyEventChangedDataAsset>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChangedDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChangedDataAsset.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationReadyEventChangedDataTransformation,
        VideoTransformationReadyEventChangedDataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChangedDataTransformation : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<string, VideoTransformationReadyEventChangedDataTransformationType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, VideoTransformationReadyEventChangedDataTransformationType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration options for video transformations.
    /// </summary>
    public VideoTransformationReadyEventChangedDataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationReadyEventChangedDataTransformationOptions>(
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

    public VideoTransformationReadyEventChangedDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedDataTransformation(
        VideoTransformationReadyEventChangedDataTransformation videoTransformationReadyEventChangedDataTransformation
    )
        : base(videoTransformationReadyEventChangedDataTransformation) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChangedDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChangedDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedDataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChangedDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedDataTransformation(
        ApiEnum<string, VideoTransformationReadyEventChangedDataTransformationType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationReadyEventChangedDataTransformationFromRaw
    : IFromRawJson<VideoTransformationReadyEventChangedDataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChangedDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChangedDataTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(typeof(VideoTransformationReadyEventChangedDataTransformationTypeConverter))]
public enum VideoTransformationReadyEventChangedDataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationReadyEventChangedDataTransformationTypeConverter
    : JsonConverter<VideoTransformationReadyEventChangedDataTransformationType>
{
    public override VideoTransformationReadyEventChangedDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationReadyEventChangedDataTransformationType.VideoTransformation,
            "gif-to-video" => VideoTransformationReadyEventChangedDataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationReadyEventChangedDataTransformationType.VideoThumbnail,
            _ => (VideoTransformationReadyEventChangedDataTransformationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventChangedDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventChangedDataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationReadyEventChangedDataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationReadyEventChangedDataTransformationType.VideoThumbnail =>
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
        VideoTransformationReadyEventChangedDataTransformationOptions,
        VideoTransformationReadyEventChangedDataTransformationOptionsFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChangedDataTransformationOptions : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec
    >? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec
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
        VideoTransformationReadyEventChangedDataTransformationOptionsFormat
    >? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, VideoTransformationReadyEventChangedDataTransformationOptionsFormat>
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
        VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol
    >? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol
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
        VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec
    >? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec
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

    public VideoTransformationReadyEventChangedDataTransformationOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedDataTransformationOptions(
        VideoTransformationReadyEventChangedDataTransformationOptions videoTransformationReadyEventChangedDataTransformationOptions
    )
        : base(videoTransformationReadyEventChangedDataTransformationOptions) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChangedDataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChangedDataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedDataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChangedDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventChangedDataTransformationOptionsFromRaw
    : IFromRawJson<VideoTransformationReadyEventChangedDataTransformationOptions>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChangedDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChangedDataTransformationOptions.FromRawUnchecked(rawData);
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodecConverter)
)]
public enum VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec
{
    Aac,
    Opus,
}

sealed class VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodecConverter
    : JsonConverter<VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec>
{
    public override VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" => VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec.Aac,
            "opus" => VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec.Opus,
            _ => (VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec.Aac =>
                    "aac",
                VideoTransformationReadyEventChangedDataTransformationOptionsAudioCodec.Opus =>
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
    typeof(VideoTransformationReadyEventChangedDataTransformationOptionsFormatConverter)
)]
public enum VideoTransformationReadyEventChangedDataTransformationOptionsFormat
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class VideoTransformationReadyEventChangedDataTransformationOptionsFormatConverter
    : JsonConverter<VideoTransformationReadyEventChangedDataTransformationOptionsFormat>
{
    public override VideoTransformationReadyEventChangedDataTransformationOptionsFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" => VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Mp4,
            "webm" => VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Webm,
            "jpg" => VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Jpg,
            "png" => VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Png,
            "webp" => VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Webp,
            _ => (VideoTransformationReadyEventChangedDataTransformationOptionsFormat)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventChangedDataTransformationOptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Mp4 => "mp4",
                VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Webm => "webm",
                VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Jpg => "jpg",
                VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Png => "png",
                VideoTransformationReadyEventChangedDataTransformationOptionsFormat.Webp => "webp",
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
    typeof(VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocolConverter)
)]
public enum VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol
{
    Hls,
    Dash,
}

sealed class VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocolConverter
    : JsonConverter<VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol>
{
    public override VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" =>
                VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol.Hls,
            "DASH" =>
                VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol.Dash,
            _ => (VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol.Hls =>
                    "HLS",
                VideoTransformationReadyEventChangedDataTransformationOptionsStreamProtocol.Dash =>
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
    typeof(VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodecConverter)
)]
public enum VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodecConverter
    : JsonConverter<VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec>
{
    public override VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" => VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.H264,
            "vp9" => VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.Vp9,
            "av1" => VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.Av1,
            _ => (VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.H264 =>
                    "h264",
                VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.Vp9 =>
                    "vp9",
                VideoTransformationReadyEventChangedDataTransformationOptionsVideoCodec.Av1 =>
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
        VideoTransformationReadyEventChangedRequest,
        VideoTransformationReadyEventChangedRequestFromRaw
    >)
)]
public sealed record class VideoTransformationReadyEventChangedRequest : JsonModel
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

    public VideoTransformationReadyEventChangedRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationReadyEventChangedRequest(
        VideoTransformationReadyEventChangedRequest videoTransformationReadyEventChangedRequest
    )
        : base(videoTransformationReadyEventChangedRequest) { }
#pragma warning restore CS8618

    public VideoTransformationReadyEventChangedRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationReadyEventChangedRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationReadyEventChangedRequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationReadyEventChangedRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationReadyEventChangedRequestFromRaw
    : IFromRawJson<VideoTransformationReadyEventChangedRequest>
{
    /// <inheritdoc/>
    public VideoTransformationReadyEventChangedRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationReadyEventChangedRequest.FromRawUnchecked(rawData);
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
