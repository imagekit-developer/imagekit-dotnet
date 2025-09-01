using System;
using System.Net.Http;

namespace Imagekit.Models.Files.Versions;

/// <summary>
/// This API deletes a non-current file version permanently. The API returns an empty response.
///
/// Note: If you want to delete all versions of a file, use the delete file API.
/// </summary>
public sealed record class VersionDeleteParams : ParamsBase
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
