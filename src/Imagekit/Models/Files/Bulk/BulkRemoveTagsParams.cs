using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Files.Bulk;

/// <summary>
/// This API removes tags from multiple files in bulk. A maximum of 50 files can
/// be specified at a time.
/// </summary>
public sealed record class BulkRemoveTagsParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// An array of fileIds from which you want to remove tags.
    /// </summary>
    public required List<string> FileIDs
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("fileIds", out JsonElement element))
                throw new ArgumentOutOfRangeException("fileIds", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("fileIds");
        }
        set
        {
            this.BodyProperties["fileIds"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An array of tags that you want to remove from the files.
    /// </summary>
    public required List<string> Tags
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("tags", out JsonElement element))
                throw new ArgumentOutOfRangeException("tags", "Missing required argument");

            return JsonSerializer.Deserialize<List<string>>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("tags");
        }
        set
        {
            this.BodyProperties["tags"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/removeTags")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
