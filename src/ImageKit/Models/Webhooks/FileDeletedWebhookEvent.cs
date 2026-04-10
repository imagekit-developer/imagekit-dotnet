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
[JsonConverter(typeof(JsonModelConverter<FileDeletedWebhookEvent, FileDeletedWebhookEventFromRaw>))]
public sealed record class FileDeletedWebhookEvent : JsonModel
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

    public required FileDeletedWebhookEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileDeletedWebhookEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(
        FileDeletedWebhookEvent fileDeletedWebhookEvent
    ) => new() { ID = fileDeletedWebhookEvent.ID, Type = fileDeletedWebhookEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileDeletedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDeletedWebhookEvent(FileDeletedWebhookEvent fileDeletedWebhookEvent)
        : base(fileDeletedWebhookEvent) { }
#pragma warning restore CS8618

    public FileDeletedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDeletedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileDeletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static FileDeletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileDeletedWebhookEventFromRaw : IFromRawJson<FileDeletedWebhookEvent>
{
    /// <inheritdoc/>
    public FileDeletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileDeletedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileDeletedWebhookEventIntersectionMember1,
        FileDeletedWebhookEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileDeletedWebhookEventIntersectionMember1 : JsonModel
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

    public required FileDeletedWebhookEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileDeletedWebhookEventIntersectionMember1Data>(
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file.deleted")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FileDeletedWebhookEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDeletedWebhookEventIntersectionMember1(
        FileDeletedWebhookEventIntersectionMember1 fileDeletedWebhookEventIntersectionMember1
    )
        : base(fileDeletedWebhookEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileDeletedWebhookEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDeletedWebhookEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileDeletedWebhookEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileDeletedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileDeletedWebhookEventIntersectionMember1FromRaw
    : IFromRawJson<FileDeletedWebhookEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileDeletedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileDeletedWebhookEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FileDeletedWebhookEventIntersectionMember1Data,
        FileDeletedWebhookEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class FileDeletedWebhookEventIntersectionMember1Data : JsonModel
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

    public FileDeletedWebhookEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileDeletedWebhookEventIntersectionMember1Data(
        FileDeletedWebhookEventIntersectionMember1Data fileDeletedWebhookEventIntersectionMember1Data
    )
        : base(fileDeletedWebhookEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public FileDeletedWebhookEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileDeletedWebhookEventIntersectionMember1Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileDeletedWebhookEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static FileDeletedWebhookEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileDeletedWebhookEventIntersectionMember1Data(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class FileDeletedWebhookEventIntersectionMember1DataFromRaw
    : IFromRawJson<FileDeletedWebhookEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public FileDeletedWebhookEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileDeletedWebhookEventIntersectionMember1Data.FromRawUnchecked(rawData);
}
