using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.MetadataProperties.ExifProperties;

/// <summary>
/// Object containing Thumbnail information.
/// </summary>
[JsonConverter(typeof(ModelConverter<Thumbnail>))]
public sealed record class Thumbnail : ModelBase, IFromRaw<Thumbnail>
{
    public long? Compression
    {
        get
        {
            if (!this.Properties.TryGetValue("Compression", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Compression"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ResolutionUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("ResolutionUnit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ResolutionUnit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ThumbnailLength
    {
        get
        {
            if (!this.Properties.TryGetValue("ThumbnailLength", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ThumbnailLength"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ThumbnailOffset
    {
        get
        {
            if (!this.Properties.TryGetValue("ThumbnailOffset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ThumbnailOffset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? XResolution
    {
        get
        {
            if (!this.Properties.TryGetValue("XResolution", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["XResolution"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? YResolution
    {
        get
        {
            if (!this.Properties.TryGetValue("YResolution", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["YResolution"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Compression;
        _ = this.ResolutionUnit;
        _ = this.ThumbnailLength;
        _ = this.ThumbnailOffset;
        _ = this.XResolution;
        _ = this.YResolution;
    }

    public Thumbnail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Thumbnail(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Thumbnail FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
