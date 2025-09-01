using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties;

namespace Imagekit.Models.CustomMetadataFields;

/// <summary>
/// This API updates the label or schema of an existing custom metadata field.
/// </summary>
public sealed record class CustomMetadataFieldUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// Human readable name of the custom metadata field. This should be unique across
    /// all non deleted custom metadata fields. This name is displayed as form field
    /// label to the users while setting field value on an asset in the media library
    /// UI. This parameter is required if `schema` is not provided.
    /// </summary>
    public string? Label
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("label", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
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
    /// An object that describes the rules for the custom metadata key. This parameter
    /// is required if `label` is not provided. Note: `type` cannot be updated and
    /// will be ignored if sent with the `schema`. The schema will be validated as
    /// per the existing `type`.
    /// </summary>
    public Schema? Schema
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("schema", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Schema?>(element, ModelBase.SerializerOptions);
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
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/customMetadataFields/{0}", this.ID)
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
