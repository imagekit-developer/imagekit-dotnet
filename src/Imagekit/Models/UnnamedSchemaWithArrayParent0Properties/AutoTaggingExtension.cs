using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties.AutoTaggingExtensionProperties;

namespace Imagekit.Models.Files.FileUploadParamsProperties.ExtensionProperties;

[JsonConverter(typeof(ModelConverter<AutoTaggingExtension>))]
public sealed record class AutoTaggingExtension : ModelBase, IFromRaw<AutoTaggingExtension>
{
    /// <summary>
    /// Maximum number of tags to attach to the asset.
    /// </summary>
    public required long MaxTags
    {
        get
        {
            if (!this.Properties.TryGetValue("maxTags", out JsonElement element))
                throw new ArgumentOutOfRangeException("maxTags", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["maxTags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Minimum confidence level for tags to be considered valid.
    /// </summary>
    public required long MinConfidence
    {
        get
        {
            if (!this.Properties.TryGetValue("minConfidence", out JsonElement element))
                throw new ArgumentOutOfRangeException("minConfidence", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["minConfidence"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the auto-tagging extension used.
    /// </summary>
    public required ApiEnum<string, Name> Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, Name>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.MaxTags;
        _ = this.MinConfidence;
        this.Name.Validate();
    }

    public AutoTaggingExtension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoTaggingExtension(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutoTaggingExtension FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
