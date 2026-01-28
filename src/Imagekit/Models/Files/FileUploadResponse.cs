using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Models.Files.FileUploadResponseProperties;
using Imagekit.Models.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// Object containing details of a successful upload.
/// </summary>
[JsonConverter(typeof(ModelConverter<FileUploadResponse>))]
public sealed record class FileUploadResponse : ModelBase, IFromRaw<FileUploadResponse>
{
    /// <summary>
    /// An array of tags assigned to the uploaded file by auto tagging.
    /// </summary>
    public List<AITag>? AITags
    {
        get
        {
            if (!this.Properties.TryGetValue("AITags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<AITag>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["AITags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("audioCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["audioCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The bit rate of the video in kbps (only for video).
    /// </summary>
    public long? BitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("bitRate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bitRate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("customCoordinates", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["customCoordinates"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A key-value data associated with the asset. Use `responseField` in API request
    /// to get `customMetadata` in the upload API response. Before setting any custom
    /// metadata on an asset, you have to create the field using custom metadata
    /// fields API. Send `customMetadata` in `responseFields` in API request to get
    /// the value of this field.
    /// </summary>
    public Dictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("customMetadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["customMetadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The duration of the video in seconds (only for video).
    /// </summary>
    public long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Consolidated embedded metadata associated with the file. It includes exif,
    /// iptc, and xmp data. Send `embeddedMetadata` in `responseFields` in API request
    /// to get embeddedMetadata in the upload API response.
    /// </summary>
    public Dictionary<string, JsonElement>? EmbeddedMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("embeddedMetadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["embeddedMetadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Extension names with their processing status at the time of completion of
    /// the request. It could have one of the following status values:
    ///
    /// `success`: The extension has been successfully applied. `failed`: The extension
    /// has failed and will not be retried. `pending`: The extension will finish processing
    /// in some time. On completion, the final status (success / failed) will be sent
    /// to the `webhookUrl` provided.
    ///
    /// If no extension was requested, then this parameter is not returned.
    /// </summary>
    public ExtensionStatus? ExtensionStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("extensionStatus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExtensionStatus?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["extensionStatus"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("fileId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fileId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The relative path of the file in the media library e.g. `/marketing-assets/new-banner.jpg`.
    /// </summary>
    public string? FilePath
    {
        get
        {
            if (!this.Properties.TryGetValue("filePath", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filePath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of the uploaded file. Possible values are `image`, `non-image`.
    /// </summary>
    public string? FileType
    {
        get
        {
            if (!this.Properties.TryGetValue("fileType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["fileType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Height of the image in pixels (Only for images)
    /// </summary>
    public double? Height
    {
        get
        {
            if (!this.Properties.TryGetValue("height", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["height"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("isPrivateFile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["isPrivateFile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
            if (!this.Properties.TryGetValue("isPublished", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["isPublished"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Legacy metadata. Send `metadata` in `responseFields` in API request to get
    /// metadata in the upload API response.
    /// </summary>
    public Metadata? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Metadata?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Name of the asset.
    /// </summary>
    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// This field is included in the response only if the Path policy feature is
    /// available in the plan. It contains schema definitions for the custom metadata
    /// fields selected for the specified file path. Field selection can only be done
    /// when the Path policy feature is enabled.
    ///
    /// Keys are the names of the custom metadata fields; the value object has details
    /// about the custom metadata schema.
    /// </summary>
    public Dictionary<string, SelectedFieldsSchemaItem>? SelectedFieldsSchema
    {
        get
        {
            if (!this.Properties.TryGetValue("selectedFieldsSchema", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, SelectedFieldsSchemaItem>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["selectedFieldsSchema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
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
            if (!this.Properties.TryGetValue("size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The array of tags associated with the asset. If no tags are set, it will
    /// be `null`. Send `tags` in `responseFields` in API request to get the value
    /// of this field.
    /// </summary>
    public List<string>? Tags
    {
        get
        {
            if (!this.Properties.TryGetValue("tags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// In the case of an image, a small thumbnail URL.
    /// </summary>
    public string? ThumbnailURL
    {
        get
        {
            if (!this.Properties.TryGetValue("thumbnailUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["thumbnailUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// A publicly accessible URL of the file.
    /// </summary>
    public string? URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An object containing the file or file version's `id` (versionId) and `name`.
    /// </summary>
    public VersionInfo? VersionInfo
    {
        get
        {
            if (!this.Properties.TryGetValue("versionInfo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<VersionInfo?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["versionInfo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The video codec used in the video (only for video).
    /// </summary>
    public string? VideoCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("videoCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["videoCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Width of the image in pixels (Only for Images)
    /// </summary>
    public double? Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.AITags ?? [])
        {
            item.Validate();
        }
        _ = this.AudioCodec;
        _ = this.BitRate;
        _ = this.CustomCoordinates;
        if (this.CustomMetadata != null)
        {
            foreach (var item in this.CustomMetadata.Values)
            {
                _ = item;
            }
        }
        _ = this.Description;
        _ = this.Duration;
        if (this.EmbeddedMetadata != null)
        {
            foreach (var item in this.EmbeddedMetadata.Values)
            {
                _ = item;
            }
        }
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
        foreach (var item in this.Tags ?? [])
        {
            _ = item;
        }
        _ = this.ThumbnailURL;
        _ = this.URL;
        this.VersionInfo?.Validate();
        _ = this.VideoCodec;
        _ = this.Width;
    }

    public FileUploadResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUploadResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileUploadResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
