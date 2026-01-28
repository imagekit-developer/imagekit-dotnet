using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnwrapWebhookEventVariants = Imagekit.Models.Webhooks.UnwrapWebhookEventVariants;

namespace Imagekit.Models.Webhooks;

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public abstract record class UnwrapWebhookEvent
{
    internal UnwrapWebhookEvent() { }

    public static implicit operator UnwrapWebhookEvent(VideoTransformationAcceptedEvent value) =>
        new UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(value);

    public static implicit operator UnwrapWebhookEvent(VideoTransformationReadyEvent value) =>
        new UnwrapWebhookEventVariants::VideoTransformationReadyEvent(value);

    public static implicit operator UnwrapWebhookEvent(VideoTransformationErrorEvent value) =>
        new UnwrapWebhookEventVariants::VideoTransformationErrorEvent(value);

    public static implicit operator UnwrapWebhookEvent(UploadPreTransformSuccessEvent value) =>
        new UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(value);

    public static implicit operator UnwrapWebhookEvent(UploadPreTransformErrorEvent value) =>
        new UnwrapWebhookEventVariants::UploadPreTransformErrorEvent(value);

    public static implicit operator UnwrapWebhookEvent(UploadPostTransformSuccessEvent value) =>
        new UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(value);

    public static implicit operator UnwrapWebhookEvent(UploadPostTransformErrorEvent value) =>
        new UnwrapWebhookEventVariants::UploadPostTransformErrorEvent(value);

    public bool TryPickVideoTransformationAccepted(
        [NotNullWhen(true)] out VideoTransformationAcceptedEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent)?.Value;
        return value != null;
    }

    public bool TryPickVideoTransformationReady(
        [NotNullWhen(true)] out VideoTransformationReadyEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::VideoTransformationReadyEvent)?.Value;
        return value != null;
    }

    public bool TryPickVideoTransformationError(
        [NotNullWhen(true)] out VideoTransformationErrorEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::VideoTransformationErrorEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPreTransformSuccess(
        [NotNullWhen(true)] out UploadPreTransformSuccessEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPreTransformError(
        [NotNullWhen(true)] out UploadPreTransformErrorEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::UploadPreTransformErrorEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPostTransformSuccess(
        [NotNullWhen(true)] out UploadPostTransformSuccessEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent)?.Value;
        return value != null;
    }

    public bool TryPickUploadPostTransformError(
        [NotNullWhen(true)] out UploadPostTransformErrorEvent? value
    )
    {
        value = (this as UnwrapWebhookEventVariants::UploadPostTransformErrorEvent)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent> videoTransformationAccepted,
        Action<UnwrapWebhookEventVariants::VideoTransformationReadyEvent> videoTransformationReady,
        Action<UnwrapWebhookEventVariants::VideoTransformationErrorEvent> videoTransformationError,
        Action<UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent> uploadPreTransformSuccess,
        Action<UnwrapWebhookEventVariants::UploadPreTransformErrorEvent> uploadPreTransformError,
        Action<UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent> uploadPostTransformSuccess,
        Action<UnwrapWebhookEventVariants::UploadPostTransformErrorEvent> uploadPostTransformError
    )
    {
        switch (this)
        {
            case UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent inner:
                videoTransformationAccepted(inner);
                break;
            case UnwrapWebhookEventVariants::VideoTransformationReadyEvent inner:
                videoTransformationReady(inner);
                break;
            case UnwrapWebhookEventVariants::VideoTransformationErrorEvent inner:
                videoTransformationError(inner);
                break;
            case UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent inner:
                uploadPreTransformSuccess(inner);
                break;
            case UnwrapWebhookEventVariants::UploadPreTransformErrorEvent inner:
                uploadPreTransformError(inner);
                break;
            case UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent inner:
                uploadPostTransformSuccess(inner);
                break;
            case UnwrapWebhookEventVariants::UploadPostTransformErrorEvent inner:
                uploadPostTransformError(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<
            UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent,
            T
        > videoTransformationAccepted,
        Func<UnwrapWebhookEventVariants::VideoTransformationReadyEvent, T> videoTransformationReady,
        Func<UnwrapWebhookEventVariants::VideoTransformationErrorEvent, T> videoTransformationError,
        Func<
            UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent,
            T
        > uploadPreTransformSuccess,
        Func<UnwrapWebhookEventVariants::UploadPreTransformErrorEvent, T> uploadPreTransformError,
        Func<
            UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent,
            T
        > uploadPostTransformSuccess,
        Func<UnwrapWebhookEventVariants::UploadPostTransformErrorEvent, T> uploadPostTransformError
    )
    {
        return this switch
        {
            UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent inner =>
                videoTransformationAccepted(inner),
            UnwrapWebhookEventVariants::VideoTransformationReadyEvent inner =>
                videoTransformationReady(inner),
            UnwrapWebhookEventVariants::VideoTransformationErrorEvent inner =>
                videoTransformationError(inner),
            UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent inner =>
                uploadPreTransformSuccess(inner),
            UnwrapWebhookEventVariants::UploadPreTransformErrorEvent inner =>
                uploadPreTransformError(inner),
            UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent inner =>
                uploadPostTransformSuccess(inner),
            UnwrapWebhookEventVariants::UploadPostTransformErrorEvent inner =>
                uploadPostTransformError(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
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
                return new UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(
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
                return new UnwrapWebhookEventVariants::VideoTransformationReadyEvent(deserialized);
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
                return new UnwrapWebhookEventVariants::VideoTransformationErrorEvent(deserialized);
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
                return new UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(deserialized);
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
                return new UnwrapWebhookEventVariants::UploadPreTransformErrorEvent(deserialized);
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
                return new UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(
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
                return new UnwrapWebhookEventVariants::UploadPostTransformErrorEvent(deserialized);
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
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UnwrapWebhookEventVariants::VideoTransformationAcceptedEvent(
                var videoTransformationAccepted
            ) => videoTransformationAccepted,
            UnwrapWebhookEventVariants::VideoTransformationReadyEvent(
                var videoTransformationReady
            ) => videoTransformationReady,
            UnwrapWebhookEventVariants::VideoTransformationErrorEvent(
                var videoTransformationError
            ) => videoTransformationError,
            UnwrapWebhookEventVariants::UploadPreTransformSuccessEvent(
                var uploadPreTransformSuccess
            ) => uploadPreTransformSuccess,
            UnwrapWebhookEventVariants::UploadPreTransformErrorEvent(var uploadPreTransformError) =>
                uploadPreTransformError,
            UnwrapWebhookEventVariants::UploadPostTransformSuccessEvent(
                var uploadPostTransformSuccess
            ) => uploadPostTransformSuccess,
            UnwrapWebhookEventVariants::UploadPostTransformErrorEvent(
                var uploadPostTransformError
            ) => uploadPostTransformError,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
