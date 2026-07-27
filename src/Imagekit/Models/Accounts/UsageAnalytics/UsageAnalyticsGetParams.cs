using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Imagekit.Core;

namespace Imagekit.Models.Accounts.UsageAnalytics;

/// <summary>
/// **Note:** This API is currently in beta.
///
/// <para>Get the account analytics data between two dates. The response covers the
/// period from the start date to the end date, both dates inclusive. Both dates
/// are interpreted as UTC calendar days.</para>
///
/// <para>The returned data is scoped to the requesting account only. Unlike `/v1/accounts/usage`,
/// an agency account's analytics are not aggregated across its child accounts.</para>
///
/// <para>The response is cached for 5 minutes per account and date range. Use `generatedAt`
/// to check how fresh the returned data is.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UsageAnalyticsGetParams : ParamsBase
{
    /// <summary>
    /// Specify an `endDate` in `YYYY-MM-DD` format, interpreted as a UTC calendar
    /// day. It should be after the `startDate`. The difference between `startDate`
    /// and `endDate` should be less than 90 days.
    /// </summary>
    public required string EndDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("endDate");
        }
        init { this._rawQueryData.Set("endDate", value); }
    }

    /// <summary>
    /// Specify a `startDate` in `YYYY-MM-DD` format, interpreted as a UTC calendar
    /// day. It should be before the `endDate`. The difference between `startDate`
    /// and `endDate` should be less than 90 days.
    /// </summary>
    public required string StartDate
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<string>("startDate");
        }
        init { this._rawQueryData.Set("startDate", value); }
    }

    public UsageAnalyticsGetParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageAnalyticsGetParams(UsageAnalyticsGetParams usageAnalyticsGetParams)
        : base(usageAnalyticsGetParams) { }
#pragma warning restore CS8618

    public UsageAnalyticsGetParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageAnalyticsGetParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UsageAnalyticsGetParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UsageAnalyticsGetParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/accounts/usage-analytics"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
