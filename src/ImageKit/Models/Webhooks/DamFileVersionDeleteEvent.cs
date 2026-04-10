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
/// Triggered when a file version is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<DamFileVersionDeleteEvent, DamFileVersionDeleteEventFromRaw>)
)]
public sealed record class DamFileVersionDeleteEvent : JsonModel
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

    public required DamFileVersionDeleteEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DamFileVersionDeleteEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(
        DamFileVersionDeleteEvent damFileVersionDeleteEvent
    ) => new() { ID = damFileVersionDeleteEvent.ID, Type = damFileVersionDeleteEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public DamFileVersionDeleteEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileVersionDeleteEvent(DamFileVersionDeleteEvent damFileVersionDeleteEvent)
        : base(damFileVersionDeleteEvent) { }
#pragma warning restore CS8618

    public DamFileVersionDeleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileVersionDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileVersionDeleteEventFromRaw.FromRawUnchecked"/>
    public static DamFileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileVersionDeleteEventFromRaw : IFromRawJson<DamFileVersionDeleteEvent>
{
    /// <inheritdoc/>
    public DamFileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileVersionDeleteEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        DamFileVersionDeleteEventIntersectionMember1,
        DamFileVersionDeleteEventIntersectionMember1FromRaw
    >)
)]
public sealed record class DamFileVersionDeleteEventIntersectionMember1 : JsonModel
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

    public required DamFileVersionDeleteEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DamFileVersionDeleteEventIntersectionMember1Data>(
                "data"
            );
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("file-version.deleted")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public DamFileVersionDeleteEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileVersionDeleteEventIntersectionMember1(
        DamFileVersionDeleteEventIntersectionMember1 damFileVersionDeleteEventIntersectionMember1
    )
        : base(damFileVersionDeleteEventIntersectionMember1) { }
#pragma warning restore CS8618

    public DamFileVersionDeleteEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileVersionDeleteEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileVersionDeleteEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static DamFileVersionDeleteEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileVersionDeleteEventIntersectionMember1FromRaw
    : IFromRawJson<DamFileVersionDeleteEventIntersectionMember1>
{
    /// <inheritdoc/>
    public DamFileVersionDeleteEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileVersionDeleteEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        DamFileVersionDeleteEventIntersectionMember1Data,
        DamFileVersionDeleteEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class DamFileVersionDeleteEventIntersectionMember1Data : JsonModel
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

    /// <summary>
    /// The unique `versionId` of the deleted file version.
    /// </summary>
    public required string VersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("versionId");
        }
        init { this._rawData.Set("versionId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.VersionID;
    }

    public DamFileVersionDeleteEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DamFileVersionDeleteEventIntersectionMember1Data(
        DamFileVersionDeleteEventIntersectionMember1Data damFileVersionDeleteEventIntersectionMember1Data
    )
        : base(damFileVersionDeleteEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public DamFileVersionDeleteEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DamFileVersionDeleteEventIntersectionMember1Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DamFileVersionDeleteEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static DamFileVersionDeleteEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DamFileVersionDeleteEventIntersectionMember1DataFromRaw
    : IFromRawJson<DamFileVersionDeleteEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public DamFileVersionDeleteEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => DamFileVersionDeleteEventIntersectionMember1Data.FromRawUnchecked(rawData);
}
