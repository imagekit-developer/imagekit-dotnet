using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;
using Text = System.Text;

namespace ImageKit.Models.Accounts.UrlEndpoints;

/// <summary>
/// **Note:** This API is currently in beta.   Updates the URL‑endpoint identified
/// by `id` and returns the updated object.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UrlEndpointUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Description of the URL endpoint.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("description");
        }
        init { this._rawBodyData.Set("description", value); }
    }

    /// <summary>
    /// Ordered list of origin IDs to try when the file isn’t in the Media Library;
    /// ImageKit checks them in the sequence provided. Origin must be created before
    /// it can be used in a URL endpoint.
    /// </summary>
    public IReadOnlyList<string>? Origins
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>("origins");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "origins",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Path segment appended to your base URL to form the endpoint (letters, digits,
    /// and hyphens only — or empty for the default endpoint).
    /// </summary>
    public string? UrlPrefix
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("urlPrefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("urlPrefix", value);
        }
    }

    /// <summary>
    /// Configuration for third-party URL rewriting.
    /// </summary>
    public UrlEndpointUpdateParamsUrlRewriter? UrlRewriter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UrlEndpointUpdateParamsUrlRewriter>(
                "urlRewriter"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("urlRewriter", value);
        }
    }

    public UrlEndpointUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointUpdateParams(UrlEndpointUpdateParams urlEndpointUpdateParams)
        : base(urlEndpointUpdateParams)
    {
        this.ID = urlEndpointUpdateParams.ID;

        this._rawBodyData = new(urlEndpointUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UrlEndpointUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static UrlEndpointUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["ID"] = this.ID,
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UrlEndpointUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/accounts/url-endpoints/{0}", this.ID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Text::Encoding.UTF8,
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
/// Configuration for third-party URL rewriting.
/// </summary>
[JsonConverter(typeof(UrlEndpointUpdateParamsUrlRewriterConverter))]
public record class UrlEndpointUpdateParamsUrlRewriter : ModelBase
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

    public UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterCloudinary value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterImgix value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterAkamai value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointUpdateParamsUrlRewriter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointUpdateParamsUrlRewriterCloudinary"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinary(out var value)) {
    ///     // `value` is of type `UrlEndpointUpdateParamsUrlRewriterCloudinary`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinary(
        [NotNullWhen(true)] out UrlEndpointUpdateParamsUrlRewriterCloudinary? value
    )
    {
        value = this.Value as UrlEndpointUpdateParamsUrlRewriterCloudinary;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointUpdateParamsUrlRewriterImgix"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImgix(out var value)) {
    ///     // `value` is of type `UrlEndpointUpdateParamsUrlRewriterImgix`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImgix([NotNullWhen(true)] out UrlEndpointUpdateParamsUrlRewriterImgix? value)
    {
        value = this.Value as UrlEndpointUpdateParamsUrlRewriterImgix;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointUpdateParamsUrlRewriterAkamai"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkamai(out var value)) {
    ///     // `value` is of type `UrlEndpointUpdateParamsUrlRewriterAkamai`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkamai(
        [NotNullWhen(true)] out UrlEndpointUpdateParamsUrlRewriterAkamai? value
    )
    {
        value = this.Value as UrlEndpointUpdateParamsUrlRewriterAkamai;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (UrlEndpointUpdateParamsUrlRewriterCloudinary value) => {...},
    ///     (UrlEndpointUpdateParamsUrlRewriterImgix value) => {...},
    ///     (UrlEndpointUpdateParamsUrlRewriterAkamai value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<UrlEndpointUpdateParamsUrlRewriterCloudinary> cloudinary,
        Action<UrlEndpointUpdateParamsUrlRewriterImgix> imgix,
        Action<UrlEndpointUpdateParamsUrlRewriterAkamai> akamai
    )
    {
        switch (this.Value)
        {
            case UrlEndpointUpdateParamsUrlRewriterCloudinary value:
                cloudinary(value);
                break;
            case UrlEndpointUpdateParamsUrlRewriterImgix value:
                imgix(value);
                break;
            case UrlEndpointUpdateParamsUrlRewriterAkamai value:
                akamai(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UrlEndpointUpdateParamsUrlRewriter"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (UrlEndpointUpdateParamsUrlRewriterCloudinary value) => {...},
    ///     (UrlEndpointUpdateParamsUrlRewriterImgix value) => {...},
    ///     (UrlEndpointUpdateParamsUrlRewriterAkamai value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<UrlEndpointUpdateParamsUrlRewriterCloudinary, T> cloudinary,
        Func<UrlEndpointUpdateParamsUrlRewriterImgix, T> imgix,
        Func<UrlEndpointUpdateParamsUrlRewriterAkamai, T> akamai
    )
    {
        return this.Value switch
        {
            UrlEndpointUpdateParamsUrlRewriterCloudinary value => cloudinary(value),
            UrlEndpointUpdateParamsUrlRewriterImgix value => imgix(value),
            UrlEndpointUpdateParamsUrlRewriterAkamai value => akamai(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UrlEndpointUpdateParamsUrlRewriter"
            ),
        };
    }

    public static implicit operator UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterCloudinary value
    ) => new(value);

    public static implicit operator UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterImgix value
    ) => new(value);

    public static implicit operator UrlEndpointUpdateParamsUrlRewriter(
        UrlEndpointUpdateParamsUrlRewriterAkamai value
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
                "Data did not match any variant of UrlEndpointUpdateParamsUrlRewriter"
            );
        }
        this.Switch(
            (cloudinary) => cloudinary.Validate(),
            (imgix) => imgix.Validate(),
            (akamai) => akamai.Validate()
        );
    }

    public virtual bool Equals(UrlEndpointUpdateParamsUrlRewriter? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            UrlEndpointUpdateParamsUrlRewriterCloudinary _ => 0,
            UrlEndpointUpdateParamsUrlRewriterImgix _ => 1,
            UrlEndpointUpdateParamsUrlRewriterAkamai _ => 2,
            _ => -1,
        };
    }
}

sealed class UrlEndpointUpdateParamsUrlRewriterConverter
    : JsonConverter<UrlEndpointUpdateParamsUrlRewriter>
{
    public override UrlEndpointUpdateParamsUrlRewriter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "CLOUDINARY":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterCloudinary>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "IMGIX":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterImgix>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "AKAMAI":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UrlEndpointUpdateParamsUrlRewriterAkamai>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UrlEndpointUpdateParamsUrlRewriter(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointUpdateParamsUrlRewriter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UrlEndpointUpdateParamsUrlRewriterCloudinary,
        UrlEndpointUpdateParamsUrlRewriterCloudinaryFromRaw
    >)
)]
public sealed record class UrlEndpointUpdateParamsUrlRewriterCloudinary : JsonModel
{
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
    /// Whether to preserve `<asset_type>/<delivery_type>` in the rewritten URL.
    /// </summary>
    public bool? PreserveAssetDeliveryTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("preserveAssetDeliveryTypes");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("preserveAssetDeliveryTypes", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("CLOUDINARY")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.PreserveAssetDeliveryTypes;
    }

    public UrlEndpointUpdateParamsUrlRewriterCloudinary()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointUpdateParamsUrlRewriterCloudinary(
        UrlEndpointUpdateParamsUrlRewriterCloudinary urlEndpointUpdateParamsUrlRewriterCloudinary
    )
        : base(urlEndpointUpdateParamsUrlRewriterCloudinary) { }
#pragma warning restore CS8618

    public UrlEndpointUpdateParamsUrlRewriterCloudinary(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointUpdateParamsUrlRewriterCloudinary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEndpointUpdateParamsUrlRewriterCloudinaryFromRaw.FromRawUnchecked"/>
    public static UrlEndpointUpdateParamsUrlRewriterCloudinary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlEndpointUpdateParamsUrlRewriterCloudinaryFromRaw
    : IFromRawJson<UrlEndpointUpdateParamsUrlRewriterCloudinary>
{
    /// <inheritdoc/>
    public UrlEndpointUpdateParamsUrlRewriterCloudinary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlEndpointUpdateParamsUrlRewriterCloudinary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UrlEndpointUpdateParamsUrlRewriterImgixConverter))]
public record class UrlEndpointUpdateParamsUrlRewriterImgix
{
    public JsonElement Element { get; private init; }

    public UrlEndpointUpdateParamsUrlRewriterImgix()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "IMGIX"
            }
            """
        );
    }

    internal UrlEndpointUpdateParamsUrlRewriterImgix(JsonElement element)
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
        if (this != new UrlEndpointUpdateParamsUrlRewriterImgix())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UrlEndpointUpdateParamsUrlRewriterImgix'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UrlEndpointUpdateParamsUrlRewriterImgix? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UrlEndpointUpdateParamsUrlRewriterImgixConverter
    : JsonConverter<UrlEndpointUpdateParamsUrlRewriterImgix>
{
    public override UrlEndpointUpdateParamsUrlRewriterImgix? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointUpdateParamsUrlRewriterImgix value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(UrlEndpointUpdateParamsUrlRewriterAkamaiConverter))]
public record class UrlEndpointUpdateParamsUrlRewriterAkamai
{
    public JsonElement Element { get; private init; }

    public UrlEndpointUpdateParamsUrlRewriterAkamai()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "AKAMAI"
            }
            """
        );
    }

    internal UrlEndpointUpdateParamsUrlRewriterAkamai(JsonElement element)
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
        if (this != new UrlEndpointUpdateParamsUrlRewriterAkamai())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UrlEndpointUpdateParamsUrlRewriterAkamai'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UrlEndpointUpdateParamsUrlRewriterAkamai? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UrlEndpointUpdateParamsUrlRewriterAkamaiConverter
    : JsonConverter<UrlEndpointUpdateParamsUrlRewriterAkamai>
{
    public override UrlEndpointUpdateParamsUrlRewriterAkamai? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointUpdateParamsUrlRewriterAkamai value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}
