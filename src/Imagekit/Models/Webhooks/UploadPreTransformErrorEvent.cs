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

    public required UploadPreTransformErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformErrorEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1Request>(
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
        UploadPreTransformErrorEventIntersectionMember1,
        UploadPreTransformErrorEventIntersectionMember1FromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventIntersectionMember1 : JsonModel
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

    public required UploadPreTransformErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPreTransformErrorEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1Request>(
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

    public UploadPreTransformErrorEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1(
        UploadPreTransformErrorEventIntersectionMember1 uploadPreTransformErrorEventIntersectionMember1
    )
        : base(uploadPreTransformErrorEventIntersectionMember1) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.pre-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventIntersectionMember1FromRaw
    : IFromRawJson<UploadPreTransformErrorEventIntersectionMember1>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventIntersectionMember1Data,
        UploadPreTransformErrorEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventIntersectionMember1Data : JsonModel
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

    public required UploadPreTransformErrorEventIntersectionMember1DataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1DataTransformation>(
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

    public UploadPreTransformErrorEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1Data(
        UploadPreTransformErrorEventIntersectionMember1Data uploadPreTransformErrorEventIntersectionMember1Data
    )
        : base(uploadPreTransformErrorEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventIntersectionMember1DataFromRaw
    : IFromRawJson<UploadPreTransformErrorEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventIntersectionMember1Data.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventIntersectionMember1DataTransformation,
        UploadPreTransformErrorEventIntersectionMember1DataTransformationFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventIntersectionMember1DataTransformation
    : JsonModel
{
    public required UploadPreTransformErrorEventIntersectionMember1DataTransformationError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPreTransformErrorEventIntersectionMember1DataTransformationError>(
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

    public UploadPreTransformErrorEventIntersectionMember1DataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1DataTransformation(
        UploadPreTransformErrorEventIntersectionMember1DataTransformation uploadPreTransformErrorEventIntersectionMember1DataTransformation
    )
        : base(uploadPreTransformErrorEventIntersectionMember1DataTransformation) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventIntersectionMember1DataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventIntersectionMember1DataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventIntersectionMember1DataTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1DataTransformation(
        UploadPreTransformErrorEventIntersectionMember1DataTransformationError error
    )
        : this()
    {
        this.Error = error;
    }
}

class UploadPreTransformErrorEventIntersectionMember1DataTransformationFromRaw
    : IFromRawJson<UploadPreTransformErrorEventIntersectionMember1DataTransformation>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventIntersectionMember1DataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPreTransformErrorEventIntersectionMember1DataTransformation.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventIntersectionMember1DataTransformationError,
        UploadPreTransformErrorEventIntersectionMember1DataTransformationErrorFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventIntersectionMember1DataTransformationError
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

    public UploadPreTransformErrorEventIntersectionMember1DataTransformationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
        UploadPreTransformErrorEventIntersectionMember1DataTransformationError uploadPreTransformErrorEventIntersectionMember1DataTransformationError
    )
        : base(uploadPreTransformErrorEventIntersectionMember1DataTransformationError) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventIntersectionMember1DataTransformationError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventIntersectionMember1DataTransformationErrorFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventIntersectionMember1DataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1DataTransformationError(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class UploadPreTransformErrorEventIntersectionMember1DataTransformationErrorFromRaw
    : IFromRawJson<UploadPreTransformErrorEventIntersectionMember1DataTransformationError>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventIntersectionMember1DataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPreTransformErrorEventIntersectionMember1DataTransformationError.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPreTransformErrorEventIntersectionMember1Request,
        UploadPreTransformErrorEventIntersectionMember1RequestFromRaw
    >)
)]
public sealed record class UploadPreTransformErrorEventIntersectionMember1Request : JsonModel
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

    public UploadPreTransformErrorEventIntersectionMember1Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPreTransformErrorEventIntersectionMember1Request(
        UploadPreTransformErrorEventIntersectionMember1Request uploadPreTransformErrorEventIntersectionMember1Request
    )
        : base(uploadPreTransformErrorEventIntersectionMember1Request) { }
#pragma warning restore CS8618

    public UploadPreTransformErrorEventIntersectionMember1Request(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPreTransformErrorEventIntersectionMember1Request(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPreTransformErrorEventIntersectionMember1RequestFromRaw.FromRawUnchecked"/>
    public static UploadPreTransformErrorEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPreTransformErrorEventIntersectionMember1RequestFromRaw
    : IFromRawJson<UploadPreTransformErrorEventIntersectionMember1Request>
{
    /// <inheritdoc/>
    public UploadPreTransformErrorEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPreTransformErrorEventIntersectionMember1Request.FromRawUnchecked(rawData);
}
