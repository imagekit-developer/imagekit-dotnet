using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.VideoTransformationAcceptedEventProperties.DataProperties;

/// <summary>
/// Information about the source video asset being transformed.
/// </summary>
[JsonConverter(typeof(ModelConverter<Asset>))]
public sealed record class Asset : ModelBase, IFromRaw<Asset>
{
    /// <summary>
    /// URL to download or access the source video file.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.URL;
    }

    public Asset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Asset(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Asset FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Asset(string url)
        : this()
    {
        this.URL = url;
    }
}
