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
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationAcceptedEvent,
        VideoTransformationAcceptedEventFromRaw
    >)
)]
public sealed record class VideoTransformationAcceptedEvent : JsonModel
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

    public required VideoTransformationAcceptedEventVideoTransformationAcceptedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationAcceptedEventVideoTransformationAcceptedEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        VideoTransformationAcceptedEvent videoTransformationAcceptedEvent
    ) =>
        new()
        {
            ID = videoTransformationAcceptedEvent.ID,
            Type = videoTransformationAcceptedEvent.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public VideoTransformationAcceptedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationAcceptedEvent(
        VideoTransformationAcceptedEvent videoTransformationAcceptedEvent
    )
        : base(videoTransformationAcceptedEvent) { }
#pragma warning restore CS8618

    public VideoTransformationAcceptedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationAcceptedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationAcceptedEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationAcceptedEventFromRaw : IFromRawJson<VideoTransformationAcceptedEvent>
{
    /// <inheritdoc/>
    public VideoTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationAcceptedEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationAcceptedEventVideoTransformationAcceptedEvent,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventFromRaw
    >)
)]
public sealed record class VideoTransformationAcceptedEventVideoTransformationAcceptedEvent
    : JsonModel
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

    public required VideoTransformationAcceptedEventVideoTransformationAcceptedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationAcceptedEventVideoTransformationAcceptedEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("video.transformation.accepted")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.accepted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEvent(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEvent videoTransformationAcceptedEventVideoTransformationAcceptedEvent
    )
        : base(videoTransformationAcceptedEventVideoTransformationAcceptedEvent) { }
#pragma warning restore CS8618

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.accepted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationAcceptedEventVideoTransformationAcceptedEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationAcceptedEventVideoTransformationAcceptedEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationAcceptedEventVideoTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationAcceptedEventVideoTransformationAcceptedEventFromRaw
    : IFromRawJson<VideoTransformationAcceptedEventVideoTransformationAcceptedEvent>
{
    /// <inheritdoc/>
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationAcceptedEventVideoTransformationAcceptedEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataFromRaw
    >)
)]
public sealed record class VideoTransformationAcceptedEventVideoTransformationAcceptedEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required Asset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Asset>("asset");
        }
        init { this._rawData.Set("asset", value); }
    }

    /// <summary>
    /// Base information about a video transformation request.
    /// </summary>
    public required VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation>(
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

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventData(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData videoTransformationAcceptedEventVideoTransformationAcceptedEventData
    )
        : base(videoTransformationAcceptedEventVideoTransformationAcceptedEventData) { }
#pragma warning restore CS8618

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationAcceptedEventVideoTransformationAcceptedEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationAcceptedEventVideoTransformationAcceptedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataFromRaw
    : IFromRawJson<VideoTransformationAcceptedEventVideoTransformationAcceptedEventData>
{
    /// <inheritdoc/>
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventData.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Asset, AssetFromRaw>))]
public sealed record class Asset : JsonModel
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

    public Asset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Asset(Asset asset)
        : base(asset) { }
#pragma warning restore CS8618

    public Asset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Asset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssetFromRaw.FromRawUnchecked"/>
    public static Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Asset(string url)
        : this()
    {
        this.Url = url;
    }
}

class AssetFromRaw : IFromRawJson<Asset>
{
    /// <inheritdoc/>
    public Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Asset.FromRawUnchecked(rawData);
}

/// <summary>
/// Base information about a video transformation request.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<
        string,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration options for video transformations.
    /// </summary>
    public Options? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Options>("options");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Options?.Validate();
    }

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation videoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation
    )
        : base(videoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation)
    { }
#pragma warning restore CS8618

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation(
        ApiEnum<
            string,
            VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationFromRaw
    : IFromRawJson<VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(
    typeof(VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationTypeConverter)
)]
public enum VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationTypeConverter
    : JsonConverter<VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType>
{
    public override VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation,
            "gif-to-video" =>
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoThumbnail,
            _ =>
                (VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationAcceptedEventVideoTransformationAcceptedEventDataTransformationType.VideoThumbnail =>
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
[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<string, AudioCodec>? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AudioCodec>>("audio_codec");
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
    public ApiEnum<string, StreamProtocol>? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, StreamProtocol>>(
                "stream_protocol"
            );
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
    public ApiEnum<string, VideoCodec>? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VideoCodec>>("video_codec");
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

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(typeof(AudioCodecConverter))]
public enum AudioCodec
{
    Aac,
    Opus,
}

sealed class AudioCodecConverter : JsonConverter<AudioCodec>
{
    public override AudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" => AudioCodec.Aac,
            "opus" => AudioCodec.Opus,
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
[JsonConverter(typeof(FormatConverter))]
public enum Format
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class FormatConverter : JsonConverter<Format>
{
    public override Format Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" => Format.Mp4,
            "webm" => Format.Webm,
            "jpg" => Format.Jpg,
            "png" => Format.Png,
            "webp" => Format.Webp,
            _ => (Format)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Format value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Format.Mp4 => "mp4",
                Format.Webm => "webm",
                Format.Jpg => "jpg",
                Format.Png => "png",
                Format.Webp => "webp",
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
[JsonConverter(typeof(StreamProtocolConverter))]
public enum StreamProtocol
{
    Hls,
    Dash,
}

sealed class StreamProtocolConverter : JsonConverter<StreamProtocol>
{
    public override StreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" => StreamProtocol.Hls,
            "DASH" => StreamProtocol.Dash,
            _ => (StreamProtocol)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                StreamProtocol.Hls => "HLS",
                StreamProtocol.Dash => "DASH",
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
[JsonConverter(typeof(VideoCodecConverter))]
public enum VideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoCodecConverter : JsonConverter<VideoCodec>
{
    public override VideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" => VideoCodec.H264,
            "vp9" => VideoCodec.Vp9,
            "av1" => VideoCodec.Av1,
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
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Information about the original request that triggered the video transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest,
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequestFromRaw
    >)
)]
public sealed record class VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
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

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest(
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest videoTransformationAcceptedEventVideoTransformationAcceptedEventRequest
    )
        : base(videoTransformationAcceptedEventVideoTransformationAcceptedEventRequest) { }
#pragma warning restore CS8618

    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequestFromRaw
    : IFromRawJson<VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest>
{
    /// <inheritdoc/>
    public VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationAcceptedEventVideoTransformationAcceptedEventRequest.FromRawUnchecked(
            rawData
        );
}
