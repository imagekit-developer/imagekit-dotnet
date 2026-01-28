using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// This API creates a new custom metadata field. Once a custom metadata field is
/// created either through this API or using the dashboard UI, its value can be set
/// on the assets. The value of a field for an asset can be set using the media library
/// UI or programmatically through upload or update assets API.
/// </summary>
public sealed record class CustomMetadataFieldCreateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    /// <summary>
    /// Human readable name of the custom metadata field. This should be unique across
    /// all non deleted custom metadata fields. This name is displayed as form field
    /// label to the users while setting field value on an asset in the media library UI.
    /// </summary>
    public required string Label
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("label", out JsonElement element))
                throw new ArgumentOutOfRangeException("label", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("label");
        }
        set
        {
            this.BodyProperties["label"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// API name of the custom metadata field. This should be unique across all (including
    /// deleted) custom metadata fields.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set
        {
            this.BodyProperties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Schema Schema
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("schema", out JsonElement element))
                throw new ArgumentOutOfRangeException("schema", "Missing required argument");

            return JsonSerializer.Deserialize<Schema>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("schema");
        }
        set
        {
            this.BodyProperties["schema"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/v1/customMetadataFields")
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
