using System;
using System.Net.Http;
using System.Text.Json;
using AssetListParamsProperties = Imagekit.Models.Assets.AssetListParamsProperties;

namespace Imagekit.Models.Assets;

/// <summary>
/// This API can list all the uploaded files and folders in your ImageKit.io media
/// library. In addition, you can fine-tune your query by specifying various filters
/// by generating a query string in a Lucene-like syntax and provide this generated
/// string as the value of the `searchQuery`.
/// </summary>
public sealed record class AssetListParams : ParamsBase
{
    /// <summary>
    /// Filter results by file type.
    ///
    /// - `all` — include all file types   - `image` — include only image files
    /// - `non-image` — include only non-image files (e.g., JS, CSS, video)
    /// </summary>
    public ApiEnum<string, AssetListParamsProperties::FileType>? FileType
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("fileType", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<
                string,
                AssetListParamsProperties::FileType
            >?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["fileType"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The maximum number of results to return in response.
    /// </summary>
    public long? Limit
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("limit", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["limit"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Folder path if you want to limit the search within a specific folder. For
    /// example, `/sales-banner/` will only search in folder sales-banner.
    ///
    /// Note : If your use case involves searching within a folder as well as its
    /// subfolders, you can use `path` parameter in `searchQuery` with appropriate
    /// operator. Checkout [Supported parameters](/docs/api-reference/digital-asset-management-dam/list-and-search-assets#supported-parameters)
    /// for more information.
    /// </summary>
    public string? Path
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("path", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Query string in a Lucene-like query language e.g. `createdAt > "7d"`.
    ///
    /// Note : When the searchQuery parameter is present, the following query parameters
    /// will have no effect on the result:
    ///
    /// 1. `tags` 2. `type` 3. `name`
    ///
    /// [Learn more](/docs/api-reference/digital-asset-management-dam/list-and-search-assets#advanced-search-queries)
    /// from examples.
    /// </summary>
    public string? SearchQuery
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("searchQuery", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["searchQuery"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The number of results to skip before returning results.
    /// </summary>
    public long? Skip
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("skip", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.QueryProperties["skip"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Sort the results by one of the supported fields in ascending or descending
    /// order.
    /// </summary>
    public ApiEnum<string, AssetListParamsProperties::Sort>? Sort
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("sort", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AssetListParamsProperties::Sort>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["sort"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Filter results by asset type.
    ///
    /// - `file` — returns only files   - `file-version` — returns specific file versions
    ///   - `folder` — returns only folders   - `all` — returns both files and folders
    /// (excludes `file-version`)
    /// </summary>
    public ApiEnum<string, AssetListParamsProperties::Type>? Type
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("type", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, AssetListParamsProperties::Type>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.QueryProperties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files")
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
