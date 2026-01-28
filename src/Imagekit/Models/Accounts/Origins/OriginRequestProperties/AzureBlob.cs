using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.Origins.OriginRequestProperties;

[JsonConverter(typeof(ModelConverter<AzureBlob>))]
public sealed record class AzureBlob : ModelBase, IFromRaw<AzureBlob>
{
    public required string AccountName
    {
        get
        {
            if (!this.Properties.TryGetValue("accountName", out JsonElement element))
                throw new ArgumentOutOfRangeException("accountName", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("accountName");
        }
        set
        {
            this.Properties["accountName"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Container
    {
        get
        {
            if (!this.Properties.TryGetValue("container", out JsonElement element))
                throw new ArgumentOutOfRangeException("container", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("container");
        }
        set
        {
            this.Properties["container"] = JsonSerializer.SerializeToElement(
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

    public required string SasToken
    {
        get
        {
            if (!this.Properties.TryGetValue("sasToken", out JsonElement element))
                throw new ArgumentOutOfRangeException("sasToken", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("sasToken");
        }
        set
        {
            this.Properties["sasToken"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public AzureBlobProperties::Type Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<AzureBlobProperties::Type>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new ImageKitInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentNullException("type")
                );
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

    public string? Prefix
    {
        get
        {
            if (!this.Properties.TryGetValue("prefix", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["prefix"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AccountName;
        _ = this.Container;
        _ = this.Name;
        _ = this.SasToken;
        this.Type.Validate();
        _ = this.BaseURLForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public AzureBlob()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureBlob(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AzureBlob FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
