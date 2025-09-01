using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models;

[JsonConverter(typeof(ModelConverter<BaseOverlay>))]
public sealed record class BaseOverlay : ModelBase, IFromRaw<BaseOverlay>
{
    public OverlayPosition? Position
    {
        get
        {
            if (!this.Properties.TryGetValue("position", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayPosition?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["position"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public OverlayTiming? Timing
    {
        get
        {
            if (!this.Properties.TryGetValue("timing", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<OverlayTiming?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timing"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Position?.Validate();
        this.Timing?.Validate();
    }

    public BaseOverlay() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseOverlay(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BaseOverlay FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
