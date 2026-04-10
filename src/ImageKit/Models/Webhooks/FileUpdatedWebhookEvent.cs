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
[JsonConverter(typeof(JsonModelConverter<FileUpdatedWebhookEvent, FileUpdatedWebhookEventFromRaw>))]
public sealed record class FileUpdatedWebhookEvent : JsonModel
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
        FileUpdatedWebhookEvent fileUpdatedWebhookEvent
    ) => new() { ID = fileUpdatedWebhookEvent.ID, Type = fileUpdatedWebhookEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileUpdatedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdatedWebhookEvent(FileUpdatedWebhookEvent fileUpdatedWebhookEvent)
        : base(fileUpdatedWebhookEvent) { }
#pragma warning restore CS8618

    public FileUpdatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static FileUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdatedWebhookEventFromRaw : IFromRawJson<FileUpdatedWebhookEvent>
{
    /// <inheritdoc/>
    public FileUpdatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUpdatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is updated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileUpdatedWebhookEventIntersectionMember1,
        FileUpdatedWebhookEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileUpdatedWebhookEventIntersectionMember1 : JsonModel
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

    public FileUpdatedWebhookEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileUpdatedWebhookEventIntersectionMember1(
        FileUpdatedWebhookEventIntersectionMember1 fileUpdatedWebhookEventIntersectionMember1
    )
        : base(fileUpdatedWebhookEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileUpdatedWebhookEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.updated");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileUpdatedWebhookEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileUpdatedWebhookEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileUpdatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileUpdatedWebhookEventIntersectionMember1FromRaw
    : IFromRawJson<FileUpdatedWebhookEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileUpdatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileUpdatedWebhookEventIntersectionMember1.FromRawUnchecked(rawData);
}
