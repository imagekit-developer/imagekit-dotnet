using System;
using System.Net.Http;
using System.Text.Json;

namespace Imagekit.Models.Accounts.Usage;

/// <summary>
/// Get the account usage information between two dates. Note that the API response
/// includes data from the start date while excluding data from the end date. In
/// other words, the data covers the period starting from the specified start date
/// up to, but not including, the end date.
/// </summary>
public sealed record class UsageGetParams : ParamsBase
{
    /// <summary>
    /// Specify a `endDate` in `YYYY-MM-DD` format. It should be after the `startDate`.
    /// The difference between `startDate` and `endDate` should be less than 90 days.
    /// </summary>
    public required DateOnly EndDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("endDate", out JsonElement element))
                throw new ArgumentOutOfRangeException("endDate", "Missing required argument");

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["endDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Specify a `startDate` in `YYYY-MM-DD` format. It should be before the `endDate`.
    /// The difference between `startDate` and `endDate` should be less than 90 days.
    /// </summary>
    public required DateOnly StartDate
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("startDate", out JsonElement element))
                throw new ArgumentOutOfRangeException("startDate", "Missing required argument");

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["startDate"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/accounts/usage")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IImageKitClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
