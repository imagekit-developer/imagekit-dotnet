using System;
using System.Net.Http;

namespace Imagekit.Models.Files.Versions;

/// <summary>
/// This API returns an object with details or attributes of a file version.
/// </summary>
public sealed record class VersionGetParams : ParamsBase
{
    public required string FileID;

    public required string VersionID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/{0}/versions/{1}", this.FileID, this.VersionID)
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
