using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OptionsProperties;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties;

/// <summary>
/// Configuration options for video transformations.
/// </summary>
[JsonConverter(typeof(ModelConverter<Options>))]
public sealed record class Options : ModelBase, IFromRaw<Options>
{
    /// <summary>
    /// Audio codec used for encoding (aac or opus).
    /// </summary>
    public ApiEnum<string, AudioCodec>? AudioCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("audio_codec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AudioCodec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["audio_codec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to automatically rotate the video based on metadata.
    /// </summary>
    public bool? AutoRotate
    {
        get
        {
            if (!this.Properties.TryGetValue("auto_rotate", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["auto_rotate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Output format for the transformed video or thumbnail.
    /// </summary>
    public ApiEnum<string, Format>? Format
    {
        get
        {
            if (!this.Properties.TryGetValue("format", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Format>?>(
                element,
                ModelBase.SerializerOptions
            );
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
    /// Quality setting for the output video.
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
    /// Streaming protocol for adaptive bitrate streaming.
    /// </summary>
    public ApiEnum<string, StreamProtocol>? StreamProtocol
    {
        get
        {
            if (!this.Properties.TryGetValue("stream_protocol", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, StreamProtocol>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["stream_protocol"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Array of quality representations for adaptive bitrate streaming.
    /// </summary>
    public List<string>? Variants
    {
        get
        {
            if (!this.Properties.TryGetValue("variants", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["variants"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Video codec used for encoding (h264, vp9, or av1).
    /// </summary>
    public ApiEnum<string, VideoCodec>? VideoCodec
    {
        get
        {
            if (!this.Properties.TryGetValue("video_codec", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, VideoCodec>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["video_codec"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.AudioCodec?.Validate();
        _ = this.AutoRotate;
        this.Format?.Validate();
        _ = this.Quality;
        this.StreamProtocol?.Validate();
        foreach (var item in this.Variants ?? [])
        {
            _ = item;
        }
        this.VideoCodec?.Validate();
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Options FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
