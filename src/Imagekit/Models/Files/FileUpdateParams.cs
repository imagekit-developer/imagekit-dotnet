using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Imagekit.Models.Files.FileUpdateParamsProperties;

namespace Imagekit.Models.Files;

/// <summary>
/// This API updates the details or attributes of the current version of the file.
/// You can update `tags`, `customCoordinates`, `customMetadata`, publication status,
/// remove existing `AITags` and apply extensions using this API.
/// </summary>
public sealed record class FileUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string FileID;

    public Update? Update
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("update", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Update?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["update"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/{0}/details", this.FileID)
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
