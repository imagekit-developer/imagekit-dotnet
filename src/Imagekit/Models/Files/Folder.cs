using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using FolderProperties = Imagekit.Models.Files.FolderProperties;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(ModelConverter<Folder>))]
public sealed record class Folder : ModelBase, IFromRaw<Folder>
{
    /// <summary>
    /// Date and time when the folder was created. The date and time is in ISO8601
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
    /// Unique identifier of the asset.
    /// </summary>
    public string? FolderID
    {
        get
        {
            if (!this.Properties.TryGetValue("folderId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["folderId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path of the folder. This is the path you would use in the URL to access the
    /// folder. For example, if the folder is at the root of the media library, the
    /// path will be /folder. If the folder is inside another folder named images,
    /// the path will be /images/folder.
    /// </summary>
    public string? FolderPath
    {
        get
        {
            if (!this.Properties.TryGetValue("folderPath", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["folderPath"] = JsonSerializer.SerializeToElement(
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
    /// Type of the asset.
    /// </summary>
    public ApiEnum<string, FolderProperties::Type>? Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, FolderProperties::Type>?>(
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
    /// Date and time when the folder was last updated. The date and time is in ISO8601
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

    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.FolderID;
        _ = this.FolderPath;
        _ = this.Name;
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public Folder() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Folder(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Folder FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
