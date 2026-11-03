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
/// Triggered when a new asynchronous image transformation request is accepted for
/// processing. This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationAcceptedEvent,
        ImageAsyncTransformationAcceptedEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationAcceptedEvent : JsonModel
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
    /// Timestamp when the event was created in ISO8601 format.
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

    public required ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
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
        ImageAsyncTransformationAcceptedEvent imageAsyncTransformationAcceptedEvent
    ) =>
        new()
        {
            ID = imageAsyncTransformationAcceptedEvent.ID,
            Type = imageAsyncTransformationAcceptedEvent.Type,
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

    public ImageAsyncTransformationAcceptedEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationAcceptedEvent(
        ImageAsyncTransformationAcceptedEvent imageAsyncTransformationAcceptedEvent
    )
        : base(imageAsyncTransformationAcceptedEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationAcceptedEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationAcceptedEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationAcceptedEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationAcceptedEventFromRaw
    : IFromRawJson<ImageAsyncTransformationAcceptedEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageAsyncTransformationAcceptedEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when a new asynchronous image transformation request is accepted for
/// processing. This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent,
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
    : JsonModel
{
    /// <summary>
    /// Timestamp when the event was created in ISO8601 format.
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

    public required ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
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
                JsonSerializer.SerializeToElement("image.async-transformation.accepted")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.accepted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent(
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent imageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent
    )
        : base(imageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.accepted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventFromRaw
    : IFromRawJson<ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEvent.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData,
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventDataFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source image asset being transformed.
    /// </summary>
    public required Asset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Asset>("asset");
        }
        init { this._rawData.Set("asset", value); }
    }

    /// <summary>
    /// Base information about an image transformation request.
    /// </summary>
    public required Transformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Transformation>("transformation");
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Asset.Validate();
        this.Transformation.Validate();
    }

    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData(
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData imageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData
    )
        : base(imageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventDataFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventDataFromRaw
    : IFromRawJson<ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationAcceptedEventImageAsyncTransformationAcceptedEventData.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the source image asset being transformed.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Asset, AssetFromRaw>))]
public sealed record class Asset : JsonModel
{
    /// <summary>
    /// URL of the source image, without the transformation.
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
        _ = this.Url;
    }

    public Asset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Asset(Asset asset)
        : base(asset) { }
#pragma warning restore CS8618

    public Asset(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Asset(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AssetFromRaw.FromRawUnchecked"/>
    public static Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Asset(string url)
        : this()
    {
        this.Url = url;
    }
}

class AssetFromRaw : IFromRawJson<Asset>
{
    /// <inheritdoc/>
    public Asset FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Asset.FromRawUnchecked(rawData);
}

/// <summary>
/// Base information about an image transformation request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Transformation, TransformationFromRaw>))]
public sealed record class Transformation : JsonModel
{
    /// <summary>
    /// Type of transformation. Always `image-transformation`.
    /// </summary>
    public required ApiEnum<string, global::Imagekit.Models.Webhooks.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Imagekit.Models.Webhooks.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Options of the requested transformation.
    /// </summary>
    public Options? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Options>("options");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("options", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Options?.Validate();
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
    public Transformation(ApiEnum<string, global::Imagekit.Models.Webhooks.Type> type)
        : this()
    {
        this.Type = type;
    }
}

class TransformationFromRaw : IFromRawJson<Transformation>
{
    /// <inheritdoc/>
    public Transformation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Transformation.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of transformation. Always `image-transformation`.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ImageTransformation,
}

sealed class TypeConverter : JsonConverter<global::Imagekit.Models.Webhooks.Type>
{
    public override global::Imagekit.Models.Webhooks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image-transformation" => global::Imagekit.Models.Webhooks.Type.ImageTransformation,
            _ => (global::Imagekit.Models.Webhooks.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Imagekit.Models.Webhooks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Imagekit.Models.Webhooks.Type.ImageTransformation => "image-transformation",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Options of the requested transformation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Options, OptionsFromRaw>))]
public sealed record class Options : JsonModel
{
    /// <summary>
    /// The transformation string from the request URL, for example `e-removedotbg`.
    /// Not present if the URL has no transformation.
    /// </summary>
    public string? Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("transformation");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("transformation", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Transformation;
    }

    public Options() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Options(Options options)
        : base(options) { }
#pragma warning restore CS8618

    public Options(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Options(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OptionsFromRaw.FromRawUnchecked"/>
    public static Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OptionsFromRaw : IFromRawJson<Options>
{
    /// <inheritdoc/>
    public Options FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Options.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the original request that triggered the image transformation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Request, RequestFromRaw>))]
public sealed record class Request : JsonModel
{
    /// <summary>
    /// Full URL of the transformation request that was submitted.
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

    /// <summary>
    /// Unique identifier for the originating transformation request.
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

    /// <summary>
    /// User-Agent header from the original request that triggered the transformation.
    /// </summary>
    public string? UserAgent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_agent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_agent", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.XRequestID;
        _ = this.UserAgent;
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
