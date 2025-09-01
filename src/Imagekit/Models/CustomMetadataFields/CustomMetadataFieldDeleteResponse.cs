using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.CustomMetadataFields;

[JsonConverter(typeof(ModelConverter<CustomMetadataFieldDeleteResponse>))]
public sealed record class CustomMetadataFieldDeleteResponse
    : ModelBase,
        IFromRaw<CustomMetadataFieldDeleteResponse>
{
    public override void Validate() { }

    public CustomMetadataFieldDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomMetadataFieldDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static CustomMetadataFieldDeleteResponse FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
