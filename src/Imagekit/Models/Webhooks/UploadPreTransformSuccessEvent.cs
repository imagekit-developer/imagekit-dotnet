using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using Files = Imagekit.Models.Files;
using System = System;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a pre-transformation completes successfully. The file has been
/// processed with the requested transformation and is now available in the Media
/// Library.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformSuccessEvent,
        UploadPreTransformSuccessEventFromRaw
    >)
)]
public sealed record class UploadPreTransformSuccessEvent : JsonModel
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
    /// Timestamp of when the event occurred in ISO8601 format.
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

    /// <summary>
    /// Object containing details of a successful upload.
    /// </summary>
    public required UploadPreTransformSuccessEventUploadPreTransformSuccessEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformSuccessEventUploadPreTransformSuccessEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        UploadPreTransformSuccessEvent uploadPreTransformSuccessEvent
    ) =>
        new()
        {
            ID = uploadPreTransformSuccessEvent.ID,
            Type = uploadPreTransformSuccessEvent.Type,
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

    public UploadPreTransformSuccessEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformSuccessEvent(
        UploadPreTransformSuccessEvent uploadPreTransformSuccessEvent
    )
        : base(uploadPreTransformSuccessEvent) { }
#pragma warning restore CS8618

    public UploadPreTransformSuccessEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformSuccessEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformSuccessEventFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformSuccessEventFromRaw : IFromRawJson<UploadPreTransformSuccessEvent>
{
    /// <inheritdoc/>
    public UploadPreTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformSuccessEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a pre-transformation completes successfully. The file has been
/// processed with the requested transformation and is now available in the Media
/// Library.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformSuccessEventUploadPreTransformSuccessEvent,
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventFromRaw
    >)
)]
public sealed record class UploadPreTransformSuccessEventUploadPreTransformSuccessEvent : JsonModel
{
    /// <summary>
    /// Timestamp of when the event occurred in ISO8601 format.
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

    /// <summary>
    /// Object containing details of a successful upload.
    /// </summary>
    public required UploadPreTransformSuccessEventUploadPreTransformSuccessEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformSuccessEventUploadPreTransformSuccessEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest>(
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
                JsonSerializer.SerializeToElement("upload.pre-transform.success")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEvent(
        UploadPreTransformSuccessEventUploadPreTransformSuccessEvent uploadPreTransformSuccessEventUploadPreTransformSuccessEvent
    )
        : base(uploadPreTransformSuccessEventUploadPreTransformSuccessEvent) { }
#pragma warning restore CS8618

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformSuccessEventUploadPreTransformSuccessEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformSuccessEventUploadPreTransformSuccessEventFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformSuccessEventUploadPreTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformSuccessEventUploadPreTransformSuccessEventFromRaw
    : IFromRawJson<UploadPreTransformSuccessEventUploadPreTransformSuccessEvent>
{
    /// <inheritdoc/>
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformSuccessEventUploadPreTransformSuccessEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Object containing details of a successful upload.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventData,
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventDataFromRaw
    >)
)]
public sealed record class UploadPreTransformSuccessEventUploadPreTransformSuccessEventData
    : JsonModel
{
    /// <summary>
    /// An array of tags assigned to the uploaded file by auto tagging.
    /// </summary>
    public IReadOnlyList<AITag>? AITags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AITag>>("AITags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AITag>?>(
                "AITags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The audio codec used in the video (only for video).
    /// </summary>
    public string? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("audioCodec");
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
    /// The bit rate of the video in kbps (only for video).
    /// </summary>
    public long? BitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bitRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitRate", value);
        }
    }

    /// <summary>
    /// Value of custom coordinates associated with the image in the format `x,y,width,height`.
    /// If `customCoordinates` are not defined, then it is `null`. Send `customCoordinates`
    /// in `responseFields` in API request to get the value of this field.
    /// </summary>
    public string? CustomCoordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customCoordinates");
        }
        init { this._rawData.Set("customCoordinates", value); }
    }

    /// <summary>
    /// A key-value data associated with the asset. Use `responseField` in API request
    /// to get `customMetadata` in the upload API response. Before setting any custom
    /// metadata on an asset, you have to create the field using custom metadata fields
    /// API. Send `customMetadata` in `responseFields` in API request to get the value
    /// of this field.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "customMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "customMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional text to describe the contents of the file. Can be set by the user
    /// or the ai-auto-description extension.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The duration of the video in seconds (only for video).
    /// </summary>
    public long? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration");
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
    /// Consolidated embedded metadata associated with the file. It includes exif,
    /// iptc, and xmp data. Send `embeddedMetadata` in `responseFields` in API request
    /// to get embeddedMetadata in the upload API response.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? EmbeddedMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "embeddedMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "embeddedMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Extension names with their processing status at the time of completion of
    /// the request. It could have one of the following status values:
    ///
    /// <para>`success`: The extension has been successfully applied. `failed`: The
    /// extension has failed and will not be retried. `pending`: The extension will
    /// finish processing in some time. On completion, the final status (success
    /// / failed) will be sent to the `webhookUrl` provided.</para>
    ///
    /// <para>If no extension was requested, then this parameter is not returned. </para>
    /// </summary>
    public ExtensionStatus? ExtensionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExtensionStatus>("extensionStatus");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("extensionStatus", value);
        }
    }

    /// <summary>
    /// Unique fileId. Store this fileld in your database, as this will be used to
    /// perform update action on this file.
    /// </summary>
    public string? FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fileId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileId", value);
        }
    }

    /// <summary>
    /// The relative path of the file in the media library e.g. `/marketing-assets/new-banner.jpg`.
    /// </summary>
    public string? FilePath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filePath");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filePath", value);
        }
    }

    /// <summary>
    /// Type of the uploaded file. Possible values are `image`, `non-image`.
    /// </summary>
    public string? FileType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("fileType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("fileType", value);
        }
    }

    /// <summary>
    /// Height of the image in pixels (Only for images)
    /// </summary>
    public double? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("height");
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
    /// Is the file marked as private. It can be either `true` or `false`. Send `isPrivateFile`
    /// in `responseFields` in API request to get the value of this field.
    /// </summary>
    public bool? IsPrivateFile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPrivateFile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPrivateFile", value);
        }
    }

    /// <summary>
    /// Is the file published or in draft state. It can be either `true` or `false`.
    /// Send `isPublished` in `responseFields` in API request to get the value of
    /// this field.
    /// </summary>
    public bool? IsPublished
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPublished");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPublished", value);
        }
    }

    /// <summary>
    /// Legacy metadata. Send `metadata` in `responseFields` in API request to get
    /// metadata in the upload API response.
    /// </summary>
    public Files::FileMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Files::FileMetadata>("metadata");
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
    /// Name of the asset.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// This field is included in the response only if the Path policy feature is
    /// available in the plan. It contains schema definitions for the custom metadata
    /// fields selected for the specified file path. Field selection can only be
    /// done when the Path policy feature is enabled.
    ///
    /// <para>Keys are the names of the custom metadata fields; the value object
    /// has details about the custom metadata schema. </para>
    /// </summary>
    public IReadOnlyDictionary<string, SelectedFieldsSchemaItem>? SelectedFieldsSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, SelectedFieldsSchemaItem>
            >("selectedFieldsSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, SelectedFieldsSchemaItem>?>(
                "selectedFieldsSchema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Size of the image file in Bytes.
    /// </summary>
    public double? Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// The array of tags associated with the asset. If no tags are set, it will be
    /// `null`. Send `tags` in `responseFields` in API request to get the value of
    /// this field.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// In the case of an image, a small thumbnail URL.
    /// </summary>
    public string? ThumbnailUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("thumbnailUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thumbnailUrl", value);
        }
    }

    /// <summary>
    /// A publicly accessible URL of the file.
    /// </summary>
    public string? Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <summary>
    /// An object containing the file or file version's `id` (versionId) and `name`.
    /// </summary>
    public VersionInfo? VersionInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VersionInfo>("versionInfo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("versionInfo", value);
        }
    }

    /// <summary>
    /// The video codec used in the video (only for video).
    /// </summary>
    public string? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("videoCodec");
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
    /// Width of the image in pixels (Only for Images)
    /// </summary>
    public double? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("width");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AITags ?? [])
        {
            item.Validate();
        }
        _ = this.AudioCodec;
        _ = this.BitRate;
        _ = this.CustomCoordinates;
        _ = this.CustomMetadata;
        _ = this.Description;
        _ = this.Duration;
        _ = this.EmbeddedMetadata;
        this.ExtensionStatus?.Validate();
        _ = this.FileID;
        _ = this.FilePath;
        _ = this.FileType;
        _ = this.Height;
        _ = this.IsPrivateFile;
        _ = this.IsPublished;
        this.Metadata?.Validate();
        _ = this.Name;
        if (this.SelectedFieldsSchema != null)
        {
            foreach (var item in this.SelectedFieldsSchema.Values)
            {
                item.Validate();
            }
        }
        _ = this.Size;
        _ = this.Tags;
        _ = this.ThumbnailUrl;
        _ = this.Url;
        this.VersionInfo?.Validate();
        _ = this.VideoCodec;
        _ = this.Width;
    }

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventData(
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventData uploadPreTransformSuccessEventUploadPreTransformSuccessEventData
    )
        : base(uploadPreTransformSuccessEventUploadPreTransformSuccessEventData) { }
#pragma warning restore CS8618

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformSuccessEventUploadPreTransformSuccessEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformSuccessEventUploadPreTransformSuccessEventDataFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformSuccessEventUploadPreTransformSuccessEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformSuccessEventUploadPreTransformSuccessEventDataFromRaw
    : IFromRawJson<UploadPreTransformSuccessEventUploadPreTransformSuccessEventData>
{
    /// <inheritdoc/>
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformSuccessEventUploadPreTransformSuccessEventData.FromRawUnchecked(rawData);
}

/// <summary>
/// Extension names with their processing status at the time of completion of the
/// request. It could have one of the following status values:
///
/// <para>`success`: The extension has been successfully applied. `failed`: The extension
/// has failed and will not be retried. `pending`: The extension will finish processing
/// in some time. On completion, the final status (success / failed) will be sent
/// to the `webhookUrl` provided.</para>
///
/// <para>If no extension was requested, then this parameter is not returned. </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExtensionStatus, ExtensionStatusFromRaw>))]
public sealed record class ExtensionStatus : JsonModel
{
    public ApiEnum<string, AIAutoDescription>? AIAutoDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AIAutoDescription>>(
                "ai-auto-description"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ai-auto-description", value);
        }
    }

    public ApiEnum<string, AITasks>? AITasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AITasks>>("ai-tasks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ai-tasks", value);
        }
    }

    public ApiEnum<string, AwsAutoTagging>? AwsAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AwsAutoTagging>>(
                "aws-auto-tagging"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("aws-auto-tagging", value);
        }
    }

    public ApiEnum<string, GoogleAutoTagging>? GoogleAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, GoogleAutoTagging>>(
                "google-auto-tagging"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("google-auto-tagging", value);
        }
    }

    public ApiEnum<string, RemoveBg>? RemoveBg
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RemoveBg>>("remove-bg");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("remove-bg", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.AIAutoDescription?.Validate();
        this.AITasks?.Validate();
        this.AwsAutoTagging?.Validate();
        this.GoogleAutoTagging?.Validate();
        this.RemoveBg?.Validate();
    }

    public ExtensionStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionStatus(ExtensionStatus extensionStatus)
        : base(extensionStatus) { }
#pragma warning restore CS8618

    public ExtensionStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionStatusFromRaw.FromRawUnchecked"/>
    public static ExtensionStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionStatusFromRaw : IFromRawJson<ExtensionStatus>
{
    /// <inheritdoc/>
    public ExtensionStatus FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExtensionStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AIAutoDescriptionConverter))]
public enum AIAutoDescription
{
    Success,
    Pending,
    Failed,
}

sealed class AIAutoDescriptionConverter : JsonConverter<AIAutoDescription>
{
    public override AIAutoDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AIAutoDescription.Success,
            "pending" => AIAutoDescription.Pending,
            "failed" => AIAutoDescription.Failed,
            _ => (AIAutoDescription)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AIAutoDescription.Success => "success",
                AIAutoDescription.Pending => "pending",
                AIAutoDescription.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AITasksConverter))]
public enum AITasks
{
    Success,
    Pending,
    Failed,
}

sealed class AITasksConverter : JsonConverter<AITasks>
{
    public override AITasks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AITasks.Success,
            "pending" => AITasks.Pending,
            "failed" => AITasks.Failed,
            _ => (AITasks)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, AITasks value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AITasks.Success => "success",
                AITasks.Pending => "pending",
                AITasks.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(AwsAutoTaggingConverter))]
public enum AwsAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class AwsAutoTaggingConverter : JsonConverter<AwsAutoTagging>
{
    public override AwsAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => AwsAutoTagging.Success,
            "pending" => AwsAutoTagging.Pending,
            "failed" => AwsAutoTagging.Failed,
            _ => (AwsAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AwsAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AwsAutoTagging.Success => "success",
                AwsAutoTagging.Pending => "pending",
                AwsAutoTagging.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GoogleAutoTaggingConverter))]
public enum GoogleAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class GoogleAutoTaggingConverter : JsonConverter<GoogleAutoTagging>
{
    public override GoogleAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => GoogleAutoTagging.Success,
            "pending" => GoogleAutoTagging.Pending,
            "failed" => GoogleAutoTagging.Failed,
            _ => (GoogleAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GoogleAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GoogleAutoTagging.Success => "success",
                GoogleAutoTagging.Pending => "pending",
                GoogleAutoTagging.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(RemoveBgConverter))]
public enum RemoveBg
{
    Success,
    Pending,
    Failed,
}

sealed class RemoveBgConverter : JsonConverter<RemoveBg>
{
    public override RemoveBg Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => RemoveBg.Success,
            "pending" => RemoveBg.Pending,
            "failed" => RemoveBg.Failed,
            _ => (RemoveBg)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, RemoveBg value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                RemoveBg.Success => "success",
                RemoveBg.Pending => "pending",
                RemoveBg.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest,
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequestFromRaw
    >)
)]
public sealed record class UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest
    : JsonModel
{
    /// <summary>
    /// The requested pre-transformation string.
    /// </summary>
    public required string Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transformation");
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <summary>
    /// Unique identifier for the originating request.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Transformation;
        _ = this.XRequestID;
    }

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest(
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest uploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest
    )
        : base(uploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest) { }
#pragma warning restore CS8618

    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequestFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequestFromRaw
    : IFromRawJson<UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest>
{
    /// <inheritdoc/>
    public UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPreTransformSuccessEventUploadPreTransformSuccessEventRequest.FromRawUnchecked(
            rawData
        );
}
