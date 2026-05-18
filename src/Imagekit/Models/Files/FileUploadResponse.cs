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
