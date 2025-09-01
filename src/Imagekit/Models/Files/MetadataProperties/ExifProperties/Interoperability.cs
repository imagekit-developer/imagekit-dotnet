using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.MetadataProperties.ExifProperties;

/// <summary>
/// JSON object.
/// </summary>
[JsonConverter(typeof(ModelConverter<Interoperability>))]
public sealed record class Interoperability : ModelBase, IFromRaw<Interoperability>
{
    public string? InteropIndex
    {
        get
        {
            if (!this.Properties.TryGetValue("InteropIndex", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["InteropIndex"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? InteropVersion
    {
        get
        {
            if (!this.Properties.TryGetValue("InteropVersion", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["InteropVersion"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.InteropIndex;
        _ = this.InteropVersion;
    }

    public Interoperability() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Interoperability(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Interoperability FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
