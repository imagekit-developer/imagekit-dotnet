using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Folders;

[JsonConverter(typeof(ModelConverter<FolderCreateResponse>))]
public sealed record class FolderCreateResponse : ModelBase, IFromRaw<FolderCreateResponse>
{
    public override void Validate() { }

    public FolderCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCreateResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FolderCreateResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
