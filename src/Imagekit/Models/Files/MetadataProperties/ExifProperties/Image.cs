using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.MetadataProperties.ExifProperties;

/// <summary>
/// Object containing EXIF image information.
/// </summary>
[JsonConverter(typeof(ModelConverter<Image>))]
public sealed record class Image : ModelBase, IFromRaw<Image>
{
    public long? ExifOffset
    {
        get
        {
            if (!this.Properties.TryGetValue("ExifOffset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExifOffset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? GpsInfo
    {
        get
        {
            if (!this.Properties.TryGetValue("GPSInfo", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["GPSInfo"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Make
    {
        get
        {
            if (!this.Properties.TryGetValue("Make", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Make"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Model
    {
        get
        {
            if (!this.Properties.TryGetValue("Model", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Model"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ModifyDate
    {
        get
        {
            if (!this.Properties.TryGetValue("ModifyDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ModifyDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Orientation
    {
        get
        {
            if (!this.Properties.TryGetValue("Orientation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Orientation"] = JsonSerializer.SerializeToElement(
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

    public string? Software
    {
        get
        {
            if (!this.Properties.TryGetValue("Software", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Software"] = JsonSerializer.SerializeToElement(
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

    public long? YCbCrPositioning
    {
        get
        {
            if (!this.Properties.TryGetValue("YCbCrPositioning", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["YCbCrPositioning"] = JsonSerializer.SerializeToElement(
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
        _ = this.ExifOffset;
        _ = this.GpsInfo;
        _ = this.Make;
        _ = this.Model;
        _ = this.ModifyDate;
        _ = this.Orientation;
        _ = this.ResolutionUnit;
        _ = this.Software;
        _ = this.XResolution;
        _ = this.YCbCrPositioning;
        _ = this.YResolution;
    }

    public Image() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Image(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Image FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
