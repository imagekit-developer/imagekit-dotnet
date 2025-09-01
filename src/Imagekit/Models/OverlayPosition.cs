using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.OverlayPositionProperties;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<OverlayPosition>))]
public sealed record class OverlayPosition : ModelBase, IFromRaw<OverlayPosition>
{
    /// <summary>
    /// Specifies the position of the overlay relative to the parent image or video.
    /// Maps to `lfo` in the URL.
    /// </summary>
    public ApiEnum<string, Focus>? Focus
    {
        get
        {
            if (!this.Properties.TryGetValue("focus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Focus>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["focus"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the x-coordinate of the top-left corner of the base asset where
    /// the overlay's top-left corner will be positioned. It also accepts arithmetic
    /// expressions such as `bw_mul_0.4` or `bw_sub_cw`. Maps to `lx` in the URL.
    /// Learn about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public X? X
    {
        get
        {
            if (!this.Properties.TryGetValue("x", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<X?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["x"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specifies the y-coordinate of the top-left corner of the base asset where
    /// the overlay's top-left corner will be positioned. It also accepts arithmetic
    /// expressions such as `bh_mul_0.4` or `bh_sub_ch`. Maps to `ly` in the URL.
    /// Learn about [Arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
    /// </summary>
    public Y? Y
    {
        get
        {
            if (!this.Properties.TryGetValue("y", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Y?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["y"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Focus?.Validate();
        this.X?.Validate();
        this.Y?.Validate();
    }

    public OverlayPosition() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OverlayPosition(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static OverlayPosition FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
