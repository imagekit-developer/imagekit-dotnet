using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;

namespace ImagekitDiversion.Models.Files.Purge;

[JsonConverter(typeof(JsonModelConverter<PurgeCacheResponse, PurgeCacheResponseFromRaw>))]
public sealed record class PurgeCacheResponse : JsonModel
{
    /// <summary>
    /// Unique identifier of the purge request. This can be used to check the status
    /// of the purge request.
    /// </summary>
    public string? RequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("requestId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("requestId", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RequestID;
    }

    public PurgeCacheResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PurgeCacheResponse(PurgeCacheResponse purgeCacheResponse)
        : base(purgeCacheResponse) { }
#pragma warning restore CS8618

    public PurgeCacheResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PurgeCacheResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PurgeCacheResponseFromRaw.FromRawUnchecked"/>
    public static PurgeCacheResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PurgeCacheResponseFromRaw : IFromRawJson<PurgeCacheResponse>
{
    /// <inheritdoc/>
    public PurgeCacheResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PurgeCacheResponse.FromRawUnchecked(rawData);
}
