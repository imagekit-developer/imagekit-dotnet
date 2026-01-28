using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;

namespace ImageKit.Models.Folders;

[JsonConverter(typeof(JsonModelConverter<FolderCreateResponse, FolderCreateResponseFromRaw>))]
public sealed record class FolderCreateResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public FolderCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCreateResponse(FolderCreateResponse folderCreateResponse)
        : base(folderCreateResponse) { }
#pragma warning restore CS8618

    public FolderCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderCreateResponseFromRaw.FromRawUnchecked"/>
    public static FolderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderCreateResponseFromRaw : IFromRawJson<FolderCreateResponse>
{
    /// <inheritdoc/>
    public FolderCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderCreateResponse.FromRawUnchecked(rawData);
}
