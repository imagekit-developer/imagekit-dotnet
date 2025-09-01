using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.MetadataProperties.ExifProperties;

/// <summary>
/// Object containing GPS information.
/// </summary>
[JsonConverter(typeof(ModelConverter<Gps>))]
public sealed record class Gps : ModelBase, IFromRaw<Gps>
{
    public List<long>? GpsVersionID
    {
        get
        {
            if (!this.Properties.TryGetValue("GPSVersionID", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<long>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["GPSVersionID"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.GpsVersionID ?? [])
        {
            _ = item;
        }
    }

    public Gps() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Gps(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Gps FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
