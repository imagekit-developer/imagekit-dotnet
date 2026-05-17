using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<FolderDeleteResponse, FolderDeleteResponseFromRaw>))]
public sealed record class FolderDeleteResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public FolderDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderDeleteResponse(FolderDeleteResponse folderDeleteResponse)
        : base(folderDeleteResponse) { }
#pragma warning restore CS8618

    public FolderDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FolderDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderDeleteResponseFromRaw : IFromRawJson<FolderDeleteResponse>
{
    /// <inheritdoc/>
    public FolderDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderDeleteResponse.FromRawUnchecked(rawData);
}
