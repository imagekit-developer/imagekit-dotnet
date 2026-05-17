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
/// Triggered when a post-transformation completes successfully. The transformed
/// version of the file is now ready and can be accessed via the provided URL. Note
/// that each post-transformation generates a separate webhook event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEvent,
        UploadPostTransformSuccessEventFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEvent : JsonModel
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

    public required UploadPostTransformSuccessEventUploadPostTransformSuccessEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventUploadPostTransformSuccessEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        UploadPostTransformSuccessEvent uploadPostTransformSuccessEvent
    ) =>
        new()
        {
            ID = uploadPostTransformSuccessEvent.ID,
            Type = uploadPostTransformSuccessEvent.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
    }

    public UploadPostTransformSuccessEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEvent(
        UploadPostTransformSuccessEvent uploadPostTransformSuccessEvent
    )
        : base(uploadPostTransformSuccessEvent) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventFromRaw : IFromRawJson<UploadPostTransformSuccessEvent>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformSuccessEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a post-transformation completes successfully. The transformed
/// version of the file is now ready and can be accessed via the provided URL. Note
/// that each post-transformation generates a separate webhook event.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventUploadPostTransformSuccessEvent,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventUploadPostTransformSuccessEvent
    : JsonModel
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

    public required UploadPostTransformSuccessEventUploadPostTransformSuccessEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventUploadPostTransformSuccessEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest>(
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
                JsonSerializer.SerializeToElement("upload.post-transform.success")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEvent(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEvent uploadPostTransformSuccessEventUploadPostTransformSuccessEvent
    )
        : base(uploadPostTransformSuccessEventUploadPostTransformSuccessEvent) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventUploadPostTransformSuccessEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventUploadPostTransformSuccessEventFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventUploadPostTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventUploadPostTransformSuccessEventFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventUploadPostTransformSuccessEvent>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformSuccessEventUploadPostTransformSuccessEvent.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventDataFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventUploadPostTransformSuccessEventData
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
    /// URL of the generated post-transformation.
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
        _ = this.Url;
    }

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventData(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData uploadPostTransformSuccessEventUploadPostTransformSuccessEventData
    )
        : base(uploadPostTransformSuccessEventUploadPostTransformSuccessEventData) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventUploadPostTransformSuccessEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventUploadPostTransformSuccessEventDataFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventUploadPostTransformSuccessEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventUploadPostTransformSuccessEventDataFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventUploadPostTransformSuccessEventData>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventData.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
    : JsonModel
{
    public required UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation>(
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

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest uploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest
    )
        : base(uploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequest.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
    : JsonModel
{
    /// <summary>
    /// Type of the requested post-transformation.
    /// </summary>
    public required ApiEnum<
        string,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Only applicable if transformation type is 'abs'. Streaming protocol used.
    /// </summary>
    public ApiEnum<
        string,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
    >? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
                >
            >("protocol");
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

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation(
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation uploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation
    )
        : base(uploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation)
    { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation(
        ApiEnum<
            string,
            UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of the requested post-transformation.
/// </summary>
[JsonConverter(
    typeof(UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationTypeConverter)
)]
public enum UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType
{
    Transformation,
    Abs,
    GifToVideo,
    Thumbnail,
}

sealed class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationTypeConverter
    : JsonConverter<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType>
{
    public override UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transformation" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation,
            "abs" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Abs,
            "gif-to-video" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.GifToVideo,
            "thumbnail" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Thumbnail,
            _ =>
                (UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Transformation =>
                    "transformation",
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Abs =>
                    "abs",
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.GifToVideo =>
                    "gif-to-video",
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationType.Thumbnail =>
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
[JsonConverter(
    typeof(UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocolConverter)
)]
public enum UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol
{
    Hls,
    Dash,
}

sealed class UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocolConverter
    : JsonConverter<UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol>
{
    public override UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls,
            "dash" =>
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Dash,
            _ =>
                (UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Hls =>
                    "hls",
                UploadPostTransformSuccessEventUploadPostTransformSuccessEventRequestTransformationProtocol.Dash =>
                    "dash",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
