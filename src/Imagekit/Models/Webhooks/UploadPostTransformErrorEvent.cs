using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Webhooks.UploadPostTransformErrorEventProperties.IntersectionMember1Properties;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a post-transformation fails. The original file remains available,
/// but the requested transformation could not be generated.
/// </summary>
[JsonConverter(typeof(ModelConverter<UploadPostTransformErrorEvent>))]
public sealed record class UploadPostTransformErrorEvent
    : ModelBase,
        IFromRaw<UploadPostTransformErrorEvent>
{
    /// <summary>
    /// Unique identifier for the event.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("id");
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
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("type");
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
                throw new ArgumentOutOfRangeException("created_at", "Missing required argument");

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
                throw new ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("data");
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
                throw new ArgumentOutOfRangeException("request", "Missing required argument");

            return JsonSerializer.Deserialize<Request>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("request");
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
        UploadPostTransformErrorEvent uploadPostTransformErrorEvent
    ) => new() { ID = uploadPostTransformErrorEvent.ID, Type = uploadPostTransformErrorEvent.Type };

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public UploadPostTransformErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UploadPostTransformErrorEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
