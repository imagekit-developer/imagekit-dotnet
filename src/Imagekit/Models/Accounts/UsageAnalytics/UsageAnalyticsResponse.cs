using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Accounts.UsageAnalytics;

[JsonConverter(typeof(JsonModelConverter<UsageAnalyticsResponse, UsageAnalyticsResponseFromRaw>))]
public sealed record class UsageAnalyticsResponse : JsonModel
{
    /// <summary>
    /// Total bandwidth, in bytes, utilized during the specified date range.
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
    /// CDN traffic grouped by browser.
    /// </summary>
    public required Browser Browser
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Browser>("browser");
        }
        init { this._rawData.Set("browser", value); }
    }

    /// <summary>
    /// CDN cache hit, miss and error counts for the date range.
    /// </summary>
    public required UsageAnalyticsResponseCache Cache
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UsageAnalyticsResponseCache>("cache");
        }
        init { this._rawData.Set("cache", value); }
    }

    /// <summary>
    /// CDN traffic grouped by country.
    /// </summary>
    public required Country Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Country>("country");
        }
        init { this._rawData.Set("country", value); }
    }

    /// <summary>
    /// CDN traffic grouped by device and operating system (e.g. `Desktop - Apple
    /// Mac`, `Smartphone - Apple iPhone`).
    /// </summary>
    public required Device Device
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Device>("device");
        }
        init { this._rawData.Set("device", value); }
    }

    /// <summary>
    /// End date of the computed analytics data.
    /// </summary>
    public required string EndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("endDate");
        }
        init { this._rawData.Set("endDate", value); }
    }

    /// <summary>
    /// Request count grouped by origin error reason. This covers failed origin fetches,
    /// such as an asset not found at origin or an origin timeout. It is not the
    /// HTTP status code returned to the client, see `statusCodes` for that.
    /// </summary>
    public required IReadOnlyList<ErrorReason> ErrorReasons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ErrorReason>>("errorReasons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ErrorReason>>(
                "errorReasons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Raw per-extension operation counts for the date range. These are raw operation
    /// counts, not billable extension units. For billable usage, use the `/v1/accounts/usage` endpoint.
    /// </summary>
    public required IReadOnlyList<Extension> Extensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Extension>>("extensions");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Extension>>(
                "extensions",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// CDN traffic grouped by response `Content-Type`.
    /// </summary>
    public required Format Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Format>("format");
        }
        init { this._rawData.Set("format", value); }
    }

    /// <summary>
    /// Date and time when the analytics data was computed. Use this to gauge how
    /// fresh the returned data is. The date and time is in ISO8601 format.
    /// </summary>
    public required DateTimeOffset GeneratedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("generatedAt");
        }
        init { this._rawData.Set("generatedAt", value); }
    }

    /// <summary>
    /// Total number of requests made during the specified date range.
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

    /// <summary>
    /// Start date of the computed analytics data.
    /// </summary>
    public required string StartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("startDate");
        }
        init { this._rawData.Set("startDate", value); }
    }

    /// <summary>
    /// Request count grouped by HTTP status code.
    /// </summary>
    public required IReadOnlyList<StatusCode> StatusCodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<StatusCode>>("statusCodes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<StatusCode>>(
                "statusCodes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top URLs that returned a 404 response.
    /// </summary>
    public required IReadOnlyList<Top404Asset> Top404Assets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Top404Asset>>("top404Assets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Top404Asset>>(
                "top404Assets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top image assets by traffic.
    /// </summary>
    public required TopImages TopImages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopImages>("topImages");
        }
        init { this._rawData.Set("topImages", value); }
    }

    /// <summary>
    /// Top image transformation strings by traffic.
    /// </summary>
    public required TopImageTransforms TopImageTransforms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopImageTransforms>("topImageTransforms");
        }
        init { this._rawData.Set("topImageTransforms", value); }
    }

    /// <summary>
    /// Top non-image, non-video assets by traffic.
    /// </summary>
    public required TopOtherAssets TopOtherAssets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopOtherAssets>("topOtherAssets");
        }
        init { this._rawData.Set("topOtherAssets", value); }
    }

    /// <summary>
    /// Top HTTP referrers by traffic.
    /// </summary>
    public required TopReferrers TopReferrers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopReferrers>("topReferrers");
        }
        init { this._rawData.Set("topReferrers", value); }
    }

    /// <summary>
    /// Top user agents by traffic.
    /// </summary>
    public required TopUserAgents TopUserAgents
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopUserAgents>("topUserAgents");
        }
        init { this._rawData.Set("topUserAgents", value); }
    }

    /// <summary>
    /// Top video assets by traffic.
    /// </summary>
    public required TopVideos TopVideos
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopVideos>("topVideos");
        }
        init { this._rawData.Set("topVideos", value); }
    }

    /// <summary>
    /// Top video transformation strings by traffic.
    /// </summary>
    public required TopVideoTransforms TopVideoTransforms
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TopVideoTransforms>("topVideoTransforms");
        }
        init { this._rawData.Set("topVideoTransforms", value); }
    }

    /// <summary>
    /// CDN traffic grouped by configured URL endpoint. Traffic that does not match
    /// any named URL endpoint pattern is grouped under `Default`.
    /// </summary>
    public required UsageAnalyticsResponseUrlEndpoints UrlEndpoints
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UsageAnalyticsResponseUrlEndpoints>(
                "urlEndpoints"
            );
        }
        init { this._rawData.Set("urlEndpoints", value); }
    }

    /// <summary>
    /// Raw observed video transcode output duration, in seconds, grouped by resolution
    /// and codec. These are raw seconds, not billable Video Processing Units (VPU).
    /// For billable VPU totals, use the `/v1/accounts/usage` endpoint.
    /// </summary>
    public required IReadOnlyList<VideoProcessing> VideoProcessing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VideoProcessing>>(
                "videoProcessing"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<VideoProcessing>>(
                "videoProcessing",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        this.Browser.Validate();
        this.Cache.Validate();
        this.Country.Validate();
        this.Device.Validate();
        _ = this.EndDate;
        foreach (var item in this.ErrorReasons)
        {
            item.Validate();
        }
        foreach (var item in this.Extensions)
        {
            item.Validate();
        }
        this.Format.Validate();
        _ = this.GeneratedAt;
        _ = this.RequestCount;
        _ = this.StartDate;
        foreach (var item in this.StatusCodes)
        {
            item.Validate();
        }
        foreach (var item in this.Top404Assets)
        {
            item.Validate();
        }
        this.TopImages.Validate();
        this.TopImageTransforms.Validate();
        this.TopOtherAssets.Validate();
        this.TopReferrers.Validate();
        this.TopUserAgents.Validate();
        this.TopVideos.Validate();
        this.TopVideoTransforms.Validate();
        this.UrlEndpoints.Validate();
        foreach (var item in this.VideoProcessing)
        {
            item.Validate();
        }
    }

    public UsageAnalyticsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsResponse(UsageAnalyticsResponse usageAnalyticsResponse)
        : base(usageAnalyticsResponse) { }
#pragma warning restore CS8618

    public UsageAnalyticsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageAnalyticsResponseFromRaw.FromRawUnchecked"/>
    public static UsageAnalyticsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageAnalyticsResponseFromRaw : IFromRawJson<UsageAnalyticsResponse>
{
    /// <inheritdoc/>
    public UsageAnalyticsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageAnalyticsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN traffic grouped by browser.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Browser, BrowserFromRaw>))]
public sealed record class Browser : JsonModel
{
    /// <summary>
    /// Top browsers sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<ByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ByBandwidth>>("byBandwidth");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top browsers sorted by request count.
    /// </summary>
    public required IReadOnlyList<ByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public Browser() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Browser(Browser browser)
        : base(browser) { }
#pragma warning restore CS8618

    public Browser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Browser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFromRaw.FromRawUnchecked"/>
    public static Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFromRaw : IFromRawJson<Browser>
{
    /// <inheritdoc/>
    public Browser FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Browser.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ByBandwidth, ByBandwidthFromRaw>))]
public sealed record class ByBandwidth : JsonModel
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

    /// <summary>
    /// Browser name (e.g. `Chrome`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(ByBandwidth byBandwidth) =>
        new()
        {
            BandwidthBytes = byBandwidth.BandwidthBytes,
            RequestCount = byBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public ByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ByBandwidth(ByBandwidth byBandwidth)
        : base(byBandwidth) { }
#pragma warning restore CS8618

    public ByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ByBandwidthFromRaw.FromRawUnchecked"/>
    public static ByBandwidth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ByBandwidthFromRaw : IFromRawJson<ByBandwidth>
{
    /// <inheritdoc/>
    public ByBandwidth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrowserByBandwidthEntry, BrowserByBandwidthEntryFromRaw>))]
public sealed record class BrowserByBandwidthEntry : JsonModel
{
    /// <summary>
    /// Browser name (e.g. `Chrome`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public BrowserByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserByBandwidthEntry(BrowserByBandwidthEntry browserByBandwidthEntry)
        : base(browserByBandwidthEntry) { }
#pragma warning restore CS8618

    public BrowserByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static BrowserByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class BrowserByBandwidthEntryFromRaw : IFromRawJson<BrowserByBandwidthEntry>
{
    /// <inheritdoc/>
    public BrowserByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ByRequest, ByRequestFromRaw>))]
public sealed record class ByRequest : JsonModel
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

    /// <summary>
    /// Browser name (e.g. `Chrome`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(ByRequest byRequest) =>
        new() { BandwidthBytes = byRequest.BandwidthBytes, RequestCount = byRequest.RequestCount };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public ByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ByRequest(ByRequest byRequest)
        : base(byRequest) { }
#pragma warning restore CS8618

    public ByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ByRequestFromRaw.FromRawUnchecked"/>
    public static ByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ByRequestFromRaw : IFromRawJson<ByRequest>
{
    /// <inheritdoc/>
    public ByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<BrowserByRequestsEntry, BrowserByRequestsEntryFromRaw>))]
public sealed record class BrowserByRequestsEntry : JsonModel
{
    /// <summary>
    /// Browser name (e.g. `Chrome`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public BrowserByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserByRequestsEntry(BrowserByRequestsEntry browserByRequestsEntry)
        : base(browserByRequestsEntry) { }
#pragma warning restore CS8618

    public BrowserByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static BrowserByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class BrowserByRequestsEntryFromRaw : IFromRawJson<BrowserByRequestsEntry>
{
    /// <inheritdoc/>
    public BrowserByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN cache hit, miss and error counts for the date range.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UsageAnalyticsResponseCache, UsageAnalyticsResponseCacheFromRaw>)
)]
public sealed record class UsageAnalyticsResponseCache : JsonModel
{
    /// <summary>
    /// Number of requests where the CDN encountered a cache error or exceeded capacity
    /// while serving the response.
    /// </summary>
    public required double ErrorCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("errorCount");
        }
        init { this._rawData.Set("errorCount", value); }
    }

    /// <summary>
    /// Number of requests served from cache, including full hits and revalidated hits.
    /// </summary>
    public required double HitCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("hitCount");
        }
        init { this._rawData.Set("hitCount", value); }
    }

    /// <summary>
    /// Number of requests that were not found in cache and had to be fetched from origin.
    /// </summary>
    public required double MissCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("missCount");
        }
        init { this._rawData.Set("missCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ErrorCount;
        _ = this.HitCount;
        _ = this.MissCount;
    }

    public UsageAnalyticsResponseCache() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsResponseCache(UsageAnalyticsResponseCache usageAnalyticsResponseCache)
        : base(usageAnalyticsResponseCache) { }
#pragma warning restore CS8618

    public UsageAnalyticsResponseCache(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsResponseCache(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageAnalyticsResponseCacheFromRaw.FromRawUnchecked"/>
    public static UsageAnalyticsResponseCache FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageAnalyticsResponseCacheFromRaw : IFromRawJson<UsageAnalyticsResponseCache>
{
    /// <inheritdoc/>
    public UsageAnalyticsResponseCache FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageAnalyticsResponseCache.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN traffic grouped by country.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Country, CountryFromRaw>))]
public sealed record class Country : JsonModel
{
    /// <summary>
    /// Top requesting countries sorted by total bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<CountryByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CountryByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<CountryByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top requesting countries sorted by request count.
    /// </summary>
    public required IReadOnlyList<CountryByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CountryByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CountryByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public Country() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Country(Country country)
        : base(country) { }
#pragma warning restore CS8618

    public Country(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Country(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryFromRaw.FromRawUnchecked"/>
    public static Country FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryFromRaw : IFromRawJson<Country>
{
    /// <inheritdoc/>
    public Country FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Country.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CountryByBandwidth, CountryByBandwidthFromRaw>))]
public sealed record class CountryByBandwidth : JsonModel
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

    /// <summary>
    /// ISO country code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Country name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(CountryByBandwidth countryByBandwidth) =>
        new()
        {
            BandwidthBytes = countryByBandwidth.BandwidthBytes,
            RequestCount = countryByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Code;
        _ = this.Name;
    }

    public CountryByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryByBandwidth(CountryByBandwidth countryByBandwidth)
        : base(countryByBandwidth) { }
#pragma warning restore CS8618

    public CountryByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryByBandwidthFromRaw.FromRawUnchecked"/>
    public static CountryByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryByBandwidthFromRaw : IFromRawJson<CountryByBandwidth>
{
    /// <inheritdoc/>
    public CountryByBandwidth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CountryByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CountryByBandwidthEntry, CountryByBandwidthEntryFromRaw>))]
public sealed record class CountryByBandwidthEntry : JsonModel
{
    /// <summary>
    /// ISO country code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Country name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
    }

    public CountryByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryByBandwidthEntry(CountryByBandwidthEntry countryByBandwidthEntry)
        : base(countryByBandwidthEntry) { }
#pragma warning restore CS8618

    public CountryByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static CountryByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryByBandwidthEntryFromRaw : IFromRawJson<CountryByBandwidthEntry>
{
    /// <inheritdoc/>
    public CountryByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CountryByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CountryByRequest, CountryByRequestFromRaw>))]
public sealed record class CountryByRequest : JsonModel
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

    /// <summary>
    /// ISO country code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Country name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(CountryByRequest countryByRequest) =>
        new()
        {
            BandwidthBytes = countryByRequest.BandwidthBytes,
            RequestCount = countryByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Code;
        _ = this.Name;
    }

    public CountryByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryByRequest(CountryByRequest countryByRequest)
        : base(countryByRequest) { }
#pragma warning restore CS8618

    public CountryByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryByRequestFromRaw.FromRawUnchecked"/>
    public static CountryByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryByRequestFromRaw : IFromRawJson<CountryByRequest>
{
    /// <inheritdoc/>
    public CountryByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CountryByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CountryByRequestsEntry, CountryByRequestsEntryFromRaw>))]
public sealed record class CountryByRequestsEntry : JsonModel
{
    /// <summary>
    /// ISO country code.
    /// </summary>
    public required string Code
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("code");
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Country name.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Name;
    }

    public CountryByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryByRequestsEntry(CountryByRequestsEntry countryByRequestsEntry)
        : base(countryByRequestsEntry) { }
#pragma warning restore CS8618

    public CountryByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CountryByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static CountryByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CountryByRequestsEntryFromRaw : IFromRawJson<CountryByRequestsEntry>
{
    /// <inheritdoc/>
    public CountryByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CountryByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN traffic grouped by device and operating system (e.g. `Desktop - Apple Mac`,
/// `Smartphone - Apple iPhone`).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Device, DeviceFromRaw>))]
public sealed record class Device : JsonModel
{
    /// <summary>
    /// Top device/OS combinations sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<DeviceByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DeviceByBandwidth>>("byBandwidth");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeviceByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top device/OS combinations sorted by request count.
    /// </summary>
    public required IReadOnlyList<DeviceByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DeviceByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<DeviceByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public Device() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Device(Device device)
        : base(device) { }
#pragma warning restore CS8618

    public Device(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Device(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceFromRaw.FromRawUnchecked"/>
    public static Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceFromRaw : IFromRawJson<Device>
{
    /// <inheritdoc/>
    public Device FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Device.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeviceByBandwidth, DeviceByBandwidthFromRaw>))]
public sealed record class DeviceByBandwidth : JsonModel
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

    /// <summary>
    /// Device category combined with operating system or vendor (e.g. `Desktop -
    /// Windows PC`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(DeviceByBandwidth deviceByBandwidth) =>
        new()
        {
            BandwidthBytes = deviceByBandwidth.BandwidthBytes,
            RequestCount = deviceByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public DeviceByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceByBandwidth(DeviceByBandwidth deviceByBandwidth)
        : base(deviceByBandwidth) { }
#pragma warning restore CS8618

    public DeviceByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceByBandwidthFromRaw.FromRawUnchecked"/>
    public static DeviceByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceByBandwidthFromRaw : IFromRawJson<DeviceByBandwidth>
{
    /// <inheritdoc/>
    public DeviceByBandwidth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeviceByBandwidthEntry, DeviceByBandwidthEntryFromRaw>))]
public sealed record class DeviceByBandwidthEntry : JsonModel
{
    /// <summary>
    /// Device category combined with operating system or vendor (e.g. `Desktop -
    /// Windows PC`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public DeviceByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceByBandwidthEntry(DeviceByBandwidthEntry deviceByBandwidthEntry)
        : base(deviceByBandwidthEntry) { }
#pragma warning restore CS8618

    public DeviceByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static DeviceByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeviceByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class DeviceByBandwidthEntryFromRaw : IFromRawJson<DeviceByBandwidthEntry>
{
    /// <inheritdoc/>
    public DeviceByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeviceByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeviceByRequest, DeviceByRequestFromRaw>))]
public sealed record class DeviceByRequest : JsonModel
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

    /// <summary>
    /// Device category combined with operating system or vendor (e.g. `Desktop -
    /// Windows PC`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(DeviceByRequest deviceByRequest) =>
        new()
        {
            BandwidthBytes = deviceByRequest.BandwidthBytes,
            RequestCount = deviceByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public DeviceByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceByRequest(DeviceByRequest deviceByRequest)
        : base(deviceByRequest) { }
#pragma warning restore CS8618

    public DeviceByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceByRequestFromRaw.FromRawUnchecked"/>
    public static DeviceByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DeviceByRequestFromRaw : IFromRawJson<DeviceByRequest>
{
    /// <inheritdoc/>
    public DeviceByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DeviceByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DeviceByRequestsEntry, DeviceByRequestsEntryFromRaw>))]
public sealed record class DeviceByRequestsEntry : JsonModel
{
    /// <summary>
    /// Device category combined with operating system or vendor (e.g. `Desktop -
    /// Windows PC`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public DeviceByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DeviceByRequestsEntry(DeviceByRequestsEntry deviceByRequestsEntry)
        : base(deviceByRequestsEntry) { }
#pragma warning restore CS8618

    public DeviceByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DeviceByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DeviceByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static DeviceByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public DeviceByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class DeviceByRequestsEntryFromRaw : IFromRawJson<DeviceByRequestsEntry>
{
    /// <inheritdoc/>
    public DeviceByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DeviceByRequestsEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ErrorReason, ErrorReasonFromRaw>))]
public sealed record class ErrorReason : JsonModel
{
    /// <summary>
    /// Description of the error reason.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of requests that failed with this error reason.
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
        _ = this.Name;
        _ = this.RequestCount;
    }

    public ErrorReason() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ErrorReason(ErrorReason errorReason)
        : base(errorReason) { }
#pragma warning restore CS8618

    public ErrorReason(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ErrorReason(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorReasonFromRaw.FromRawUnchecked"/>
    public static ErrorReason FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ErrorReasonFromRaw : IFromRawJson<ErrorReason>
{
    /// <inheritdoc/>
    public ErrorReason FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ErrorReason.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Extension, ExtensionFromRaw>))]
public sealed record class Extension : JsonModel
{
    /// <summary>
    /// Extension identifier.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of times this extension ran during the date range.
    /// </summary>
    public required double OperationCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("operationCount");
        }
        init { this._rawData.Set("operationCount", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.OperationCount;
    }

    public Extension() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Extension(Extension extension)
        : base(extension) { }
#pragma warning restore CS8618

    public Extension(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Extension(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionFromRaw.FromRawUnchecked"/>
    public static Extension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExtensionFromRaw : IFromRawJson<Extension>
{
    /// <inheritdoc/>
    public Extension FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Extension.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN traffic grouped by response `Content-Type`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Format, FormatFromRaw>))]
public sealed record class Format : JsonModel
{
    /// <summary>
    /// Top content types sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<FormatByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormatByBandwidth>>("byBandwidth");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormatByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top content types sorted by request count.
    /// </summary>
    public required IReadOnlyList<FormatByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FormatByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FormatByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public Format() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Format(Format format)
        : base(format) { }
#pragma warning restore CS8618

    public Format(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Format(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormatFromRaw.FromRawUnchecked"/>
    public static Format FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormatFromRaw : IFromRawJson<Format>
{
    /// <inheritdoc/>
    public Format FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Format.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FormatByBandwidth, FormatByBandwidthFromRaw>))]
public sealed record class FormatByBandwidth : JsonModel
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

    /// <summary>
    /// MIME type (e.g. `image/webp`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(FormatByBandwidth formatByBandwidth) =>
        new()
        {
            BandwidthBytes = formatByBandwidth.BandwidthBytes,
            RequestCount = formatByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public FormatByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormatByBandwidth(FormatByBandwidth formatByBandwidth)
        : base(formatByBandwidth) { }
#pragma warning restore CS8618

    public FormatByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormatByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormatByBandwidthFromRaw.FromRawUnchecked"/>
    public static FormatByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormatByBandwidthFromRaw : IFromRawJson<FormatByBandwidth>
{
    /// <inheritdoc/>
    public FormatByBandwidth FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormatByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FormatByBandwidthEntry, FormatByBandwidthEntryFromRaw>))]
public sealed record class FormatByBandwidthEntry : JsonModel
{
    /// <summary>
    /// MIME type (e.g. `image/webp`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public FormatByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormatByBandwidthEntry(FormatByBandwidthEntry formatByBandwidthEntry)
        : base(formatByBandwidthEntry) { }
#pragma warning restore CS8618

    public FormatByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormatByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormatByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static FormatByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormatByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class FormatByBandwidthEntryFromRaw : IFromRawJson<FormatByBandwidthEntry>
{
    /// <inheritdoc/>
    public FormatByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormatByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FormatByRequest, FormatByRequestFromRaw>))]
public sealed record class FormatByRequest : JsonModel
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

    /// <summary>
    /// MIME type (e.g. `image/webp`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(FormatByRequest formatByRequest) =>
        new()
        {
            BandwidthBytes = formatByRequest.BandwidthBytes,
            RequestCount = formatByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public FormatByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormatByRequest(FormatByRequest formatByRequest)
        : base(formatByRequest) { }
#pragma warning restore CS8618

    public FormatByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormatByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormatByRequestFromRaw.FromRawUnchecked"/>
    public static FormatByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FormatByRequestFromRaw : IFromRawJson<FormatByRequest>
{
    /// <inheritdoc/>
    public FormatByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FormatByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FormatByRequestsEntry, FormatByRequestsEntryFromRaw>))]
public sealed record class FormatByRequestsEntry : JsonModel
{
    /// <summary>
    /// MIME type (e.g. `image/webp`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public FormatByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FormatByRequestsEntry(FormatByRequestsEntry formatByRequestsEntry)
        : base(formatByRequestsEntry) { }
#pragma warning restore CS8618

    public FormatByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FormatByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FormatByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static FormatByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FormatByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class FormatByRequestsEntryFromRaw : IFromRawJson<FormatByRequestsEntry>
{
    /// <inheritdoc/>
    public FormatByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FormatByRequestsEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<StatusCode, StatusCodeFromRaw>))]
public sealed record class StatusCode : JsonModel
{
    /// <summary>
    /// HTTP status code.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of requests that received this status code.
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
        _ = this.Name;
        _ = this.RequestCount;
    }

    public StatusCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public StatusCode(StatusCode statusCode)
        : base(statusCode) { }
#pragma warning restore CS8618

    public StatusCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    StatusCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="StatusCodeFromRaw.FromRawUnchecked"/>
    public static StatusCode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class StatusCodeFromRaw : IFromRawJson<StatusCode>
{
    /// <inheritdoc/>
    public StatusCode FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        StatusCode.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Top404Asset, Top404AssetFromRaw>))]
public sealed record class Top404Asset : JsonModel
{
    /// <summary>
    /// URL that returned a 404 response.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Number of requests to this URL that returned a 404 response.
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
        _ = this.Name;
        _ = this.RequestCount;
    }

    public Top404Asset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Top404Asset(Top404Asset top404Asset)
        : base(top404Asset) { }
#pragma warning restore CS8618

    public Top404Asset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Top404Asset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="Top404AssetFromRaw.FromRawUnchecked"/>
    public static Top404Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class Top404AssetFromRaw : IFromRawJson<Top404Asset>
{
    /// <inheritdoc/>
    public Top404Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Top404Asset.FromRawUnchecked(rawData);
}

/// <summary>
/// Top image assets by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopImages, TopImagesFromRaw>))]
public sealed record class TopImages : JsonModel
{
    /// <summary>
    /// Top image assets sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopImagesByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopImagesByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopImagesByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top image assets sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopImagesByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopImagesByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopImagesByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopImages() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImages(TopImages topImages)
        : base(topImages) { }
#pragma warning restore CS8618

    public TopImages(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImages(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImagesFromRaw.FromRawUnchecked"/>
    public static TopImages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImagesFromRaw : IFromRawJson<TopImages>
{
    /// <inheritdoc/>
    public TopImages FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopImages.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopImagesByBandwidth, TopImagesByBandwidthFromRaw>))]
public sealed record class TopImagesByBandwidth : JsonModel
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

    /// <summary>
    /// URL of the image asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopImagesByBandwidth topImagesByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topImagesByBandwidth.BandwidthBytes,
            RequestCount = topImagesByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopImagesByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImagesByBandwidth(TopImagesByBandwidth topImagesByBandwidth)
        : base(topImagesByBandwidth) { }
#pragma warning restore CS8618

    public TopImagesByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImagesByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImagesByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopImagesByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImagesByBandwidthFromRaw : IFromRawJson<TopImagesByBandwidth>
{
    /// <inheritdoc/>
    public TopImagesByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImagesByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopImagesByBandwidthEntry, TopImagesByBandwidthEntryFromRaw>)
)]
public sealed record class TopImagesByBandwidthEntry : JsonModel
{
    /// <summary>
    /// URL of the image asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopImagesByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImagesByBandwidthEntry(TopImagesByBandwidthEntry topImagesByBandwidthEntry)
        : base(topImagesByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopImagesByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImagesByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImagesByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopImagesByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopImagesByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopImagesByBandwidthEntryFromRaw : IFromRawJson<TopImagesByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopImagesByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImagesByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopImagesByRequest, TopImagesByRequestFromRaw>))]
public sealed record class TopImagesByRequest : JsonModel
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

    /// <summary>
    /// URL of the image asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(TopImagesByRequest topImagesByRequest) =>
        new()
        {
            BandwidthBytes = topImagesByRequest.BandwidthBytes,
            RequestCount = topImagesByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopImagesByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImagesByRequest(TopImagesByRequest topImagesByRequest)
        : base(topImagesByRequest) { }
#pragma warning restore CS8618

    public TopImagesByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImagesByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImagesByRequestFromRaw.FromRawUnchecked"/>
    public static TopImagesByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImagesByRequestFromRaw : IFromRawJson<TopImagesByRequest>
{
    /// <inheritdoc/>
    public TopImagesByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopImagesByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopImagesByRequestsEntry, TopImagesByRequestsEntryFromRaw>)
)]
public sealed record class TopImagesByRequestsEntry : JsonModel
{
    /// <summary>
    /// URL of the image asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopImagesByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImagesByRequestsEntry(TopImagesByRequestsEntry topImagesByRequestsEntry)
        : base(topImagesByRequestsEntry) { }
#pragma warning restore CS8618

    public TopImagesByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImagesByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImagesByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopImagesByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopImagesByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopImagesByRequestsEntryFromRaw : IFromRawJson<TopImagesByRequestsEntry>
{
    /// <inheritdoc/>
    public TopImagesByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImagesByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top image transformation strings by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopImageTransforms, TopImageTransformsFromRaw>))]
public sealed record class TopImageTransforms : JsonModel
{
    /// <summary>
    /// Top image transformation strings sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopImageTransformsByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopImageTransformsByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopImageTransformsByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top image transformation strings sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopImageTransformsByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopImageTransformsByRequest>>(
                "byRequests"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopImageTransformsByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopImageTransforms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImageTransforms(TopImageTransforms topImageTransforms)
        : base(topImageTransforms) { }
#pragma warning restore CS8618

    public TopImageTransforms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImageTransforms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImageTransformsFromRaw.FromRawUnchecked"/>
    public static TopImageTransforms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImageTransformsFromRaw : IFromRawJson<TopImageTransforms>
{
    /// <inheritdoc/>
    public TopImageTransforms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopImageTransforms.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopImageTransformsByBandwidth, TopImageTransformsByBandwidthFromRaw>)
)]
public sealed record class TopImageTransformsByBandwidth : JsonModel
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

    /// <summary>
    /// Image transformation string (e.g. `tr:w-400,h-400`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopImageTransformsByBandwidth topImageTransformsByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topImageTransformsByBandwidth.BandwidthBytes,
            RequestCount = topImageTransformsByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopImageTransformsByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImageTransformsByBandwidth(
        TopImageTransformsByBandwidth topImageTransformsByBandwidth
    )
        : base(topImageTransformsByBandwidth) { }
#pragma warning restore CS8618

    public TopImageTransformsByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImageTransformsByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImageTransformsByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopImageTransformsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImageTransformsByBandwidthFromRaw : IFromRawJson<TopImageTransformsByBandwidth>
{
    /// <inheritdoc/>
    public TopImageTransformsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImageTransformsByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TopImageTransformsByBandwidthEntry,
        TopImageTransformsByBandwidthEntryFromRaw
    >)
)]
public sealed record class TopImageTransformsByBandwidthEntry : JsonModel
{
    /// <summary>
    /// Image transformation string (e.g. `tr:w-400,h-400`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopImageTransformsByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImageTransformsByBandwidthEntry(
        TopImageTransformsByBandwidthEntry topImageTransformsByBandwidthEntry
    )
        : base(topImageTransformsByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopImageTransformsByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImageTransformsByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImageTransformsByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopImageTransformsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopImageTransformsByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopImageTransformsByBandwidthEntryFromRaw : IFromRawJson<TopImageTransformsByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopImageTransformsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImageTransformsByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopImageTransformsByRequest, TopImageTransformsByRequestFromRaw>)
)]
public sealed record class TopImageTransformsByRequest : JsonModel
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

    /// <summary>
    /// Image transformation string (e.g. `tr:w-400,h-400`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopImageTransformsByRequest topImageTransformsByRequest
    ) =>
        new()
        {
            BandwidthBytes = topImageTransformsByRequest.BandwidthBytes,
            RequestCount = topImageTransformsByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopImageTransformsByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImageTransformsByRequest(TopImageTransformsByRequest topImageTransformsByRequest)
        : base(topImageTransformsByRequest) { }
#pragma warning restore CS8618

    public TopImageTransformsByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImageTransformsByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImageTransformsByRequestFromRaw.FromRawUnchecked"/>
    public static TopImageTransformsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopImageTransformsByRequestFromRaw : IFromRawJson<TopImageTransformsByRequest>
{
    /// <inheritdoc/>
    public TopImageTransformsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImageTransformsByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TopImageTransformsByRequestsEntry,
        TopImageTransformsByRequestsEntryFromRaw
    >)
)]
public sealed record class TopImageTransformsByRequestsEntry : JsonModel
{
    /// <summary>
    /// Image transformation string (e.g. `tr:w-400,h-400`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopImageTransformsByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopImageTransformsByRequestsEntry(
        TopImageTransformsByRequestsEntry topImageTransformsByRequestsEntry
    )
        : base(topImageTransformsByRequestsEntry) { }
#pragma warning restore CS8618

    public TopImageTransformsByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopImageTransformsByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopImageTransformsByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopImageTransformsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopImageTransformsByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopImageTransformsByRequestsEntryFromRaw : IFromRawJson<TopImageTransformsByRequestsEntry>
{
    /// <inheritdoc/>
    public TopImageTransformsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopImageTransformsByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top non-image, non-video assets by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopOtherAssets, TopOtherAssetsFromRaw>))]
public sealed record class TopOtherAssets : JsonModel
{
    /// <summary>
    /// Top non-image, non-video assets sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopOtherAssetsByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopOtherAssetsByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopOtherAssetsByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top non-image, non-video assets sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopOtherAssetsByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopOtherAssetsByRequest>>(
                "byRequests"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopOtherAssetsByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopOtherAssets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopOtherAssets(TopOtherAssets topOtherAssets)
        : base(topOtherAssets) { }
#pragma warning restore CS8618

    public TopOtherAssets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopOtherAssets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopOtherAssetsFromRaw.FromRawUnchecked"/>
    public static TopOtherAssets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopOtherAssetsFromRaw : IFromRawJson<TopOtherAssets>
{
    /// <inheritdoc/>
    public TopOtherAssets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopOtherAssets.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopOtherAssetsByBandwidth, TopOtherAssetsByBandwidthFromRaw>)
)]
public sealed record class TopOtherAssetsByBandwidth : JsonModel
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

    /// <summary>
    /// URL of the non-image, non-video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopOtherAssetsByBandwidth topOtherAssetsByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topOtherAssetsByBandwidth.BandwidthBytes,
            RequestCount = topOtherAssetsByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopOtherAssetsByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopOtherAssetsByBandwidth(TopOtherAssetsByBandwidth topOtherAssetsByBandwidth)
        : base(topOtherAssetsByBandwidth) { }
#pragma warning restore CS8618

    public TopOtherAssetsByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopOtherAssetsByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopOtherAssetsByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopOtherAssetsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopOtherAssetsByBandwidthFromRaw : IFromRawJson<TopOtherAssetsByBandwidth>
{
    /// <inheritdoc/>
    public TopOtherAssetsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopOtherAssetsByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TopOtherAssetsByBandwidthEntry,
        TopOtherAssetsByBandwidthEntryFromRaw
    >)
)]
public sealed record class TopOtherAssetsByBandwidthEntry : JsonModel
{
    /// <summary>
    /// URL of the non-image, non-video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopOtherAssetsByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopOtherAssetsByBandwidthEntry(
        TopOtherAssetsByBandwidthEntry topOtherAssetsByBandwidthEntry
    )
        : base(topOtherAssetsByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopOtherAssetsByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopOtherAssetsByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopOtherAssetsByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopOtherAssetsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopOtherAssetsByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopOtherAssetsByBandwidthEntryFromRaw : IFromRawJson<TopOtherAssetsByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopOtherAssetsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopOtherAssetsByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopOtherAssetsByRequest, TopOtherAssetsByRequestFromRaw>))]
public sealed record class TopOtherAssetsByRequest : JsonModel
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

    /// <summary>
    /// URL of the non-image, non-video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopOtherAssetsByRequest topOtherAssetsByRequest
    ) =>
        new()
        {
            BandwidthBytes = topOtherAssetsByRequest.BandwidthBytes,
            RequestCount = topOtherAssetsByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopOtherAssetsByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopOtherAssetsByRequest(TopOtherAssetsByRequest topOtherAssetsByRequest)
        : base(topOtherAssetsByRequest) { }
#pragma warning restore CS8618

    public TopOtherAssetsByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopOtherAssetsByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopOtherAssetsByRequestFromRaw.FromRawUnchecked"/>
    public static TopOtherAssetsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopOtherAssetsByRequestFromRaw : IFromRawJson<TopOtherAssetsByRequest>
{
    /// <inheritdoc/>
    public TopOtherAssetsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopOtherAssetsByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopOtherAssetsByRequestsEntry, TopOtherAssetsByRequestsEntryFromRaw>)
)]
public sealed record class TopOtherAssetsByRequestsEntry : JsonModel
{
    /// <summary>
    /// URL of the non-image, non-video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopOtherAssetsByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopOtherAssetsByRequestsEntry(
        TopOtherAssetsByRequestsEntry topOtherAssetsByRequestsEntry
    )
        : base(topOtherAssetsByRequestsEntry) { }
#pragma warning restore CS8618

    public TopOtherAssetsByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopOtherAssetsByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopOtherAssetsByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopOtherAssetsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopOtherAssetsByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopOtherAssetsByRequestsEntryFromRaw : IFromRawJson<TopOtherAssetsByRequestsEntry>
{
    /// <inheritdoc/>
    public TopOtherAssetsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopOtherAssetsByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top HTTP referrers by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopReferrers, TopReferrersFromRaw>))]
public sealed record class TopReferrers : JsonModel
{
    /// <summary>
    /// Top HTTP referrers sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopReferrersByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopReferrersByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopReferrersByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top HTTP referrers sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopReferrersByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopReferrersByRequest>>(
                "byRequests"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopReferrersByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopReferrers() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopReferrers(TopReferrers topReferrers)
        : base(topReferrers) { }
#pragma warning restore CS8618

    public TopReferrers(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopReferrers(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopReferrersFromRaw.FromRawUnchecked"/>
    public static TopReferrers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopReferrersFromRaw : IFromRawJson<TopReferrers>
{
    /// <inheritdoc/>
    public TopReferrers FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopReferrers.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopReferrersByBandwidth, TopReferrersByBandwidthFromRaw>))]
public sealed record class TopReferrersByBandwidth : JsonModel
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

    /// <summary>
    /// Referrer URL.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopReferrersByBandwidth topReferrersByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topReferrersByBandwidth.BandwidthBytes,
            RequestCount = topReferrersByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopReferrersByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopReferrersByBandwidth(TopReferrersByBandwidth topReferrersByBandwidth)
        : base(topReferrersByBandwidth) { }
#pragma warning restore CS8618

    public TopReferrersByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopReferrersByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopReferrersByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopReferrersByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopReferrersByBandwidthFromRaw : IFromRawJson<TopReferrersByBandwidth>
{
    /// <inheritdoc/>
    public TopReferrersByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopReferrersByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopReferrersByBandwidthEntry, TopReferrersByBandwidthEntryFromRaw>)
)]
public sealed record class TopReferrersByBandwidthEntry : JsonModel
{
    /// <summary>
    /// Referrer URL.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopReferrersByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopReferrersByBandwidthEntry(TopReferrersByBandwidthEntry topReferrersByBandwidthEntry)
        : base(topReferrersByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopReferrersByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopReferrersByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopReferrersByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopReferrersByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopReferrersByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopReferrersByBandwidthEntryFromRaw : IFromRawJson<TopReferrersByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopReferrersByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopReferrersByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopReferrersByRequest, TopReferrersByRequestFromRaw>))]
public sealed record class TopReferrersByRequest : JsonModel
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

    /// <summary>
    /// Referrer URL.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopReferrersByRequest topReferrersByRequest
    ) =>
        new()
        {
            BandwidthBytes = topReferrersByRequest.BandwidthBytes,
            RequestCount = topReferrersByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopReferrersByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopReferrersByRequest(TopReferrersByRequest topReferrersByRequest)
        : base(topReferrersByRequest) { }
#pragma warning restore CS8618

    public TopReferrersByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopReferrersByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopReferrersByRequestFromRaw.FromRawUnchecked"/>
    public static TopReferrersByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopReferrersByRequestFromRaw : IFromRawJson<TopReferrersByRequest>
{
    /// <inheritdoc/>
    public TopReferrersByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopReferrersByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopReferrersByRequestsEntry, TopReferrersByRequestsEntryFromRaw>)
)]
public sealed record class TopReferrersByRequestsEntry : JsonModel
{
    /// <summary>
    /// Referrer URL.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopReferrersByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopReferrersByRequestsEntry(TopReferrersByRequestsEntry topReferrersByRequestsEntry)
        : base(topReferrersByRequestsEntry) { }
#pragma warning restore CS8618

    public TopReferrersByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopReferrersByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopReferrersByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopReferrersByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopReferrersByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopReferrersByRequestsEntryFromRaw : IFromRawJson<TopReferrersByRequestsEntry>
{
    /// <inheritdoc/>
    public TopReferrersByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopReferrersByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top user agents by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopUserAgents, TopUserAgentsFromRaw>))]
public sealed record class TopUserAgents : JsonModel
{
    /// <summary>
    /// Top user agents sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopUserAgentsByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopUserAgentsByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopUserAgentsByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top user agents sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopUserAgentsByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopUserAgentsByRequest>>(
                "byRequests"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopUserAgentsByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopUserAgents() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUserAgents(TopUserAgents topUserAgents)
        : base(topUserAgents) { }
#pragma warning restore CS8618

    public TopUserAgents(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUserAgents(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUserAgentsFromRaw.FromRawUnchecked"/>
    public static TopUserAgents FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUserAgentsFromRaw : IFromRawJson<TopUserAgents>
{
    /// <inheritdoc/>
    public TopUserAgents FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopUserAgents.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopUserAgentsByBandwidth, TopUserAgentsByBandwidthFromRaw>)
)]
public sealed record class TopUserAgentsByBandwidth : JsonModel
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

    /// <summary>
    /// User agent string.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopUserAgentsByBandwidth topUserAgentsByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topUserAgentsByBandwidth.BandwidthBytes,
            RequestCount = topUserAgentsByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopUserAgentsByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUserAgentsByBandwidth(TopUserAgentsByBandwidth topUserAgentsByBandwidth)
        : base(topUserAgentsByBandwidth) { }
#pragma warning restore CS8618

    public TopUserAgentsByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUserAgentsByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUserAgentsByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopUserAgentsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUserAgentsByBandwidthFromRaw : IFromRawJson<TopUserAgentsByBandwidth>
{
    /// <inheritdoc/>
    public TopUserAgentsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUserAgentsByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopUserAgentsByBandwidthEntry, TopUserAgentsByBandwidthEntryFromRaw>)
)]
public sealed record class TopUserAgentsByBandwidthEntry : JsonModel
{
    /// <summary>
    /// User agent string.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopUserAgentsByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUserAgentsByBandwidthEntry(
        TopUserAgentsByBandwidthEntry topUserAgentsByBandwidthEntry
    )
        : base(topUserAgentsByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopUserAgentsByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUserAgentsByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUserAgentsByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopUserAgentsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopUserAgentsByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopUserAgentsByBandwidthEntryFromRaw : IFromRawJson<TopUserAgentsByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopUserAgentsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUserAgentsByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopUserAgentsByRequest, TopUserAgentsByRequestFromRaw>))]
public sealed record class TopUserAgentsByRequest : JsonModel
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

    /// <summary>
    /// User agent string.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopUserAgentsByRequest topUserAgentsByRequest
    ) =>
        new()
        {
            BandwidthBytes = topUserAgentsByRequest.BandwidthBytes,
            RequestCount = topUserAgentsByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopUserAgentsByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUserAgentsByRequest(TopUserAgentsByRequest topUserAgentsByRequest)
        : base(topUserAgentsByRequest) { }
#pragma warning restore CS8618

    public TopUserAgentsByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUserAgentsByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUserAgentsByRequestFromRaw.FromRawUnchecked"/>
    public static TopUserAgentsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopUserAgentsByRequestFromRaw : IFromRawJson<TopUserAgentsByRequest>
{
    /// <inheritdoc/>
    public TopUserAgentsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUserAgentsByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopUserAgentsByRequestsEntry, TopUserAgentsByRequestsEntryFromRaw>)
)]
public sealed record class TopUserAgentsByRequestsEntry : JsonModel
{
    /// <summary>
    /// User agent string.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopUserAgentsByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopUserAgentsByRequestsEntry(TopUserAgentsByRequestsEntry topUserAgentsByRequestsEntry)
        : base(topUserAgentsByRequestsEntry) { }
#pragma warning restore CS8618

    public TopUserAgentsByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopUserAgentsByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopUserAgentsByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopUserAgentsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopUserAgentsByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopUserAgentsByRequestsEntryFromRaw : IFromRawJson<TopUserAgentsByRequestsEntry>
{
    /// <inheritdoc/>
    public TopUserAgentsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopUserAgentsByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top video assets by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopVideos, TopVideosFromRaw>))]
public sealed record class TopVideos : JsonModel
{
    /// <summary>
    /// Top video assets sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopVideosByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopVideosByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopVideosByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top video assets sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopVideosByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopVideosByRequest>>("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopVideosByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopVideos() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideos(TopVideos topVideos)
        : base(topVideos) { }
#pragma warning restore CS8618

    public TopVideos(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideos(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideosFromRaw.FromRawUnchecked"/>
    public static TopVideos FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideosFromRaw : IFromRawJson<TopVideos>
{
    /// <inheritdoc/>
    public TopVideos FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopVideos.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopVideosByBandwidth, TopVideosByBandwidthFromRaw>))]
public sealed record class TopVideosByBandwidth : JsonModel
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

    /// <summary>
    /// URL of the video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopVideosByBandwidth topVideosByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topVideosByBandwidth.BandwidthBytes,
            RequestCount = topVideosByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopVideosByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideosByBandwidth(TopVideosByBandwidth topVideosByBandwidth)
        : base(topVideosByBandwidth) { }
#pragma warning restore CS8618

    public TopVideosByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideosByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideosByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopVideosByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideosByBandwidthFromRaw : IFromRawJson<TopVideosByBandwidth>
{
    /// <inheritdoc/>
    public TopVideosByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideosByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopVideosByBandwidthEntry, TopVideosByBandwidthEntryFromRaw>)
)]
public sealed record class TopVideosByBandwidthEntry : JsonModel
{
    /// <summary>
    /// URL of the video asset.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopVideosByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideosByBandwidthEntry(TopVideosByBandwidthEntry topVideosByBandwidthEntry)
        : base(topVideosByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopVideosByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideosByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideosByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopVideosByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopVideosByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopVideosByBandwidthEntryFromRaw : IFromRawJson<TopVideosByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopVideosByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideosByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TopVideosByRequest, TopVideosByRequestFromRaw>))]
public sealed record class TopVideosByRequest : JsonModel
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

    /// <summary>
    /// Full URL of the video asset (e.g. `https://ik.imagekit.io/demo/clip.mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(TopVideosByRequest topVideosByRequest) =>
        new()
        {
            BandwidthBytes = topVideosByRequest.BandwidthBytes,
            RequestCount = topVideosByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopVideosByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideosByRequest(TopVideosByRequest topVideosByRequest)
        : base(topVideosByRequest) { }
#pragma warning restore CS8618

    public TopVideosByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideosByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideosByRequestFromRaw.FromRawUnchecked"/>
    public static TopVideosByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideosByRequestFromRaw : IFromRawJson<TopVideosByRequest>
{
    /// <inheritdoc/>
    public TopVideosByRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopVideosByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopVideosByRequestsEntry, TopVideosByRequestsEntryFromRaw>)
)]
public sealed record class TopVideosByRequestsEntry : JsonModel
{
    /// <summary>
    /// Full URL of the video asset (e.g. `https://ik.imagekit.io/demo/clip.mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopVideosByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideosByRequestsEntry(TopVideosByRequestsEntry topVideosByRequestsEntry)
        : base(topVideosByRequestsEntry) { }
#pragma warning restore CS8618

    public TopVideosByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideosByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideosByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopVideosByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopVideosByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopVideosByRequestsEntryFromRaw : IFromRawJson<TopVideosByRequestsEntry>
{
    /// <inheritdoc/>
    public TopVideosByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideosByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// Top video transformation strings by traffic.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TopVideoTransforms, TopVideoTransformsFromRaw>))]
public sealed record class TopVideoTransforms : JsonModel
{
    /// <summary>
    /// Top video transformation strings sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<TopVideoTransformsByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopVideoTransformsByBandwidth>>(
                "byBandwidth"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopVideoTransformsByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top video transformation strings sorted by request count.
    /// </summary>
    public required IReadOnlyList<TopVideoTransformsByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TopVideoTransformsByRequest>>(
                "byRequests"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TopVideoTransformsByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public TopVideoTransforms() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideoTransforms(TopVideoTransforms topVideoTransforms)
        : base(topVideoTransforms) { }
#pragma warning restore CS8618

    public TopVideoTransforms(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideoTransforms(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideoTransformsFromRaw.FromRawUnchecked"/>
    public static TopVideoTransforms FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideoTransformsFromRaw : IFromRawJson<TopVideoTransforms>
{
    /// <inheritdoc/>
    public TopVideoTransforms FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TopVideoTransforms.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopVideoTransformsByBandwidth, TopVideoTransformsByBandwidthFromRaw>)
)]
public sealed record class TopVideoTransformsByBandwidth : JsonModel
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

    /// <summary>
    /// Video transformation string (e.g. `tr:h-720,f-mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopVideoTransformsByBandwidth topVideoTransformsByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = topVideoTransformsByBandwidth.BandwidthBytes,
            RequestCount = topVideoTransformsByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopVideoTransformsByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideoTransformsByBandwidth(
        TopVideoTransformsByBandwidth topVideoTransformsByBandwidth
    )
        : base(topVideoTransformsByBandwidth) { }
#pragma warning restore CS8618

    public TopVideoTransformsByBandwidth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideoTransformsByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideoTransformsByBandwidthFromRaw.FromRawUnchecked"/>
    public static TopVideoTransformsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideoTransformsByBandwidthFromRaw : IFromRawJson<TopVideoTransformsByBandwidth>
{
    /// <inheritdoc/>
    public TopVideoTransformsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideoTransformsByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TopVideoTransformsByBandwidthEntry,
        TopVideoTransformsByBandwidthEntryFromRaw
    >)
)]
public sealed record class TopVideoTransformsByBandwidthEntry : JsonModel
{
    /// <summary>
    /// Video transformation string (e.g. `tr:h-720,f-mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopVideoTransformsByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideoTransformsByBandwidthEntry(
        TopVideoTransformsByBandwidthEntry topVideoTransformsByBandwidthEntry
    )
        : base(topVideoTransformsByBandwidthEntry) { }
#pragma warning restore CS8618

    public TopVideoTransformsByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideoTransformsByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideoTransformsByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static TopVideoTransformsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopVideoTransformsByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopVideoTransformsByBandwidthEntryFromRaw : IFromRawJson<TopVideoTransformsByBandwidthEntry>
{
    /// <inheritdoc/>
    public TopVideoTransformsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideoTransformsByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<TopVideoTransformsByRequest, TopVideoTransformsByRequestFromRaw>)
)]
public sealed record class TopVideoTransformsByRequest : JsonModel
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

    /// <summary>
    /// Video transformation string (e.g. `tr:h-720,f-mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        TopVideoTransformsByRequest topVideoTransformsByRequest
    ) =>
        new()
        {
            BandwidthBytes = topVideoTransformsByRequest.BandwidthBytes,
            RequestCount = topVideoTransformsByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public TopVideoTransformsByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideoTransformsByRequest(TopVideoTransformsByRequest topVideoTransformsByRequest)
        : base(topVideoTransformsByRequest) { }
#pragma warning restore CS8618

    public TopVideoTransformsByRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideoTransformsByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideoTransformsByRequestFromRaw.FromRawUnchecked"/>
    public static TopVideoTransformsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopVideoTransformsByRequestFromRaw : IFromRawJson<TopVideoTransformsByRequest>
{
    /// <inheritdoc/>
    public TopVideoTransformsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideoTransformsByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        TopVideoTransformsByRequestsEntry,
        TopVideoTransformsByRequestsEntryFromRaw
    >)
)]
public sealed record class TopVideoTransformsByRequestsEntry : JsonModel
{
    /// <summary>
    /// Video transformation string (e.g. `tr:h-720,f-mp4`).
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public TopVideoTransformsByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TopVideoTransformsByRequestsEntry(
        TopVideoTransformsByRequestsEntry topVideoTransformsByRequestsEntry
    )
        : base(topVideoTransformsByRequestsEntry) { }
#pragma warning restore CS8618

    public TopVideoTransformsByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopVideoTransformsByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopVideoTransformsByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static TopVideoTransformsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TopVideoTransformsByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class TopVideoTransformsByRequestsEntryFromRaw : IFromRawJson<TopVideoTransformsByRequestsEntry>
{
    /// <inheritdoc/>
    public TopVideoTransformsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopVideoTransformsByRequestsEntry.FromRawUnchecked(rawData);
}

/// <summary>
/// CDN traffic grouped by configured URL endpoint. Traffic that does not match any
/// named URL endpoint pattern is grouped under `Default`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UsageAnalyticsResponseUrlEndpoints,
        UsageAnalyticsResponseUrlEndpointsFromRaw
    >)
)]
public sealed record class UsageAnalyticsResponseUrlEndpoints : JsonModel
{
    /// <summary>
    /// Top URL endpoints sorted by bandwidth utilized.
    /// </summary>
    public required IReadOnlyList<UsageAnalyticsResponseUrlEndpointsByBandwidth> ByBandwidth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<UsageAnalyticsResponseUrlEndpointsByBandwidth>
            >("byBandwidth");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageAnalyticsResponseUrlEndpointsByBandwidth>>(
                "byBandwidth",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Top URL endpoints sorted by request count.
    /// </summary>
    public required IReadOnlyList<UsageAnalyticsResponseUrlEndpointsByRequest> ByRequests
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<UsageAnalyticsResponseUrlEndpointsByRequest>
            >("byRequests");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UsageAnalyticsResponseUrlEndpointsByRequest>>(
                "byRequests",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ByBandwidth)
        {
            item.Validate();
        }
        foreach (var item in this.ByRequests)
        {
            item.Validate();
        }
    }

    public UsageAnalyticsResponseUrlEndpoints() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsResponseUrlEndpoints(
        UsageAnalyticsResponseUrlEndpoints usageAnalyticsResponseUrlEndpoints
    )
        : base(usageAnalyticsResponseUrlEndpoints) { }
#pragma warning restore CS8618

    public UsageAnalyticsResponseUrlEndpoints(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsResponseUrlEndpoints(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageAnalyticsResponseUrlEndpointsFromRaw.FromRawUnchecked"/>
    public static UsageAnalyticsResponseUrlEndpoints FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageAnalyticsResponseUrlEndpointsFromRaw : IFromRawJson<UsageAnalyticsResponseUrlEndpoints>
{
    /// <inheritdoc/>
    public UsageAnalyticsResponseUrlEndpoints FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageAnalyticsResponseUrlEndpoints.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UsageAnalyticsResponseUrlEndpointsByBandwidth,
        UsageAnalyticsResponseUrlEndpointsByBandwidthFromRaw
    >)
)]
public sealed record class UsageAnalyticsResponseUrlEndpointsByBandwidth : JsonModel
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

    /// <summary>
    /// URL endpoint name, or `Default` for traffic that does not match a named endpoint.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        UsageAnalyticsResponseUrlEndpointsByBandwidth usageAnalyticsResponseUrlEndpointsByBandwidth
    ) =>
        new()
        {
            BandwidthBytes = usageAnalyticsResponseUrlEndpointsByBandwidth.BandwidthBytes,
            RequestCount = usageAnalyticsResponseUrlEndpointsByBandwidth.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public UsageAnalyticsResponseUrlEndpointsByBandwidth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsResponseUrlEndpointsByBandwidth(
        UsageAnalyticsResponseUrlEndpointsByBandwidth usageAnalyticsResponseUrlEndpointsByBandwidth
    )
        : base(usageAnalyticsResponseUrlEndpointsByBandwidth) { }
#pragma warning restore CS8618

    public UsageAnalyticsResponseUrlEndpointsByBandwidth(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsResponseUrlEndpointsByBandwidth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageAnalyticsResponseUrlEndpointsByBandwidthFromRaw.FromRawUnchecked"/>
    public static UsageAnalyticsResponseUrlEndpointsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageAnalyticsResponseUrlEndpointsByBandwidthFromRaw
    : IFromRawJson<UsageAnalyticsResponseUrlEndpointsByBandwidth>
{
    /// <inheritdoc/>
    public UsageAnalyticsResponseUrlEndpointsByBandwidth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageAnalyticsResponseUrlEndpointsByBandwidth.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UrlEndpointsByBandwidthEntry, UrlEndpointsByBandwidthEntryFromRaw>)
)]
public sealed record class UrlEndpointsByBandwidthEntry : JsonModel
{
    /// <summary>
    /// URL endpoint name, or `Default` for traffic that does not match a named endpoint.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public UrlEndpointsByBandwidthEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointsByBandwidthEntry(UrlEndpointsByBandwidthEntry urlEndpointsByBandwidthEntry)
        : base(urlEndpointsByBandwidthEntry) { }
#pragma warning restore CS8618

    public UrlEndpointsByBandwidthEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointsByBandwidthEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEndpointsByBandwidthEntryFromRaw.FromRawUnchecked"/>
    public static UrlEndpointsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlEndpointsByBandwidthEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class UrlEndpointsByBandwidthEntryFromRaw : IFromRawJson<UrlEndpointsByBandwidthEntry>
{
    /// <inheritdoc/>
    public UrlEndpointsByBandwidthEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlEndpointsByBandwidthEntry.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UsageAnalyticsResponseUrlEndpointsByRequest,
        UsageAnalyticsResponseUrlEndpointsByRequestFromRaw
    >)
)]
public sealed record class UsageAnalyticsResponseUrlEndpointsByRequest : JsonModel
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

    /// <summary>
    /// URL endpoint name, or `Default` for traffic that does not match a named endpoint.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public static implicit operator RequestBandwidthEntry(
        UsageAnalyticsResponseUrlEndpointsByRequest usageAnalyticsResponseUrlEndpointsByRequest
    ) =>
        new()
        {
            BandwidthBytes = usageAnalyticsResponseUrlEndpointsByRequest.BandwidthBytes,
            RequestCount = usageAnalyticsResponseUrlEndpointsByRequest.RequestCount,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BandwidthBytes;
        _ = this.RequestCount;
        _ = this.Name;
    }

    public UsageAnalyticsResponseUrlEndpointsByRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsResponseUrlEndpointsByRequest(
        UsageAnalyticsResponseUrlEndpointsByRequest usageAnalyticsResponseUrlEndpointsByRequest
    )
        : base(usageAnalyticsResponseUrlEndpointsByRequest) { }
#pragma warning restore CS8618

    public UsageAnalyticsResponseUrlEndpointsByRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsResponseUrlEndpointsByRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UsageAnalyticsResponseUrlEndpointsByRequestFromRaw.FromRawUnchecked"/>
    public static UsageAnalyticsResponseUrlEndpointsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UsageAnalyticsResponseUrlEndpointsByRequestFromRaw
    : IFromRawJson<UsageAnalyticsResponseUrlEndpointsByRequest>
{
    /// <inheritdoc/>
    public UsageAnalyticsResponseUrlEndpointsByRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UsageAnalyticsResponseUrlEndpointsByRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<UrlEndpointsByRequestsEntry, UrlEndpointsByRequestsEntryFromRaw>)
)]
public sealed record class UrlEndpointsByRequestsEntry : JsonModel
{
    /// <summary>
    /// URL endpoint name, or `Default` for traffic that does not match a named endpoint.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public UrlEndpointsByRequestsEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointsByRequestsEntry(UrlEndpointsByRequestsEntry urlEndpointsByRequestsEntry)
        : base(urlEndpointsByRequestsEntry) { }
#pragma warning restore CS8618

    public UrlEndpointsByRequestsEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointsByRequestsEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEndpointsByRequestsEntryFromRaw.FromRawUnchecked"/>
    public static UrlEndpointsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlEndpointsByRequestsEntry(string name)
        : this()
    {
        this.Name = name;
    }
}

class UrlEndpointsByRequestsEntryFromRaw : IFromRawJson<UrlEndpointsByRequestsEntry>
{
    /// <inheritdoc/>
    public UrlEndpointsByRequestsEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlEndpointsByRequestsEntry.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<VideoProcessing, VideoProcessingFromRaw>))]
public sealed record class VideoProcessing : JsonModel
{
    /// <summary>
    /// Video codec used for the output (e.g. `h264`, `av1`).
    /// </summary>
    public required string Codec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("codec");
        }
        init { this._rawData.Set("codec", value); }
    }

    /// <summary>
    /// Total output duration, in seconds, for this resolution and codec combination.
    /// </summary>
    public required double DurationSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("durationSeconds");
        }
        init { this._rawData.Set("durationSeconds", value); }
    }

    /// <summary>
    /// Output resolution tier (e.g. `SD`, `HD`, `4K`).
    /// </summary>
    public required string Resolution
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("resolution");
        }
        init { this._rawData.Set("resolution", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Codec;
        _ = this.DurationSeconds;
        _ = this.Resolution;
    }

    public VideoProcessing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VideoProcessing(VideoProcessing videoProcessing)
        : base(videoProcessing) { }
#pragma warning restore CS8618

    public VideoProcessing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VideoProcessing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VideoProcessingFromRaw.FromRawUnchecked"/>
    public static VideoProcessing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VideoProcessingFromRaw : IFromRawJson<VideoProcessing>
{
    /// <inheritdoc/>
    public VideoProcessing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        VideoProcessing.FromRawUnchecked(rawData);
}
