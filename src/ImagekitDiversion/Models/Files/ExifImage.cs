using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

/// <summary>
/// Object containing EXIF image information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExifImage, ExifImageFromRaw>))]
public sealed record class ExifImage : JsonModel
{
    public long? ExifOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ExifOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ExifOffset", value);
        }
    }

    public long? GpsInfo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("GPSInfo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("GPSInfo", value);
        }
    }

    public string? Make
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("Make");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Make", value);
        }
    }

    public string? Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("Model");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Model", value);
        }
    }

    public string? ModifyDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ModifyDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ModifyDate", value);
        }
    }

    public long? Orientation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("Orientation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Orientation", value);
        }
    }

    public long? ResolutionUnit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ResolutionUnit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ResolutionUnit", value);
        }
    }

    public string? Software
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("Software");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Software", value);
        }
    }

    public long? XResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("XResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("XResolution", value);
        }
    }

    public long? YCbCrPositioning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("YCbCrPositioning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("YCbCrPositioning", value);
        }
    }

    public long? YResolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("YResolution");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("YResolution", value);
        }
    }

    /// <inheritdoc/>
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

    public ExifImage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExifImage(ExifImage exifImage)
        : base(exifImage) { }
#pragma warning restore CS8618

    public ExifImage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExifImage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExifImageFromRaw.FromRawUnchecked"/>
    public static ExifImage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExifImageFromRaw : IFromRawJson<ExifImage>
{
    /// <inheritdoc/>
    public ExifImage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExifImage.FromRawUnchecked(rawData);
}
