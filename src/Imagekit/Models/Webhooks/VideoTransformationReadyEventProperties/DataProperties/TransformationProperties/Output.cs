using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties.OutputProperties;
using System = System;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.DataProperties.TransformationProperties;

/// <summary>
/// Information about the transformed output video.
/// </summary>
[JsonConverter(typeof(ModelConverter<Output>))]
public sealed record class Output : ModelBase, IFromRaw<Output>
{
    /// <summary>
    /// URL to access the transformed video.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.Properties.TryGetValue("url", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new System::ArgumentNullException("url");
        }
        set
        {
            this.Properties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Metadata of the output video file.
    /// </summary>
    public VideoMetadata? VideoMetadata
    {
        get
        {
            if (!this.Properties.TryGetValue("video_metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<VideoMetadata?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["video_metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.URL;
        this.VideoMetadata?.Validate();
    }

    public Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Output(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Output FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Output(string url)
        : this()
    {
        this.URL = url;
    }
}
