using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.MetadataProperties.ExifProperties;

/// <summary>
/// Object containing Exif details.
/// </summary>
[JsonConverter(typeof(ModelConverter<Exif>))]
public sealed record class Exif : ModelBase, IFromRaw<Exif>
{
    public double? ApertureValue
    {
        get
        {
            if (!this.Properties.TryGetValue("ApertureValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ApertureValue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ColorSpace
    {
        get
        {
            if (!this.Properties.TryGetValue("ColorSpace", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ColorSpace"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? CreateDate
    {
        get
        {
            if (!this.Properties.TryGetValue("CreateDate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["CreateDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? CustomRendered
    {
        get
        {
            if (!this.Properties.TryGetValue("CustomRendered", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["CustomRendered"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? DateTimeOriginal
    {
        get
        {
            if (!this.Properties.TryGetValue("DateTimeOriginal", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["DateTimeOriginal"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ExifImageHeight
    {
        get
        {
            if (!this.Properties.TryGetValue("ExifImageHeight", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExifImageHeight"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ExifImageWidth
    {
        get
        {
            if (!this.Properties.TryGetValue("ExifImageWidth", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExifImageWidth"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ExifVersion
    {
        get
        {
            if (!this.Properties.TryGetValue("ExifVersion", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExifVersion"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? ExposureCompensation
    {
        get
        {
            if (!this.Properties.TryGetValue("ExposureCompensation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExposureCompensation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ExposureMode
    {
        get
        {
            if (!this.Properties.TryGetValue("ExposureMode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExposureMode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ExposureProgram
    {
        get
        {
            if (!this.Properties.TryGetValue("ExposureProgram", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExposureProgram"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? ExposureTime
    {
        get
        {
            if (!this.Properties.TryGetValue("ExposureTime", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ExposureTime"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Flash
    {
        get
        {
            if (!this.Properties.TryGetValue("Flash", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["Flash"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? FlashpixVersion
    {
        get
        {
            if (!this.Properties.TryGetValue("FlashpixVersion", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FlashpixVersion"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? FNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("FNumber", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FNumber"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? FocalLength
    {
        get
        {
            if (!this.Properties.TryGetValue("FocalLength", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FocalLength"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? FocalPlaneResolutionUnit
    {
        get
        {
            if (!this.Properties.TryGetValue("FocalPlaneResolutionUnit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FocalPlaneResolutionUnit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? FocalPlaneXResolution
    {
        get
        {
            if (!this.Properties.TryGetValue("FocalPlaneXResolution", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FocalPlaneXResolution"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? FocalPlaneYResolution
    {
        get
        {
            if (!this.Properties.TryGetValue("FocalPlaneYResolution", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["FocalPlaneYResolution"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? InteropOffset
    {
        get
        {
            if (!this.Properties.TryGetValue("InteropOffset", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["InteropOffset"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? ISO
    {
        get
        {
            if (!this.Properties.TryGetValue("ISO", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ISO"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? MeteringMode
    {
        get
        {
            if (!this.Properties.TryGetValue("MeteringMode", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["MeteringMode"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? SceneCaptureType
    {
        get
        {
            if (!this.Properties.TryGetValue("SceneCaptureType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["SceneCaptureType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public double? ShutterSpeedValue
    {
        get
        {
            if (!this.Properties.TryGetValue("ShutterSpeedValue", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<double?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ShutterSpeedValue"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? SubSecTime
    {
        get
        {
            if (!this.Properties.TryGetValue("SubSecTime", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["SubSecTime"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? WhiteBalance
    {
        get
        {
            if (!this.Properties.TryGetValue("WhiteBalance", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["WhiteBalance"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ApertureValue;
        _ = this.ColorSpace;
        _ = this.CreateDate;
        _ = this.CustomRendered;
        _ = this.DateTimeOriginal;
        _ = this.ExifImageHeight;
        _ = this.ExifImageWidth;
        _ = this.ExifVersion;
        _ = this.ExposureCompensation;
        _ = this.ExposureMode;
        _ = this.ExposureProgram;
        _ = this.ExposureTime;
        _ = this.Flash;
        _ = this.FlashpixVersion;
        _ = this.FNumber;
        _ = this.FocalLength;
        _ = this.FocalPlaneResolutionUnit;
        _ = this.FocalPlaneXResolution;
        _ = this.FocalPlaneYResolution;
        _ = this.InteropOffset;
        _ = this.ISO;
        _ = this.MeteringMode;
        _ = this.SceneCaptureType;
        _ = this.ShutterSpeedValue;
        _ = this.SubSecTime;
        _ = this.WhiteBalance;
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
