using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Accounts.Webhooks;

/// <summary>
/// A webhook event type. Learn more about the payload of each [webhook event](https://imagekit.io/docs/webhooks#list-of-events).
/// </summary>
[JsonConverter(typeof(WebhookEventTypeConverter))]
public enum WebhookEventType
{
    VideoTransformationAccepted,
    VideoTransformationReady,
    VideoTransformationError,
    UploadPreTransformSuccess,
    UploadPreTransformError,
    UploadPostTransformSuccess,
    UploadPostTransformError,
    FileCreated,
    FileUpdated,
    FileDeleted,
    FileVersionCreated,
    FileVersionDeleted,
}

sealed class WebhookEventTypeConverter : JsonConverter<WebhookEventType>
{
    public override WebhookEventType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "video.transformation.accepted" => WebhookEventType.VideoTransformationAccepted,
            "video.transformation.ready" => WebhookEventType.VideoTransformationReady,
            "video.transformation.error" => WebhookEventType.VideoTransformationError,
            "upload.pre-transform.success" => WebhookEventType.UploadPreTransformSuccess,
            "upload.pre-transform.error" => WebhookEventType.UploadPreTransformError,
            "upload.post-transform.success" => WebhookEventType.UploadPostTransformSuccess,
            "upload.post-transform.error" => WebhookEventType.UploadPostTransformError,
            "file.created" => WebhookEventType.FileCreated,
            "file.updated" => WebhookEventType.FileUpdated,
            "file.deleted" => WebhookEventType.FileDeleted,
            "file-version.created" => WebhookEventType.FileVersionCreated,
            "file-version.deleted" => WebhookEventType.FileVersionDeleted,
            _ => (WebhookEventType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookEventType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookEventType.VideoTransformationAccepted => "video.transformation.accepted",
                WebhookEventType.VideoTransformationReady => "video.transformation.ready",
                WebhookEventType.VideoTransformationError => "video.transformation.error",
                WebhookEventType.UploadPreTransformSuccess => "upload.pre-transform.success",
                WebhookEventType.UploadPreTransformError => "upload.pre-transform.error",
                WebhookEventType.UploadPostTransformSuccess => "upload.post-transform.success",
                WebhookEventType.UploadPostTransformError => "upload.post-transform.error",
                WebhookEventType.FileCreated => "file.created",
                WebhookEventType.FileUpdated => "file.updated",
                WebhookEventType.FileDeleted => "file.deleted",
                WebhookEventType.FileVersionCreated => "file-version.created",
                WebhookEventType.FileVersionDeleted => "file-version.deleted",
                _ => throw new ImageKitInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
