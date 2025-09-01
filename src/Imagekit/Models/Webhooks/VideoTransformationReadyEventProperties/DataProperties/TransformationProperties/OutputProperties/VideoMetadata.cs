using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OutputProperties;

/// <summary>
/// Metadata of the output video file.
/// </summary>
[JsonConverter(typeof(ModelConverter<VideoMetadata>))]
public sealed record class VideoMetadata : ModelBase, IFromRaw<VideoMetadata>
{
    /// <summary>
    /// Bitrate of the output video in bits per second.
    /// </summary>
    public required long Bitrate
    {
        get
        {
            if (!this.Properties.TryGetValue("bitrate", out JsonElement element))
                throw new ArgumentOutOfRangeException("bitrate", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bitrate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Duration of the output video in seconds.
    /// </summary>
    public required double Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                throw new ArgumentOutOfRangeException("duration", "Missing required argument");

            return JsonSerializer.Deserialize<double>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Height of the output video in pixels.
    /// </summary>
    public required long Height
    {
        get
        {
            if (!this.Properties.TryGetValue("height", out JsonElement element))
                throw new ArgumentOutOfRangeException("height", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
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
    /// Width of the output video in pixels.
    /// </summary>
    public required long Width
    {
        get
        {
            if (!this.Properties.TryGetValue("width", out JsonElement element))
                throw new ArgumentOutOfRangeException("width", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
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
        _ = this.Bitrate;
        _ = this.Duration;
        _ = this.Height;
        _ = this.Width;
    }

    public VideoMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoMetadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static VideoMetadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
