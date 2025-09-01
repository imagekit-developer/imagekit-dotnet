using System;
using System.Net.Http;

namespace Imagekit.Models.Files;

/// <summary>
/// This API deletes the file and all its file versions permanently.
///
/// Note: If a file or specific transformation has been requested in the past, then
/// the response is cached. Deleting a file does not purge the cache. You can purge
/// the cache using purge cache API.
/// </summary>
public sealed record class FileDeleteParams : ParamsBase
{
    public required string FileID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + string.Format("/v1/files/{0}", this.FileID)
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
