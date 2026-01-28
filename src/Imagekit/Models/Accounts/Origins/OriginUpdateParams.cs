using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// **Note:** This API is currently in beta.   Updates the origin identified by `id`
/// and returns the updated origin object.
/// </summary>
public sealed record class OriginUpdateParams : ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required string ID;

    /// <summary>
    /// Schema for origin request resources.
    /// </summary>
    public required OriginRequest Origin
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("origin", out JsonElement element))
                throw new ArgumentOutOfRangeException("origin", "Missing required argument");

            return JsonSerializer.Deserialize<OriginRequest>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("origin");
        }
        set
        {
            this.BodyProperties["origin"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override Uri Url(IImageKitClient client)
    {
        return new UriBuilder(
            client.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/origins/{0}", this.ID)
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
