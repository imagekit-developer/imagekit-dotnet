using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using ImageKit.Models.Files;

namespace ImageKit.Models.Webhooks;

/// <summary>
/// Triggered when a file is updated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DamFileUpdateEvent, DamFileUpdateEventFromRaw>))]
public sealed record class DamFileUpdateEvent : JsonModel
{
    /// <summary>
    /// Unique identifier for the event.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The type of webhook event.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Timestamp of when the event occurred in ISO8601 format.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Object containing details of a file or file version.
    /// </summary>
    public required File Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<File>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(DamFileUpdateEvent damFileUpdateEvent) =>
        new() { ID = damFileUpdateEvent.ID, Type = damFileUpdateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public DamFileUpdateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileUpdateEvent(DamFileUpdateEvent damFileUpdateEvent)
        : base(damFileUpdateEvent) { }
#pragma warning restore CS8618

    public DamFileUpdateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileUpdateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileUpdateEventFromRaw.FromRawUnchecked"/>
    public static DamFileUpdateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileUpdateEventFromRaw : IFromRawJson<DamFileUpdateEvent>
{
    /// <inheritdoc/>
    public DamFileUpdateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DamFileUpdateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is updated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DamFileUpdateEventIntersectionMember1,
        DamFileUpdateEventIntersectionMember1FromRaw
    >)
)]
public sealed record class DamFileUpdateEventIntersectionMember1 : JsonModel
{
    /// <summary>
    /// Timestamp of when the event occurred in ISO8601 format.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Object containing details of a file or file version.
    /// </summary>
    public required File Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<File>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Type of the webhook event.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        this.Data.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file.updated")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public DamFileUpdateEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileUpdateEventIntersectionMember1(
        DamFileUpdateEventIntersectionMember1 damFileUpdateEventIntersectionMember1
    )
        : base(damFileUpdateEventIntersectionMember1) { }
#pragma warning restore CS8618

    public DamFileUpdateEventIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileUpdateEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileUpdateEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DamFileUpdateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileUpdateEventIntersectionMember1FromRaw
    : IFromRawJson<DamFileUpdateEventIntersectionMember1>
{
    /// <inheritdoc/>
    public DamFileUpdateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileUpdateEventIntersectionMember1.FromRawUnchecked(rawData);
}
