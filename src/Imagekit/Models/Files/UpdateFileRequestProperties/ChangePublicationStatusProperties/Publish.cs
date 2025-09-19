using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.UpdateFileRequestProperties.ChangePublicationStatusProperties;

/// <summary>
/// Configure the publication status of a file and its versions.
/// </summary>
[JsonConverter(typeof(ModelConverter<Publish>))]
public sealed record class Publish : ModelBase, IFromRaw<Publish>
{
    /// <summary>
    /// Set to `true` to publish the file. Set to `false` to unpublish the file.
    /// </summary>
    public required bool IsPublished
    {
        get
        {
            if (!this.Properties.TryGetValue("isPublished", out JsonElement element))
                throw new ArgumentOutOfRangeException("isPublished", "Missing required argument");

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
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
    /// Set to `true` to publish/unpublish all versions of the file. Set to `false`
    /// to publish/unpublish only the current version of the file.
    /// </summary>
    public bool? IncludeFileVersions
    {
        get
        {
            if (!this.Properties.TryGetValue("includeFileVersions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["includeFileVersions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.IsPublished;
        _ = this.IncludeFileVersions;
    }

    public Publish() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Publish(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Publish FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Publish(bool isPublished)
        : this()
    {
        this.IsPublished = isPublished;
    }
}
