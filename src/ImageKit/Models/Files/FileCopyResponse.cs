using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;

namespace ImageKit.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileCopyResponse, FileCopyResponseFromRaw>))]
public sealed record class FileCopyResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public FileCopyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCopyResponse(FileCopyResponse fileCopyResponse)
        : base(fileCopyResponse) { }
#pragma warning restore CS8618

    public FileCopyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCopyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCopyResponseFromRaw.FromRawUnchecked"/>
    public static FileCopyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCopyResponseFromRaw : IFromRawJson<FileCopyResponse>
{
    /// <inheritdoc/>
    public FileCopyResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileCopyResponse.FromRawUnchecked(rawData);
}
