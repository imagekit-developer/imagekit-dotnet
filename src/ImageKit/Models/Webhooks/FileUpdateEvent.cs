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
/// Triggered when a file is updated.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileUpdateEvent, FileUpdateEventFromRaw>))]
public sealed record class FileUpdateEvent : JsonModel
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

    public static implicit operator BaseWebhookEvent(FileUpdateEvent fileUpdateEvent) =>
        new() { ID = fileUpdateEvent.ID, Type = fileUpdateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileUpdateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdateEvent(FileUpdateEvent fileUpdateEvent)
        : base(fileUpdateEvent) { }
#pragma warning restore CS8618

    public FileUpdateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdateEventFromRaw.FromRawUnchecked"/>
    public static FileUpdateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdateEventFromRaw : IFromRawJson<FileUpdateEvent>
{
    /// <inheritdoc/>
    public FileUpdateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileUpdateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is updated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileUpdateEventIntersectionMember1,
        FileUpdateEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileUpdateEventIntersectionMember1 : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file.updated")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FileUpdateEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdateEventIntersectionMember1(
        FileUpdateEventIntersectionMember1 fileUpdateEventIntersectionMember1
    )
        : base(fileUpdateEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileUpdateEventIntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdateEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdateEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileUpdateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdateEventIntersectionMember1FromRaw : IFromRawJson<FileUpdateEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileUpdateEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUpdateEventIntersectionMember1.FromRawUnchecked(rawData);
}
