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
[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionCreatedWebhookEvent,
        FileVersionCreatedWebhookEventFromRaw
    >)
)]
public sealed record class FileVersionCreatedWebhookEvent : JsonModel
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
        FileVersionCreatedWebhookEvent fileVersionCreatedWebhookEvent
    ) =>
        new()
        {
            ID = fileVersionCreatedWebhookEvent.ID,
            Type = fileVersionCreatedWebhookEvent.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileVersionCreatedWebhookEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionCreatedWebhookEvent(
        FileVersionCreatedWebhookEvent fileVersionCreatedWebhookEvent
    )
        : base(fileVersionCreatedWebhookEvent) { }
#pragma warning restore CS8618

    public FileVersionCreatedWebhookEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionCreatedWebhookEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionCreatedWebhookEventFromRaw.FromRawUnchecked"/>
    public static FileVersionCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionCreatedWebhookEventFromRaw : IFromRawJson<FileVersionCreatedWebhookEvent>
{
    /// <inheritdoc/>
    public FileVersionCreatedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionCreatedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file version is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        FileVersionCreatedWebhookEventIntersectionMember1,
        FileVersionCreatedWebhookEventIntersectionMember1FromRaw
    >)
)]
public sealed record class FileVersionCreatedWebhookEventIntersectionMember1 : JsonModel
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

    public FileVersionCreatedWebhookEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileVersionCreatedWebhookEventIntersectionMember1(
        FileVersionCreatedWebhookEventIntersectionMember1 fileVersionCreatedWebhookEventIntersectionMember1
    )
        : base(fileVersionCreatedWebhookEventIntersectionMember1) { }
#pragma warning restore CS8618

    public FileVersionCreatedWebhookEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file-version.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileVersionCreatedWebhookEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileVersionCreatedWebhookEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static FileVersionCreatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileVersionCreatedWebhookEventIntersectionMember1FromRaw
    : IFromRawJson<FileVersionCreatedWebhookEventIntersectionMember1>
{
    /// <inheritdoc/>
    public FileVersionCreatedWebhookEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileVersionCreatedWebhookEventIntersectionMember1.FromRawUnchecked(rawData);
}
