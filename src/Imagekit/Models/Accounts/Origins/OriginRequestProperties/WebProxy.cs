using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.Origins.OriginRequestProperties;

[JsonConverter(typeof(ModelConverter<WebProxy>))]
public sealed record class WebProxy : ModelBase, IFromRaw<WebProxy>
{
    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                throw new ArgumentOutOfRangeException("name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("name");
        }
        set
        {
            this.Properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseURLForCanonicalHeader
    {
        get
        {
            if (!this.Properties.TryGetValue("baseUrlForCanonicalHeader", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["baseUrlForCanonicalHeader"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            if (!this.Properties.TryGetValue("includeCanonicalHeader", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["includeCanonicalHeader"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Name;
        _ = this.BaseURLForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public WebProxy()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"WEB_PROXY\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebProxy(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebProxy FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public WebProxy(string name)
        : this()
    {
        this.Name = name;
    }
}
