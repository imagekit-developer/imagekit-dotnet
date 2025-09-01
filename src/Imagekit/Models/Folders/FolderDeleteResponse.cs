using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Folders;

[JsonConverter(typeof(ModelConverter<FolderDeleteResponse>))]
public sealed record class FolderDeleteResponse : ModelBase, IFromRaw<FolderDeleteResponse>
{
    public override void Validate() { }

    public FolderDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderDeleteResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FolderDeleteResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
