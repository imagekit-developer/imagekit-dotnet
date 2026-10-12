using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using Imagekit.Models.Files;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a folder is updated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderUpdateEvent, FolderUpdateEventFromRaw>))]
public sealed record class FolderUpdateEvent : JsonModel
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

    public required Folder Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Folder>("data");
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(FolderUpdateEvent folderUpdateEvent) =>
        new() { ID = folderUpdateEvent.ID, Type = folderUpdateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FolderUpdateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderUpdateEvent(FolderUpdateEvent folderUpdateEvent)
        : base(folderUpdateEvent) { }
#pragma warning restore CS8618

    public FolderUpdateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderUpdateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderUpdateEventFromRaw.FromRawUnchecked"/>
    public static FolderUpdateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderUpdateEventFromRaw : IFromRawJson<FolderUpdateEvent>
{
    /// <inheritdoc/>
    public FolderUpdateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderUpdateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a folder is updated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FolderUpdateEventFolderUpdateEvent,
        FolderUpdateEventFolderUpdateEventFromRaw
    >)
)]
public sealed record class FolderUpdateEventFolderUpdateEvent : JsonModel
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

    public required Folder Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Folder>("data");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("folder.updated")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FolderUpdateEventFolderUpdateEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("folder.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderUpdateEventFolderUpdateEvent(
        FolderUpdateEventFolderUpdateEvent folderUpdateEventFolderUpdateEvent
    )
        : base(folderUpdateEventFolderUpdateEvent) { }
#pragma warning restore CS8618

    public FolderUpdateEventFolderUpdateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("folder.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderUpdateEventFolderUpdateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderUpdateEventFolderUpdateEventFromRaw.FromRawUnchecked"/>
    public static FolderUpdateEventFolderUpdateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderUpdateEventFolderUpdateEventFromRaw : IFromRawJson<FolderUpdateEventFolderUpdateEvent>
{
    /// <inheritdoc/>
    public FolderUpdateEventFolderUpdateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderUpdateEventFolderUpdateEvent.FromRawUnchecked(rawData);
}
