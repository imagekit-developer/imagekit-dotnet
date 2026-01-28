using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Files;

/// <summary>
/// This will copy a file from one folder to another.
///
/// Note: If any file at the destination has the same name as the source file, then
/// the source file and its versions (if `includeFileVersions` is set to true) will
/// be appended to the destination file version history.
/// </summary>
public sealed record class FileCopyParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Full path to the folder you want to copy the above file into.
    /// </summary>
    public required string DestinationPath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("destinationPath", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "destinationPath",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("destinationPath");
        }
        set
        {
            this.BodyProperties["destinationPath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The full path of the file you want to copy.
    /// </summary>
    public required string SourceFilePath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("sourceFilePath", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "sourceFilePath",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("sourceFilePath");
        }
        set
        {
            this.BodyProperties["sourceFilePath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Option to copy all versions of a file. By default, only the current version
    /// of the file is copied. When set to true, all versions of the file will be
    /// copied. Default value - `false`.
    /// </summary>
    public bool? IncludeFileVersions
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("includeFileVersions", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["includeFileVersions"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/copy")
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
