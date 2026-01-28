using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.URLEndpoints.URLEndpointRequestProperties;

namespace Imagekit.Models.Accounts.URLEndpoints;

/// <summary>
/// Schema for URL endpoint resource.
/// </summary>
[JsonConverter(typeof(ModelConverter<URLEndpointRequest>))]
public sealed record class URLEndpointRequest : ModelBase, IFromRaw<URLEndpointRequest>
{
    /// <summary>
    /// Description of the URL endpoint.
    /// </summary>
    public required string Description
    {
        get
        {
            if (!this.Properties.TryGetValue("description", out JsonElement element))
                throw new ArgumentOutOfRangeException("description", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("description");
        }
        set
        {
            this.Properties["description"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("origins", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["origins"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("urlPrefix", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["urlPrefix"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("urlRewriter", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<URLRewriter?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["urlRewriter"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Description;
        _ = this.Origins;
        _ = this.URLPrefix;
        this.URLRewriter?.Validate();
    }

    public URLEndpointRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    URLEndpointRequest(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static URLEndpointRequest FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public URLEndpointRequest(string description)
        : this()
    {
        this.Description = description;
    }
}
