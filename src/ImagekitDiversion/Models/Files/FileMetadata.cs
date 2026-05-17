using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

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
    public ExifDetails? ExifValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExifDetails>("exif");
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
    public ExifImage? Image
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExifImage>("image");
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
    public Thumbnail? Thumbnail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Thumbnail>("thumbnail");
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
