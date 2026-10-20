using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a folder is deleted. Deleting a folder tree sends one event per
/// folder in the tree; the files inside it send `file.deleted` events and their versions
/// send `file-version.deleted` events. Moving a folder sends this event for the old
/// `folderId` and `folder.created` for the new one.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderDeleteEvent, FolderDeleteEventFromRaw>))]
public sealed record class FolderDeleteEvent : JsonModel
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

    public required FolderDeleteEventFolderDeleteEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FolderDeleteEventFolderDeleteEventData>("data");
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

    public static implicit operator BaseWebhookEvent(FolderDeleteEvent folderDeleteEvent) =>
        new() { ID = folderDeleteEvent.ID };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Data.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("folder.deleted")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FolderDeleteEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("folder.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderDeleteEvent(FolderDeleteEvent folderDeleteEvent)
        : base(folderDeleteEvent) { }
#pragma warning restore CS8618

    public FolderDeleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("folder.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderDeleteEventFromRaw.FromRawUnchecked"/>
    public static FolderDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderDeleteEventFromRaw : IFromRawJson<FolderDeleteEvent>
{
    /// <inheritdoc/>
    public FolderDeleteEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderDeleteEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a folder is deleted. Deleting a folder tree sends one event per
/// folder in the tree; the files inside it send `file.deleted` events and their versions
/// send `file-version.deleted` events. Moving a folder sends this event for the old
/// `folderId` and `folder.created` for the new one.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FolderDeleteEventFolderDeleteEvent,
        FolderDeleteEventFolderDeleteEventFromRaw
    >)
)]
public sealed record class FolderDeleteEventFolderDeleteEvent : JsonModel
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

    public required FolderDeleteEventFolderDeleteEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FolderDeleteEventFolderDeleteEventData>("data");
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("folder.deleted")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FolderDeleteEventFolderDeleteEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("folder.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderDeleteEventFolderDeleteEvent(
        FolderDeleteEventFolderDeleteEvent folderDeleteEventFolderDeleteEvent
    )
        : base(folderDeleteEventFolderDeleteEvent) { }
#pragma warning restore CS8618

    public FolderDeleteEventFolderDeleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("folder.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderDeleteEventFolderDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderDeleteEventFolderDeleteEventFromRaw.FromRawUnchecked"/>
    public static FolderDeleteEventFolderDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderDeleteEventFolderDeleteEventFromRaw : IFromRawJson<FolderDeleteEventFolderDeleteEvent>
{
    /// <inheritdoc/>
    public FolderDeleteEventFolderDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderDeleteEventFolderDeleteEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FolderDeleteEventFolderDeleteEventData,
        FolderDeleteEventFolderDeleteEventDataFromRaw
    >)
)]
public sealed record class FolderDeleteEventFolderDeleteEventData : JsonModel
{
    /// <summary>
    /// The unique `folderId` of the deleted folder.
    /// </summary>
    public required string FolderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("folderId");
        }
        init { this._rawData.Set("folderId", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FolderID;
    }

    public FolderDeleteEventFolderDeleteEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderDeleteEventFolderDeleteEventData(
        FolderDeleteEventFolderDeleteEventData folderDeleteEventFolderDeleteEventData
    )
        : base(folderDeleteEventFolderDeleteEventData) { }
#pragma warning restore CS8618

    public FolderDeleteEventFolderDeleteEventData(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderDeleteEventFolderDeleteEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderDeleteEventFolderDeleteEventDataFromRaw.FromRawUnchecked"/>
    public static FolderDeleteEventFolderDeleteEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FolderDeleteEventFolderDeleteEventData(string folderID)
        : this()
    {
        this.FolderID = folderID;
    }
}

class FolderDeleteEventFolderDeleteEventDataFromRaw
    : IFromRawJson<FolderDeleteEventFolderDeleteEventData>
{
    /// <inheritdoc/>
    public FolderDeleteEventFolderDeleteEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderDeleteEventFolderDeleteEventData.FromRawUnchecked(rawData);
}
