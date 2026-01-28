using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnsafeUnwrapWebhookEventVariants = Imagekit.Models.Webhooks.UnsafeUnwrapWebhookEventVariants;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public abstract record class UnsafeUnwrapWebhookEvent
{
    internal UnsafeUnwrapWebhookEvent() { }

    public static implicit operator UnsafeUnwrapWebhookEvent(
        VideoTransformationAcceptedEvent value
    ) => new UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(VideoTransformationReadyEvent value) =>
        new UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(VideoTransformationErrorEvent value) =>
        new UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        UploadPreTransformSuccessEvent value
    ) => new UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(UploadPreTransformErrorEvent value) =>
        new UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        UploadPostTransformSuccessEvent value
    ) => new UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(UploadPostTransformErrorEvent value) =>
        new UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent(value);

    public bool TryPickVideoTransformationAccepted(
        [NotNullWhen(true)] out VideoTransformationAcceptedEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent)?.Value;
        return value != null;
    }

    public bool TryPickVideoTransformationReady(
        [NotNullWhen(true)] out VideoTransformationReadyEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent)?.Value;
        return value != null;
    }

    public bool TryPickVideoTransformationError(
        [NotNullWhen(true)] out VideoTransformationErrorEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPreTransformSuccess(
        [NotNullWhen(true)] out UploadPreTransformSuccessEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPreTransformError(
        [NotNullWhen(true)] out UploadPreTransformErrorEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPostTransformSuccess(
        [NotNullWhen(true)] out UploadPostTransformSuccessEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPostTransformError(
        [NotNullWhen(true)] out UploadPostTransformErrorEvent? value
    )
    {
        value = (this as UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent> videoTransformationAccepted,
        Action<UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent> videoTransformationReady,
        Action<UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent> videoTransformationError,
        Action<UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent> uploadPreTransformSuccess,
        Action<UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent> uploadPreTransformError,
        Action<UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent> uploadPostTransformSuccess,
        Action<UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent> uploadPostTransformError
    )
    {
        switch (this)
        {
            case UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent inner:
                videoTransformationAccepted(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent inner:
                videoTransformationReady(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent inner:
                videoTransformationError(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent inner:
                uploadPreTransformSuccess(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent inner:
                uploadPreTransformError(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent inner:
                uploadPostTransformSuccess(inner);
                break;
            case UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent inner:
                uploadPostTransformError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent,
            T
        > videoTransformationAccepted,
        Func<
            UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent,
            T
        > videoTransformationReady,
        Func<
            UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent,
            T
        > videoTransformationError,
        Func<
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent,
            T
        > uploadPreTransformSuccess,
        Func<
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent,
            T
        > uploadPreTransformError,
        Func<
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent,
            T
        > uploadPostTransformSuccess,
        Func<
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent,
            T
        > uploadPostTransformError
    )
    {
        return this switch
        {
            UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent inner =>
                videoTransformationAccepted(inner),
            UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent inner =>
                videoTransformationReady(inner),
            UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent inner =>
                videoTransformationError(inner),
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent inner =>
                uploadPreTransformSuccess(inner),
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent inner =>
                uploadPreTransformError(inner),
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent inner =>
                uploadPostTransformSuccess(inner),
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent inner =>
                uploadPostTransformError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationAcceptedEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationReadyEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<VideoTransformationErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPreTransformSuccessEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPreTransformErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPostTransformSuccessEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<UploadPostTransformErrorEvent>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent(
                    deserialized
                );
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UnsafeUnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(
                var videoTransformationAccepted
            ) => videoTransformationAccepted,
            UnsafeUnwrapWebhookEventVariants::VideoTransformationReadyEvent(
                var videoTransformationReady
            ) => videoTransformationReady,
            UnsafeUnwrapWebhookEventVariants::VideoTransformationErrorEvent(
                var videoTransformationError
            ) => videoTransformationError,
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(
                var uploadPreTransformSuccess
            ) => uploadPreTransformSuccess,
            UnsafeUnwrapWebhookEventVariants::UploadPreTransformErrorEvent(
                var uploadPreTransformError
            ) => uploadPreTransformError,
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(
                var uploadPostTransformSuccess
            ) => uploadPostTransformSuccess,
            UnsafeUnwrapWebhookEventVariants::UploadPostTransformErrorEvent(
                var uploadPostTransformError
            ) => uploadPostTransformError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
