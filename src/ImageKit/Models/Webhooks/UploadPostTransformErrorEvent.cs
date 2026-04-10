using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Webhooks;

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

    public required UploadPostTransformErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Request>("request");
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
        UploadPostTransformErrorEventIntersectionMember1,
        UploadPostTransformErrorEventIntersectionMember1FromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventIntersectionMember1 : JsonModel
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

    public required UploadPostTransformErrorEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformErrorEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Request>("request");
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

    public UploadPostTransformErrorEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventIntersectionMember1(
        UploadPostTransformErrorEventIntersectionMember1 uploadPostTransformErrorEventIntersectionMember1
    )
        : base(uploadPostTransformErrorEventIntersectionMember1) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventIntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventIntersectionMember1FromRaw
    : IFromRawJson<UploadPostTransformErrorEventIntersectionMember1>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformErrorEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformErrorEventIntersectionMember1Data,
        UploadPostTransformErrorEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class UploadPostTransformErrorEventIntersectionMember1Data : JsonModel
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

    public required Transformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Transformation>("transformation");
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

    public UploadPostTransformErrorEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformErrorEventIntersectionMember1Data(
        UploadPostTransformErrorEventIntersectionMember1Data uploadPostTransformErrorEventIntersectionMember1Data
    )
        : base(uploadPostTransformErrorEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public UploadPostTransformErrorEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformErrorEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformErrorEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformErrorEventIntersectionMember1DataFromRaw
    : IFromRawJson<UploadPostTransformErrorEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public UploadPostTransformErrorEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformErrorEventIntersectionMember1Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Transformation, TransformationFromRaw>))]
public sealed record class Transformation : JsonModel
{
    public required Error Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Error>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Error.Validate();
    }

    public Transformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transformation(Transformation transformation)
        : base(transformation) { }
#pragma warning restore CS8618

    public Transformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Transformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TransformationFromRaw.FromRawUnchecked"/>
    public static Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Transformation(Error error)
        : this()
    {
        this.Error = error;
    }
}

class TransformationFromRaw : IFromRawJson<Transformation>
{
    /// <inheritdoc/>
    public Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transformation.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
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

    public Error() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error(Error error)
        : base(error) { }
#pragma warning restore CS8618

    public Error(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Error(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Error(string reason)
        : this()
    {
        this.Reason = reason;
    }
}

class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Error.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
{
    public required RequestTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RequestTransformation>("transformation");
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

    public Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Request(Request request)
        : base(request) { }
#pragma warning restore CS8618

    public Request(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Request(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestFromRaw.FromRawUnchecked"/>
    public static Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequestFromRaw : IFromRawJson<Request>
{
    /// <inheritdoc/>
    public Request FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Request.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RequestTransformation, RequestTransformationFromRaw>))]
public sealed record class RequestTransformation : JsonModel
{
    /// <summary>
    /// Type of the requested post-transformation.
    /// </summary>
    public required ApiEnum<string, global::ImageKit.Models.Webhooks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::ImageKit.Models.Webhooks.Type>
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

    public RequestTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestTransformation(RequestTransformation requestTransformation)
        : base(requestTransformation) { }
#pragma warning restore CS8618

    public RequestTransformation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestTransformation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequestTransformationFromRaw.FromRawUnchecked"/>
    public static RequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RequestTransformation(ApiEnum<string, global::ImageKit.Models.Webhooks.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class RequestTransformationFromRaw : IFromRawJson<RequestTransformation>
{
    /// <inheritdoc/>
    public RequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequestTransformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the requested post-transformation.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Transformation,
    Abs,
    GifToVideo,
    Thumbnail,
}

sealed class TypeConverter : JsonConverter<global::ImageKit.Models.Webhooks.Type>
{
    public override global::ImageKit.Models.Webhooks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transformation" => global::ImageKit.Models.Webhooks.Type.Transformation,
            "abs" => global::ImageKit.Models.Webhooks.Type.Abs,
            "gif-to-video" => global::ImageKit.Models.Webhooks.Type.GifToVideo,
            "thumbnail" => global::ImageKit.Models.Webhooks.Type.Thumbnail,
            _ => (global::ImageKit.Models.Webhooks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ImageKit.Models.Webhooks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ImageKit.Models.Webhooks.Type.Transformation => "transformation",
                global::ImageKit.Models.Webhooks.Type.Abs => "abs",
                global::ImageKit.Models.Webhooks.Type.GifToVideo => "gif-to-video",
                global::ImageKit.Models.Webhooks.Type.Thumbnail => "thumbnail",
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
