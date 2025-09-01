using System;
using System.Net.Http;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// **Note:** This API is currently in beta.   Permanently removes the origin identified
/// by `id`. If the origin is in use by any URL‑endpoints, the API will return an
/// error.
/// </summary>
public sealed record class OriginDeleteParams : ParamsBase
{
    public required string ID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/origins/{0}", this.ID)
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
