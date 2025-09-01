using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Folders;

/// <summary>
/// This will move one folder into another. The selected folder, its nested folders,
/// files, and their versions are moved in this operation. Note: If any file at the
/// destination has the same name as the source file, then the source file and its
/// versions will be appended to the destination file version history.
/// </summary>
public sealed record class FolderMoveParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Full path to the destination folder where you want to move the source folder
    /// into.
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
    /// The full path to the source folder you want to move.
    /// </summary>
    public required string SourceFolderPath
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("sourceFolderPath", out JsonElement element))
                throw new ArgumentOutOfRangeException(
                    "sourceFolderPath",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("sourceFolderPath");
        }
        set
        {
            this.BodyProperties["sourceFolderPath"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/bulkJobs/moveFolder")
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
