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
[JsonConverter(typeof(UnwrapWebhookEventConverter))]
public record class UnwrapWebhookEvent : ModelBase
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
                uploadPostTransformError: (x) => x.CreatedAt
            );
        }
    }

    public UnwrapWebhookEvent(VideoTransformationAcceptedEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(VideoTransformationReadyEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(VideoTransformationErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UploadPreTransformSuccessEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UploadPreTransformErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UploadPostTransformSuccessEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(UploadPostTransformErrorEvent value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UnwrapWebhookEvent(JsonElement element)
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
    ///     (UploadPostTransformErrorEvent value) =&gt; {...}
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
        System::Action<UploadPostTransformErrorEvent> uploadPostTransformError
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
                    "Data did not match any variant of UnwrapWebhookEvent"
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
    ///     (UploadPostTransformErrorEvent value) =&gt; {...}
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
        System::Func<UploadPostTransformErrorEvent, T> uploadPostTransformError
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
                "Data did not match any variant of UnwrapWebhookEvent"
            ),
        };
    }

    public static implicit operator UnwrapWebhookEvent(VideoTransformationAcceptedEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(VideoTransformationReadyEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(VideoTransformationErrorEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(UploadPreTransformSuccessEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(UploadPreTransformErrorEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(UploadPostTransformSuccessEvent value) =>
        new(value);

    public static implicit operator UnwrapWebhookEvent(UploadPostTransformErrorEvent value) =>
        new(value);

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
                "Data did not match any variant of UnwrapWebhookEvent"
            );
        }
        this.Switch(
            (videoTransformationAccepted) => videoTransformationAccepted.Validate(),
            (videoTransformationReady) => videoTransformationReady.Validate(),
            (videoTransformationError) => videoTransformationError.Validate(),
            (uploadPreTransformSuccess) => uploadPreTransformSuccess.Validate(),
            (uploadPreTransformError) => uploadPreTransformError.Validate(),
            (uploadPostTransformSuccess) => uploadPostTransformSuccess.Validate(),
            (uploadPostTransformError) => uploadPostTransformError.Validate()
        );
    }

    public virtual bool Equals(UnwrapWebhookEvent? other) =>
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
            _ => -1,
        };
    }
}

sealed class UnwrapWebhookEventConverter : JsonConverter<UnwrapWebhookEvent>
{
    public override UnwrapWebhookEvent? Read(
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

                return new(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnwrapWebhookEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
