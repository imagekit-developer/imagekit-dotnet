using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(ModelConverter<FileMoveResponse>))]
public sealed record class FileMoveResponse : ModelBase, IFromRaw<FileMoveResponse>
{
    public override void Validate() { }

    public FileMoveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMoveResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileMoveResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
