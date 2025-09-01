using System;
using System.Net.Http;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// This API deletes a custom metadata field. Even after deleting a custom metadata
/// field, you cannot create any new custom metadata field with the same name.
/// </summary>
public sealed record class CustomMetadataFieldDeleteParams : ParamsBase
{
    public required string ID;

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/customMetadataFields/{0}", this.ID)
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
