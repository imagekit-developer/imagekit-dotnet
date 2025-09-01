using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Files;

/// <summary>
/// You can rename an already existing file in the media library using rename file
/// API. This operation would rename all file versions of the file.
///
/// Note: The old URLs will stop working. The file/file version URLs cached on CDN
/// will continue to work unless a purge is requested.
/// </summary>
public sealed record class FileRenameParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The full path of the file you want to rename.
    /// </summary>
    public required string FilePath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("filePath", out JsonElement element))
                throw new ArgumentOutOfRangeException("filePath", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("filePath");
        }
        set
        {
            this.BodyProperties["filePath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The new name of the file. A filename can contain:
    ///
    /// Alphanumeric Characters: `a-z`, `A-Z`, `0-9` (including Unicode letters, marks,
    /// and numerals in other languages). Special Characters: `.`, `_`, and `-`.
    ///
    /// Any other character, including space, will be replaced by `_`.
    /// </summary>
    public required string NewFileName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("newFileName", out JsonElement element))
                throw new ArgumentOutOfRangeException("newFileName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("newFileName");
        }
        set
        {
            this.BodyProperties["newFileName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Option to purge cache for the old file and its versions' URLs.
    ///
    /// When set to true, it will internally issue a purge cache request on CDN to
    /// remove cached content of old file and its versions. This purge request is
    /// counted against your monthly purge quota.
    ///
    /// Note: If the old file were accessible at `https://ik.imagekit.io/demo/old-filename.jpg`,
    /// a purge cache request would be issued against `https://ik.imagekit.io/demo/old-filename.jpg*`
    /// (with a wildcard at the end). It will remove the file and its versions' URLs
    /// and any transformations made using query parameters on this file or its versions.
    /// However, the cache for file transformations made using path parameters will
    /// persist. You can purge them using the purge API. For more details, refer to
    /// the purge API documentation.
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
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/rename")
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
