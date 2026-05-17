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
/// Triggered when a file version is deleted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileVersionDeleteEvent, FileVersionDeleteEventFromRaw>))]
public sealed record class FileVersionDeleteEvent : JsonModel
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

    public required FileVersionDeleteEventFileVersionDeleteEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileVersionDeleteEventFileVersionDeleteEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(
        FileVersionDeleteEvent fileVersionDeleteEvent
    ) => new() { ID = fileVersionDeleteEvent.ID, Type = fileVersionDeleteEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileVersionDeleteEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeleteEvent(FileVersionDeleteEvent fileVersionDeleteEvent)
        : base(fileVersionDeleteEvent) { }
#pragma warning restore CS8618

    public FileVersionDeleteEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeleteEventFromRaw.FromRawUnchecked"/>
    public static FileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeleteEventFromRaw : IFromRawJson<FileVersionDeleteEvent>
{
    /// <inheritdoc/>
    public FileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeleteEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionDeleteEventFileVersionDeleteEvent,
        FileVersionDeleteEventFileVersionDeleteEventFromRaw
    >)
)]
public sealed record class FileVersionDeleteEventFileVersionDeleteEvent : JsonModel
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

    public required FileVersionDeleteEventFileVersionDeleteEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileVersionDeleteEventFileVersionDeleteEventData>(
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

    public FileVersionDeleteEventFileVersionDeleteEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeleteEventFileVersionDeleteEvent(
        FileVersionDeleteEventFileVersionDeleteEvent fileVersionDeleteEventFileVersionDeleteEvent
    )
        : base(fileVersionDeleteEventFileVersionDeleteEvent) { }
#pragma warning restore CS8618

    public FileVersionDeleteEventFileVersionDeleteEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeleteEventFileVersionDeleteEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeleteEventFileVersionDeleteEventFromRaw.FromRawUnchecked"/>
    public static FileVersionDeleteEventFileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeleteEventFileVersionDeleteEventFromRaw
    : IFromRawJson<FileVersionDeleteEventFileVersionDeleteEvent>
{
    /// <inheritdoc/>
    public FileVersionDeleteEventFileVersionDeleteEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeleteEventFileVersionDeleteEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionDeleteEventFileVersionDeleteEventData,
        FileVersionDeleteEventFileVersionDeleteEventDataFromRaw
    >)
)]
public sealed record class FileVersionDeleteEventFileVersionDeleteEventData : JsonModel
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

    public FileVersionDeleteEventFileVersionDeleteEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeleteEventFileVersionDeleteEventData(
        FileVersionDeleteEventFileVersionDeleteEventData fileVersionDeleteEventFileVersionDeleteEventData
    )
        : base(fileVersionDeleteEventFileVersionDeleteEventData) { }
#pragma warning restore CS8618

    public FileVersionDeleteEventFileVersionDeleteEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeleteEventFileVersionDeleteEventData(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeleteEventFileVersionDeleteEventDataFromRaw.FromRawUnchecked"/>
    public static FileVersionDeleteEventFileVersionDeleteEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeleteEventFileVersionDeleteEventDataFromRaw
    : IFromRawJson<FileVersionDeleteEventFileVersionDeleteEventData>
{
    /// <inheritdoc/>
    public FileVersionDeleteEventFileVersionDeleteEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeleteEventFileVersionDeleteEventData.FromRawUnchecked(rawData);
}
