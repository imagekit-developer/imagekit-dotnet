using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a pre-transformation completes successfully. The file has been
/// processed with the requested transformation and is now available in the Media
/// Library.
/// </summary>
[JsonConverter(typeof(ModelConverter<UploadPreTransformSuccessEvent>))]
public sealed record class UploadPreTransformSuccessEvent
    : ModelBase,
        IFromRaw<UploadPreTransformSuccessEvent>
{
    /// <summary>
    /// Unique identifier for the event.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ImageKitInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The type of webhook event.
    /// </summary>
    public required string Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ImageKitInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
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
    /// Timestamp of when the event occurred in ISO8601 format.
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

    /// <summary>
    /// Object containing details of a successful upload.
    /// </summary>
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

    public static implicit operator BaseWebhookEvent(
        UploadPreTransformSuccessEvent uploadPreTransformSuccessEvent
    ) =>
        new()
        {
            ID = uploadPreTransformSuccessEvent.ID,
            Type = uploadPreTransformSuccessEvent.Type,
        };

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public UploadPreTransformSuccessEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformSuccessEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UploadPreTransformSuccessEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
