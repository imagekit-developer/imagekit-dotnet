using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files.Versions;

[JsonConverter(typeof(ModelConverter<VersionDeleteResponse>))]
public sealed record class VersionDeleteResponse : ModelBase, IFromRaw<VersionDeleteResponse>
{
    public override void Validate() { }

    public VersionDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static VersionDeleteResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
