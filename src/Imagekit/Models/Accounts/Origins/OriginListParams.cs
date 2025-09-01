using System;
using System.Net.Http;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// **Note:** This API is currently in beta.   Returns an array of all configured
/// origins for the current account.
/// </summary>
public sealed record class OriginListParams : ParamsBase
{
    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/accounts/origins")
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
