using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUpdateResponseProperties.IntersectionMember1Properties;

namespace Imagekit.Models.Files.FileUpdateResponseProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public ExtensionStatus? ExtensionStatus
    {
        get
        {
            if (!this.Properties.TryGetValue("extensionStatus", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ExtensionStatus?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["extensionStatus"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ExtensionStatus?.Validate();
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
