using System;
using System.Net.Http;

namespace Imagekit.Models.Files.Metadata;

/// <summary>
/// You can programmatically get image EXIF, pHash, and other metadata for uploaded
/// files in the ImageKit.io media library using this API.
///
/// You can also get the metadata in upload API response by passing `metadata` in
/// `responseFields` parameter.
/// </summary>
public sealed record class MetadataGetParams : ParamsBase
{
    public required string FileID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/{0}/metadata", this.FileID)
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
