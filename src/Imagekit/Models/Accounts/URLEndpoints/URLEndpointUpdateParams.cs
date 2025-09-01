using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Imagekit.Models.Accounts.URLEndpoints.URLEndpointUpdateParamsProperties;

namespace Imagekit.Models.Accounts.URLEndpoints;

/// <summary>
/// **Note:** This API is currently in beta.   Updates the URL‑endpoint identified
/// by `id` and returns the updated object.
/// </summary>
public sealed record class URLEndpointUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// Description of the URL endpoint.
    /// </summary>
    public required string Description
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("description");
        }
        set
        {
            this.BodyProperties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Ordered list of origin IDs to try when the file isn’t in the Media Library;
    /// ImageKit checks them in the sequence provided. Origin must be created before
    /// it can be used in a URL endpoint.
    /// </summary>
    public List<string>? Origins
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("origins", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["origins"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path segment appended to your base URL to form the endpoint (letters, digits,
    /// and hyphens only — or empty for the default endpoint).
    /// </summary>
    public string? URLPrefix
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("urlPrefix", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["urlPrefix"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Configuration for third-party URL rewriting.
    /// </summary>
    public URLRewriter? URLRewriter
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("urlRewriter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<URLRewriter?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.BodyProperties["urlRewriter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/url-endpoints/{0}", this.ID)
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
