using Webhooks = Imagekit.Models.Webhooks;

namespace Imagekit.Models.Webhooks.UnsafeUnwrapWebhookEventVariants;

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
public sealed record class VideoTransformationAcceptedEvent(
    Webhooks::VideoTransformationAcceptedEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<VideoTransformationAcceptedEvent, Webhooks::VideoTransformationAcceptedEvent>
{
    public static VideoTransformationAcceptedEvent From(
        Webhooks::VideoTransformationAcceptedEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when video encoding is finished and the transformed resource is ready
/// to be served. This is the key event to listen for - update your database or CMS
/// flags when you receive this so your application can start showing the transformed
/// video to users.
/// </summary>
public sealed record class VideoTransformationReadyEvent(
    Webhooks::VideoTransformationReadyEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<VideoTransformationReadyEvent, Webhooks::VideoTransformationReadyEvent>
{
    public static VideoTransformationReadyEvent From(Webhooks::VideoTransformationReadyEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when an error occurs during video encoding. Listen to this webhook to
/// log error reasons and debug issues. Check your origin and URL endpoint settings
/// if the reason is related to download failure. For other errors, contact ImageKit
/// support.
/// </summary>
public sealed record class VideoTransformationErrorEvent(
    Webhooks::VideoTransformationErrorEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<VideoTransformationErrorEvent, Webhooks::VideoTransformationErrorEvent>
{
    public static VideoTransformationErrorEvent From(Webhooks::VideoTransformationErrorEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when a pre-transformation completes successfully. The file has been
/// processed with the requested transformation and is now available in the Media
/// Library.
/// </summary>
public sealed record class UploadPreTransformSuccessEvent(
    Webhooks::UploadPreTransformSuccessEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<UploadPreTransformSuccessEvent, Webhooks::UploadPreTransformSuccessEvent>
{
    public static UploadPreTransformSuccessEvent From(
        Webhooks::UploadPreTransformSuccessEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when a pre-transformation fails. The file upload may have been accepted,
/// but the requested transformation could not be applied.
/// </summary>
public sealed record class UploadPreTransformErrorEvent(
    Webhooks::UploadPreTransformErrorEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<UploadPreTransformErrorEvent, Webhooks::UploadPreTransformErrorEvent>
{
    public static UploadPreTransformErrorEvent From(Webhooks::UploadPreTransformErrorEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when a post-transformation completes successfully. The transformed version
/// of the file is now ready and can be accessed via the provided URL. Note that
/// each post-transformation generates a separate webhook event.
/// </summary>
public sealed record class UploadPostTransformSuccessEvent(
    Webhooks::UploadPostTransformSuccessEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<UploadPostTransformSuccessEvent, Webhooks::UploadPostTransformSuccessEvent>
{
    public static UploadPostTransformSuccessEvent From(
        Webhooks::UploadPostTransformSuccessEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Triggered when a post-transformation fails. The original file remains available,
/// but the requested transformation could not be generated.
/// </summary>
public sealed record class UploadPostTransformErrorEvent(
    Webhooks::UploadPostTransformErrorEvent Value
)
    : Webhooks::UnsafeUnwrapWebhookEvent,
        IVariant<UploadPostTransformErrorEvent, Webhooks::UploadPostTransformErrorEvent>
{
    public static UploadPostTransformErrorEvent From(Webhooks::UploadPostTransformErrorEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
