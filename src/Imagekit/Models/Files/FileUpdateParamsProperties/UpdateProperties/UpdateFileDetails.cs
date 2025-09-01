using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties.UpdateFileDetailsProperties;

namespace Imagekit.Models.Files.FileUpdateParamsProperties.UpdateProperties;

[JsonConverter(typeof(ModelConverter<UpdateFileDetails>))]
public sealed record class UpdateFileDetails : ModelBase, IFromRaw<UpdateFileDetails>
{
    /// <summary>
    /// Define an important area in the image in the format `x,y,width,height` e.g.
    /// `10,10,100,100`. Send `null` to unset this value.
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
    /// A key-value data to be associated with the asset. To unset a key, send `null`
    /// value for that key. Before setting any custom metadata on an asset you have
    /// to create the field using custom metadata fields API.
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
    /// Optional text to describe the contents of the file.
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
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public List<Extension>? Extensions
    {
        get
        {
            if (!this.Properties.TryGetValue("extensions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Extension>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["extensions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of AITags associated with the file that you want to remove, e.g.
    /// `["car", "vehicle", "motorsports"]`.
    ///
    /// If you want to remove all AITags associated with the file, send a string - "all".
    ///
    /// Note: The remove operation for `AITags` executes before any of the `extensions`
    /// are processed.
    /// </summary>
    public RemoveAITags? RemoveAITags
    {
        get
        {
            if (!this.Properties.TryGetValue("removeAITags", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<RemoveAITags?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["removeAITags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of tags associated with the file, such as `["tag1", "tag2"]`. Send
    /// `null` to unset all tags associated with the file.
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
    /// The final status of extensions after they have completed execution will be
    /// delivered to this endpoint as a POST request. [Learn more](/docs/api-reference/digital-asset-management-dam/managing-assets/update-file-details#webhook-payload-structure)
    /// about the webhook payload structure.
    /// </summary>
    public string? WebhookURL
    {
        get
        {
            if (!this.Properties.TryGetValue("webhookUrl", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["webhookUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CustomCoordinates;
        if (this.CustomMetadata != null)
        {
            foreach (var item in this.CustomMetadata.Values)
            {
                _ = item;
            }
        }
        _ = this.Description;
        foreach (var item in this.Extensions ?? [])
        {
            item.Validate();
        }
        this.RemoveAITags?.Validate();
        foreach (var item in this.Tags ?? [])
        {
            _ = item;
        }
        _ = this.WebhookURL;
    }

    public UpdateFileDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFileDetails(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UpdateFileDetails FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
