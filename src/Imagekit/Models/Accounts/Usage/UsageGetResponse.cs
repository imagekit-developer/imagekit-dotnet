using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.Usage;

[JsonConverter(typeof(ModelConverter<UsageGetResponse>))]
public sealed record class UsageGetResponse : ModelBase, IFromRaw<UsageGetResponse>
{
    /// <summary>
    /// Amount of bandwidth used in bytes.
    /// </summary>
    public long? BandwidthBytes
    {
        get
        {
            if (!this.Properties.TryGetValue("bandwidthBytes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bandwidthBytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of extension units used.
    /// </summary>
    public long? ExtensionUnitsCount
    {
        get
        {
            if (!this.Properties.TryGetValue("extensionUnitsCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["extensionUnitsCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Storage used by media library in bytes.
    /// </summary>
    public long? MediaLibraryStorageBytes
    {
        get
        {
            if (!this.Properties.TryGetValue("mediaLibraryStorageBytes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["mediaLibraryStorageBytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Storage used by the original cache in bytes.
    /// </summary>
    public long? OriginalCacheStorageBytes
    {
        get
        {
            if (!this.Properties.TryGetValue("originalCacheStorageBytes", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["originalCacheStorageBytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of video processing units used.
    /// </summary>
    public long? VideoProcessingUnitsCount
    {
        get
        {
            if (!this.Properties.TryGetValue("videoProcessingUnitsCount", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["videoProcessingUnitsCount"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.ExtensionUnitsCount;
        _ = this.MediaLibraryStorageBytes;
        _ = this.OriginalCacheStorageBytes;
        _ = this.VideoProcessingUnitsCount;
    }

    public UsageGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageGetResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UsageGetResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
