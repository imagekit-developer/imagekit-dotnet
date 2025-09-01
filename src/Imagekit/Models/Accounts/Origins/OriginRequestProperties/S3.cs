using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Imagekit.Models.Accounts.Origins.OriginRequestProperties;

[JsonConverter(typeof(ModelConverter<S3>))]
public sealed record class S3 : ModelBase, IFromRaw<S3>
{
    /// <summary>
    /// Access key for the bucket.
    /// </summary>
    public required string AccessKey
    {
        get
        {
            if (!this.Properties.TryGetValue("accessKey", out JsonElement element))
                throw new ArgumentOutOfRangeException("accessKey", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("accessKey");
        }
        set
        {
            this.Properties["accessKey"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// S3 bucket name.
    /// </summary>
    public required string Bucket
    {
        get
        {
            if (!this.Properties.TryGetValue("bucket", out JsonElement element))
                throw new ArgumentOutOfRangeException("bucket", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("bucket");
        }
        set
        {
            this.Properties["bucket"] = JsonSerializer.SerializeToElement(
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
    /// Secret key for the bucket.
    /// </summary>
    public required string SecretKey
    {
        get
        {
            if (!this.Properties.TryGetValue("secretKey", out JsonElement element))
                throw new ArgumentOutOfRangeException("secretKey", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("secretKey");
        }
        set
        {
            this.Properties["secretKey"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Path prefix inside the bucket.
    /// </summary>
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
        _ = this.AccessKey;
        _ = this.Bucket;
        _ = this.Name;
        _ = this.SecretKey;
        _ = this.BaseURLForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public S3()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"S3\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    S3(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static S3 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
