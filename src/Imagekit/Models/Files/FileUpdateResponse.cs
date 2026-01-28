using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileProperties.SelectedFieldsSchemaProperties;
using Imagekit.Models.Files.FileUpdateResponseProperties.IntersectionMember1Properties;
using FileProperties = Imagekit.Models.Files.FileProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// Object containing details of a file or file version.
/// </summary>
[JsonConverter(typeof(ModelConverter<FileUpdateResponse>))]
public sealed record class FileUpdateResponse : ModelBase, IFromRaw<FileUpdateResponse>
{
    /// <summary>
    /// An array of tags assigned to the file by auto tagging.
    /// </summary>
    public List<FileProperties::AITag>? AITags
    {
        get
        {
            if (!this.Properties.TryGetValue("AITags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<FileProperties::AITag>?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Date and time when the file was uploaded. The date and time is in ISO8601
    /// format.
    /// </summary>
    public DateTime? CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("createdAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["createdAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An string with custom coordinates of the file.
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
    /// An object with custom metadata for the file.
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
    /// Unique identifier of the asset.
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
    /// Path of the file. This is the path you would use in the URL to access the
    /// file. For example, if the file is at the root of the media library, the path
    /// will be `/file.jpg`. If the file is inside a folder named `images`, the path
    /// will be `/images/file.jpg`.
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
    /// Type of the file. Possible values are `image`, `non-image`.
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
    /// Specifies if the image has an alpha channel.
    /// </summary>
    public bool? HasAlpha
    {
        get
        {
            if (!this.Properties.TryGetValue("hasAlpha", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hasAlpha"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Height of the file.
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
    /// Specifies if the file is private or not.
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
    /// Specifies if the file is published or not.
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
    /// MIME type of the file.
    /// </summary>
    public string? Mime
    {
        get
        {
            if (!this.Properties.TryGetValue("mime", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["mime"] = JsonSerializer.SerializeToElement(
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
    /// Size of the file in bytes.
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
    /// An array of tags assigned to the file. Tags are used to search files in the
    /// media library.
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
    /// URL of the thumbnail image. This URL is used to access the thumbnail image
    /// of the file in the media library.
    /// </summary>
    public string? Thumbnail
    {
        get
        {
            if (!this.Properties.TryGetValue("thumbnail", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["thumbnail"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Type of the asset.
    /// </summary>
    public ApiEnum<string, FileProperties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, FileProperties::Type>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Date and time when the file was last updated. The date and time is in ISO8601
    /// format.
    /// </summary>
    public DateTime? UpdatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("updatedAt", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<DateTime?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["updatedAt"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL of the file.
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
    /// An object with details of the file version.
    /// </summary>
    public FileProperties::VersionInfo? VersionInfo
    {
        get
        {
            if (!this.Properties.TryGetValue("versionInfo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<FileProperties::VersionInfo?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Width of the file.
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

    public static implicit operator File(FileUpdateResponse fileUpdateResponse) =>
        new()
        {
            AITags = fileUpdateResponse.AITags,
            CreatedAt = fileUpdateResponse.CreatedAt,
            CustomCoordinates = fileUpdateResponse.CustomCoordinates,
            CustomMetadata = fileUpdateResponse.CustomMetadata,
            Description = fileUpdateResponse.Description,
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
            URL = fileUpdateResponse.URL,
            VersionInfo = fileUpdateResponse.VersionInfo,
            Width = fileUpdateResponse.Width,
        };

    public override void Validate()
    {
        foreach (var item in this.AITags ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.CustomCoordinates;
        if (this.CustomMetadata != null)
        {
            foreach (var item in this.CustomMetadata.Values)
            {
                _ = item;
            }
        }
        _ = this.Description;
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
        foreach (var item in this.Tags ?? [])
        {
            _ = item;
        }
        _ = this.Thumbnail;
        this.Type?.Validate();
        _ = this.UpdatedAt;
        _ = this.URL;
        this.VersionInfo?.Validate();
        _ = this.Width;
        this.ExtensionStatus?.Validate();
    }

    public FileUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileUpdateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
