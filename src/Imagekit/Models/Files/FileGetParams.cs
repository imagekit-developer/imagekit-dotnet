using System;
using System.Net.Http;

namespace Imagekit.Models.Files;

/// <summary>
/// This API returns an object with details or attributes about the current version
/// of the file.
/// </summary>
public sealed record class FileGetParams : ParamsBase
{
    public required string FileID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/{0}/details", this.FileID)
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
