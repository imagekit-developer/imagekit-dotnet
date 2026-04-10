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
    typeof(JsonModelConverter<
        FileVersionDeletedWebhookEvent,
        FileVersionDeletedWebhookEventFromRaw
    >)
)]
public sealed record class FileVersionDeletedWebhookEvent : JsonModel
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

    public required FileVersionDeletedWebhookEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileVersionDeletedWebhookEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public static implicit operator BaseWebhookEvent(
        FileVersionDeletedWebhookEvent fileVersionDeletedWebhookEvent
    ) =>
        new()
        {
            ID = fileVersionDeletedWebhookEvent.ID,
            Type = fileVersionDeletedWebhookEvent.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileVersionDeletedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeletedWebhookEvent(
        FileVersionDeletedWebhookEvent fileVersionDeletedWebhookEvent
    )
        : base(fileVersionDeletedWebhookEvent) { }
#pragma warning restore CS8618

    public FileVersionDeletedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeletedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static FileVersionDeletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeletedWebhookEventFromRaw : IFromRawJson<FileVersionDeletedWebhookEvent>
{
    /// <inheritdoc/>
    public FileVersionDeletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeletedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionDeletedWebhookEventIntersectionMember1,
        FileVersionDeletedWebhookEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileVersionDeletedWebhookEventIntersectionMember1 : JsonModel
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

    public required FileVersionDeletedWebhookEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FileVersionDeletedWebhookEventIntersectionMember1Data>(
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

    public FileVersionDeletedWebhookEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeletedWebhookEventIntersectionMember1(
        FileVersionDeletedWebhookEventIntersectionMember1 fileVersionDeletedWebhookEventIntersectionMember1
    )
        : base(fileVersionDeletedWebhookEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileVersionDeletedWebhookEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeletedWebhookEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeletedWebhookEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileVersionDeletedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeletedWebhookEventIntersectionMember1FromRaw
    : IFromRawJson<FileVersionDeletedWebhookEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileVersionDeletedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeletedWebhookEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionDeletedWebhookEventIntersectionMember1Data,
        FileVersionDeletedWebhookEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class FileVersionDeletedWebhookEventIntersectionMember1Data : JsonModel
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

    public FileVersionDeletedWebhookEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionDeletedWebhookEventIntersectionMember1Data(
        FileVersionDeletedWebhookEventIntersectionMember1Data fileVersionDeletedWebhookEventIntersectionMember1Data
    )
        : base(fileVersionDeletedWebhookEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public FileVersionDeletedWebhookEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionDeletedWebhookEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionDeletedWebhookEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static FileVersionDeletedWebhookEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionDeletedWebhookEventIntersectionMember1DataFromRaw
    : IFromRawJson<FileVersionDeletedWebhookEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public FileVersionDeletedWebhookEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionDeletedWebhookEventIntersectionMember1Data.FromRawUnchecked(rawData);
}
