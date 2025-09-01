using System;
using System.Net.Http;
using System.Text.Json;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// This API returns the array of created custom metadata field objects. By default
/// the API returns only non deleted field objects, but you can include deleted fields
/// in the API response.
/// </summary>
public sealed record class CustomMetadataFieldListParams : ParamsBase
{
    /// <summary>
    /// Set it to `true` to include deleted field objects in the API response.
    /// </summary>
    public bool? IncludeDeleted
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("includeDeleted", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["includeDeleted"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/customMetadataFields")
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
