using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Files;

/// <summary>
/// Object containing details of a successful upload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUploadResponse, FileUploadResponseFromRaw>))]
public sealed record class FileUploadResponse : JsonModel
{
    /// <summary>
    /// An array of tags assigned to the uploaded file by auto tagging.
    /// </summary>
    public IReadOnlyList<FileUploadResponseAITag>? AITags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FileUploadResponseAITag>>(
                "AITags"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<FileUploadResponseAITag>?>(
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
    public FileUploadResponseExtensionStatus? ExtensionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileUploadResponseExtensionStatus>(
                "extensionStatus"
            );
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
    public FileMetadata? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileMetadata>("metadata");
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
    public IReadOnlyDictionary<
        string,
        FileUploadResponseSelectedFieldsSchemaItem
    >? SelectedFieldsSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<string, FileUploadResponseSelectedFieldsSchemaItem>
            >("selectedFieldsSchema");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<
                string,
                FileUploadResponseSelectedFieldsSchemaItem
            >?>(
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
    public FileUploadResponseVersionInfo? VersionInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileUploadResponseVersionInfo>("versionInfo");
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

    public FileUploadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponse(FileUploadResponse fileUploadResponse)
        : base(fileUploadResponse) { }
#pragma warning restore CS8618

    public FileUploadResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseFromRaw.FromRawUnchecked"/>
    public static FileUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUploadResponseFromRaw : IFromRawJson<FileUploadResponse>
{
    /// <inheritdoc/>
    public FileUploadResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileUploadResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// AI-generated tag associated with an image. These tags can be added using the `google-auto-tagging`
/// or `aws-auto-tagging` extensions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUploadResponseAITag, FileUploadResponseAITagFromRaw>))]
public sealed record class FileUploadResponseAITag : JsonModel
{
    /// <summary>
    /// Confidence score of the tag.
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// Name of the tag.
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
    /// Source of the tag. Possible values are `google-auto-tagging` and `aws-auto-tagging`.
    /// </summary>
    public string? Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("source");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Name;
        _ = this.Source;
    }

    public FileUploadResponseAITag() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponseAITag(FileUploadResponseAITag fileUploadResponseAITag)
        : base(fileUploadResponseAITag) { }
#pragma warning restore CS8618

    public FileUploadResponseAITag(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponseAITag(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseAITagFromRaw.FromRawUnchecked"/>
    public static FileUploadResponseAITag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUploadResponseAITagFromRaw : IFromRawJson<FileUploadResponseAITag>
{
    /// <inheritdoc/>
    public FileUploadResponseAITag FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUploadResponseAITag.FromRawUnchecked(rawData);
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
[JsonConverter(
    typeof(JsonModelConverter<
        FileUploadResponseExtensionStatus,
        FileUploadResponseExtensionStatusFromRaw
    >)
)]
public sealed record class FileUploadResponseExtensionStatus : JsonModel
{
    public ApiEnum<string, FileUploadResponseExtensionStatusAIAutoDescription>? AIAutoDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FileUploadResponseExtensionStatusAIAutoDescription>
            >("ai-auto-description");
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

    public ApiEnum<string, FileUploadResponseExtensionStatusAITasks>? AITasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FileUploadResponseExtensionStatusAITasks>
            >("ai-tasks");
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

    public ApiEnum<string, FileUploadResponseExtensionStatusAwsAutoTagging>? AwsAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FileUploadResponseExtensionStatusAwsAutoTagging>
            >("aws-auto-tagging");
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

    public ApiEnum<string, FileUploadResponseExtensionStatusGoogleAutoTagging>? GoogleAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FileUploadResponseExtensionStatusGoogleAutoTagging>
            >("google-auto-tagging");
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

    public ApiEnum<string, FileUploadResponseExtensionStatusRemoveBg>? RemoveBg
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, FileUploadResponseExtensionStatusRemoveBg>
            >("remove-bg");
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

    public FileUploadResponseExtensionStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponseExtensionStatus(
        FileUploadResponseExtensionStatus fileUploadResponseExtensionStatus
    )
        : base(fileUploadResponseExtensionStatus) { }
#pragma warning restore CS8618

    public FileUploadResponseExtensionStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponseExtensionStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseExtensionStatusFromRaw.FromRawUnchecked"/>
    public static FileUploadResponseExtensionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUploadResponseExtensionStatusFromRaw : IFromRawJson<FileUploadResponseExtensionStatus>
{
    /// <inheritdoc/>
    public FileUploadResponseExtensionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUploadResponseExtensionStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(FileUploadResponseExtensionStatusAIAutoDescriptionConverter))]
public enum FileUploadResponseExtensionStatusAIAutoDescription
{
    Success,
    Pending,
    Failed,
}

sealed class FileUploadResponseExtensionStatusAIAutoDescriptionConverter
    : JsonConverter<FileUploadResponseExtensionStatusAIAutoDescription>
{
    public override FileUploadResponseExtensionStatusAIAutoDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => FileUploadResponseExtensionStatusAIAutoDescription.Success,
            "pending" => FileUploadResponseExtensionStatusAIAutoDescription.Pending,
            "failed" => FileUploadResponseExtensionStatusAIAutoDescription.Failed,
            _ => (FileUploadResponseExtensionStatusAIAutoDescription)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseExtensionStatusAIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseExtensionStatusAIAutoDescription.Success => "success",
                FileUploadResponseExtensionStatusAIAutoDescription.Pending => "pending",
                FileUploadResponseExtensionStatusAIAutoDescription.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FileUploadResponseExtensionStatusAITasksConverter))]
public enum FileUploadResponseExtensionStatusAITasks
{
    Success,
    Pending,
    Failed,
}

sealed class FileUploadResponseExtensionStatusAITasksConverter
    : JsonConverter<FileUploadResponseExtensionStatusAITasks>
{
    public override FileUploadResponseExtensionStatusAITasks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => FileUploadResponseExtensionStatusAITasks.Success,
            "pending" => FileUploadResponseExtensionStatusAITasks.Pending,
            "failed" => FileUploadResponseExtensionStatusAITasks.Failed,
            _ => (FileUploadResponseExtensionStatusAITasks)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseExtensionStatusAITasks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseExtensionStatusAITasks.Success => "success",
                FileUploadResponseExtensionStatusAITasks.Pending => "pending",
                FileUploadResponseExtensionStatusAITasks.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FileUploadResponseExtensionStatusAwsAutoTaggingConverter))]
public enum FileUploadResponseExtensionStatusAwsAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class FileUploadResponseExtensionStatusAwsAutoTaggingConverter
    : JsonConverter<FileUploadResponseExtensionStatusAwsAutoTagging>
{
    public override FileUploadResponseExtensionStatusAwsAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => FileUploadResponseExtensionStatusAwsAutoTagging.Success,
            "pending" => FileUploadResponseExtensionStatusAwsAutoTagging.Pending,
            "failed" => FileUploadResponseExtensionStatusAwsAutoTagging.Failed,
            _ => (FileUploadResponseExtensionStatusAwsAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseExtensionStatusAwsAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseExtensionStatusAwsAutoTagging.Success => "success",
                FileUploadResponseExtensionStatusAwsAutoTagging.Pending => "pending",
                FileUploadResponseExtensionStatusAwsAutoTagging.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FileUploadResponseExtensionStatusGoogleAutoTaggingConverter))]
public enum FileUploadResponseExtensionStatusGoogleAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class FileUploadResponseExtensionStatusGoogleAutoTaggingConverter
    : JsonConverter<FileUploadResponseExtensionStatusGoogleAutoTagging>
{
    public override FileUploadResponseExtensionStatusGoogleAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => FileUploadResponseExtensionStatusGoogleAutoTagging.Success,
            "pending" => FileUploadResponseExtensionStatusGoogleAutoTagging.Pending,
            "failed" => FileUploadResponseExtensionStatusGoogleAutoTagging.Failed,
            _ => (FileUploadResponseExtensionStatusGoogleAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseExtensionStatusGoogleAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseExtensionStatusGoogleAutoTagging.Success => "success",
                FileUploadResponseExtensionStatusGoogleAutoTagging.Pending => "pending",
                FileUploadResponseExtensionStatusGoogleAutoTagging.Failed => "failed",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(FileUploadResponseExtensionStatusRemoveBgConverter))]
public enum FileUploadResponseExtensionStatusRemoveBg
{
    Success,
    Pending,
    Failed,
}

sealed class FileUploadResponseExtensionStatusRemoveBgConverter
    : JsonConverter<FileUploadResponseExtensionStatusRemoveBg>
{
    public override FileUploadResponseExtensionStatusRemoveBg Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => FileUploadResponseExtensionStatusRemoveBg.Success,
            "pending" => FileUploadResponseExtensionStatusRemoveBg.Pending,
            "failed" => FileUploadResponseExtensionStatusRemoveBg.Failed,
            _ => (FileUploadResponseExtensionStatusRemoveBg)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseExtensionStatusRemoveBg value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseExtensionStatusRemoveBg.Success => "success",
                FileUploadResponseExtensionStatusRemoveBg.Pending => "pending",
                FileUploadResponseExtensionStatusRemoveBg.Failed => "failed",
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
        FileUploadResponseSelectedFieldsSchemaItem,
        FileUploadResponseSelectedFieldsSchemaItemFromRaw
    >)
)]
public sealed record class FileUploadResponseSelectedFieldsSchemaItem : JsonModel
{
    /// <summary>
    /// Type of the custom metadata field.
    /// </summary>
    public required ApiEnum<string, FileUploadResponseSelectedFieldsSchemaItemType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, FileUploadResponseSelectedFieldsSchemaItemType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The default value for this custom metadata field. The value should match
    /// the `type` of custom metadata field.
    /// </summary>
    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue? DefaultValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileUploadResponseSelectedFieldsSchemaItemDefaultValue>(
                "defaultValue"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("defaultValue", value);
        }
    }

    /// <summary>
    /// Specifies if the custom metadata field is required or not.
    /// </summary>
    public bool? IsValueRequired
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isValueRequired");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isValueRequired", value);
        }
    }

    /// <summary>
    /// Maximum length of string. Only set if `type` is set to `Text` or `Textarea`.
    /// </summary>
    public double? MaxLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("maxLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxLength", value);
        }
    }

    /// <summary>
    /// Maximum value of the field. Only set if field type is `Date` or `Number`.
    /// For `Date` type field, the value will be in ISO8601 string format. For `Number`
    /// type field, it will be a numeric value.
    /// </summary>
    public FileUploadResponseSelectedFieldsSchemaItemMaxValue? MaxValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileUploadResponseSelectedFieldsSchemaItemMaxValue>(
                "maxValue"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("maxValue", value);
        }
    }

    /// <summary>
    /// Minimum length of string. Only set if `type` is set to `Text` or `Textarea`.
    /// </summary>
    public double? MinLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("minLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minLength", value);
        }
    }

    /// <summary>
    /// Minimum value of the field. Only set if field type is `Date` or `Number`.
    /// For `Date` type field, the value will be in ISO8601 string format. For `Number`
    /// type field, it will be a numeric value.
    /// </summary>
    public FileUploadResponseSelectedFieldsSchemaItemMinValue? MinValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FileUploadResponseSelectedFieldsSchemaItemMinValue>(
                "minValue"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("minValue", value);
        }
    }

    /// <summary>
    /// Indicates whether the custom metadata field is read only. A read only field
    /// cannot be modified after being set. This field is configurable only via the
    /// **Path policy** feature.
    /// </summary>
    public bool? ReadOnly
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("readOnly");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("readOnly", value);
        }
    }

    /// <summary>
    /// An array of allowed values when field type is `SingleSelect` or `MultiSelect`.
    /// </summary>
    public IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemSelectOption>? SelectOptions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<FileUploadResponseSelectedFieldsSchemaItemSelectOption>
            >("selectOptions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<FileUploadResponseSelectedFieldsSchemaItemSelectOption>?>(
                "selectOptions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Specifies if the selectOptions array is truncated. It is truncated when number
    /// of options are &gt; 100.
    /// </summary>
    public bool? SelectOptionsTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("selectOptionsTruncated");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("selectOptionsTruncated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.DefaultValue?.Validate();
        _ = this.IsValueRequired;
        _ = this.MaxLength;
        this.MaxValue?.Validate();
        _ = this.MinLength;
        this.MinValue?.Validate();
        _ = this.ReadOnly;
        foreach (var item in this.SelectOptions ?? [])
        {
            item.Validate();
        }
        _ = this.SelectOptionsTruncated;
    }

    public FileUploadResponseSelectedFieldsSchemaItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponseSelectedFieldsSchemaItem(
        FileUploadResponseSelectedFieldsSchemaItem fileUploadResponseSelectedFieldsSchemaItem
    )
        : base(fileUploadResponseSelectedFieldsSchemaItem) { }
#pragma warning restore CS8618

    public FileUploadResponseSelectedFieldsSchemaItem(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponseSelectedFieldsSchemaItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseSelectedFieldsSchemaItemFromRaw.FromRawUnchecked"/>
    public static FileUploadResponseSelectedFieldsSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileUploadResponseSelectedFieldsSchemaItem(
        ApiEnum<string, FileUploadResponseSelectedFieldsSchemaItemType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class FileUploadResponseSelectedFieldsSchemaItemFromRaw
    : IFromRawJson<FileUploadResponseSelectedFieldsSchemaItem>
{
    /// <inheritdoc/>
    public FileUploadResponseSelectedFieldsSchemaItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUploadResponseSelectedFieldsSchemaItem.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the custom metadata field.
/// </summary>
[JsonConverter(typeof(FileUploadResponseSelectedFieldsSchemaItemTypeConverter))]
public enum FileUploadResponseSelectedFieldsSchemaItemType
{
    Text,
    Textarea,
    Number,
    Date,
    Boolean,
    SingleSelect,
    MultiSelect,
}

sealed class FileUploadResponseSelectedFieldsSchemaItemTypeConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemType>
{
    public override FileUploadResponseSelectedFieldsSchemaItemType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Text" => FileUploadResponseSelectedFieldsSchemaItemType.Text,
            "Textarea" => FileUploadResponseSelectedFieldsSchemaItemType.Textarea,
            "Number" => FileUploadResponseSelectedFieldsSchemaItemType.Number,
            "Date" => FileUploadResponseSelectedFieldsSchemaItemType.Date,
            "Boolean" => FileUploadResponseSelectedFieldsSchemaItemType.Boolean,
            "SingleSelect" => FileUploadResponseSelectedFieldsSchemaItemType.SingleSelect,
            "MultiSelect" => FileUploadResponseSelectedFieldsSchemaItemType.MultiSelect,
            _ => (FileUploadResponseSelectedFieldsSchemaItemType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                FileUploadResponseSelectedFieldsSchemaItemType.Text => "Text",
                FileUploadResponseSelectedFieldsSchemaItemType.Textarea => "Textarea",
                FileUploadResponseSelectedFieldsSchemaItemType.Number => "Number",
                FileUploadResponseSelectedFieldsSchemaItemType.Date => "Date",
                FileUploadResponseSelectedFieldsSchemaItemType.Boolean => "Boolean",
                FileUploadResponseSelectedFieldsSchemaItemType.SingleSelect => "SingleSelect",
                FileUploadResponseSelectedFieldsSchemaItemType.MultiSelect => "MultiSelect",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The default value for this custom metadata field. The value should match the `type`
/// of custom metadata field.
/// </summary>
[JsonConverter(typeof(FileUploadResponseSelectedFieldsSchemaItemDefaultValueConverter))]
public record class FileUploadResponseSelectedFieldsSchemaItemDefaultValue : ModelBase
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

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValue(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMixed(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMixed(
        [NotNullWhen(true)]
            out IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>? value
    )
    {
        value =
            this.Value
            as IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<
            IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>
        > mixed
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem> value:
                mixed(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValue"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...},
    ///     (IReadOnlyList&lt;FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem&gt; value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<
            IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>,
            T
        > mixed
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem> value =>
                mixed(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValue"
            ),
        };
    }

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        string value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        double value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        bool value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValue(
        List<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem> value
    ) =>
        new(
            (IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>)
                value
        );

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
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValue"
            );
        }
        this.Switch(
            (_) => { },
            (_) => { },
            (_) => { },
            (mixed) =>
            {
                foreach (var item in mixed)
                {
                    item.Validate();
                }
            }
        );
    }

    public virtual bool Equals(FileUploadResponseSelectedFieldsSchemaItemDefaultValue? other) =>
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
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            IReadOnlyList<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem> _ =>
                3,
            _ => -1,
        };
    }
}

sealed class FileUploadResponseSelectedFieldsSchemaItemDefaultValueConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemDefaultValue>
{
    public override FileUploadResponseSelectedFieldsSchemaItemDefaultValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<
                List<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>
            >(element, options);
            if (deserialized != null)
            {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemDefaultValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItemConverter)
)]
public record class FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem
    : ModelBase
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

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        JsonElement element
    )
    {
        this._element = element;
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
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem"
            ),
        };
    }

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        string value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        double value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem(
        bool value
    ) => new(value);

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
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem"
            );
        }
    }

    public virtual bool Equals(
        FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem? other
    ) =>
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
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItemConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem>
{
    public override FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemDefaultValueDefaultValueArrayItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Maximum value of the field. Only set if field type is `Date` or `Number`. For
/// `Date` type field, the value will be in ISO8601 string format. For `Number` type
/// field, it will be a numeric value.
/// </summary>
[JsonConverter(typeof(FileUploadResponseSelectedFieldsSchemaItemMaxValueConverter))]
public record class FileUploadResponseSelectedFieldsSchemaItemMaxValue : ModelBase
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

    public FileUploadResponseSelectedFieldsSchemaItemMaxValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemMaxValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemMaxValue(JsonElement element)
    {
        this._element = element;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMaxValue"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMaxValue"
            ),
        };
    }

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemMaxValue(
        string value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemMaxValue(
        double value
    ) => new(value);

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
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMaxValue"
            );
        }
    }

    public virtual bool Equals(FileUploadResponseSelectedFieldsSchemaItemMaxValue? other) =>
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
            string _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class FileUploadResponseSelectedFieldsSchemaItemMaxValueConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemMaxValue>
{
    public override FileUploadResponseSelectedFieldsSchemaItemMaxValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemMaxValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Minimum value of the field. Only set if field type is `Date` or `Number`. For
/// `Date` type field, the value will be in ISO8601 string format. For `Number` type
/// field, it will be a numeric value.
/// </summary>
[JsonConverter(typeof(FileUploadResponseSelectedFieldsSchemaItemMinValueConverter))]
public record class FileUploadResponseSelectedFieldsSchemaItemMinValue : ModelBase
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

    public FileUploadResponseSelectedFieldsSchemaItemMinValue(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemMinValue(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemMinValue(JsonElement element)
    {
        this._element = element;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<string> @string, System::Action<double> @double)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMinValue"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<string, T> @string, System::Func<double, T> @double)
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMinValue"
            ),
        };
    }

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemMinValue(
        string value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemMinValue(
        double value
    ) => new(value);

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
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemMinValue"
            );
        }
    }

    public virtual bool Equals(FileUploadResponseSelectedFieldsSchemaItemMinValue? other) =>
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
            string _ => 0,
            double _ => 1,
            _ => -1,
        };
    }
}

sealed class FileUploadResponseSelectedFieldsSchemaItemMinValueConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemMinValue>
{
    public override FileUploadResponseSelectedFieldsSchemaItemMinValue? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemMinValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(FileUploadResponseSelectedFieldsSchemaItemSelectOptionConverter))]
public record class FileUploadResponseSelectedFieldsSchemaItemSelectOption : ModelBase
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

    public FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        string value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        double value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        bool value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FileUploadResponseSelectedFieldsSchemaItemSelectOption(JsonElement element)
    {
        this._element = element;
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
    /// type <see cref="bool"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBool(out var value)) {
    ///     // `value` is of type `bool`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemSelectOption"
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
    ///     (string value) =&gt; {...},
    ///     (double value) =&gt; {...},
    ///     (bool value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            double value => @double(value),
            bool value => @bool(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemSelectOption"
            ),
        };
    }

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        string value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        double value
    ) => new(value);

    public static implicit operator FileUploadResponseSelectedFieldsSchemaItemSelectOption(
        bool value
    ) => new(value);

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
                "Data did not match any variant of FileUploadResponseSelectedFieldsSchemaItemSelectOption"
            );
        }
    }

    public virtual bool Equals(FileUploadResponseSelectedFieldsSchemaItemSelectOption? other) =>
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
            string _ => 0,
            double _ => 1,
            bool _ => 2,
            _ => -1,
        };
    }
}

sealed class FileUploadResponseSelectedFieldsSchemaItemSelectOptionConverter
    : JsonConverter<FileUploadResponseSelectedFieldsSchemaItemSelectOption>
{
    public override FileUploadResponseSelectedFieldsSchemaItemSelectOption? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<double>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        FileUploadResponseSelectedFieldsSchemaItemSelectOption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// An object containing the file or file version's `id` (versionId) and `name`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<FileUploadResponseVersionInfo, FileUploadResponseVersionInfoFromRaw>)
)]
public sealed record class FileUploadResponseVersionInfo : JsonModel
{
    /// <summary>
    /// Unique identifier of the file version.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Name of the file version.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public FileUploadResponseVersionInfo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUploadResponseVersionInfo(
        FileUploadResponseVersionInfo fileUploadResponseVersionInfo
    )
        : base(fileUploadResponseVersionInfo) { }
#pragma warning restore CS8618

    public FileUploadResponseVersionInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponseVersionInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUploadResponseVersionInfoFromRaw.FromRawUnchecked"/>
    public static FileUploadResponseVersionInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUploadResponseVersionInfoFromRaw : IFromRawJson<FileUploadResponseVersionInfo>
{
    /// <inheritdoc/>
    public FileUploadResponseVersionInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUploadResponseVersionInfo.FromRawUnchecked(rawData);
}
