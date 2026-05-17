using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;
using Dummy = ImagekitDiversion.Models.Dummy;
using System = System;

namespace ImagekitDiversion.Models.Files.Details;

/// <summary>
/// This API updates the details or attributes of the current version of the file.
/// You can update `tags`, `customCoordinates`, `customMetadata`, publication status,
/// remove existing `AITags` and apply extensions using this API.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DetailUpdateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? FileID { get; init; }

    /// <summary>
    /// Schema for update file update request.
    /// </summary>
    public required Body Body
    {
        get { return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData"); }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public DetailUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailUpdateParams(DetailUpdateParams detailUpdateParams)
        : base(detailUpdateParams)
    {
        this.FileID = detailUpdateParams.FileID;

        this.RawBodyData = detailUpdateParams.RawBodyData;
    }
#pragma warning restore CS8618

    public DetailUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string fileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.FileID = fileID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DetailUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string fileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            fileID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FileID"] = JsonSerializer.SerializeToElement(this.FileID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(DetailUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FileID?.Equals(other.FileID) ?? other.FileID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this.RawBodyData.Equals(other.RawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/files/{0}/details", this.FileID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Schema for update file update request.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
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

    public Body(UpdateFileDetails value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(ChangePublicationStatus value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body(JsonElement element)
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
    /// if (instance.TryPickUpdateFileDetails(out var value)) {
    ///     // `value` is of type `UpdateFileDetails`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUpdateFileDetails([NotNullWhen(true)] out UpdateFileDetails? value)
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
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
        System::Action<UpdateFileDetails> updateFileDetails,
        System::Action<ChangePublicationStatus> changePublicationStatus
    )
    {
        switch (this.Value)
        {
            case UpdateFileDetails value:
                updateFileDetails(value);
                break;
            case ChangePublicationStatus value:
                changePublicationStatus(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
                    "Data did not match any variant of Body"
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
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
        System::Func<UpdateFileDetails, T> updateFileDetails,
        System::Func<ChangePublicationStatus, T> changePublicationStatus
    )
    {
        return this.Value switch
        {
            UpdateFileDetails value => updateFileDetails(value),
            ChangePublicationStatus value => changePublicationStatus(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Body"
            ),
        };
    }

    public static implicit operator Body(UpdateFileDetails value) => new(value);

    public static implicit operator Body(ChangePublicationStatus value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of Body"
            );
        }
        this.Switch(
            (updateFileDetails) => updateFileDetails.Validate(),
            (changePublicationStatus) => changePublicationStatus.Validate()
        );
    }

    public virtual bool Equals(Body? other) =>
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

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
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
        catch (System::Exception e)
            when (e is JsonException || e is ImagekitDiversionInvalidDataException)
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
        catch (System::Exception e)
            when (e is JsonException || e is ImagekitDiversionInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("customCoordinates", value);
        }
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
    public IReadOnlyList<Dummy::ExtensionsItem>? Extensions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Dummy::ExtensionsItem>>(
                "extensions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Dummy::ExtensionsItem>?>(
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
    /// are processed.</para>
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
            if (value == null)
            {
                return;
            }

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
/// are processed.</para>
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

    public RemoveAITags(All value, JsonElement? element = null)
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
    /// type <see cref="All"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAll(out var value)) {
    ///     // `value` is of type `All`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAll([NotNullWhen(true)] out All? value)
    {
        value = this.Value as All;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (All value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(System::Action<IReadOnlyList<string>> strings, System::Action<All> all)
    {
        switch (this.Value)
        {
            case IReadOnlyList<string> value:
                strings(value);
                break;
            case All value:
                all(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (IReadOnlyList&lt;string&gt; value) =&gt; {...},
    ///     (All value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(System::Func<IReadOnlyList<string>, T> strings, System::Func<All, T> all)
    {
        return this.Value switch
        {
            IReadOnlyList<string> value => strings(value),
            All value => all(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of RemoveAITags"
            ),
        };
    }

    public static implicit operator RemoveAITags(List<string> value) =>
        new((IReadOnlyList<string>)value);

    public static implicit operator RemoveAITags(All value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new ImagekitDiversionInvalidDataException(
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
            All _ => 1,
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
            var deserialized = JsonSerializer.Deserialize<All>(element, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)
            when (e is JsonException || e is ImagekitDiversionInvalidDataException)
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
        catch (System::Exception e)
            when (e is JsonException || e is ImagekitDiversionInvalidDataException)
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

[JsonConverter(typeof(AllConverter))]
public record class All
{
    public JsonElement Element { get; private init; }

    public All()
    {
        Element = JsonSerializer.SerializeToElement("all");
    }

    internal All(JsonElement element)
    {
        Element = element;
    }

    /// <summary>
    /// Validates that the instance's underlying value is the expected constant.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this != new All())
        {
            throw new ImagekitDiversionInvalidDataException("Invalid value given for 'All'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(All? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class AllConverter : JsonConverter<All>
{
    public override All? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, All value, JsonSerializerOptions options)
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
