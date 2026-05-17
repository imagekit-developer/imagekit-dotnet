using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using ImagekitDiversion.Models.Api.V1.Files;
using System = System;

namespace ImagekitDiversion.Models.Files.Details;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DetailUpdateResponse, DetailUpdateResponseFromRaw>))]
public sealed record class DetailUpdateResponse : JsonModel
{
    /// <summary>
    /// Array of AI-generated tags associated with the image. If no AITags are set,
    /// it will be null.
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<AITag>?>(
                "AITags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The audio codec used in the video (only for video/audio).
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
    /// Date and time when the file was uploaded. The date and time is in ISO8601 format.
    /// </summary>
    public System::DateTimeOffset? CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("createdAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("createdAt", value);
        }
    }

    /// <summary>
    /// An string with custom coordinates of the file.
    /// </summary>
    public string? CustomCoordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customCoordinates");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customCoordinates", value);
        }
    }

    /// <summary>
    /// An object with custom metadata for the file.
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
    /// iptc, and xmp data.
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
    /// Unique identifier of the asset.
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
    /// Path of the file. This is the path you would use in the URL to access the
    /// file. For example, if the file is at the root of the media library, the path
    /// will be `/file.jpg`. If the file is inside a folder named `images`, the path
    /// will be `/images/file.jpg`.
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
    /// Type of the file. Possible values are `image`, `non-image`.
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
    /// Specifies if the image has an alpha channel.
    /// </summary>
    public bool? HasAlpha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasAlpha");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasAlpha", value);
        }
    }

    /// <summary>
    /// Height of the file.
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
    /// Specifies if the file is private or not.
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
    /// Specifies if the file is published or not.
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
    /// MIME type of the file.
    /// </summary>
    public string? Mime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mime", value);
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
    /// has details about the custom metadata schema.</para>
    /// </summary>
    public IReadOnlyDictionary<
        string,
        global::ImagekitDiversion.Models.Files.Details.SelectedFieldsSchemaItem
    >? SelectedFieldsSchema
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                FrozenDictionary<
                    string,
                    global::ImagekitDiversion.Models.Files.Details.SelectedFieldsSchemaItem
                >
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
                global::ImagekitDiversion.Models.Files.Details.SelectedFieldsSchemaItem
            >?>(
                "selectedFieldsSchema",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Size of the file in bytes.
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
    /// An array of tags assigned to the file. Tags are used to search files in the
    /// media library.
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
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL of the thumbnail image. This URL is used to access the thumbnail image
    /// of the file in the media library.
    /// </summary>
    public string? Thumbnail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("thumbnail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thumbnail", value);
        }
    }

    /// <summary>
    /// Type of the asset.
    /// </summary>
    public ApiEnum<string, FileDetailsType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FileDetailsType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// Date and time when the file was last updated. The date and time is in ISO8601 format.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <summary>
    /// URL of the file.
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
    /// Width of the file.
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

    public global::ImagekitDiversion.Models.Files.Details.ExtensionStatus? ExtensionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::ImagekitDiversion.Models.Files.Details.ExtensionStatus>(
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

    public static implicit operator FileDetails(DetailUpdateResponse detailUpdateResponse) =>
        new()
        {
            AITags = detailUpdateResponse.AITags,
            AudioCodec = detailUpdateResponse.AudioCodec,
            BitRate = detailUpdateResponse.BitRate,
            CreatedAt = detailUpdateResponse.CreatedAt,
            CustomCoordinates = detailUpdateResponse.CustomCoordinates,
            CustomMetadata = detailUpdateResponse.CustomMetadata,
            Description = detailUpdateResponse.Description,
            Duration = detailUpdateResponse.Duration,
            EmbeddedMetadata = detailUpdateResponse.EmbeddedMetadata,
            FileID = detailUpdateResponse.FileID,
            FilePath = detailUpdateResponse.FilePath,
            FileType = detailUpdateResponse.FileType,
            HasAlpha = detailUpdateResponse.HasAlpha,
            Height = detailUpdateResponse.Height,
            IsPrivateFile = detailUpdateResponse.IsPrivateFile,
            IsPublished = detailUpdateResponse.IsPublished,
            Mime = detailUpdateResponse.Mime,
            Name = detailUpdateResponse.Name,
            SelectedFieldsSchema = detailUpdateResponse.SelectedFieldsSchema,
            Size = detailUpdateResponse.Size,
            Tags = detailUpdateResponse.Tags,
            Thumbnail = detailUpdateResponse.Thumbnail,
            Type = detailUpdateResponse.Type,
            UpdatedAt = detailUpdateResponse.UpdatedAt,
            Url = detailUpdateResponse.Url,
            VersionInfo = detailUpdateResponse.VersionInfo,
            VideoCodec = detailUpdateResponse.VideoCodec,
            Width = detailUpdateResponse.Width,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AITags ?? [])
        {
            item.Validate();
        }
        _ = this.AudioCodec;
        _ = this.BitRate;
        _ = this.CreatedAt;
        _ = this.CustomCoordinates;
        _ = this.CustomMetadata;
        _ = this.Description;
        _ = this.Duration;
        _ = this.EmbeddedMetadata;
        _ = this.FileID;
        _ = this.FilePath;
        _ = this.FileType;
        _ = this.HasAlpha;
        _ = this.Height;
        _ = this.IsPrivateFile;
        _ = this.IsPublished;
        _ = this.Mime;
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
        _ = this.Thumbnail;
        this.Type?.Validate();
        _ = this.UpdatedAt;
        _ = this.Url;
        this.VersionInfo?.Validate();
        _ = this.VideoCodec;
        _ = this.Width;
        this.ExtensionStatus?.Validate();
    }

    public DetailUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailUpdateResponse(DetailUpdateResponse detailUpdateResponse)
        : base(detailUpdateResponse) { }
#pragma warning restore CS8618

    public DetailUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DetailUpdateResponseFromRaw.FromRawUnchecked"/>
    public static DetailUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DetailUpdateResponseFromRaw : IFromRawJson<DetailUpdateResponse>
{
    /// <inheritdoc/>
    public DetailUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DetailUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FileUpdateResponse, FileUpdateResponseFromRaw>))]
public sealed record class FileUpdateResponse : JsonModel
{
    public global::ImagekitDiversion.Models.Files.Details.ExtensionStatus? ExtensionStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<global::ImagekitDiversion.Models.Files.Details.ExtensionStatus>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExtensionStatus?.Validate();
    }

    public FileUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdateResponse(FileUpdateResponse fileUpdateResponse)
        : base(fileUpdateResponse) { }
#pragma warning restore CS8618

    public FileUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdateResponseFromRaw : IFromRawJson<FileUpdateResponse>
{
    /// <inheritdoc/>
    public FileUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::ImagekitDiversion.Models.Files.Details.ExtensionStatus,
        global::ImagekitDiversion.Models.Files.Details.ExtensionStatusFromRaw
    >)
)]
public sealed record class ExtensionStatus : JsonModel
{
    public ApiEnum<
        string,
        global::ImagekitDiversion.Models.Files.Details.AIAutoDescription
    >? AIAutoDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.AIAutoDescription>
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

    public ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.AITasks>? AITasks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.AITasks>
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

    public ApiEnum<
        string,
        global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging
    >? AwsAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging>
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

    public ApiEnum<
        string,
        global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging
    >? GoogleAutoTagging
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging>
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

    public ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.RemoveBg>? RemoveBg
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::ImagekitDiversion.Models.Files.Details.RemoveBg>
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

    public ExtensionStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionStatus(
        global::ImagekitDiversion.Models.Files.Details.ExtensionStatus extensionStatus
    )
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

    /// <inheritdoc cref="global::ImagekitDiversion.Models.Files.Details.ExtensionStatusFromRaw.FromRawUnchecked"/>
    public static global::ImagekitDiversion.Models.Files.Details.ExtensionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionStatusFromRaw
    : IFromRawJson<global::ImagekitDiversion.Models.Files.Details.ExtensionStatus>
{
    /// <inheritdoc/>
    public global::ImagekitDiversion.Models.Files.Details.ExtensionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::ImagekitDiversion.Models.Files.Details.ExtensionStatus.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(global::ImagekitDiversion.Models.Files.Details.AIAutoDescriptionConverter))]
public enum AIAutoDescription
{
    Success,
    Pending,
    Failed,
}

sealed class AIAutoDescriptionConverter
    : JsonConverter<global::ImagekitDiversion.Models.Files.Details.AIAutoDescription>
{
    public override global::ImagekitDiversion.Models.Files.Details.AIAutoDescription Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Success,
            "pending" => global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Pending,
            "failed" => global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Failed,
            _ => (global::ImagekitDiversion.Models.Files.Details.AIAutoDescription)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.Files.Details.AIAutoDescription value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Success =>
                    "success",
                global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Pending =>
                    "pending",
                global::ImagekitDiversion.Models.Files.Details.AIAutoDescription.Failed => "failed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::ImagekitDiversion.Models.Files.Details.AITasksConverter))]
public enum AITasks
{
    Success,
    Pending,
    Failed,
}

sealed class AITasksConverter
    : JsonConverter<global::ImagekitDiversion.Models.Files.Details.AITasks>
{
    public override global::ImagekitDiversion.Models.Files.Details.AITasks Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => global::ImagekitDiversion.Models.Files.Details.AITasks.Success,
            "pending" => global::ImagekitDiversion.Models.Files.Details.AITasks.Pending,
            "failed" => global::ImagekitDiversion.Models.Files.Details.AITasks.Failed,
            _ => (global::ImagekitDiversion.Models.Files.Details.AITasks)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.Files.Details.AITasks value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.Files.Details.AITasks.Success => "success",
                global::ImagekitDiversion.Models.Files.Details.AITasks.Pending => "pending",
                global::ImagekitDiversion.Models.Files.Details.AITasks.Failed => "failed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::ImagekitDiversion.Models.Files.Details.AwsAutoTaggingConverter))]
public enum AwsAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class AwsAutoTaggingConverter
    : JsonConverter<global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging>
{
    public override global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Success,
            "pending" => global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Pending,
            "failed" => global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Failed,
            _ => (global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Success => "success",
                global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Pending => "pending",
                global::ImagekitDiversion.Models.Files.Details.AwsAutoTagging.Failed => "failed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::ImagekitDiversion.Models.Files.Details.GoogleAutoTaggingConverter))]
public enum GoogleAutoTagging
{
    Success,
    Pending,
    Failed,
}

sealed class GoogleAutoTaggingConverter
    : JsonConverter<global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging>
{
    public override global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Success,
            "pending" => global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Pending,
            "failed" => global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Failed,
            _ => (global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Success =>
                    "success",
                global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Pending =>
                    "pending",
                global::ImagekitDiversion.Models.Files.Details.GoogleAutoTagging.Failed => "failed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(global::ImagekitDiversion.Models.Files.Details.RemoveBgConverter))]
public enum RemoveBg
{
    Success,
    Pending,
    Failed,
}

sealed class RemoveBgConverter
    : JsonConverter<global::ImagekitDiversion.Models.Files.Details.RemoveBg>
{
    public override global::ImagekitDiversion.Models.Files.Details.RemoveBg Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "success" => global::ImagekitDiversion.Models.Files.Details.RemoveBg.Success,
            "pending" => global::ImagekitDiversion.Models.Files.Details.RemoveBg.Pending,
            "failed" => global::ImagekitDiversion.Models.Files.Details.RemoveBg.Failed,
            _ => (global::ImagekitDiversion.Models.Files.Details.RemoveBg)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImagekitDiversion.Models.Files.Details.RemoveBg value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImagekitDiversion.Models.Files.Details.RemoveBg.Success => "success",
                global::ImagekitDiversion.Models.Files.Details.RemoveBg.Pending => "pending",
                global::ImagekitDiversion.Models.Files.Details.RemoveBg.Failed => "failed",
                _ => throw new ImagekitDiversionInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
