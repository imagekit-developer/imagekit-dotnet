using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties.IntersectionMember1Properties;

namespace Imagekit.Models.Webhooks.VideoTransformationReadyEventProperties;

/// <summary>
/// Triggered when video encoding is finished and the transformed resource is ready
/// to be served. This is the key event to listen for - update your database or CMS
/// flags when you receive this so your application can start showing the transformed
/// video to users.
/// </summary>
[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    /// <summary>
    /// Timestamp when the event was created in ISO8601 format.
    /// </summary>
    public required DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTime>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Data Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Information about the original request that triggered the video transformation.
    /// </summary>
    public required Request Request
    {
        get
        {
            if (!this.Properties.TryGetValue("request", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'request' cannot be null",
                    new ArgumentOutOfRangeException("request", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Request>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'request' cannot be null",
                    new ArgumentNullException("request")
                );
        }
        set
        {
            this.Properties["request"] = JsonSerializer.SerializeToElement(
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
                throw new ImageKitInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

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
    /// Performance metrics for the transformation process.
    /// </summary>
    public Timings? Timings
    {
        get
        {
            if (!this.Properties.TryGetValue("timings", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Timings?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timings"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
        this.Timings?.Validate();
    }

    public IntersectionMember1()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
