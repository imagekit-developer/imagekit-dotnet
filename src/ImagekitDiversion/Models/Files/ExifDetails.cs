using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// Object containing Exif details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExifDetails, ExifDetailsFromRaw>))]
public sealed record class ExifDetails : JsonModel
{
    public double? ApertureValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ApertureValue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ApertureValue", value);
        }
    }

    public long? ColorSpace
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ColorSpace");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ColorSpace", value);
        }
    }

    public string? CreateDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("CreateDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("CreateDate", value);
        }
    }

    public long? CustomRendered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("CustomRendered");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("CustomRendered", value);
        }
    }

    public string? DateTimeOriginal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("DateTimeOriginal");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("DateTimeOriginal", value);
        }
    }

    public long? ExifImageHeight
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ExifImageHeight");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExifImageHeight", value);
        }
    }

    public long? ExifImageWidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ExifImageWidth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExifImageWidth", value);
        }
    }

    public string? ExifVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ExifVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExifVersion", value);
        }
    }

    public double? ExposureCompensation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ExposureCompensation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExposureCompensation", value);
        }
    }

    public long? ExposureMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ExposureMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExposureMode", value);
        }
    }

    public long? ExposureProgram
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ExposureProgram");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExposureProgram", value);
        }
    }

    public double? ExposureTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ExposureTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExposureTime", value);
        }
    }

    public long? Flash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("Flash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Flash", value);
        }
    }

    public string? FlashpixVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("FlashpixVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FlashpixVersion", value);
        }
    }

    public double? FNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("FNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FNumber", value);
        }
    }

    public long? FocalLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("FocalLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FocalLength", value);
        }
    }

    public long? FocalPlaneResolutionUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("FocalPlaneResolutionUnit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FocalPlaneResolutionUnit", value);
        }
    }

    public double? FocalPlaneXResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("FocalPlaneXResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FocalPlaneXResolution", value);
        }
    }

    public double? FocalPlaneYResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("FocalPlaneYResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("FocalPlaneYResolution", value);
        }
    }

    public long? InteropOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("InteropOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("InteropOffset", value);
        }
    }

    public long? Iso
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ISO");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ISO", value);
        }
    }

    public long? MeteringMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("MeteringMode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("MeteringMode", value);
        }
    }

    public long? SceneCaptureType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("SceneCaptureType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("SceneCaptureType", value);
        }
    }

    public double? ShutterSpeedValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("ShutterSpeedValue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ShutterSpeedValue", value);
        }
    }

    public string? SubSecTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("SubSecTime");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("SubSecTime", value);
        }
    }

    public long? WhiteBalance
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("WhiteBalance");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("WhiteBalance", value);
        }
    }

    /// <inheritdoc/>
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
        _ = this.Iso;
        _ = this.MeteringMode;
        _ = this.SceneCaptureType;
        _ = this.ShutterSpeedValue;
        _ = this.SubSecTime;
        _ = this.WhiteBalance;
    }

    public ExifDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExifDetails(ExifDetails exifDetails)
        : base(exifDetails) { }
#pragma warning restore CS8618

    public ExifDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExifDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExifDetailsFromRaw.FromRawUnchecked"/>
    public static ExifDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExifDetailsFromRaw : IFromRawJson<ExifDetails>
{
    /// <inheritdoc/>
    public ExifDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExifDetails.FromRawUnchecked(rawData);
}
