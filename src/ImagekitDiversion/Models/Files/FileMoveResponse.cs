using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files;

[JsonConverter(typeof(JsonModelConverter<FileMoveResponse, FileMoveResponseFromRaw>))]
public sealed record class FileMoveResponse : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public FileMoveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileMoveResponse(FileMoveResponse fileMoveResponse)
        : base(fileMoveResponse) { }
#pragma warning restore CS8618

    public FileMoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileMoveResponseFromRaw.FromRawUnchecked"/>
    public static FileMoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileMoveResponseFromRaw : IFromRawJson<FileMoveResponse>
{
    /// <inheritdoc/>
    public FileMoveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileMoveResponse.FromRawUnchecked(rawData);
}
