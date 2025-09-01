using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.MetadataProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// JSON object containing metadata.
/// </summary>
[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    /// <summary>
    /// The audio codec used in the video (only for video).
    /// </summary>
    public string? AudioCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("audioCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["audioCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The bit rate of the video in kbps (only for video).
    /// </summary>
    public long? BitRate
    {
        get
        {
            if (!this.Properties.TryGetValue("bitRate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bitRate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The density of the image in DPI.
    /// </summary>
    public long? Density
    {
        get
        {
            if (!this.Properties.TryGetValue("density", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["density"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The duration of the video in seconds (only for video).
    /// </summary>
    public long? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Exif? Exif
    {
        get
        {
            if (!this.Properties.TryGetValue("exif", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Exif?>(element, ModelBase.SerializerOptions);
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
    /// The format of the file (e.g., 'jpg', 'mp4').
    /// </summary>
    public string? Format
    {
        get
        {
            if (!this.Properties.TryGetValue("format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["format"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the image has a color profile.
    /// </summary>
    public bool? HasColorProfile
    {
        get
        {
            if (!this.Properties.TryGetValue("hasColorProfile", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hasColorProfile"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Indicates if the image contains transparent areas.
    /// </summary>
    public bool? HasTransparency
    {
        get
        {
            if (!this.Properties.TryGetValue("hasTransparency", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["hasTransparency"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The height of the image or video in pixels.
    /// </summary>
    public long? Height
    {
        get
        {
            if (!this.Properties.TryGetValue("height", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["height"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Perceptual hash of the image.
    /// </summary>
    public string? PHash
    {
        get
        {
            if (!this.Properties.TryGetValue("pHash", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["pHash"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The quality indicator of the image.
    /// </summary>
    public long? Quality
    {
        get
        {
            if (!this.Properties.TryGetValue("quality", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["quality"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The file size in bytes.
    /// </summary>
    public long? Size
    {
        get
        {
            if (!this.Properties.TryGetValue("size", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["size"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The video codec used in the video (only for video).
    /// </summary>
    public string? VideoCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("videoCodec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["videoCodec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The width of the image or video in pixels.
    /// </summary>
    public long? Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["width"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
