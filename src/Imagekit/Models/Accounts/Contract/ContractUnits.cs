using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Accounts.Contract;

[JsonConverter(typeof(JsonModelConverter<ContractUnits, ContractUnitsFromRaw>))]
public sealed record class ContractUnits : JsonModel
{
    /// <summary>
    /// Bandwidth in bytes.
    /// </summary>
    public required long BandwidthBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("bandwidthBytes");
        }
        init { this._rawData.Set("bandwidthBytes", value); }
    }

    /// <summary>
    /// Number of extension units.
    /// </summary>
    public required long ExtensionUnitsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("extensionUnitsCount");
        }
        init { this._rawData.Set("extensionUnitsCount", value); }
    }

    /// <summary>
    /// Number of purge cache requests.
    /// </summary>
    public required long PurgeCacheRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("purgeCacheRequests");
        }
        init { this._rawData.Set("purgeCacheRequests", value); }
    }

    /// <summary>
    /// Number of video processing units.
    /// </summary>
    public required long VideoProcessingUnitsCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("videoProcessingUnitsCount");
        }
        init { this._rawData.Set("videoProcessingUnitsCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.ExtensionUnitsCount;
        _ = this.PurgeCacheRequests;
        _ = this.VideoProcessingUnitsCount;
    }

    public ContractUnits() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractUnits(ContractUnits contractUnits)
        : base(contractUnits) { }
#pragma warning restore CS8618

    public ContractUnits(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractUnits(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractUnitsFromRaw.FromRawUnchecked"/>
    public static ContractUnits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContractUnitsFromRaw : IFromRawJson<ContractUnits>
{
    /// <inheritdoc/>
    public ContractUnits FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContractUnits.FromRawUnchecked(rawData);
}
