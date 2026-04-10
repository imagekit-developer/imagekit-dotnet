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
[JsonConverter(typeof(JsonModelConverter<FileCreateEvent, FileCreateEventFromRaw>))]
public sealed record class FileCreateEvent : JsonModel
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

    public static implicit operator BaseWebhookEvent(FileCreateEvent fileCreateEvent) =>
        new() { ID = fileCreateEvent.ID, Type = fileCreateEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
    }

    public FileCreateEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCreateEvent(FileCreateEvent fileCreateEvent)
        : base(fileCreateEvent) { }
#pragma warning restore CS8618

    public FileCreateEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCreateEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileCreateEventFromRaw.FromRawUnchecked"/>
    public static FileCreateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileCreateEventFromRaw : IFromRawJson<FileCreateEvent>
{
    /// <inheritdoc/>
    public FileCreateEvent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileCreateEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a file is created.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::ImageKit.Models.Webhooks.IntersectionMember1,
        global::ImageKit.Models.Webhooks.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
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

    public IntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("file.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(
        global::ImageKit.Models.Webhooks.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }
#pragma warning restore CS8618

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file.created");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::ImageKit.Models.Webhooks.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::ImageKit.Models.Webhooks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw
    : IFromRawJson<global::ImageKit.Models.Webhooks.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::ImageKit.Models.Webhooks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::ImageKit.Models.Webhooks.IntersectionMember1.FromRawUnchecked(rawData);
}
