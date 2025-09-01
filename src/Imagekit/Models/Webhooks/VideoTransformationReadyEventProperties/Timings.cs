using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties;

/// <summary>
/// Performance metrics for the transformation process.
/// </summary>
[JsonConverter(typeof(ModelConverter<Timings>))]
public sealed record class Timings : ModelBase, IFromRaw<Timings>
{
    /// <summary>
    /// Time spent downloading the source video from your origin or media library,
    /// in milliseconds.
    /// </summary>
    public long? DownloadDuration
    {
        get
        {
            if (!this.Properties.TryGetValue("download_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["download_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Time spent encoding the video, in milliseconds.
    /// </summary>
    public long? EncodingDuration
    {
        get
        {
            if (!this.Properties.TryGetValue("encoding_duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["encoding_duration"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.DownloadDuration;
        _ = this.EncodingDuration;
    }

    public Timings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timings(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Timings FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
