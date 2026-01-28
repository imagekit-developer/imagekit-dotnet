using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Files.Bulk;

/// <summary>
/// This API deletes multiple files and all their file versions permanently.
///
/// Note: If a file or specific transformation has been requested in the past, then
/// the response is cached. Deleting a file does not purge the cache. You can purge
/// the cache using purge cache API.
///
/// A maximum of 100 files can be deleted at a time.
/// </summary>
public sealed record class BulkDeleteParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// An array of fileIds which you want to delete.
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

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/batch/deleteByFileIds"
        )
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
