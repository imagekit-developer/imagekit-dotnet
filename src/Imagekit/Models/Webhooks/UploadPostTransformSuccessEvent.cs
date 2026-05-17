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

    public required UploadPostTransformSuccessEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformSuccessEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventIntersectionMember1Request>(
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
        UploadPostTransformSuccessEventIntersectionMember1,
        UploadPostTransformSuccessEventIntersectionMember1FromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventIntersectionMember1 : JsonModel
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

    public required UploadPostTransformSuccessEventIntersectionMember1Data Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventIntersectionMember1Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    public required UploadPostTransformSuccessEventIntersectionMember1Request Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventIntersectionMember1Request>(
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

    public UploadPostTransformSuccessEventIntersectionMember1()
    {
        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventIntersectionMember1(
        UploadPostTransformSuccessEventIntersectionMember1 uploadPostTransformSuccessEventIntersectionMember1
    )
        : base(uploadPostTransformSuccessEventIntersectionMember1) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventIntersectionMember1(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("upload.post-transform.success");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventIntersectionMember1(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventIntersectionMember1FromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventIntersectionMember1FromRaw
    : IFromRawJson<UploadPostTransformSuccessEventIntersectionMember1>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventIntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformSuccessEventIntersectionMember1.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventIntersectionMember1Data,
        UploadPostTransformSuccessEventIntersectionMember1DataFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventIntersectionMember1Data : JsonModel
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

    public UploadPostTransformSuccessEventIntersectionMember1Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventIntersectionMember1Data(
        UploadPostTransformSuccessEventIntersectionMember1Data uploadPostTransformSuccessEventIntersectionMember1Data
    )
        : base(uploadPostTransformSuccessEventIntersectionMember1Data) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventIntersectionMember1Data(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventIntersectionMember1Data(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventIntersectionMember1DataFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventIntersectionMember1DataFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventIntersectionMember1Data>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventIntersectionMember1Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformSuccessEventIntersectionMember1Data.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventIntersectionMember1Request,
        UploadPostTransformSuccessEventIntersectionMember1RequestFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventIntersectionMember1Request : JsonModel
{
    public required UploadPostTransformSuccessEventIntersectionMember1RequestTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UploadPostTransformSuccessEventIntersectionMember1RequestTransformation>(
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

    public UploadPostTransformSuccessEventIntersectionMember1Request() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventIntersectionMember1Request(
        UploadPostTransformSuccessEventIntersectionMember1Request uploadPostTransformSuccessEventIntersectionMember1Request
    )
        : base(uploadPostTransformSuccessEventIntersectionMember1Request) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventIntersectionMember1Request(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventIntersectionMember1Request(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventIntersectionMember1RequestFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UploadPostTransformSuccessEventIntersectionMember1RequestFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventIntersectionMember1Request>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventIntersectionMember1Request FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UploadPostTransformSuccessEventIntersectionMember1Request.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation,
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationFromRaw
    >)
)]
public sealed record class UploadPostTransformSuccessEventIntersectionMember1RequestTransformation
    : JsonModel
{
    /// <summary>
    /// Type of the requested post-transformation.
    /// </summary>
    public required ApiEnum<
        string,
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
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
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
    >? Protocol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<
                    string,
                    UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
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

    public UploadPostTransformSuccessEventIntersectionMember1RequestTransformation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventIntersectionMember1RequestTransformation(
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation uploadPostTransformSuccessEventIntersectionMember1RequestTransformation
    )
        : base(uploadPostTransformSuccessEventIntersectionMember1RequestTransformation) { }
#pragma warning restore CS8618

    public UploadPostTransformSuccessEventIntersectionMember1RequestTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPostTransformSuccessEventIntersectionMember1RequestTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UploadPostTransformSuccessEventIntersectionMember1RequestTransformationFromRaw.FromRawUnchecked"/>
    public static UploadPostTransformSuccessEventIntersectionMember1RequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UploadPostTransformSuccessEventIntersectionMember1RequestTransformation(
        ApiEnum<
            string,
            UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationFromRaw
    : IFromRawJson<UploadPostTransformSuccessEventIntersectionMember1RequestTransformation>
{
    /// <inheritdoc/>
    public UploadPostTransformSuccessEventIntersectionMember1RequestTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of the requested post-transformation.
/// </summary>
[JsonConverter(
    typeof(UploadPostTransformSuccessEventIntersectionMember1RequestTransformationTypeConverter)
)]
public enum UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType
{
    Transformation,
    Abs,
    GifToVideo,
    Thumbnail,
}

sealed class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationTypeConverter
    : JsonConverter<UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType>
{
    public override UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "transformation" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation,
            "abs" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Abs,
            "gif-to-video" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.GifToVideo,
            "thumbnail" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Thumbnail,
            _ => (UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Transformation =>
                    "transformation",
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Abs =>
                    "abs",
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.GifToVideo =>
                    "gif-to-video",
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationType.Thumbnail =>
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
    typeof(UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocolConverter)
)]
public enum UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol
{
    Hls,
    Dash,
}

sealed class UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocolConverter
    : JsonConverter<UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol>
{
    public override UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hls" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls,
            "dash" =>
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Dash,
            _ => (UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol)(
                -1
            ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Hls =>
                    "hls",
                UploadPostTransformSuccessEventIntersectionMember1RequestTransformationProtocol.Dash =>
                    "dash",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
