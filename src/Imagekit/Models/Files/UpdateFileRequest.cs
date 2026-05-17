using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Files;

/// <summary>
/// Schema for update file update request.
/// </summary>
[JsonConverter(typeof(UpdateFileRequestConverter))]
public record class UpdateFileRequest : ModelBase
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

    public UpdateFileRequest(UpdateFileDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFileRequest(ChangePublicationStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UpdateFileRequest(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UpdateFileDetails"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDetails(out var value)) {
    ///     // `value` is of type `UpdateFileDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDetails([NotNullWhen(true)] out UpdateFileDetails? value)
    {
        value = this.Value as UpdateFileDetails;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ChangePublicationStatus"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickChangePublicationStatus(out var value)) {
    ///     // `value` is of type `ChangePublicationStatus`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickChangePublicationStatus(
        [NotNullWhen(true)] out ChangePublicationStatus? value
    )
    {
        value = this.Value as ChangePublicationStatus;
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
    ///     (UpdateFileDetails value) =&gt; {...},
    ///     (ChangePublicationStatus value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UpdateFileDetails> details,
        System::Action<ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this.Value)
        {
            case UpdateFileDetails value:
                details(value);
                break;
            case ChangePublicationStatus value:
                changePublicationStatus(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UpdateFileRequest"
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
    ///     (UpdateFileDetails value) =&gt; {...},
    ///     (ChangePublicationStatus value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UpdateFileDetails, T> details,
        System::Func<ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this.Value switch
        {
            UpdateFileDetails value => details(value),
            ChangePublicationStatus value => changePublicationStatus(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UpdateFileRequest"
            ),
        };
    }

    public static implicit operator UpdateFileRequest(UpdateFileDetails value) => new(value);

    public static implicit operator UpdateFileRequest(ChangePublicationStatus value) => new(value);

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
                "Data did not match any variant of UpdateFileRequest"
            );
        }
        this.Switch(
            (details) => details.Validate(),
            (changePublicationStatus) => changePublicationStatus.Validate()
        );
    }

    public virtual bool Equals(UpdateFileRequest? other) =>
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
            UpdateFileDetails _ => 0,
            ChangePublicationStatus _ => 1,
            _ => -1,
        };
    }
}

sealed class UpdateFileRequestConverter : JsonConverter<UpdateFileRequest>
{
    public override UpdateFileRequest? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UpdateFileDetails>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ChangePublicationStatus>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UpdateFileRequest value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<UpdateFileDetails, UpdateFileDetailsFromRaw>))]
public sealed record class UpdateFileDetails : JsonModel
{
    /// <summary>
    /// Define an important area in the image in the format `x,y,width,height` e.g.
    /// `10,10,100,100`. Send `null` to unset this value.
    /// </summary>
    public string? CustomCoordinates
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("customCoordinates");
        }
        init { this._rawData.Set("customCoordinates", value); }
    }

    /// <summary>
    /// A key-value data to be associated with the asset. To unset a key, send `null`
    /// value for that key. Before setting any custom metadata on an asset you have
    /// to create the field using custom metadata fields API.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? CustomMetadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "customMetadata"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "customMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional text to describe the contents of the file.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Array of extensions to be applied to the asset. Each extension can be configured
    /// with specific parameters based on the extension type.
    /// </summary>
    public IReadOnlyList<UnnamedSchemaWithArrayParent0>? Extensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UnnamedSchemaWithArrayParent0>>(
                "extensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<UnnamedSchemaWithArrayParent0>?>(
                "extensions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An array of AITags associated with the file that you want to remove, e.g.
    /// `["car", "vehicle", "motorsports"]`.
    ///
    /// <para>If you want to remove all AITags associated with the file, send a string
    /// - "all".</para>
    ///
    /// <para>Note: The remove operation for `AITags` executes before any of the `extensions`
    /// are processed. </para>
    /// </summary>
    public RemoveAITags? RemoveAITags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RemoveAITags>("removeAITags");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("removeAITags", value);
        }
    }

    /// <summary>
    /// An array of tags associated with the file, such as `["tag1", "tag2"]`. Send
    /// `null` to unset all tags associated with the file.
    /// </summary>
    public IReadOnlyList<string>? Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("tags");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The final status of extensions after they have completed execution will be
    /// delivered to this endpoint as a POST request. [Learn more](/docs/api-reference/digital-asset-management-dam/managing-assets/update-file-details#webhook-payload-structure)
    /// about the webhook payload structure.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhookUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookUrl", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CustomCoordinates;
        _ = this.CustomMetadata;
        _ = this.Description;
        foreach (var item in this.Extensions ?? [])
        {
            item.Validate();
        }
        this.RemoveAITags?.Validate();
        _ = this.Tags;
        _ = this.WebhookUrl;
    }

    public UpdateFileDetails() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateFileDetails(UpdateFileDetails updateFileDetails)
        : base(updateFileDetails) { }
#pragma warning restore CS8618

    public UpdateFileDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateFileDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UpdateFileDetailsFromRaw.FromRawUnchecked"/>
    public static UpdateFileDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UpdateFileDetailsFromRaw : IFromRawJson<UpdateFileDetails>
{
    /// <inheritdoc/>
    public UpdateFileDetails FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UpdateFileDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// An array of AITags associated with the file that you want to remove, e.g. `["car",
/// "vehicle", "motorsports"]`.
///
/// <para>If you want to remove all AITags associated with the file, send a string
/// - "all".</para>
///
/// <para>Note: The remove operation for `AITags` executes before any of the `extensions`
/// are processed. </para>
/// </summary>
[JsonConverter(typeof(RemoveAITagsConverter))]
public record class RemoveAITags : ModelBase
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

    public RemoveAITags(IReadOnlyList<string> value, JsonElement? element = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public RemoveAITags(UnionMember1 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public RemoveAITags(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="List{T}"/> where <c>T</c> is a <c>string</c>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickStrings(out var value)) {
    ///     // `value` is of type `IReadOnlyList&lt;string&gt;`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickStrings([NotNullWhen(true)] out IReadOnlyList<string>? value)
    {
        value = this.Value as IReadOnlyList<string>;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UnionMember1"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `UnionMember1`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<IReadOnlyList<string>> strings,
        System::Action<UnionMember1> all
    )
    {
        switch (this.Value)
        {
            case IReadOnlyList<string> value:
                strings(value);
                break;
            case UnionMember1 value:
                all(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of RemoveAITags"
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
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (UnionMember1 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<IReadOnlyList<string>, T> strings,
        System::Func<UnionMember1, T> all
    )
    {
        return this.Value switch
        {
            IReadOnlyList<string> value => strings(value),
            UnionMember1 value => all(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of RemoveAITags"
            ),
        };
    }

    public static implicit operator RemoveAITags(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator RemoveAITags(UnionMember1 value) => new(value);

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
                "Data did not match any variant of RemoveAITags"
            );
        }
        this.Switch((_) => { }, (all) => all.Validate());
    }

    public virtual bool Equals(RemoveAITags? other) =>
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
            IReadOnlyList<string> _ => 0,
            UnionMember1 _ => 1,
            _ => -1,
        };
    }
}

sealed class RemoveAITagsConverter : JsonConverter<RemoveAITags>
{
    public override RemoveAITags? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<string>>(element, options);
            if (deserialized != null)
            {
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        RemoveAITags value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(UnionMember1Converter))]
public record class UnionMember1
{
    public JsonElement Element { get; private init; }

    public UnionMember1()
    {
        Element = JsonSerializer.SerializeToElement("all");
    }

    internal UnionMember1(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImageKitInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new UnionMember1())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'UnionMember1'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UnionMember1? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UnionMember1Converter : JsonConverter<UnionMember1>
{
    public override UnionMember1? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnionMember1 value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ChangePublicationStatus, ChangePublicationStatusFromRaw>))]
public sealed record class ChangePublicationStatus : JsonModel
{
    /// <summary>
    /// Configure the publication status of a file and its versions.
    /// </summary>
    public Publish? Publish
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Publish>("publish");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("publish", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Publish?.Validate();
    }

    public ChangePublicationStatus() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChangePublicationStatus(ChangePublicationStatus changePublicationStatus)
        : base(changePublicationStatus) { }
#pragma warning restore CS8618

    public ChangePublicationStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChangePublicationStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChangePublicationStatusFromRaw.FromRawUnchecked"/>
    public static ChangePublicationStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChangePublicationStatusFromRaw : IFromRawJson<ChangePublicationStatus>
{
    /// <inheritdoc/>
    public ChangePublicationStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChangePublicationStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// Configure the publication status of a file and its versions.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Publish, PublishFromRaw>))]
public sealed record class Publish : JsonModel
{
    /// <summary>
    /// Set to `true` to publish the file. Set to `false` to unpublish the file.
    /// </summary>
    public required bool IsPublished
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isPublished");
        }
        init { this._rawData.Set("isPublished", value); }
    }

    /// <summary>
    /// Set to `true` to publish/unpublish all versions of the file. Set to `false`
    /// to publish/unpublish only the current version of the file.
    /// </summary>
    public bool? IncludeFileVersions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeFileVersions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeFileVersions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsPublished;
        _ = this.IncludeFileVersions;
    }

    public Publish() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Publish(Publish publish)
        : base(publish) { }
#pragma warning restore CS8618

    public Publish(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Publish(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PublishFromRaw.FromRawUnchecked"/>
    public static Publish FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Publish(bool isPublished)
        : this()
    {
        this.IsPublished = isPublished;
    }
}

class PublishFromRaw : IFromRawJson<Publish>
{
    /// <inheritdoc/>
    public Publish FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Publish.FromRawUnchecked(rawData);
}
