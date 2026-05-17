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
/// Triggered when a pre-transformation fails. The file upload may have been accepted,
/// but the requested transformation could not be applied.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UploadPreTransformErrorEvent, UploadPreTransformErrorEventFromRaw>)
)]
public sealed record class UploadPreTransformErrorEvent : JsonModel
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

    public required UploadPreTransformErrorEventUploadPreTransformErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformErrorEventUploadPreTransformErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        UploadPreTransformErrorEvent uploadPreTransformErrorEvent
    ) => new() { ID = uploadPreTransformErrorEvent.ID, Type = uploadPreTransformErrorEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public UploadPreTransformErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEvent(UploadPreTransformErrorEvent uploadPreTransformErrorEvent)
        : base(uploadPreTransformErrorEvent) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventFromRaw : IFromRawJson<UploadPreTransformErrorEvent>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a pre-transformation fails. The file upload may have been accepted,
/// but the requested transformation could not be applied.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventUploadPreTransformErrorEvent,
        UploadPreTransformErrorEventUploadPreTransformErrorEventFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventUploadPreTransformErrorEvent : JsonModel
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

    public required UploadPreTransformErrorEventUploadPreTransformErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformErrorEventUploadPreTransformErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

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
        this.Request.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("upload.pre-transform.error")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public UploadPreTransformErrorEventUploadPreTransformErrorEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEvent(
        UploadPreTransformErrorEventUploadPreTransformErrorEvent uploadPreTransformErrorEventUploadPreTransformErrorEvent
    )
        : base(uploadPreTransformErrorEventUploadPreTransformErrorEvent) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventUploadPreTransformErrorEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventUploadPreTransformErrorEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventUploadPreTransformErrorEventFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventUploadPreTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventUploadPreTransformErrorEventFromRaw
    : IFromRawJson<UploadPreTransformErrorEventUploadPreTransformErrorEvent>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventUploadPreTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventUploadPreTransformErrorEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventUploadPreTransformErrorEventData,
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventUploadPreTransformErrorEventData : JsonModel
{
    /// <summary>
    /// Name of the file.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Path of the file.
    /// </summary>
    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    public required UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation>(
                "transformation"
            );
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Path;
        this.Transformation.Validate();
    }

    public UploadPreTransformErrorEventUploadPreTransformErrorEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventData(
        UploadPreTransformErrorEventUploadPreTransformErrorEventData uploadPreTransformErrorEventUploadPreTransformErrorEventData
    )
        : base(uploadPreTransformErrorEventUploadPreTransformErrorEventData) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventUploadPreTransformErrorEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventUploadPreTransformErrorEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventUploadPreTransformErrorEventDataFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventUploadPreTransformErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventUploadPreTransformErrorEventDataFromRaw
    : IFromRawJson<UploadPreTransformErrorEventUploadPreTransformErrorEventData>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventUploadPreTransformErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventUploadPreTransformErrorEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation,
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation
    : JsonModel
{
    public required UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
    }

    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation(
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation uploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation
    )
        : base(uploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation(
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError error
    )
        : this()
    {
        this.Error = error;
    }
}

class UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationFromRaw
    : IFromRawJson<UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError,
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationErrorFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError
    : JsonModel
{
    /// <summary>
    /// Reason for the pre-transformation failure.
    /// </summary>
    public required string Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError(
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError uploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError
    )
        : base(uploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationErrorFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError(
        string reason
    )
        : this()
    {
        this.Reason = reason;
    }
}

class UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationErrorFromRaw
    : IFromRawJson<UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPreTransformErrorEventUploadPreTransformErrorEventDataTransformationError.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventUploadPreTransformErrorEventRequest,
        UploadPreTransformErrorEventUploadPreTransformErrorEventRequestFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventUploadPreTransformErrorEventRequest
    : JsonModel
{
    /// <summary>
    /// The requested pre-transformation string.
    /// </summary>
    public required string Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("transformation");
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <summary>
    /// Unique identifier for the originating request.
    /// </summary>
    public required string XRequestID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("x_request_id");
        }
        init { this._rawData.Set("x_request_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Transformation;
        _ = this.XRequestID;
    }

    public UploadPreTransformErrorEventUploadPreTransformErrorEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventUploadPreTransformErrorEventRequest(
        UploadPreTransformErrorEventUploadPreTransformErrorEventRequest uploadPreTransformErrorEventUploadPreTransformErrorEventRequest
    )
        : base(uploadPreTransformErrorEventUploadPreTransformErrorEventRequest) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventUploadPreTransformErrorEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventUploadPreTransformErrorEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventUploadPreTransformErrorEventRequestFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventUploadPreTransformErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventUploadPreTransformErrorEventRequestFromRaw
    : IFromRawJson<UploadPreTransformErrorEventUploadPreTransformErrorEventRequest>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventUploadPreTransformErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventUploadPreTransformErrorEventRequest.FromRawUnchecked(rawData);
}
