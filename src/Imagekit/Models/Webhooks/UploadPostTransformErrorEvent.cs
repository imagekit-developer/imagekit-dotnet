using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a post-transformation fails. The original file remains available,
/// but the requested transformation could not be generated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<UploadPostTransformErrorEvent, UploadPostTransformErrorEventFromRaw>)
)]
public sealed record class UploadPostTransformErrorEvent : JsonModel
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
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required UploadPostTransformErrorEventUploadPostTransformErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformErrorEventUploadPostTransformErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        UploadPostTransformErrorEvent uploadPostTransformErrorEvent
    ) => new() { ID = uploadPostTransformErrorEvent.ID, Type = uploadPostTransformErrorEvent.Type };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public UploadPostTransformErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEvent(
        UploadPostTransformErrorEvent uploadPostTransformErrorEvent
    )
        : base(uploadPostTransformErrorEvent) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventFromRaw : IFromRawJson<UploadPostTransformErrorEvent>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformErrorEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a post-transformation fails. The original file remains available,
/// but the requested transformation could not be generated.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEvent,
        UploadPostTransformErrorEventUploadPostTransformErrorEventFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEvent : JsonModel
{
    /// <summary>
    /// Timestamp of when the event occurred in ISO8601 format.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required UploadPostTransformErrorEventUploadPostTransformErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformErrorEventUploadPostTransformErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventRequest>(
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
                JsonSerializer.SerializeToElement("upload.post-transform.error")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public UploadPostTransformErrorEventUploadPostTransformErrorEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEvent(
        UploadPostTransformErrorEventUploadPostTransformErrorEvent uploadPostTransformErrorEventUploadPostTransformErrorEvent
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEvent) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEvent>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformErrorEventUploadPostTransformErrorEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEventData,
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEventData
    : JsonModel
{
    /// <summary>
    /// Unique identifier of the originally uploaded file.
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

    public required UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation>(
                "transformation"
            );
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <summary>
    /// URL of the attempted post-transformation.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        _ = this.Name;
        _ = this.Path;
        this.Transformation.Validate();
        _ = this.Url;
    }

    public UploadPostTransformErrorEventUploadPostTransformErrorEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventData(
        UploadPostTransformErrorEventUploadPostTransformErrorEventData uploadPostTransformErrorEventUploadPostTransformErrorEventData
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEventData) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventDataFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventDataFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEventData>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformErrorEventUploadPostTransformErrorEventData.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation,
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
    : JsonModel
{
    public required UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError>(
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

    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation(
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation uploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation(
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError error
    )
        : this()
    {
        this.Error = error;
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError,
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationErrorFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
    : JsonModel
{
    /// <summary>
    /// Reason for the post-transformation failure.
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

    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError uploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError)
    { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationErrorFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError(
        string reason
    )
        : this()
    {
        this.Reason = reason;
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationErrorFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformErrorEventUploadPostTransformErrorEventDataTransformationError.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest,
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEventRequest
    : JsonModel
{
    public required UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation>(
                "transformation"
            );
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
        this.Transformation.Validate();
        _ = this.XRequestID;
    }

    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequest(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest uploadPostTransformErrorEventUploadPostTransformErrorEventRequest
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEventRequest) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventRequestFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEventRequest>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequest.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation,
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
    : JsonModel
{
    /// <summary>
    /// Type of the requested post-transformation.
    /// </summary>
    public required ApiEnum<
        string,
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Only applicable if transformation type is 'abs'. Streaming protocol used.
    /// </summary>
    public ApiEnum<string, Protocol>? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Protocol>>("protocol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("protocol", value);
        }
    }

    /// <summary>
    /// Value for the requested transformation type.
    /// </summary>
    public string? Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("value");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Protocol?.Validate();
        _ = this.Value;
    }

    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation(
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation uploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation
    )
        : base(uploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation(
        ApiEnum<
            string,
            UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationFromRaw
    : IFromRawJson<UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of the requested post-transformation.
/// </summary>
[JsonConverter(
    typeof(UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationTypeConverter)
)]
public enum UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType
{
    Transformation,
    Abs,
    GifToVideo,
    Thumbnail,
}

sealed class UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationTypeConverter
    : JsonConverter<UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType>
{
    public override UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transformation" =>
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation,
            "abs" =>
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Abs,
            "gif-to-video" =>
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.GifToVideo,
            "thumbnail" =>
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Thumbnail,
            _ =>
                (UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Transformation =>
                    "transformation",
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Abs =>
                    "abs",
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.GifToVideo =>
                    "gif-to-video",
                UploadPostTransformErrorEventUploadPostTransformErrorEventRequestTransformationType.Thumbnail =>
                    "thumbnail",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Only applicable if transformation type is 'abs'. Streaming protocol used.
/// </summary>
[JsonConverter(typeof(ProtocolConverter))]
public enum Protocol
{
    Hls,
    Dash,
}

sealed class ProtocolConverter : JsonConverter<Protocol>
{
    public override Protocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" => Protocol.Hls,
            "dash" => Protocol.Dash,
            _ => (Protocol)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Protocol value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Protocol.Hls => "hls",
                Protocol.Dash => "dash",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
