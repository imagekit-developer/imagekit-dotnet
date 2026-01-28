using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;

namespace ImageKit.Models.Files;

/// <summary>
/// JSON object containing metadata.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileMetadata, FileMetadataFromRaw>))]
public sealed record class FileMetadata : JsonModel
{
    /// <summary>
    /// The audio codec used in the video (only for video).
    /// </summary>
    public string? AudioCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("audioCodec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audioCodec", value);
        }
    }

    /// <summary>
    /// The bit rate of the video in kbps (only for video).
    /// </summary>
    public long? BitRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("bitRate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bitRate", value);
        }
    }

    /// <summary>
    /// The density of the image in DPI.
    /// </summary>
    public long? Density
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("density");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("density", value);
        }
    }

    /// <summary>
    /// The duration of the video in seconds (only for video).
    /// </summary>
    public long? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    public Exif? Exif
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Exif>("exif");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exif", value);
        }
    }

    /// <summary>
    /// The format of the file (e.g., 'jpg', 'mp4').
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <summary>
    /// Indicates if the image has a color profile.
    /// </summary>
    public bool? HasColorProfile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasColorProfile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasColorProfile", value);
        }
    }

    /// <summary>
    /// Indicates if the image contains transparent areas.
    /// </summary>
    public bool? HasTransparency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("hasTransparency");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("hasTransparency", value);
        }
    }

    /// <summary>
    /// The height of the image or video in pixels.
    /// </summary>
    public long? Height
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("height");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("height", value);
        }
    }

    /// <summary>
    /// Perceptual hash of the image.
    /// </summary>
    public string? PHash
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("pHash");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pHash", value);
        }
    }

    /// <summary>
    /// The quality indicator of the image.
    /// </summary>
    public long? Quality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("quality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quality", value);
        }
    }

    /// <summary>
    /// The file size in bytes.
    /// </summary>
    public long? Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("size");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("size", value);
        }
    }

    /// <summary>
    /// The video codec used in the video (only for video).
    /// </summary>
    public string? VideoCodec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("videoCodec");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("videoCodec", value);
        }
    }

    /// <summary>
    /// The width of the image or video in pixels.
    /// </summary>
    public long? Width
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("width");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("width", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AudioCodec;
        _ = this.BitRate;
        _ = this.Density;
        _ = this.Duration;
        this.Exif?.Validate();
        _ = this.Format;
        _ = this.HasColorProfile;
        _ = this.HasTransparency;
        _ = this.Height;
        _ = this.PHash;
        _ = this.Quality;
        _ = this.Size;
        _ = this.VideoCodec;
        _ = this.Width;
    }

    public FileMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileMetadata(FileMetadata fileMetadata)
        : base(fileMetadata) { }
#pragma warning restore CS8618

    public FileMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileMetadataFromRaw.FromRawUnchecked"/>
    public static FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileMetadataFromRaw : IFromRawJson<FileMetadata>
{
    /// <inheritdoc/>
    public FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileMetadata.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Exif, ExifFromRaw>))]
public sealed record class Exif : JsonModel
{
    /// <summary>
    /// Object containing Exif details.
    /// </summary>
    public ExifExif? ExifValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExifExif>("exif");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("exif", value);
        }
    }

    /// <summary>
    /// Object containing GPS information.
    /// </summary>
    public Gps? Gps
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Gps>("gps");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("gps", value);
        }
    }

    /// <summary>
    /// Object containing EXIF image information.
    /// </summary>
    public Image? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Image>("image");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image", value);
        }
    }

    /// <summary>
    /// JSON object.
    /// </summary>
    public Interoperability? Interoperability
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Interoperability>("interoperability");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("interoperability", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Makernote
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "makernote"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "makernote",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Object containing Thumbnail information.
    /// </summary>
    public ExifThumbnail? Thumbnail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExifThumbnail>("thumbnail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("thumbnail", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ExifValue?.Validate();
        this.Gps?.Validate();
        this.Image?.Validate();
        this.Interoperability?.Validate();
        _ = this.Makernote;
        this.Thumbnail?.Validate();
    }

    public Exif() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Exif(Exif exif)
        : base(exif) { }
#pragma warning restore CS8618

    public Exif(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Exif(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExifFromRaw.FromRawUnchecked"/>
    public static Exif FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExifFromRaw : IFromRawJson<Exif>
{
    /// <inheritdoc/>
    public Exif FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Exif.FromRawUnchecked(rawData);
}

/// <summary>
/// Object containing Exif details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExifExif, ExifExifFromRaw>))]
public sealed record class ExifExif : JsonModel
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

    public ExifExif() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExifExif(ExifExif exifExif)
        : base(exifExif) { }
#pragma warning restore CS8618

    public ExifExif(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExifExif(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExifExifFromRaw.FromRawUnchecked"/>
    public static ExifExif FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExifExifFromRaw : IFromRawJson<ExifExif>
{
    /// <inheritdoc/>
    public ExifExif FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExifExif.FromRawUnchecked(rawData);
}

/// <summary>
/// Object containing GPS information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Gps, GpsFromRaw>))]
public sealed record class Gps : JsonModel
{
    public IReadOnlyList<long>? GpsVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("GPSVersionID");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "GPSVersionID",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GpsVersionID;
    }

    public Gps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Gps(Gps gps)
        : base(gps) { }
#pragma warning restore CS8618

    public Gps(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Gps(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GpsFromRaw.FromRawUnchecked"/>
    public static Gps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GpsFromRaw : IFromRawJson<Gps>
{
    /// <inheritdoc/>
    public Gps FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Gps.FromRawUnchecked(rawData);
}

/// <summary>
/// Object containing EXIF image information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Image, ImageFromRaw>))]
public sealed record class Image : JsonModel
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

    public Image() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Image(Image image)
        : base(image) { }
#pragma warning restore CS8618

    public Image(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Image(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageFromRaw.FromRawUnchecked"/>
    public static Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageFromRaw : IFromRawJson<Image>
{
    /// <inheritdoc/>
    public Image FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Image.FromRawUnchecked(rawData);
}

/// <summary>
/// JSON object.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Interoperability, InteroperabilityFromRaw>))]
public sealed record class Interoperability : JsonModel
{
    public string? InteropIndex
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("InteropIndex");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("InteropIndex", value);
        }
    }

    public string? InteropVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("InteropVersion");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("InteropVersion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InteropIndex;
        _ = this.InteropVersion;
    }

    public Interoperability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Interoperability(Interoperability interoperability)
        : base(interoperability) { }
#pragma warning restore CS8618

    public Interoperability(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Interoperability(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InteroperabilityFromRaw.FromRawUnchecked"/>
    public static Interoperability FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InteroperabilityFromRaw : IFromRawJson<Interoperability>
{
    /// <inheritdoc/>
    public Interoperability FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Interoperability.FromRawUnchecked(rawData);
}

/// <summary>
/// Object containing Thumbnail information.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExifThumbnail, ExifThumbnailFromRaw>))]
public sealed record class ExifThumbnail : JsonModel
{
    public long? Compression
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("Compression");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("Compression", value);
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

    public long? ThumbnailLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ThumbnailLength");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ThumbnailLength", value);
        }
    }

    public long? ThumbnailOffset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("ThumbnailOffset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ThumbnailOffset", value);
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
        _ = this.Compression;
        _ = this.ResolutionUnit;
        _ = this.ThumbnailLength;
        _ = this.ThumbnailOffset;
        _ = this.XResolution;
        _ = this.YResolution;
    }

    public ExifThumbnail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExifThumbnail(ExifThumbnail exifThumbnail)
        : base(exifThumbnail) { }
#pragma warning restore CS8618

    public ExifThumbnail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExifThumbnail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExifThumbnailFromRaw.FromRawUnchecked"/>
    public static ExifThumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExifThumbnailFromRaw : IFromRawJson<ExifThumbnail>
{
    /// <inheritdoc/>
    public ExifThumbnail FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExifThumbnail.FromRawUnchecked(rawData);
}
