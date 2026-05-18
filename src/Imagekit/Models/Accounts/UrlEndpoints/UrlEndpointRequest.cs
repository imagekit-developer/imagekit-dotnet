using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;
using System = System;

namespace Imagekit.Models.Accounts.UrlEndpoints;

/// <summary>
/// Schema for URL endpoint resource.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UrlEndpointRequest, UrlEndpointRequestFromRaw>))]
public sealed record class UrlEndpointRequest : JsonModel
{
    /// <summary>
    /// Description of the URL endpoint.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
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
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("origins");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
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
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("urlPrefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlPrefix", value);
        }
    }

    /// <summary>
    /// Configuration for third-party URL rewriting.
    /// </summary>
    public UrlEndpointRequestUrlRewriter? UrlRewriter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UrlEndpointRequestUrlRewriter>("urlRewriter");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("urlRewriter", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Origins;
        _ = this.UrlPrefix;
        this.UrlRewriter?.Validate();
    }

    public UrlEndpointRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointRequest(UrlEndpointRequest urlEndpointRequest)
        : base(urlEndpointRequest) { }
#pragma warning restore CS8618

    public UrlEndpointRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEndpointRequestFromRaw.FromRawUnchecked"/>
    public static UrlEndpointRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public UrlEndpointRequest(string description)
        : this()
    {
        this.Description = description;
    }
}

class UrlEndpointRequestFromRaw : IFromRawJson<UrlEndpointRequest>
{
    /// <inheritdoc/>
    public UrlEndpointRequest FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UrlEndpointRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Configuration for third-party URL rewriting.
/// </summary>
[JsonConverter(typeof(UrlEndpointRequestUrlRewriterConverter))]
public record class UrlEndpointRequestUrlRewriter : ModelBase
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

    public UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterCloudinary value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterImgix value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterAkamai value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UrlEndpointRequestUrlRewriter(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointRequestUrlRewriterCloudinary"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinary(out var value)) {
    ///     // `value` is of type `UrlEndpointRequestUrlRewriterCloudinary`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinary(
        [NotNullWhen(true)] out UrlEndpointRequestUrlRewriterCloudinary? value
    )
    {
        value = this.Value as UrlEndpointRequestUrlRewriterCloudinary;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointRequestUrlRewriterImgix"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickImgix(out var value)) {
    ///     // `value` is of type `UrlEndpointRequestUrlRewriterImgix`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickImgix([NotNullWhen(true)] out UrlEndpointRequestUrlRewriterImgix? value)
    {
        value = this.Value as UrlEndpointRequestUrlRewriterImgix;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UrlEndpointRequestUrlRewriterAkamai"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkamai(out var value)) {
    ///     // `value` is of type `UrlEndpointRequestUrlRewriterAkamai`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkamai([NotNullWhen(true)] out UrlEndpointRequestUrlRewriterAkamai? value)
    {
        value = this.Value as UrlEndpointRequestUrlRewriterAkamai;
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
    ///     (UrlEndpointRequestUrlRewriterCloudinary value) =&gt; {...},
    ///     (UrlEndpointRequestUrlRewriterImgix value) =&gt; {...},
    ///     (UrlEndpointRequestUrlRewriterAkamai value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UrlEndpointRequestUrlRewriterCloudinary> cloudinary,
        System::Action<UrlEndpointRequestUrlRewriterImgix> imgix,
        System::Action<UrlEndpointRequestUrlRewriterAkamai> akamai
    )
    {
        switch (this.Value)
        {
            case UrlEndpointRequestUrlRewriterCloudinary value:
                cloudinary(value);
                break;
            case UrlEndpointRequestUrlRewriterImgix value:
                imgix(value);
                break;
            case UrlEndpointRequestUrlRewriterAkamai value:
                akamai(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UrlEndpointRequestUrlRewriter"
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
    ///     (UrlEndpointRequestUrlRewriterCloudinary value) =&gt; {...},
    ///     (UrlEndpointRequestUrlRewriterImgix value) =&gt; {...},
    ///     (UrlEndpointRequestUrlRewriterAkamai value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UrlEndpointRequestUrlRewriterCloudinary, T> cloudinary,
        System::Func<UrlEndpointRequestUrlRewriterImgix, T> imgix,
        System::Func<UrlEndpointRequestUrlRewriterAkamai, T> akamai
    )
    {
        return this.Value switch
        {
            UrlEndpointRequestUrlRewriterCloudinary value => cloudinary(value),
            UrlEndpointRequestUrlRewriterImgix value => imgix(value),
            UrlEndpointRequestUrlRewriterAkamai value => akamai(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UrlEndpointRequestUrlRewriter"
            ),
        };
    }

    public static implicit operator UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterCloudinary value
    ) => new(value);

    public static implicit operator UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterImgix value
    ) => new(value);

    public static implicit operator UrlEndpointRequestUrlRewriter(
        UrlEndpointRequestUrlRewriterAkamai value
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
                "Data did not match any variant of UrlEndpointRequestUrlRewriter"
            );
        }
        this.Switch(
            (cloudinary) => cloudinary.Validate(),
            (imgix) => imgix.Validate(),
            (akamai) => akamai.Validate()
        );
    }

    public virtual bool Equals(UrlEndpointRequestUrlRewriter? other) =>
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
            UrlEndpointRequestUrlRewriterCloudinary _ => 0,
            UrlEndpointRequestUrlRewriterImgix _ => 1,
            UrlEndpointRequestUrlRewriterAkamai _ => 2,
            _ => -1,
        };
    }
}

sealed class UrlEndpointRequestUrlRewriterConverter : JsonConverter<UrlEndpointRequestUrlRewriter>
{
    public override UrlEndpointRequestUrlRewriter? Read(
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
            case "CLOUDINARY":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterCloudinary>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterImgix>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
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
                        JsonSerializer.Deserialize<UrlEndpointRequestUrlRewriterAkamai>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new UrlEndpointRequestUrlRewriter(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointRequestUrlRewriter value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        UrlEndpointRequestUrlRewriterCloudinary,
        UrlEndpointRequestUrlRewriterCloudinaryFromRaw
    >)
)]
public sealed record class UrlEndpointRequestUrlRewriterCloudinary : JsonModel
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
    /// Whether to preserve `&lt;asset_type&gt;/&lt;delivery_type&gt;` in the rewritten URL.
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

    public UrlEndpointRequestUrlRewriterCloudinary()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UrlEndpointRequestUrlRewriterCloudinary(
        UrlEndpointRequestUrlRewriterCloudinary urlEndpointRequestUrlRewriterCloudinary
    )
        : base(urlEndpointRequestUrlRewriterCloudinary) { }
#pragma warning restore CS8618

    public UrlEndpointRequestUrlRewriterCloudinary(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UrlEndpointRequestUrlRewriterCloudinary(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UrlEndpointRequestUrlRewriterCloudinaryFromRaw.FromRawUnchecked"/>
    public static UrlEndpointRequestUrlRewriterCloudinary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UrlEndpointRequestUrlRewriterCloudinaryFromRaw
    : IFromRawJson<UrlEndpointRequestUrlRewriterCloudinary>
{
    /// <inheritdoc/>
    public UrlEndpointRequestUrlRewriterCloudinary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UrlEndpointRequestUrlRewriterCloudinary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UrlEndpointRequestUrlRewriterImgixConverter))]
public record class UrlEndpointRequestUrlRewriterImgix
{
    public JsonElement Element { get; private init; }

    public UrlEndpointRequestUrlRewriterImgix()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "IMGIX"
            }
            """
        );
    }

    internal UrlEndpointRequestUrlRewriterImgix(JsonElement element)
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
        if (this != new UrlEndpointRequestUrlRewriterImgix())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UrlEndpointRequestUrlRewriterImgix'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UrlEndpointRequestUrlRewriterImgix? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UrlEndpointRequestUrlRewriterImgixConverter
    : JsonConverter<UrlEndpointRequestUrlRewriterImgix>
{
    public override UrlEndpointRequestUrlRewriterImgix? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointRequestUrlRewriterImgix value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}

[JsonConverter(typeof(UrlEndpointRequestUrlRewriterAkamaiConverter))]
public record class UrlEndpointRequestUrlRewriterAkamai
{
    public JsonElement Element { get; private init; }

    public UrlEndpointRequestUrlRewriterAkamai()
    {
        Element = JsonSerializer.Deserialize<JsonElement>(
            """
            {
              "type": "AKAMAI"
            }
            """
        );
    }

    internal UrlEndpointRequestUrlRewriterAkamai(JsonElement element)
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
        if (this != new UrlEndpointRequestUrlRewriterAkamai())
        {
            throw new ImageKitInvalidDataException(
                "Invalid value given for 'UrlEndpointRequestUrlRewriterAkamai'"
            );
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public virtual bool Equals(UrlEndpointRequestUrlRewriterAkamai? other)
    {
        if (other == null)
        {
            return false;
        }

        return JsonElement.DeepEquals(this.Element, other.Element);
    }
}

class UrlEndpointRequestUrlRewriterAkamaiConverter
    : JsonConverter<UrlEndpointRequestUrlRewriterAkamai>
{
    public override UrlEndpointRequestUrlRewriterAkamai? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return new(JsonSerializer.Deserialize<JsonElement>(ref reader, options));
    }

    public override void Write(
        Utf8JsonWriter writer,
        UrlEndpointRequestUrlRewriterAkamai value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Element, options);
    }
}
