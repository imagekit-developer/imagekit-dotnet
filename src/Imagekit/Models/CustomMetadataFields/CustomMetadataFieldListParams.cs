using System;
using System.Net.Http;
using System.Text.Json;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// This API returns the array of created custom metadata field objects. By default
/// the API returns only non deleted field objects, but you can include deleted fields
/// in the API response.
///
/// You can also filter results by a specific folder path to retrieve custom metadata
/// fields applicable at that location. This path-specific filtering is useful when
/// using the **Path policy** feature to determine which custom metadata fields are
/// selected for a given path.
/// </summary>
public sealed record class CustomMetadataFieldListParams : ParamsBase
{
    /// <summary>
    /// The folder path (e.g., `/path/to/folder`) for which to retrieve applicable
    /// custom metadata fields. Useful for determining path-specific field selections
    /// when the [Path policy](https://imagekit.io/docs/dam/path-policy) feature is
    /// in use.
    /// </summary>
    public string? FolderPath
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("folderPath", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["folderPath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
