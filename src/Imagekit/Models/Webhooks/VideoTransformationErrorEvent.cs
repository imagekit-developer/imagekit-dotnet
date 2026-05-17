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

    public required VideoTransformationErrorEventVideoTransformationErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationErrorEventVideoTransformationErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventRequest>(
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
        VideoTransformationErrorEventVideoTransformationErrorEvent,
        VideoTransformationErrorEventVideoTransformationErrorEventFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEvent : JsonModel
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

    public required VideoTransformationErrorEventVideoTransformationErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required VideoTransformationErrorEventVideoTransformationErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventRequest>(
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

    public VideoTransformationErrorEventVideoTransformationErrorEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("video.transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEvent(
        VideoTransformationErrorEventVideoTransformationErrorEvent videoTransformationErrorEventVideoTransformationErrorEvent
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEvent) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("video.transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEvent>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventVideoTransformationErrorEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventVideoTransformationErrorEventData,
        VideoTransformationErrorEventVideoTransformationErrorEventDataFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source video asset being transformed.
    /// </summary>
    public required VideoTransformationErrorEventVideoTransformationErrorEventDataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventDataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation>(
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

    public VideoTransformationErrorEventVideoTransformationErrorEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventData(
        VideoTransformationErrorEventVideoTransformationErrorEventData videoTransformationErrorEventVideoTransformationErrorEventData
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventData) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventDataFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventDataFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventData>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VideoTransformationErrorEventVideoTransformationErrorEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset,
        VideoTransformationErrorEventVideoTransformationErrorEventDataAssetFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventDataAsset
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

    public VideoTransformationErrorEventVideoTransformationErrorEventDataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataAsset(
        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset videoTransformationErrorEventVideoTransformationErrorEventDataAsset
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventDataAsset) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventDataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventDataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventDataAssetFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventDataAssetFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventDataAsset>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventVideoTransformationErrorEventDataAsset.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of video transformation: - `video-transformation`: Standard video processing
    /// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF
    /// to video format - `video-thumbnail`: Generate thumbnail image from video
    /// </summary>
    public required ApiEnum<
        string,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Details about the transformation error.
    /// </summary>
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError>(
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
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions>(
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

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation videoTransformationErrorEventVideoTransformationErrorEventDataTransformation
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventDataTransformation) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation(
        ApiEnum<
            string,
            VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of video transformation: - `video-transformation`: Standard video processing
/// (resize, format conversion, etc.) - `gif-to-video`: Convert animated GIF to video
/// format - `video-thumbnail`: Generate thumbnail image from video
/// </summary>
[JsonConverter(
    typeof(VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationTypeConverter)
)]
public enum VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType
{
    VideoTransformation,
    GifToVideo,
    VideoThumbnail,
}

sealed class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationTypeConverter
    : JsonConverter<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType>
{
    public override VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video-transformation" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation,
            "gif-to-video" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.GifToVideo,
            "video-thumbnail" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoThumbnail,
            _ => (VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoTransformation =>
                    "video-transformation",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.GifToVideo =>
                    "gif-to-video",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationType.VideoThumbnail =>
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
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationErrorFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
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

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError videoTransformationErrorEventVideoTransformationErrorEventDataTransformationError
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventDataTransformationError)
    { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationErrorFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError(
        ApiEnum<string, Reason> reason
    )
        : this()
    {
        this.Reason = reason;
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationErrorFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationError.FromRawUnchecked(
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
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
    : JsonModel
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<
        string,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
    >? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
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
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
    >? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
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
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
    >? StreamProtocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
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
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
    >? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
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

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions(
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions videoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions)
    { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Audio codec used for encoding (aac or opus).
/// </summary>
[JsonConverter(
    typeof(VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodecConverter)
)]
public enum VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec
{
    Aac,
    Opus,
}

sealed class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodecConverter
    : JsonConverter<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec>
{
    public override VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aac" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac,
            "opus" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Opus,
            _ =>
                (VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Aac =>
                    "aac",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsAudioCodec.Opus =>
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
    typeof(VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormatConverter)
)]
public enum VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat
{
    Mp4,
    Webm,
    Jpg,
    Png,
    Webp,
}

sealed class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormatConverter
    : JsonConverter<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat>
{
    public override VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mp4" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4,
            "webm" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webm,
            "jpg" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Jpg,
            "png" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Png,
            "webp" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webp,
            _ =>
                (VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Mp4 =>
                    "mp4",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webm =>
                    "webm",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Jpg =>
                    "jpg",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Png =>
                    "png",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsFormat.Webp =>
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
    typeof(VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocolConverter)
)]
public enum VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol
{
    Hls,
    Dash,
}

sealed class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocolConverter
    : JsonConverter<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol>
{
    public override VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "HLS" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls,
            "DASH" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Dash,
            _ =>
                (VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Hls =>
                    "HLS",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsStreamProtocol.Dash =>
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
    typeof(VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodecConverter)
)]
public enum VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec
{
    H264,
    Vp9,
    Av1,
}

sealed class VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodecConverter
    : JsonConverter<VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec>
{
    public override VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "h264" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264,
            "vp9" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Vp9,
            "av1" =>
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Av1,
            _ =>
                (VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.H264 =>
                    "h264",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Vp9 =>
                    "vp9",
                VideoTransformationErrorEventVideoTransformationErrorEventDataTransformationOptionsVideoCodec.Av1 =>
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
        VideoTransformationErrorEventVideoTransformationErrorEventRequest,
        VideoTransformationErrorEventVideoTransformationErrorEventRequestFromRaw
    >)
)]
public sealed record class VideoTransformationErrorEventVideoTransformationErrorEventRequest
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

    public VideoTransformationErrorEventVideoTransformationErrorEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoTransformationErrorEventVideoTransformationErrorEventRequest(
        VideoTransformationErrorEventVideoTransformationErrorEventRequest videoTransformationErrorEventVideoTransformationErrorEventRequest
    )
        : base(videoTransformationErrorEventVideoTransformationErrorEventRequest) { }
#pragma warning restore CS8618

    public VideoTransformationErrorEventVideoTransformationErrorEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoTransformationErrorEventVideoTransformationErrorEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoTransformationErrorEventVideoTransformationErrorEventRequestFromRaw.FromRawUnchecked"/>
    public static VideoTransformationErrorEventVideoTransformationErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoTransformationErrorEventVideoTransformationErrorEventRequestFromRaw
    : IFromRawJson<VideoTransformationErrorEventVideoTransformationErrorEventRequest>
{
    /// <inheritdoc/>
    public VideoTransformationErrorEventVideoTransformationErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        VideoTransformationErrorEventVideoTransformationErrorEventRequest.FromRawUnchecked(rawData);
}
