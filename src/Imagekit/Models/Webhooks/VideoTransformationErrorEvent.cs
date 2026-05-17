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
/// Triggered when an error occurs during video encoding. Listen to this webhook
/// to log error reasons and debug issues. Check your origin and URL endpoint settings
/// if the reason is related to download failure. For other errors, contact ImageKit
/// support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<VideoTransformationErrorEvent, VideoTransformationErrorEventFromRaw>)
)]
public sealed record class VideoTransformationErrorEvent : JsonModel
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

    public required VideoTransformationErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationErrorEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1Request>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        VideoTransformationErrorEvent videoTransformationErrorEvent
    ) => new() { ID = videoTransformationErrorEvent.ID, Type = videoTransformationErrorEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public VideoTransformationErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEvent(
        VideoTransformationErrorEvent videoTransformationErrorEvent
    )
        : base(videoTransformationErrorEvent) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventFromRaw : IFromRawJson<VideoTransformationErrorEvent>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when an error occurs during video encoding. Listen to this webhook
/// to log error reasons and debug issues. Check your origin and URL endpoint settings
/// if the reason is related to download failure. For other errors, contact ImageKit
/// support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1,
        VideoTransformationErrorEventIntersectionMember1FromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1 : JsonModel
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

    public required VideoTransformationErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationErrorEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1Request>(
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
                JsonSerializer.SerializeToElement("video.transformation.error")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public VideoTransformationErrorEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1(
        VideoTransformationErrorEventIntersectionMember1 videoTransformationErrorEventIntersectionMember1
    )
        : base(videoTransformationErrorEventIntersectionMember1) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventIntersectionMember1FromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1Data,
        VideoTransformationErrorEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1Data : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required VideoTransformationErrorEventIntersectionMember1DataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1DataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required VideoTransformationErrorEventIntersectionMember1DataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventIntersectionMember1DataTransformation>(
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

    public VideoTransformationErrorEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1Data(
        VideoTransformationErrorEventIntersectionMember1Data videoTransformationErrorEventIntersectionMember1Data
    )
        : base(videoTransformationErrorEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventIntersectionMember1DataFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventIntersectionMember1Data.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1DataAsset,
        VideoTransformationErrorEventIntersectionMember1DataAssetFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1DataAsset : JsonModel
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

    public VideoTransformationErrorEventIntersectionMember1DataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataAsset(
        VideoTransformationErrorEventIntersectionMember1DataAsset videoTransformationErrorEventIntersectionMember1DataAsset
    )
        : base(videoTransformationErrorEventIntersectionMember1DataAsset) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1DataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1DataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1DataAssetFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1DataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class VideoTransformationErrorEventIntersectionMember1DataAssetFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1DataAsset>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1DataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventIntersectionMember1DataAsset.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1DataTransformation,
        VideoTransformationErrorEventIntersectionMember1DataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1DataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<
        string,
        VideoTransformationErrorEventIntersectionMember1DataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventIntersectionMember1DataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Details about the transformation error.
    /// </summary>
    public VideoTransformationErrorEventIntersectionMember1DataTransformationError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationErrorEventIntersectionMember1DataTransformationError>(
                "error"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Configuration options for video transformations.
    /// </summary>
    public VideoTransformationErrorEventIntersectionMember1DataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationErrorEventIntersectionMember1DataTransformationOptions>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Error?.Validate();
        this.Options?.Validate();
    }

    public VideoTransformationErrorEventIntersectionMember1DataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataTransformation(
        VideoTransformationErrorEventIntersectionMember1DataTransformation videoTransformationErrorEventIntersectionMember1DataTransformation
    )
        : base(videoTransformationErrorEventIntersectionMember1DataTransformation) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1DataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1DataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1DataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataTransformation(
        ApiEnum<string, VideoTransformationErrorEventIntersectionMember1DataTransformationType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationErrorEventIntersectionMember1DataTransformationFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1DataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventIntersectionMember1DataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(
    typeof(VideoTransformationErrorEventIntersectionMember1DataTransformationTypeConverter)
)]
public enum VideoTransformationErrorEventIntersectionMember1DataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationErrorEventIntersectionMember1DataTransformationTypeConverter
    : JsonConverter<VideoTransformationErrorEventIntersectionMember1DataTransformationType>
{
    public override VideoTransformationErrorEventIntersectionMember1DataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation,
            "gif-to-video" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoThumbnail,
            _ => (VideoTransformationErrorEventIntersectionMember1DataTransformationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventIntersectionMember1DataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationErrorEventIntersectionMember1DataTransformationType.VideoThumbnail =>
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
/// Details about the transformation error.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1DataTransformationError,
        VideoTransformationErrorEventIntersectionMember1DataTransformationErrorFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1DataTransformationError
    : JsonModel
{
    /// <summary>
    /// Specific reason for the transformation failure: - `encoding_failed`: Error
    /// during video encoding process - `download_failed`: Could not download source
    /// video - `internal_server_error`: Unexpected server error
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
    }

    public VideoTransformationErrorEventIntersectionMember1DataTransformationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataTransformationError(
        VideoTransformationErrorEventIntersectionMember1DataTransformationError videoTransformationErrorEventIntersectionMember1DataTransformationError
    )
        : base(videoTransformationErrorEventIntersectionMember1DataTransformationError) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1DataTransformationError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1DataTransformationError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1DataTransformationErrorFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1DataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataTransformationError(
        ApiEnum<string, Reason> reason
    )
        : this()
    {
        this.Reason = reason;
    }
}

class VideoTransformationErrorEventIntersectionMember1DataTransformationErrorFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1DataTransformationError>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1DataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventIntersectionMember1DataTransformationError.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Specific reason for the transformation failure: - `encoding_failed`: Error during
/// video encoding process - `download_failed`: Could not download source video -
/// `internal_server_error`: Unexpected server error
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    EncodingFailed,
    DownloadFailed,
    InternalServerError,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "encoding_failed" => Reason.EncodingFailed,
            "download_failed" => Reason.DownloadFailed,
            "internal_server_error" => Reason.InternalServerError,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.EncodingFailed => "encoding_failed",
                Reason.DownloadFailed => "download_failed",
                Reason.InternalServerError => "internal_server_error",
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
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1DataTransformationOptions
    : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
    >? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
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
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
    >? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
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
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
    >? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
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
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
    >? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
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

    public VideoTransformationErrorEventIntersectionMember1DataTransformationOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1DataTransformationOptions(
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions videoTransformationErrorEventIntersectionMember1DataTransformationOptions
    )
        : base(videoTransformationErrorEventIntersectionMember1DataTransformationOptions) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1DataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1DataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1DataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1DataTransformationOptions>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1DataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodecConverter)
)]
public enum VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec
{
    Aac,
    Opus,
}

sealed class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodecConverter
    : JsonConverter<VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec>
{
    public override VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac,
            "opus" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus,
            _ =>
                (VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Aac =>
                    "aac",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsAudioCodec.Opus =>
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
    typeof(VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormatConverter)
)]
public enum VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormatConverter
    : JsonConverter<VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat>
{
    public override VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4,
            "webm" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webm,
            "jpg" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Jpg,
            "png" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Png,
            "webp" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webp,
            _ => (VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Mp4 =>
                    "mp4",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webm =>
                    "webm",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Jpg =>
                    "jpg",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Png =>
                    "png",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsFormat.Webp =>
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
    typeof(VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocolConverter)
)]
public enum VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol
{
    Hls,
    Dash,
}

sealed class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocolConverter
    : JsonConverter<VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol>
{
    public override VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls,
            "DASH" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash,
            _ =>
                (VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Hls =>
                    "HLS",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsStreamProtocol.Dash =>
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
    typeof(VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodecConverter)
)]
public enum VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodecConverter
    : JsonConverter<VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec>
{
    public override VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264,
            "vp9" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9,
            "av1" =>
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1,
            _ =>
                (VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.H264 =>
                    "h264",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Vp9 =>
                    "vp9",
                VideoTransformationErrorEventIntersectionMember1DataTransformationOptionsVideoCodec.Av1 =>
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
/// Information about the original request that triggered the video transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventIntersectionMember1Request,
        VideoTransformationErrorEventIntersectionMember1RequestFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventIntersectionMember1Request : JsonModel
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

    public VideoTransformationErrorEventIntersectionMember1Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventIntersectionMember1Request(
        VideoTransformationErrorEventIntersectionMember1Request videoTransformationErrorEventIntersectionMember1Request
    )
        : base(videoTransformationErrorEventIntersectionMember1Request) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventIntersectionMember1Request(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventIntersectionMember1Request(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventIntersectionMember1RequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventIntersectionMember1RequestFromRaw
    : IFromRawJson<VideoTransformationErrorEventIntersectionMember1Request>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventIntersectionMember1Request.FromRawUnchecked(rawData);
}
