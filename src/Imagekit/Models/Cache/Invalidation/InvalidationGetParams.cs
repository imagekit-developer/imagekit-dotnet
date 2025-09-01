using System;
using System.Net.Http;

namespace Imagekit.Models.Cache.Invalidation;

/// <summary>
/// This API returns the status of a purge cache request.
/// </summary>
public sealed record class InvalidationGetParams : ParamsBase
{
    public required string RequestID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/purge/{0}", this.RequestID)
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
