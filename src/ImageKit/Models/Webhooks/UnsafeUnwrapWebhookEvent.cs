using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using System = System;

namespace ImageKit.Models.Webhooks;

/// <summary>
/// Triggered when a new video transformation request is accepted for processing.
/// This event confirms that ImageKit has received and queued your transformation
/// request. Use this for debugging and tracking transformation lifecycle.
/// </summary>
[JsonConverter(typeof(UnsafeUnwrapWebhookEventConverter))]
public record class UnsafeUnwrapWebhookEvent : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

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
                uploadPostTransformError: (x) => x.ID,
                fileCreated: (x) => x.STAINLESS_FIXME_ID,
                fileUpdated: (x) => x.STAINLESS_FIXME_ID,
                fileDeleted: (x) => x.STAINLESS_FIXME_ID,
                fileVersionCreated: (x) => x.STAINLESS_FIXME_ID,
                fileVersionDeleted: (x) => x.STAINLESS_FIXME_ID
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
                uploadPostTransformError: (x) => x.Type,
                fileCreated: (x) => x.STAINLESS_FIXME_Type,
                fileUpdated: (x) => x.STAINLESS_FIXME_Type,
                fileDeleted: (x) => x.STAINLESS_FIXME_Type,
                fileVersionCreated: (x) => x.STAINLESS_FIXME_Type,
                fileVersionDeleted: (x) => x.STAINLESS_FIXME_Type
            );
        }
    }

    public System::DateTimeOffset CreatedAt
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
                uploadPostTransformError: (x) => x.CreatedAt,
                fileCreated: (x) => x.STAINLESS_FIXME_CreatedAt,
                fileUpdated: (x) => x.STAINLESS_FIXME_CreatedAt,
                fileDeleted: (x) => x.STAINLESS_FIXME_CreatedAt,
                fileVersionCreated: (x) => x.STAINLESS_FIXME_CreatedAt,
                fileVersionDeleted: (x) => x.STAINLESS_FIXME_CreatedAt
            );
        }
    }

    public UnsafeUnwrapWebhookEvent(
        VideoTransformationAcceptedEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        VideoTransformationReadyEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        VideoTransformationErrorEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        UploadPreTransformSuccessEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(UploadPreTransformErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        UploadPostTransformSuccessEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        UploadPostTransformErrorEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(FileCreatedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(FileUpdatedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(FileDeletedWebhookEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        FileVersionCreatedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(
        FileVersionDeletedWebhookEvent value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnsafeUnwrapWebhookEvent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoTransformationAcceptedEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideoTransformationAccepted(out var value)) {
    ///     // `value` is of type `VideoTransformationAcceptedEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideoTransformationAccepted(
        [NotNullWhen(true)] out VideoTransformationAcceptedEvent? value
    )
    {
        value = this.Value as VideoTransformationAcceptedEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoTransformationReadyEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideoTransformationReady(out var value)) {
    ///     // `value` is of type `VideoTransformationReadyEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideoTransformationReady(
        [NotNullWhen(true)] out VideoTransformationReadyEvent? value
    )
    {
        value = this.Value as VideoTransformationReadyEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="VideoTransformationErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickVideoTransformationError(out var value)) {
    ///     // `value` is of type `VideoTransformationErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickVideoTransformationError(
        [NotNullWhen(true)] out VideoTransformationErrorEvent? value
    )
    {
        value = this.Value as VideoTransformationErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UploadPreTransformSuccessEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUploadPreTransformSuccess(out var value)) {
    ///     // `value` is of type `UploadPreTransformSuccessEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUploadPreTransformSuccess(
        [NotNullWhen(true)] out UploadPreTransformSuccessEvent? value
    )
    {
        value = this.Value as UploadPreTransformSuccessEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UploadPreTransformErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUploadPreTransformError(out var value)) {
    ///     // `value` is of type `UploadPreTransformErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUploadPreTransformError(
        [NotNullWhen(true)] out UploadPreTransformErrorEvent? value
    )
    {
        value = this.Value as UploadPreTransformErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UploadPostTransformSuccessEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUploadPostTransformSuccess(out var value)) {
    ///     // `value` is of type `UploadPostTransformSuccessEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUploadPostTransformSuccess(
        [NotNullWhen(true)] out UploadPostTransformSuccessEvent? value
    )
    {
        value = this.Value as UploadPostTransformSuccessEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UploadPostTransformErrorEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUploadPostTransformError(out var value)) {
    ///     // `value` is of type `UploadPostTransformErrorEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUploadPostTransformError(
        [NotNullWhen(true)] out UploadPostTransformErrorEvent? value
    )
    {
        value = this.Value as UploadPostTransformErrorEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileCreatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileCreated(out var value)) {
    ///     // `value` is of type `FileCreatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileCreated([NotNullWhen(true)] out FileCreatedWebhookEvent? value)
    {
        value = this.Value as FileCreatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileUpdatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileUpdated(out var value)) {
    ///     // `value` is of type `FileUpdatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileUpdated([NotNullWhen(true)] out FileUpdatedWebhookEvent? value)
    {
        value = this.Value as FileUpdatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileDeletedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileDeleted(out var value)) {
    ///     // `value` is of type `FileDeletedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileDeleted([NotNullWhen(true)] out FileDeletedWebhookEvent? value)
    {
        value = this.Value as FileDeletedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileVersionCreatedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileVersionCreated(out var value)) {
    ///     // `value` is of type `FileVersionCreatedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileVersionCreated(
        [NotNullWhen(true)] out FileVersionCreatedWebhookEvent? value
    )
    {
        value = this.Value as FileVersionCreatedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="FileVersionDeletedWebhookEvent"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileVersionDeleted(out var value)) {
    ///     // `value` is of type `FileVersionDeletedWebhookEvent`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileVersionDeleted(
        [NotNullWhen(true)] out FileVersionDeletedWebhookEvent? value
    )
    {
        value = this.Value as FileVersionDeletedWebhookEvent;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (VideoTransformationAcceptedEvent value) =&gt; {...},
    ///     (VideoTransformationReadyEvent value) =&gt; {...},
    ///     (VideoTransformationErrorEvent value) =&gt; {...},
    ///     (UploadPreTransformSuccessEvent value) =&gt; {...},
    ///     (UploadPreTransformErrorEvent value) =&gt; {...},
    ///     (UploadPostTransformSuccessEvent value) =&gt; {...},
    ///     (UploadPostTransformErrorEvent value) =&gt; {...},
    ///     (FileCreatedWebhookEvent value) =&gt; {...},
    ///     (FileUpdatedWebhookEvent value) =&gt; {...},
    ///     (FileDeletedWebhookEvent value) =&gt; {...},
    ///     (FileVersionCreatedWebhookEvent value) =&gt; {...},
    ///     (FileVersionDeletedWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<VideoTransformationAcceptedEvent> videoTransformationAccepted,
        System::Action<VideoTransformationReadyEvent> videoTransformationReady,
        System::Action<VideoTransformationErrorEvent> videoTransformationError,
        System::Action<UploadPreTransformSuccessEvent> uploadPreTransformSuccess,
        System::Action<UploadPreTransformErrorEvent> uploadPreTransformError,
        System::Action<UploadPostTransformSuccessEvent> uploadPostTransformSuccess,
        System::Action<UploadPostTransformErrorEvent> uploadPostTransformError,
        System::Action<FileCreatedWebhookEvent> fileCreated,
        System::Action<FileUpdatedWebhookEvent> fileUpdated,
        System::Action<FileDeletedWebhookEvent> fileDeleted,
        System::Action<FileVersionCreatedWebhookEvent> fileVersionCreated,
        System::Action<FileVersionDeletedWebhookEvent> fileVersionDeleted
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
            case FileCreatedWebhookEvent value:
                fileCreated(value);
                break;
            case FileUpdatedWebhookEvent value:
                fileUpdated(value);
                break;
            case FileDeletedWebhookEvent value:
                fileDeleted(value);
                break;
            case FileVersionCreatedWebhookEvent value:
                fileVersionCreated(value);
                break;
            case FileVersionDeletedWebhookEvent value:
                fileVersionDeleted(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnsafeUnwrapWebhookEvent"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (VideoTransformationAcceptedEvent value) =&gt; {...},
    ///     (VideoTransformationReadyEvent value) =&gt; {...},
    ///     (VideoTransformationErrorEvent value) =&gt; {...},
    ///     (UploadPreTransformSuccessEvent value) =&gt; {...},
    ///     (UploadPreTransformErrorEvent value) =&gt; {...},
    ///     (UploadPostTransformSuccessEvent value) =&gt; {...},
    ///     (UploadPostTransformErrorEvent value) =&gt; {...},
    ///     (FileCreatedWebhookEvent value) =&gt; {...},
    ///     (FileUpdatedWebhookEvent value) =&gt; {...},
    ///     (FileDeletedWebhookEvent value) =&gt; {...},
    ///     (FileVersionCreatedWebhookEvent value) =&gt; {...},
    ///     (FileVersionDeletedWebhookEvent value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<VideoTransformationAcceptedEvent, T> videoTransformationAccepted,
        System::Func<VideoTransformationReadyEvent, T> videoTransformationReady,
        System::Func<VideoTransformationErrorEvent, T> videoTransformationError,
        System::Func<UploadPreTransformSuccessEvent, T> uploadPreTransformSuccess,
        System::Func<UploadPreTransformErrorEvent, T> uploadPreTransformError,
        System::Func<UploadPostTransformSuccessEvent, T> uploadPostTransformSuccess,
        System::Func<UploadPostTransformErrorEvent, T> uploadPostTransformError,
        System::Func<FileCreatedWebhookEvent, T> fileCreated,
        System::Func<FileUpdatedWebhookEvent, T> fileUpdated,
        System::Func<FileDeletedWebhookEvent, T> fileDeleted,
        System::Func<FileVersionCreatedWebhookEvent, T> fileVersionCreated,
        System::Func<FileVersionDeletedWebhookEvent, T> fileVersionDeleted
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
            FileCreatedWebhookEvent value => fileCreated(value),
            FileUpdatedWebhookEvent value => fileUpdated(value),
            FileDeletedWebhookEvent value => fileDeleted(value),
            FileVersionCreatedWebhookEvent value => fileVersionCreated(value),
            FileVersionDeletedWebhookEvent value => fileVersionDeleted(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnsafeUnwrapWebhookEvent(
        VideoTransformationAcceptedEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(VideoTransformationReadyEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(VideoTransformationErrorEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        UploadPreTransformSuccessEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(UploadPreTransformErrorEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        UploadPostTransformSuccessEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(UploadPostTransformErrorEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(FileCreatedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(FileUpdatedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(FileDeletedWebhookEvent value) =>
        new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        FileVersionCreatedWebhookEvent value
    ) => new(value);

    public static implicit operator UnsafeUnwrapWebhookEvent(
        FileVersionDeletedWebhookEvent value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnsafeUnwrapWebhookEvent"
            );
        }
        this.Switch(
            (videoTransformationAccepted) => videoTransformationAccepted.Validate(),
            (videoTransformationReady) => videoTransformationReady.Validate(),
            (videoTransformationError) => videoTransformationError.Validate(),
            (uploadPreTransformSuccess) => uploadPreTransformSuccess.Validate(),
            (uploadPreTransformError) => uploadPreTransformError.Validate(),
            (uploadPostTransformSuccess) => uploadPostTransformSuccess.Validate(),
            (uploadPostTransformError) => uploadPostTransformError.Validate(),
            (fileCreated) => fileCreated.Validate(),
            (fileUpdated) => fileUpdated.Validate(),
            (fileDeleted) => fileDeleted.Validate(),
            (fileVersionCreated) => fileVersionCreated.Validate(),
            (fileVersionDeleted) => fileVersionDeleted.Validate()
        );
    }

    public virtual bool Equals(UnsafeUnwrapWebhookEvent? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            VideoTransformationAcceptedEvent _ => 0,
            VideoTransformationReadyEvent _ => 1,
            VideoTransformationErrorEvent _ => 2,
            UploadPreTransformSuccessEvent _ => 3,
            UploadPreTransformErrorEvent _ => 4,
            UploadPostTransformSuccessEvent _ => 5,
            UploadPostTransformErrorEvent _ => 6,
            FileCreatedWebhookEvent _ => 7,
            FileUpdatedWebhookEvent _ => 8,
            FileDeletedWebhookEvent _ => 9,
            FileVersionCreatedWebhookEvent _ => 10,
            FileVersionDeletedWebhookEvent _ => 11,
            _ => -1,
        };
    }
}

sealed class UnsafeUnwrapWebhookEventConverter : JsonConverter<UnsafeUnwrapWebhookEvent>
{
    public override UnsafeUnwrapWebhookEvent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            default:
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoTransformationAcceptedEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoTransformationReadyEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<VideoTransformationErrorEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UploadPreTransformSuccessEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UploadPreTransformErrorEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UploadPostTransformSuccessEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<UploadPostTransformErrorEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileCreatedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileUpdatedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileDeletedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileVersionCreatedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                try
                {
                    var deserialized = JsonSerializer.Deserialize<FileVersionDeletedWebhookEvent>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnsafeUnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
