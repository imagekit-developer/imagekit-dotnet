using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.Origins.OriginRequestProperties;

[JsonConverter(typeof(ModelConverter<AkeneoPim>))]
public sealed record class AkeneoPim : ModelBase, IFromRaw<AkeneoPim>
{
    /// <summary>
    /// Akeneo instance base URL.
    /// </summary>
    public required string BaseURL
    {
        get
        {
            if (!this.Properties.TryGetValue("baseUrl", out JsonElement element))
                throw new ArgumentOutOfRangeException("baseUrl", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("baseUrl");
        }
        set
        {
            this.Properties["baseUrl"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Akeneo API client ID.
    /// </summary>
    public required string ClientID
    {
        get
        {
            if (!this.Properties.TryGetValue("clientId", out JsonElement element))
                throw new ArgumentOutOfRangeException("clientId", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("clientId");
        }
        set
        {
            this.Properties["clientId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Akeneo API client secret.
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            if (!this.Properties.TryGetValue("clientSecret", out JsonElement element))
                throw new ArgumentOutOfRangeException("clientSecret", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("clientSecret");
        }
        set
        {
            this.Properties["clientSecret"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    /// <summary>
    /// Akeneo API password.
    /// </summary>
    public required string Password
    {
        get
        {
            if (!this.Properties.TryGetValue("password", out JsonElement element))
                throw new ArgumentOutOfRangeException("password", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("password");
        }
        set
        {
            this.Properties["password"] = JsonSerializer.SerializeToElement(
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
    /// Akeneo API username.
    /// </summary>
    public required string Username
    {
        get
        {
            if (!this.Properties.TryGetValue("username", out JsonElement element))
                throw new ArgumentOutOfRangeException("username", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("username");
        }
        set
        {
            this.Properties["username"] = JsonSerializer.SerializeToElement(
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
        _ = this.BaseURL;
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.Name;
        _ = this.Password;
        _ = this.Username;
        _ = this.BaseURLForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public AkeneoPim()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"AKENEO_PIM\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AkeneoPim(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AkeneoPim FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
