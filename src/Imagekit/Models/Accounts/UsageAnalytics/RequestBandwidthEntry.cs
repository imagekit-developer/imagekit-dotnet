using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Accounts.UsageAnalytics;

[JsonConverter(typeof(JsonModelConverter<RequestBandwidthEntry, RequestBandwidthEntryFromRaw>))]
public sealed record class RequestBandwidthEntry : JsonModel
{
    /// <summary>
    /// Total bandwidth used in bytes.
    /// </summary>
    public required double BandwidthBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("bandwidthBytes");
        }
        init { this._rawData.Set("bandwidthBytes", value); }
    }

    /// <summary>
    /// Number of requests.
    /// </summary>
    public required double RequestCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("requestCount");
        }
        init { this._rawData.Set("requestCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
    }

    public RequestBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestBandwidthEntry(RequestBandwidthEntry requestBandwidthEntry)
        : base(requestBandwidthEntry) { }
#pragma warning restore CS8618

    public RequestBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static RequestBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestBandwidthEntryFromRaw : IFromRawJson<RequestBandwidthEntry>
{
    /// <inheritdoc/>
    public RequestBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestBandwidthEntry.FromRawUnchecked(rawData);
}
