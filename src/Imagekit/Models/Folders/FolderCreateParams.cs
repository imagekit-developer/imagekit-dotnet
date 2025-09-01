using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Folders;

/// <summary>
/// This will create a new folder. You can specify the folder name and location of
/// the parent folder where this new folder should be created.
/// </summary>
public sealed record class FolderCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// The folder will be created with this name.
    ///
    /// All characters except alphabets and numbers (inclusive of unicode letters,
    /// marks, and numerals in other languages) will be replaced by an underscore
    /// i.e. `_`.
    /// </summary>
    public required string FolderName
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("folderName", out JsonElement element))
                throw new ArgumentOutOfRangeException("folderName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("folderName");
        }
        set
        {
            this.BodyProperties["folderName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The folder where the new folder should be created, for root use `/` else the
    /// path e.g. `containing/folder/`.
    ///
    /// Note: If any folder(s) is not present in the parentFolderPath parameter,
    /// it will be automatically created. For example, if you pass `/product/images/summer`,
    /// then `product`, `images`, and `summer` folders will be created if they don't
    /// already exist.
    /// </summary>
    public required string ParentFolderPath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("parentFolderPath", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "parentFolderPath",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("parentFolderPath");
        }
        set
        {
            this.BodyProperties["parentFolderPath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/folder")
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
