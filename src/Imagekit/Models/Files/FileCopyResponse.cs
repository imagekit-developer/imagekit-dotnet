using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Files;

[JsonConverter(typeof(ModelConverter<FileCopyResponse>))]
public sealed record class FileCopyResponse : ModelBase, IFromRaw<FileCopyResponse>
{
    public override void Validate() { }

    public FileCopyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCopyResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileCopyResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
