using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Folders;

/// <summary>
/// This API allows you to rename an existing folder. The folder and all its nested
/// assets and sub-folders will remain unchanged, but their paths will be updated
/// to reflect the new folder name.
/// </summary>
public sealed record class FolderRenameParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The full path to the folder you want to rename.
    /// </summary>
    public required string FolderPath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("folderPath", out JsonElement element))
                throw new ArgumentOutOfRangeException("folderPath", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("folderPath");
        }
        set
        {
            this.BodyProperties["folderPath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new name for the folder.
    ///
    /// All characters except alphabets and numbers (inclusive of unicode letters,
    /// marks, and numerals in other languages) and `-` will be replaced by an underscore
    /// i.e. `_`.
    /// </summary>
    public required string NewFolderName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("newFolderName", out JsonElement element))
                throw new ArgumentOutOfRangeException("newFolderName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("newFolderName");
        }
        set
        {
            this.BodyProperties["newFolderName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Option to purge cache for the old nested files and their versions' URLs.
    ///
    /// When set to true, it will internally issue a purge cache request on CDN to
    /// remove the cached content of the old nested files and their versions. There
    /// will only be one purge request for all the nested files, which will be counted
    /// against your monthly purge quota.
    ///
    /// Note: A purge cache request will be issued against `https://ik.imagekit.io/old/folder/path*`
    /// (with a wildcard at the end). This will remove all nested files, their versions'
    /// URLs, and any transformations made using query parameters on these files
    /// or their versions. However, the cache for file transformations made using
    /// path parameters will persist. You can purge them using the purge API. For
    /// more details, refer to the purge API documentation.
    ///
    /// Default value - `false`
    /// </summary>
    public bool? PurgeCache
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("purgeCache", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["purgeCache"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/bulkJobs/renameFolder")
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
