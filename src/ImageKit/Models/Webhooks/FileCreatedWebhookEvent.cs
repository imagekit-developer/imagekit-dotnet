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
/// Triggered when a file is created.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileCreatedWebhookEvent, FileCreatedWebhookEventFromRaw>))]
public sealed record class FileCreatedWebhookEvent : JsonModel
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
        FileCreatedWebhookEvent fileCreatedWebhookEvent
    ) => new() { ID = fileCreatedWebhookEvent.ID, Type = fileCreatedWebhookEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileCreatedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCreatedWebhookEvent(FileCreatedWebhookEvent fileCreatedWebhookEvent)
        : base(fileCreatedWebhookEvent) { }
#pragma warning restore CS8618

    public FileCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static FileCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCreatedWebhookEventFromRaw : IFromRawJson<FileCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public FileCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileCreatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileCreatedWebhookEventIntersectionMember1,
        FileCreatedWebhookEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileCreatedWebhookEventIntersectionMember1 : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file.created")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public FileCreatedWebhookEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCreatedWebhookEventIntersectionMember1(
        FileCreatedWebhookEventIntersectionMember1 fileCreatedWebhookEventIntersectionMember1
    )
        : base(fileCreatedWebhookEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileCreatedWebhookEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCreatedWebhookEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCreatedWebhookEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileCreatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCreatedWebhookEventIntersectionMember1FromRaw
    : IFromRawJson<FileCreatedWebhookEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileCreatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileCreatedWebhookEventIntersectionMember1.FromRawUnchecked(rawData);
}
