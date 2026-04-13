using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Files;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUpdateResponse, FileUpdateResponseFromRaw>))]
public sealed record class FileUpdateResponse : JsonModel
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
    /// Date and time when the file was uploaded. The date and time is in ISO8601
    /// format.
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
        init { this._rawData.Set("customCoordinates", value); }
    }

    /// <summary>
    /// A key-value data associated with the asset.
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
    public ApiEnum<string, FileType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FileType>>("type");
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
    /// Date and time when the file was last updated. The date and time is in ISO8601
    /// format.
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

    public static implicit operator File(FileUpdateResponse fileUpdateResponse) =>
        new()
        {
            AITags = fileUpdateResponse.AITags,
            AudioCodec = fileUpdateResponse.AudioCodec,
            BitRate = fileUpdateResponse.BitRate,
            CreatedAt = fileUpdateResponse.CreatedAt,
            CustomCoordinates = fileUpdateResponse.CustomCoordinates,
            CustomMetadata = fileUpdateResponse.CustomMetadata,
            Description = fileUpdateResponse.Description,
            Duration = fileUpdateResponse.Duration,
            EmbeddedMetadata = fileUpdateResponse.EmbeddedMetadata,
            FileID = fileUpdateResponse.FileID,
            FilePath = fileUpdateResponse.FilePath,
            FileType = fileUpdateResponse.FileType,
            HasAlpha = fileUpdateResponse.HasAlpha,
            Height = fileUpdateResponse.Height,
            IsPrivateFile = fileUpdateResponse.IsPrivateFile,
            IsPublished = fileUpdateResponse.IsPublished,
            Mime = fileUpdateResponse.Mime,
            Name = fileUpdateResponse.Name,
            SelectedFieldsSchema = fileUpdateResponse.SelectedFieldsSchema,
            Size = fileUpdateResponse.Size,
            Tags = fileUpdateResponse.Tags,
            Thumbnail = fileUpdateResponse.Thumbnail,
            Type = fileUpdateResponse.Type,
            UpdatedAt = fileUpdateResponse.UpdatedAt,
            Url = fileUpdateResponse.Url,
            VersionInfo = fileUpdateResponse.VersionInfo,
            VideoCodec = fileUpdateResponse.VideoCodec,
            Width = fileUpdateResponse.Width,
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

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExtensionStatus?.Validate();
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}

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
