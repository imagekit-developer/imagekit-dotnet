using System;
using System.Net.Http;

namespace Imagekit.Models.Accounts.URLEndpoints;

/// <summary>
/// **Note:** This API is currently in beta.   Retrieves the URL‑endpoint identified
/// by `id`.
/// </summary>
public sealed record class URLEndpointGetParams : ParamsBase
{
    public required string ID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/url-endpoints/{0}", this.ID)
        )
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
