using System;
using System.Net.Http;
using System.Text.Json;

namespace Imagekit.Models.Files.Metadata;

/// <summary>
/// Get image EXIF, pHash, and other metadata from ImageKit.io powered remote URL
/// using this API.
/// </summary>
public sealed record class MetadataGetFromURLParams : ParamsBase
{
    /// <summary>
    /// Should be a valid file URL. It should be accessible using your ImageKit.io
    /// account.
    /// </summary>
    public required string URL
    {
        get
        {
            if (!this.QueryProperties.TryGetValue("url", out JsonElement element))
                throw new ArgumentOutOfRangeException("url", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("url");
        }
        set
        {
            this.QueryProperties["url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/metadata")
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
