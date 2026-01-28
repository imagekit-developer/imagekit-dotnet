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
/// **Note:** This API is currently in beta.   Creates a new URL‑endpoint and returns
/// the resulting object.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UrlEndpointCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

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
    public UrlRewriter? UrlRewriter
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<UrlRewriter>("urlRewriter");
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

    public UrlEndpointCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointCreateParams(UrlEndpointCreateParams urlEndpointCreateParams)
        : base(urlEndpointCreateParams)
    {
        this._rawBodyData = new(urlEndpointCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public UrlEndpointCreateParams(
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
    UrlEndpointCreateParams(
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
    public static UrlEndpointCreateParams FromRawUnchecked(
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
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(UrlEndpointCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/accounts/url-endpoints"
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
[JsonConverter(typeof(UrlRewriterConverter))]
public record class UrlRewriter : ModelBase
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

    public UrlRewriter(Cloudinary value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UrlRewriter(Imgix value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UrlRewriter(Akamai value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public UrlRewriter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Cloudinary"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinary(out var value)) {
    ///     // `value` is of type `Cloudinary`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinary([NotNullWhen(true)] out Cloudinary? value)
    {
        value = this.Value as Cloudinary;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Imgix"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImgix(out var value)) {
    ///     // `value` is of type `Imgix`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImgix([NotNullWhen(true)] out Imgix? value)
    {
        value = this.Value as Imgix;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Akamai"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkamai(out var value)) {
    ///     // `value` is of type `Akamai`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkamai([NotNullWhen(true)] out Akamai? value)
    {
        value = this.Value as Akamai;
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
    ///     (Cloudinary value) => {...},
    ///     (Imgix value) => {...},
    ///     (Akamai value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(Action<Cloudinary> cloudinary, Action<Imgix> imgix, Action<Akamai> akamai)
    {
        switch (this.Value)
        {
            case Cloudinary value:
                cloudinary(value);
                break;
            case Imgix value:
                imgix(value);
                break;
            case Akamai value:
                akamai(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UrlRewriter"
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
    ///     (Cloudinary value) => {...},
    ///     (Imgix value) => {...},
    ///     (Akamai value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(Func<Cloudinary, T> cloudinary, Func<Imgix, T> imgix, Func<Akamai, T> akamai)
    {
        return this.Value switch
        {
            Cloudinary value => cloudinary(value),
            Imgix value => imgix(value),
            Akamai value => akamai(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UrlRewriter"
            ),
        };
    }

    public static implicit operator UrlRewriter(Cloudinary value) => new(value);

    public static implicit operator UrlRewriter(Imgix value) => new(value);

    public static implicit operator UrlRewriter(Akamai value) => new(value);

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
            throw new ImageKitInvalidDataException("Data did not match any variant of UrlRewriter");
        }
        this.Switch(
            (cloudinary) => cloudinary.Validate(),
            (imgix) => imgix.Validate(),
            (akamai) => akamai.Validate()
        );
    }

    public virtual bool Equals(UrlRewriter? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class UrlRewriterConverter : JsonConverter<UrlRewriter>
{
    public override UrlRewriter? Read(
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
                    var deserialized = JsonSerializer.Deserialize<Cloudinary>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Imgix>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Akamai>(element, options);
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
                return new UrlRewriter(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlRewriter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<Cloudinary, CloudinaryFromRaw>))]
public sealed record class Cloudinary : JsonModel
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

    public Cloudinary()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cloudinary(Cloudinary cloudinary)
        : base(cloudinary) { }
#pragma warning restore CS8618

    public Cloudinary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cloudinary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudinaryFromRaw.FromRawUnchecked"/>
    public static Cloudinary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudinaryFromRaw : IFromRawJson<Cloudinary>
{
    /// <inheritdoc/>
    public Cloudinary FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cloudinary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ImgixConverter))]
public record class Imgix
{
    public JsonElement Element { get; private init; }

    public Imgix()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "IMGIX"
            }
            """
        );
    }

    internal Imgix(JsonElement element)
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
        if (this != new Imgix())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'Imgix'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Imgix? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class ImgixConverter : JsonConverter<Imgix>
{
    public override Imgix? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Imgix value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(AkamaiConverter))]
public record class Akamai
{
    public JsonElement Element { get; private init; }

    public Akamai()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "AKAMAI"
            }
            """
        );
    }

    internal Akamai(JsonElement element)
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
        if (this != new Akamai())
        {
            throw new ImageKitInvalidDataException("Invalid value given for 'Akamai'");
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(Akamai? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class AkamaiConverter : JsonConverter<Akamai>
{
    public override Akamai? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(Utf8JsonWriter writer, Akamai value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}
