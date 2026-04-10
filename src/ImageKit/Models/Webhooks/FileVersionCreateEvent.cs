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
/// Triggered when a file version is created.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileVersionCreateEvent, FileVersionCreateEventFromRaw>))]
public sealed record class FileVersionCreateEvent : JsonModel
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

    public static implicit operator BaseWebhookEvent(
        FileVersionCreateEvent fileVersionCreateEvent
    ) => new() { ID = fileVersionCreateEvent.ID, Type = fileVersionCreateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileVersionCreateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionCreateEvent(FileVersionCreateEvent fileVersionCreateEvent)
        : base(fileVersionCreateEvent) { }
#pragma warning restore CS8618

    public FileVersionCreateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionCreateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionCreateEventFromRaw.FromRawUnchecked"/>
    public static FileVersionCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionCreateEventFromRaw : IFromRawJson<FileVersionCreateEvent>
{
    /// <inheritdoc/>
    public FileVersionCreateEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionCreateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionCreateEventIntersectionMember1,
        FileVersionCreateEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileVersionCreateEventIntersectionMember1 : JsonModel
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

    public FileVersionCreateEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionCreateEventIntersectionMember1(
        FileVersionCreateEventIntersectionMember1 fileVersionCreateEventIntersectionMember1
    )
        : base(fileVersionCreateEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileVersionCreateEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionCreateEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionCreateEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileVersionCreateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionCreateEventIntersectionMember1FromRaw
    : IFromRawJson<FileVersionCreateEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileVersionCreateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionCreateEventIntersectionMember1.FromRawUnchecked(rawData);
}
