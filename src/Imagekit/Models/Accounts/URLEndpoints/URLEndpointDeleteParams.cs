using System;
using System.Net.Http;

namespace Imagekit.Models.Accounts.URLEndpoints;

/// <summary>
/// **Note:** This API is currently in beta.   Deletes the URL‑endpoint identified
/// by `id`. You cannot delete the default URL‑endpoint created by ImageKit during
/// account creation.
/// </summary>
public sealed record class URLEndpointDeleteParams : ParamsBase
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
