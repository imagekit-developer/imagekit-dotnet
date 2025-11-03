using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent
{
    public object Value { get; private init; }

    public string ID
    {
        get
        {
            return Match(
                videoTransformationAccepted: (x) => x.ID,
                videoTransformationReady: (x) => x.ID,
                videoTransformationError: (x) => x.ID,
                uploadPreTransformSuccess: (x) => x.ID,
                uploadPreTransformError: (x) => x.ID,
                uploadPostTransformSuccess: (x) => x.ID,
                uploadPostTransformError: (x) => x.ID
            );
        }
    }

    public string Type
    {
        get
        {
            return Match(
                videoTransformationAccepted: (x) => x.Type,
                videoTransformationReady: (x) => x.Type,
                videoTransformationError: (x) => x.Type,
                uploadPreTransformSuccess: (x) => x.Type,
                uploadPreTransformError: (x) => x.Type,
                uploadPostTransformSuccess: (x) => x.Type,
                uploadPostTransformError: (x) => x.Type
            );
        }
    }

    public DateTime CreatedAt
    {
        get
        {
            return Match(
                videoTransformationAccepted: (x) => x.CreatedAt,
                videoTransformationReady: (x) => x.CreatedAt,
                videoTransformationError: (x) => x.CreatedAt,
                uploadPreTransformSuccess: (x) => x.CreatedAt,
                uploadPreTransformError: (x) => x.CreatedAt,
                uploadPostTransformSuccess: (x) => x.CreatedAt,
                uploadPostTransformError: (x) => x.CreatedAt
            );
        }
    }

    public UnsafeUnwrapWebhookEvent(VideoTransformationAcceptedEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(VideoTransformationReadyEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(VideoTransformationErrorEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(UploadPreTransformSuccessEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(UploadPreTransformErrorEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(UploadPostTransformSuccessEvent value)
    {
        Value = value;
    }

    public UnsafeUnwrapWebhookEvent(UploadPostTransformErrorEvent value)
    {
        Value = value;
    }

    UnsafeUnwrapWebhookEvent(UnknownVariant value)
    {
        Value = value;
    }

    public static UnsafeUnwrapWebhookEvent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickVideoTransformationAccepted(
        [NotNullWhen(true)] out VideoTransformationAcceptedEvent? value
    )
    {
        value = this.Value as VideoTransformationAcceptedEvent;
        return value != null;
    }

    public bool TryPickVideoTransformationReady(
        [NotNullWhen(true)] out VideoTransformationReadyEvent? value
    )
    {
        value = this.Value as VideoTransformationReadyEvent;
        return value != null;
    }

    public bool TryPickVideoTransformationError(
        [NotNullWhen(true)] out VideoTransformationErrorEvent? value
    )
    {
        value = this.Value as VideoTransformationErrorEvent;
        return value != null;
    }

    public bool TryPickUploadPreTransformSuccess(
        [NotNullWhen(true)] out UploadPreTransformSuccessEvent? value
    )
    {
        value = this.Value as UploadPreTransformSuccessEvent;
        return value != null;
    }

    public bool TryPickUploadPreTransformError(
        [NotNullWhen(true)] out UploadPreTransformErrorEvent? value
    )
    {
        value = this.Value as UploadPreTransformErrorEvent;
        return value != null;
    }

    public bool TryPickUploadPostTransformSuccess(
        [NotNullWhen(true)] out UploadPostTransformSuccessEvent? value
    )
    {
        value = this.Value as UploadPostTransformSuccessEvent;
        return value != null;
    }

    public bool TryPickUploadPostTransformError(
        [NotNullWhen(true)] out UploadPostTransformErrorEvent? value
    )
    {
        value = this.Value as UploadPostTransformErrorEvent;
        return value != null;
    }

    public void Switch(
        Action<VideoTransformationAcceptedEvent> videoTransformationAccepted,
        Action<VideoTransformationReadyEvent> videoTransformationReady,
        Action<VideoTransformationErrorEvent> videoTransformationError,
        Action<UploadPreTransformSuccessEvent> uploadPreTransformSuccess,
        Action<UploadPreTransformErrorEvent> uploadPreTransformError,
        Action<UploadPostTransformSuccessEvent> uploadPostTransformSuccess,
        Action<UploadPostTransformErrorEvent> uploadPostTransformError
    )
    {
        switch (this.Value)
        {
            case VideoTransformationAcceptedEvent value:
                videoTransformationAccepted(value);
                break;
            case VideoTransformationReadyEvent value:
                videoTransformationReady(value);
                break;
            case VideoTransformationErrorEvent value:
                videoTransformationError(value);
                break;
            case UploadPreTransformSuccessEvent value:
                uploadPreTransformSuccess(value);
                break;
            case UploadPreTransformErrorEvent value:
                uploadPreTransformError(value);
                break;
            case UploadPostTransformSuccessEvent value:
                uploadPostTransformSuccess(value);
                break;
            case UploadPostTransformErrorEvent value:
                uploadPostTransformError(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnsafeUnwrapWebhookEvent"
                );
        }
    }

    public T Match<T>(
        Func<VideoTransformationAcceptedEvent, T> videoTransformationAccepted,
        Func<VideoTransformationReadyEvent, T> videoTransformationReady,
        Func<VideoTransformationErrorEvent, T> videoTransformationError,
        Func<UploadPreTransformSuccessEvent, T> uploadPreTransformSuccess,
        Func<UploadPreTransformErrorEvent, T> uploadPreTransformError,
        Func<UploadPostTransformSuccessEvent, T> uploadPostTransformSuccess,
        Func<UploadPostTransformErrorEvent, T> uploadPostTransformError
    )
    {
        return this.Value switch
        {
            VideoTransformationAcceptedEvent value => videoTransformationAccepted(value),
            VideoTransformationReadyEvent value => videoTransformationReady(value),
            VideoTransformationErrorEvent value => videoTransformationError(value),
            UploadPreTransformSuccessEvent value => uploadPreTransformSuccess(value),
            UploadPreTransformErrorEvent value => uploadPreTransformError(value),
            UploadPostTransformSuccessEvent value => uploadPostTransformSuccess(value),
            UploadPostTransformErrorEvent value => uploadPostTransformError(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<ImageKitInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationAcceptedEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'VideoTransformationAcceptedEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationReadyEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'VideoTransformationReadyEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'VideoTransformationErrorEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPreTransformSuccessEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'UploadPreTransformSuccessEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPreTransformErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'UploadPreTransformErrorEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPostTransformSuccessEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'UploadPostTransformSuccessEvent'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPostTransformErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsafeUnwrapWebhookEvent(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(
                new ImageKitInvalidDataException(
                    "Data does not match union variant 'UploadPostTransformErrorEvent'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
