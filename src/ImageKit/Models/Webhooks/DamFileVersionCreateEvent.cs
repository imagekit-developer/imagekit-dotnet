using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models.Webhooks;

/// <summary>
/// Triggered when a file version is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DamFileVersionCreateEvent, DamFileVersionCreateEventFromRaw>)
)]
public sealed record class DamFileVersionCreateEvent : JsonModel
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

    public required JsonElement Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(
        DamFileVersionCreateEvent damFileVersionCreateEvent
    ) => new() { ID = damFileVersionCreateEvent.ID, Type = damFileVersionCreateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        _ = this.Data;
    }

    public DamFileVersionCreateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileVersionCreateEvent(DamFileVersionCreateEvent damFileVersionCreateEvent)
        : base(damFileVersionCreateEvent) { }
#pragma warning restore CS8618

    public DamFileVersionCreateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileVersionCreateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileVersionCreateEventFromRaw.FromRawUnchecked"/>
    public static DamFileVersionCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileVersionCreateEventFromRaw : IFromRawJson<DamFileVersionCreateEvent>
{
    /// <inheritdoc/>
    public DamFileVersionCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileVersionCreateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DamFileVersionCreateEventIntersectionMember1,
        DamFileVersionCreateEventIntersectionMember1FromRaw
    >)
)]
public sealed record class DamFileVersionCreateEventIntersectionMember1 : JsonModel
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

    public required JsonElement Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("data");
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
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("file-version.created")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public DamFileVersionCreateEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileVersionCreateEventIntersectionMember1(
        DamFileVersionCreateEventIntersectionMember1 damFileVersionCreateEventIntersectionMember1
    )
        : base(damFileVersionCreateEventIntersectionMember1) { }
#pragma warning restore CS8618

    public DamFileVersionCreateEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileVersionCreateEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileVersionCreateEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DamFileVersionCreateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileVersionCreateEventIntersectionMember1FromRaw
    : IFromRawJson<DamFileVersionCreateEventIntersectionMember1>
{
    /// <inheritdoc/>
    public DamFileVersionCreateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileVersionCreateEventIntersectionMember1.FromRawUnchecked(rawData);
}
