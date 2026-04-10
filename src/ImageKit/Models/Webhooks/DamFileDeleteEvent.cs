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
/// Triggered when a file is deleted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DamFileDeleteEvent, DamFileDeleteEventFromRaw>))]
public sealed record class DamFileDeleteEvent : JsonModel
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

    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(DamFileDeleteEvent damFileDeleteEvent) =>
        new() { ID = damFileDeleteEvent.ID, Type = damFileDeleteEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public DamFileDeleteEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileDeleteEvent(DamFileDeleteEvent damFileDeleteEvent)
        : base(damFileDeleteEvent) { }
#pragma warning restore CS8618

    public DamFileDeleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileDeleteEventFromRaw.FromRawUnchecked"/>
    public static DamFileDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileDeleteEventFromRaw : IFromRawJson<DamFileDeleteEvent>
{
    /// <inheritdoc/>
    public DamFileDeleteEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DamFileDeleteEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DamFileDeleteEventIntersectionMember1,
        DamFileDeleteEventIntersectionMember1FromRaw
    >)
)]
public sealed record class DamFileDeleteEventIntersectionMember1 : JsonModel
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

    public required Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>("data");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file.deleted")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public DamFileDeleteEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileDeleteEventIntersectionMember1(
        DamFileDeleteEventIntersectionMember1 damFileDeleteEventIntersectionMember1
    )
        : base(damFileDeleteEventIntersectionMember1) { }
#pragma warning restore CS8618

    public DamFileDeleteEventIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileDeleteEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileDeleteEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DamFileDeleteEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileDeleteEventIntersectionMember1FromRaw
    : IFromRawJson<DamFileDeleteEventIntersectionMember1>
{
    /// <inheritdoc/>
    public DamFileDeleteEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileDeleteEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The unique `fileId` of the deleted file.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("fileId");
        }
        init { this._rawData.Set("fileId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Data(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}
