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
/// Triggered when an asynchronous image transformation is finished and the transformed
/// image is ready to be served. Listen to this webhook and update any flags in your
/// database or CMS so your application can start displaying the transformed image
/// to users.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEvent,
        ImageAsyncTransformationReadyEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEvent : JsonModel
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

    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest>(
                "request"
            );
        }
        init { this._rawData.Set("request", value); }
    }

    /// <summary>
    /// Performance metrics for the transformation process.
    /// </summary>
    public Timings? Timings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timings>("timings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timings", value);
        }
    }

    public static implicit operator BaseWebhookEvent(
        ImageAsyncTransformationReadyEvent imageAsyncTransformationReadyEvent
    ) =>
        new()
        {
            ID = imageAsyncTransformationReadyEvent.ID,
            Type = imageAsyncTransformationReadyEvent.Type,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
        _ = this.CreatedAt;
        this.Data.Validate();
        this.Request.Validate();
        this.Timings?.Validate();
    }

    public ImageAsyncTransformationReadyEvent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEvent(
        ImageAsyncTransformationReadyEvent imageAsyncTransformationReadyEvent
    )
        : base(imageAsyncTransformationReadyEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationReadyEventFromRaw : IFromRawJson<ImageAsyncTransformationReadyEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageAsyncTransformationReadyEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Triggered when an asynchronous image transformation is finished and the transformed
/// image is ready to be served. Listen to this webhook and update any flags in your
/// database or CMS so your application can start displaying the transformed image
/// to users.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
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

    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Information about the original request that triggered the image transformation.
    /// </summary>
    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest Request
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest>(
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

    /// <summary>
    /// Performance metrics for the transformation process.
    /// </summary>
    public Timings? Timings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Timings>("timings");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timings", value);
        }
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
                JsonSerializer.SerializeToElement("image.async-transformation.ready")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        this.Timings?.Validate();
    }

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent imageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent
    )
        : base(imageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("image.async-transformation.ready");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEvent.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
    : JsonModel
{
    /// <summary>
    /// Information about the source image asset being transformed.
    /// </summary>
    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset Asset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset>(
                "asset"
            );
        }
        init { this._rawData.Set("asset", value); }
    }

    public required ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation Transformation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation>(
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

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData
    )
        : base(imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventData.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the source image asset being transformed.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAssetFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
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

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset
    )
        : base(imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAssetFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset(string url)
        : this()
    {
        this.Url = url;
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAssetFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataAsset.FromRawUnchecked(
            rawData
        );
}

[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
    : JsonModel
{
    /// <summary>
    /// Type of transformation. Always `image-transformation`.
    /// </summary>
    public required ApiEnum<
        string,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<
                    string,
                    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
                >
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Options of the requested transformation.
    /// </summary>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions? Options
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions>(
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

    /// <summary>
    /// Information about the transformed output image.
    /// </summary>
    public Output? Output
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Output>("output");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("output", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        this.Options?.Validate();
        this.Output?.Validate();
    }

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
    )
        : base(
            imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation
        ) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation(
        ApiEnum<
            string,
            ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
        > type
    )
        : this()
    {
        this.Type = type;
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformation.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Type of transformation. Always `image-transformation`.
/// </summary>
[JsonConverter(
    typeof(ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationTypeConverter)
)]
public enum ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType
{
    ImageTransformation,
}

sealed class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationTypeConverter
    : JsonConverter<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType>
{
    public override ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "image-transformation" =>
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation,
            _ =>
                (ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType)(
                    -1
                ),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationType.ImageTransformation =>
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
/// Options of the requested transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptionsFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
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

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions()
    { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
    )
        : base(
            imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions
        ) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptionsFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptionsFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventDataTransformationOptions.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Information about the transformed output image.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Output, OutputFromRaw>))]
public sealed record class Output : JsonModel
{
    /// <summary>
    /// URL to access the transformed image.
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
    /// Metadata of the output image.
    /// </summary>
    public ImageMetadata? ImageMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ImageMetadata>("image_metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("image_metadata", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        this.ImageMetadata?.Validate();
    }

    public Output() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Output(Output output)
        : base(output) { }
#pragma warning restore CS8618

    public Output(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Output(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OutputFromRaw.FromRawUnchecked"/>
    public static Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Output(string url)
        : this()
    {
        this.Url = url;
    }
}

class OutputFromRaw : IFromRawJson<Output>
{
    /// <inheritdoc/>
    public Output FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Output.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata of the output image.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ImageMetadata, ImageMetadataFromRaw>))]
public sealed record class ImageMetadata : JsonModel
{
    /// <summary>
    /// Size of the output image in bytes.
    /// </summary>
    public required long Size
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size");
        }
        init { this._rawData.Set("size", value); }
    }

    /// <summary>
    /// Format of the output image, for example `webp` or `png`.
    /// </summary>
    public string? Format
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("format");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("format", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Size;
        _ = this.Format;
    }

    public ImageMetadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageMetadata(ImageMetadata imageMetadata)
        : base(imageMetadata) { }
#pragma warning restore CS8618

    public ImageMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageMetadataFromRaw.FromRawUnchecked"/>
    public static ImageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ImageMetadata(long size)
        : this()
    {
        this.Size = size;
    }
}

class ImageMetadataFromRaw : IFromRawJson<ImageMetadata>
{
    /// <inheritdoc/>
    public ImageMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageMetadata.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the original request that triggered the image transformation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest,
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequestFromRaw
    >)
)]
public sealed record class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
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

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest(
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest
    )
        : base(imageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest) { }
#pragma warning restore CS8618

    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequestFromRaw.FromRawUnchecked"/>
    public static ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequestFromRaw
    : IFromRawJson<ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest>
{
    /// <inheritdoc/>
    public ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) =>
        ImageAsyncTransformationReadyEventImageAsyncTransformationReadyEventRequest.FromRawUnchecked(
            rawData
        );
}

/// <summary>
/// Performance metrics for the transformation process.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Timings, TimingsFromRaw>))]
public sealed record class Timings : JsonModel
{
    /// <summary>
    /// Time spent processing the transformation, in milliseconds.
    /// </summary>
    public long? ProcessingDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("processing_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("processing_duration", value);
        }
    }

    /// <summary>
    /// Time the request waited in the queue before processing started, in milliseconds.
    /// </summary>
    public long? QueueDuration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("queue_duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("queue_duration", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ProcessingDuration;
        _ = this.QueueDuration;
    }

    public Timings() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Timings(Timings timings)
        : base(timings) { }
#pragma warning restore CS8618

    public Timings(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timings(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimingsFromRaw.FromRawUnchecked"/>
    public static Timings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimingsFromRaw : IFromRawJson<Timings>
{
    /// <inheritdoc/>
    public Timings FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Timings.FromRawUnchecked(rawData);
}
