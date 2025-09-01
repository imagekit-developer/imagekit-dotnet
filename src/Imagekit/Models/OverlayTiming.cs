using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.OverlayTimingProperties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<OverlayTiming>))]
public sealed record class OverlayTiming : ModelBase, IFromRaw<OverlayTiming>
{
    /// <summary>
    /// Specifies the duration (in seconds) during which the overlay should appear
    /// on the base video. Accepts a positive number up to two decimal places (e.g.,
    /// `20` or `20.50`) and arithmetic expressions such as `bdu_mul_0.4` or `bdu_sub_idu`.
    /// Applies only if the base asset is a video. Maps to `ldu` in the URL.
    /// </summary>
    public Duration? Duration
    {
        get
        {
            if (!this.Properties.TryGetValue("duration", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Duration?>(element, ModelBase.SerializerOptions);
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
    /// Specifies the end time (in seconds) for when the overlay should disappear
    /// from the base video. If both end and duration are provided, duration is ignored.
    /// Accepts a positive number up to two decimal places (e.g., `20` or `20.50`)
    /// and arithmetic expressions such as `bdu_mul_0.4` or `bdu_sub_idu`. Applies
    /// only if the base asset is a video. Maps to `leo` in the URL.
    /// </summary>
    public End? End
    {
        get
        {
            if (!this.Properties.TryGetValue("end", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<End?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["end"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the start time (in seconds) for when the overlay should appear on
    /// the base video. Accepts a positive number up to two decimal places (e.g.,
    /// `20` or `20.50`) and arithmetic expressions such as `bdu_mul_0.4` or `bdu_sub_idu`.
    /// Applies only if the base asset is a video. Maps to `lso` in the URL.
    /// </summary>
    public Start? Start
    {
        get
        {
            if (!this.Properties.TryGetValue("start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Start?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Duration?.Validate();
        this.End?.Validate();
        this.Start?.Validate();
    }

    public OverlayTiming() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OverlayTiming(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OverlayTiming FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
