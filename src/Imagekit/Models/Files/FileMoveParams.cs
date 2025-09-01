using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Files;

/// <summary>
/// This will move a file and all its versions from one folder to another.
///
/// Note: If any file at the destination has the same name as the source file, then
/// the source file and its versions will be appended to the destination file.
/// </summary>
public sealed record class FileMoveParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Full path to the folder you want to move the above file into.
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
    /// The full path of the file you want to move.
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

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/files/move")
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
