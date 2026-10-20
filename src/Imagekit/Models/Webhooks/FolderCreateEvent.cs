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
/// Triggered when a folder is created, whether explicitly, by copying or moving
/// a folder, or implicitly when an upload creates missing parent folders. Copying
/// or moving a folder tree sends one event per folder in the tree.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FolderCreateEvent, FolderCreateEventFromRaw>))]
public sealed record class FolderCreateEvent : JsonModel
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

    public static implicit operator BaseWebhookEvent(FolderCreateEvent folderCreateEvent) =>
        new() { ID = folderCreateEvent.ID };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Data.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("folder.created")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FolderCreateEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("folder.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCreateEvent(FolderCreateEvent folderCreateEvent)
        : base(folderCreateEvent) { }
#pragma warning restore CS8618

    public FolderCreateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("folder.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCreateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderCreateEventFromRaw.FromRawUnchecked"/>
    public static FolderCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderCreateEventFromRaw : IFromRawJson<FolderCreateEvent>
{
    /// <inheritdoc/>
    public FolderCreateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FolderCreateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a folder is created, whether explicitly, by copying or moving
/// a folder, or implicitly when an upload creates missing parent folders. Copying
/// or moving a folder tree sends one event per folder in the tree.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FolderCreateEventFolderCreateEvent,
        FolderCreateEventFolderCreateEventFromRaw
    >)
)]
public sealed record class FolderCreateEventFolderCreateEvent : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("folder.created")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FolderCreateEventFolderCreateEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("folder.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FolderCreateEventFolderCreateEvent(
        FolderCreateEventFolderCreateEvent folderCreateEventFolderCreateEvent
    )
        : base(folderCreateEventFolderCreateEvent) { }
#pragma warning restore CS8618

    public FolderCreateEventFolderCreateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("folder.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FolderCreateEventFolderCreateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FolderCreateEventFolderCreateEventFromRaw.FromRawUnchecked"/>
    public static FolderCreateEventFolderCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FolderCreateEventFolderCreateEventFromRaw : IFromRawJson<FolderCreateEventFolderCreateEvent>
{
    /// <inheritdoc/>
    public FolderCreateEventFolderCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FolderCreateEventFolderCreateEvent.FromRawUnchecked(rawData);
}
