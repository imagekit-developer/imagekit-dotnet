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
/// Triggered when an asynchronous image transformation fails. Listen to this webhook
/// to log error reasons and debug issues. Check your origin and URL endpoint settings
/// if the reason is related to download failure. For other errors, contact ImageKit
/// support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEvent,
        ImageAsyncTransformationErrorEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEvent : JsonModel
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

    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    public static implicit operator BaseWebhookEvent(
        ImageAsyncTransformationErrorEvent imageAsyncTransformationErrorEvent
    ) =>
        new()
        {
            ID = imageAsyncTransformationErrorEvent.ID,
            Type = imageAsyncTransformationErrorEvent.Type,
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

    public ImageAsyncTransformationErrorEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEvent(
        ImageAsyncTransformationErrorEvent imageAsyncTransformationErrorEvent
    )
        : base(imageAsyncTransformationErrorEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationErrorEventFromRaw : IFromRawJson<ImageAsyncTransformationErrorEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageAsyncTransformationErrorEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when an asynchronous image transformation fails. Listen to this webhook
/// to log error reasons and debug issues. Check your origin and URL endpoint settings
/// if the reason is related to download failure. For other errors, contact ImageKit
/// support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
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

    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest>(
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
                JsonSerializer.SerializeToElement("image.async-transformation.error")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
    }

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent imageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent
    )
        : base(imageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEvent.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source image asset being transformed.
    /// </summary>
    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation>(
                "transformation"
            );
        }
        init { this._rawData.Set("transformation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Asset.Validate();
        this.Transformation.Validate();
    }

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData
    )
        : base(imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventData.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the source image asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAssetFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
    : JsonModel
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

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset
    )
        : base(imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAssetFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAssetFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataAsset.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of transformation. Always `image-transformation`.
    /// </summary>
    public required ApiEnum<
        string,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Details about the transformation error.
    /// </summary>
    public Error? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Error>("error");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("error", value);
        }
    }

    /// <summary>
    /// Options of the requested transformation.
    /// </summary>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions>(
                "options"
            );
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
        this.Error?.Validate();
        this.Options?.Validate();
    }

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
    )
        : base(
            imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation
        ) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation(
        ApiEnum<
            string,
            ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of transformation. Always `image-transformation`.
/// </summary>
[JsonConverter(
    typeof(ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationTypeConverter)
)]
public enum ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType
{
    ImageTransformation,
}

sealed class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationTypeConverter
    : JsonConverter<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType>
{
    public override ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image-transformation" =>
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation,
            _ =>
                (ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationType.ImageTransformation =>
                    "image-transformation",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Details about the transformation error.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Specific reason for the transformation failure: - `download_failed`: Could
    /// not download the source image - `invalid_transformation`: The requested transformation
    /// is invalid - `limit_exceeded`: The source image or transformation exceeds
    /// a limit - `internal_server_error`: Unexpected server error
    /// </summary>
    public required ApiEnum<string, Reason> Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// A description of the error, when available.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Reason.Validate();
        _ = this.Message;
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
    public Error(ApiEnum<string, Reason> reason)
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

/// <summary>
/// Specific reason for the transformation failure: - `download_failed`: Could not
/// download the source image - `invalid_transformation`: The requested transformation
/// is invalid - `limit_exceeded`: The source image or transformation exceeds a limit
/// - `internal_server_error`: Unexpected server error
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    DownloadFailed,
    InvalidTransformation,
    LimitExceeded,
    InternalServerError,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "download_failed" => Reason.DownloadFailed,
            "invalid_transformation" => Reason.InvalidTransformation,
            "limit_exceeded" => Reason.LimitExceeded,
            "internal_server_error" => Reason.InternalServerError,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.DownloadFailed => "download_failed",
                Reason.InvalidTransformation => "invalid_transformation",
                Reason.LimitExceeded => "limit_exceeded",
                Reason.InternalServerError => "internal_server_error",
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
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptionsFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
    : JsonModel
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

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
    )
        : base(
            imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions
        ) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptionsFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventDataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the original request that triggered the image transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest,
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequestFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
    : JsonModel
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

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest(
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest
    )
        : base(imageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequestFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequestFromRaw
    : IFromRawJson<ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationErrorEventImageAsyncTransformationErrorEventRequest.FromRawUnchecked(
            rawData
        );
}
