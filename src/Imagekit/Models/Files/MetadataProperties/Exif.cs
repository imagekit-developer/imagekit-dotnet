using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using ExifProperties = Imagekit.Models.Files.MetadataProperties.ExifProperties;

namespace Imagekit.Models.Files.MetadataProperties;

[JsonConverter(typeof(ModelConverter<Exif>))]
public sealed record class Exif : ModelBase, IFromRaw<Exif>
{
    /// <summary>
    /// Object containing Exif details.
    /// </summary>
    public ExifProperties::Exif? Exif1
    {
        get
        {
            if (!this.Properties.TryGetValue("exif", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExifProperties::Exif?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["exif"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object containing GPS information.
    /// </summary>
    public ExifProperties::Gps? Gps
    {
        get
        {
            if (!this.Properties.TryGetValue("gps", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExifProperties::Gps?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["gps"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object containing EXIF image information.
    /// </summary>
    public ExifProperties::Image? Image
    {
        get
        {
            if (!this.Properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExifProperties::Image?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// JSON object.
    /// </summary>
    public ExifProperties::Interoperability? Interoperability
    {
        get
        {
            if (!this.Properties.TryGetValue("interoperability", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExifProperties::Interoperability?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["interoperability"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Makernote
    {
        get
        {
            if (!this.Properties.TryGetValue("makernote", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["makernote"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object containing Thumbnail information.
    /// </summary>
    public ExifProperties::Thumbnail? Thumbnail
    {
        get
        {
            if (!this.Properties.TryGetValue("thumbnail", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExifProperties::Thumbnail?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["thumbnail"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Exif1?.Validate();
        this.Gps?.Validate();
        this.Image?.Validate();
        this.Interoperability?.Validate();
        _ = this.Makernote;
        this.Thumbnail?.Validate();
    }

    public Exif() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Exif(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Exif FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
