using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImageKit.Core;
using ImageKit.Exceptions;

namespace ImageKit.Models.Accounts.Origins;

/// <summary>
/// Schema for origin request resources.
/// </summary>
[JsonConverter(typeof(OriginRequestConverter))]
public record class OriginRequest : ModelBase
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

    public string? AccessKey
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.AccessKey,
                s3Compatible: (x) => x.AccessKey,
                cloudinaryBackup: (x) => x.AccessKey,
                webFolder: (_) => null,
                webProxy: (_) => null,
                gcs: (_) => null,
                azureBlob: (_) => null,
                akeneoPim: (_) => null
            );
        }
    }

    public string? Bucket
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.Bucket,
                s3Compatible: (x) => x.Bucket,
                cloudinaryBackup: (x) => x.Bucket,
                webFolder: (_) => null,
                webProxy: (_) => null,
                gcs: (x) => x.Bucket,
                azureBlob: (_) => null,
                akeneoPim: (_) => null
            );
        }
    }

    public string Name
    {
        get
        {
            return Match(
                s3: (x) => x.Name,
                s3Compatible: (x) => x.Name,
                cloudinaryBackup: (x) => x.Name,
                webFolder: (x) => x.Name,
                webProxy: (x) => x.Name,
                gcs: (x) => x.Name,
                azureBlob: (x) => x.Name,
                akeneoPim: (x) => x.Name
            );
        }
    }

    public string? SecretKey
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.SecretKey,
                s3Compatible: (x) => x.SecretKey,
                cloudinaryBackup: (x) => x.SecretKey,
                webFolder: (_) => null,
                webProxy: (_) => null,
                gcs: (_) => null,
                azureBlob: (_) => null,
                akeneoPim: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                s3: (x) => x.Type,
                s3Compatible: (x) => x.Type,
                cloudinaryBackup: (x) => x.Type,
                webFolder: (x) => x.Type,
                webProxy: (x) => x.Type,
                gcs: (x) => x.Type,
                azureBlob: (x) => x.Type,
                akeneoPim: (x) => x.Type
            );
        }
    }

    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.BaseUrlForCanonicalHeader,
                s3Compatible: (x) => x.BaseUrlForCanonicalHeader,
                cloudinaryBackup: (x) => x.BaseUrlForCanonicalHeader,
                webFolder: (x) => x.BaseUrlForCanonicalHeader,
                webProxy: (x) => x.BaseUrlForCanonicalHeader,
                gcs: (x) => x.BaseUrlForCanonicalHeader,
                azureBlob: (x) => x.BaseUrlForCanonicalHeader,
                akeneoPim: (x) => x.BaseUrlForCanonicalHeader
            );
        }
    }

    public bool? IncludeCanonicalHeader
    {
        get
        {
            return Match<bool?>(
                s3: (x) => x.IncludeCanonicalHeader,
                s3Compatible: (x) => x.IncludeCanonicalHeader,
                cloudinaryBackup: (x) => x.IncludeCanonicalHeader,
                webFolder: (x) => x.IncludeCanonicalHeader,
                webProxy: (x) => x.IncludeCanonicalHeader,
                gcs: (x) => x.IncludeCanonicalHeader,
                azureBlob: (x) => x.IncludeCanonicalHeader,
                akeneoPim: (x) => x.IncludeCanonicalHeader
            );
        }
    }

    public string? Prefix
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.Prefix,
                s3Compatible: (x) => x.Prefix,
                cloudinaryBackup: (x) => x.Prefix,
                webFolder: (_) => null,
                webProxy: (_) => null,
                gcs: (x) => x.Prefix,
                azureBlob: (x) => x.Prefix,
                akeneoPim: (_) => null
            );
        }
    }

    public string? BaseUrl
    {
        get
        {
            return Match<string?>(
                s3: (_) => null,
                s3Compatible: (_) => null,
                cloudinaryBackup: (_) => null,
                webFolder: (x) => x.BaseUrl,
                webProxy: (_) => null,
                gcs: (_) => null,
                azureBlob: (_) => null,
                akeneoPim: (x) => x.BaseUrl
            );
        }
    }

    public OriginRequest(S3 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(S3Compatible value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(CloudinaryBackup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(WebFolder value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(WebProxy value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(Gcs value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(AzureBlob value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(AkeneoPim value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="S3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3(out var value)) {
    ///     // `value` is of type `S3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3([NotNullWhen(true)] out S3? value)
    {
        value = this.Value as S3;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="S3Compatible"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3Compatible(out var value)) {
    ///     // `value` is of type `S3Compatible`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3Compatible([NotNullWhen(true)] out S3Compatible? value)
    {
        value = this.Value as S3Compatible;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CloudinaryBackup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinaryBackup(out var value)) {
    ///     // `value` is of type `CloudinaryBackup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinaryBackup([NotNullWhen(true)] out CloudinaryBackup? value)
    {
        value = this.Value as CloudinaryBackup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFolder"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFolder(out var value)) {
    ///     // `value` is of type `WebFolder`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFolder([NotNullWhen(true)] out WebFolder? value)
    {
        value = this.Value as WebFolder;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebProxy"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebProxy(out var value)) {
    ///     // `value` is of type `WebProxy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebProxy([NotNullWhen(true)] out WebProxy? value)
    {
        value = this.Value as WebProxy;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Gcs"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGcs(out var value)) {
    ///     // `value` is of type `Gcs`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGcs([NotNullWhen(true)] out Gcs? value)
    {
        value = this.Value as Gcs;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AzureBlob"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureBlob(out var value)) {
    ///     // `value` is of type `AzureBlob`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureBlob([NotNullWhen(true)] out AzureBlob? value)
    {
        value = this.Value as AzureBlob;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AkeneoPim"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkeneoPim(out var value)) {
    ///     // `value` is of type `AkeneoPim`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkeneoPim([NotNullWhen(true)] out AkeneoPim? value)
    {
        value = this.Value as AkeneoPim;
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
    ///     (S3 value) =&gt; {...},
    ///     (S3Compatible value) =&gt; {...},
    ///     (CloudinaryBackup value) =&gt; {...},
    ///     (WebFolder value) =&gt; {...},
    ///     (WebProxy value) =&gt; {...},
    ///     (Gcs value) =&gt; {...},
    ///     (AzureBlob value) =&gt; {...},
    ///     (AkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<S3> s3,
        Action<S3Compatible> s3Compatible,
        Action<CloudinaryBackup> cloudinaryBackup,
        Action<WebFolder> webFolder,
        Action<WebProxy> webProxy,
        Action<Gcs> gcs,
        Action<AzureBlob> azureBlob,
        Action<AkeneoPim> akeneoPim
    )
    {
        switch (this.Value)
        {
            case S3 value:
                s3(value);
                break;
            case S3Compatible value:
                s3Compatible(value);
                break;
            case CloudinaryBackup value:
                cloudinaryBackup(value);
                break;
            case WebFolder value:
                webFolder(value);
                break;
            case WebProxy value:
                webProxy(value);
                break;
            case Gcs value:
                gcs(value);
                break;
            case AzureBlob value:
                azureBlob(value);
                break;
            case AkeneoPim value:
                akeneoPim(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of OriginRequest"
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
    ///     (S3 value) =&gt; {...},
    ///     (S3Compatible value) =&gt; {...},
    ///     (CloudinaryBackup value) =&gt; {...},
    ///     (WebFolder value) =&gt; {...},
    ///     (WebProxy value) =&gt; {...},
    ///     (Gcs value) =&gt; {...},
    ///     (AzureBlob value) =&gt; {...},
    ///     (AkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<S3, T> s3,
        Func<S3Compatible, T> s3Compatible,
        Func<CloudinaryBackup, T> cloudinaryBackup,
        Func<WebFolder, T> webFolder,
        Func<WebProxy, T> webProxy,
        Func<Gcs, T> gcs,
        Func<AzureBlob, T> azureBlob,
        Func<AkeneoPim, T> akeneoPim
    )
    {
        return this.Value switch
        {
            S3 value => s3(value),
            S3Compatible value => s3Compatible(value),
            CloudinaryBackup value => cloudinaryBackup(value),
            WebFolder value => webFolder(value),
            WebProxy value => webProxy(value),
            Gcs value => gcs(value),
            AzureBlob value => azureBlob(value),
            AkeneoPim value => akeneoPim(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of OriginRequest"
            ),
        };
    }

    public static implicit operator OriginRequest(S3 value) => new(value);

    public static implicit operator OriginRequest(S3Compatible value) => new(value);

    public static implicit operator OriginRequest(CloudinaryBackup value) => new(value);

    public static implicit operator OriginRequest(WebFolder value) => new(value);

    public static implicit operator OriginRequest(WebProxy value) => new(value);

    public static implicit operator OriginRequest(Gcs value) => new(value);

    public static implicit operator OriginRequest(AzureBlob value) => new(value);

    public static implicit operator OriginRequest(AkeneoPim value) => new(value);

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
                "Data did not match any variant of OriginRequest"
            );
        }
        this.Switch(
            (s3) => s3.Validate(),
            (s3Compatible) => s3Compatible.Validate(),
            (cloudinaryBackup) => cloudinaryBackup.Validate(),
            (webFolder) => webFolder.Validate(),
            (webProxy) => webProxy.Validate(),
            (gcs) => gcs.Validate(),
            (azureBlob) => azureBlob.Validate(),
            (akeneoPim) => akeneoPim.Validate()
        );
    }

    public virtual bool Equals(OriginRequest? other) =>
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
            S3 _ => 0,
            S3Compatible _ => 1,
            CloudinaryBackup _ => 2,
            WebFolder _ => 3,
            WebProxy _ => 4,
            Gcs _ => 5,
            AzureBlob _ => 6,
            AkeneoPim _ => 7,
            _ => -1,
        };
    }
}

sealed class OriginRequestConverter : JsonConverter<OriginRequest>
{
    public override OriginRequest? Read(
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
            case "S3":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3>(element, options);
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
            case "S3_COMPATIBLE":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3Compatible>(element, options);
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
            case "CLOUDINARY_BACKUP":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CloudinaryBackup>(
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
            case "WEB_FOLDER":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFolder>(element, options);
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
            case "WEB_PROXY":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebProxy>(element, options);
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
            case "GCS":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Gcs>(element, options);
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
            case "AZURE_BLOB":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureBlob>(element, options);
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
            case "AKENEO_PIM":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<AkeneoPim>(element, options);
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
                return new OriginRequest(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        OriginRequest value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<S3, S3FromRaw>))]
public sealed record class S3 : JsonModel
{
    /// <summary>
    /// Access key for the bucket.
    /// </summary>
    public required string AccessKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accessKey");
        }
        init { this._rawData.Set("accessKey", value); }
    }

    /// <summary>
    /// S3 bucket name.
    /// </summary>
    public required string Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket");
        }
        init { this._rawData.Set("bucket", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Secret key for the bucket.
    /// </summary>
    public required string SecretKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secretKey");
        }
        init { this._rawData.Set("secretKey", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Path prefix inside the bucket.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prefix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessKey;
        _ = this.Bucket;
        _ = this.Name;
        _ = this.SecretKey;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("S3")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public S3()
    {
        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public S3(S3 s3)
        : base(s3) { }
#pragma warning restore CS8618

    public S3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    S3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="S3FromRaw.FromRawUnchecked"/>
    public static S3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class S3FromRaw : IFromRawJson<S3>
{
    /// <inheritdoc/>
    public S3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        S3.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<S3Compatible, S3CompatibleFromRaw>))]
public sealed record class S3Compatible : JsonModel
{
    /// <summary>
    /// Access key for the bucket.
    /// </summary>
    public required string AccessKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accessKey");
        }
        init { this._rawData.Set("accessKey", value); }
    }

    /// <summary>
    /// S3 bucket name.
    /// </summary>
    public required string Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket");
        }
        init { this._rawData.Set("bucket", value); }
    }

    /// <summary>
    /// Custom S3-compatible endpoint.
    /// </summary>
    public required string Endpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("endpoint");
        }
        init { this._rawData.Set("endpoint", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Secret key for the bucket.
    /// </summary>
    public required string SecretKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secretKey");
        }
        init { this._rawData.Set("secretKey", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Path prefix inside the bucket.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prefix", value);
        }
    }

    /// <summary>
    /// Use path-style S3 URLs?
    /// </summary>
    public bool? S3ForcePathStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("s3ForcePathStyle");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("s3ForcePathStyle", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessKey;
        _ = this.Bucket;
        _ = this.Endpoint;
        _ = this.Name;
        _ = this.SecretKey;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("S3_COMPATIBLE")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
        _ = this.S3ForcePathStyle;
    }

    public S3Compatible()
    {
        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public S3Compatible(S3Compatible s3Compatible)
        : base(s3Compatible) { }
#pragma warning restore CS8618

    public S3Compatible(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    S3Compatible(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="S3CompatibleFromRaw.FromRawUnchecked"/>
    public static S3Compatible FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class S3CompatibleFromRaw : IFromRawJson<S3Compatible>
{
    /// <inheritdoc/>
    public S3Compatible FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        S3Compatible.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CloudinaryBackup, CloudinaryBackupFromRaw>))]
public sealed record class CloudinaryBackup : JsonModel
{
    /// <summary>
    /// Access key for the bucket.
    /// </summary>
    public required string AccessKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accessKey");
        }
        init { this._rawData.Set("accessKey", value); }
    }

    /// <summary>
    /// S3 bucket name.
    /// </summary>
    public required string Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket");
        }
        init { this._rawData.Set("bucket", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Secret key for the bucket.
    /// </summary>
    public required string SecretKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secretKey");
        }
        init { this._rawData.Set("secretKey", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Path prefix inside the bucket.
    /// </summary>
    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prefix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessKey;
        _ = this.Bucket;
        _ = this.Name;
        _ = this.SecretKey;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP")
            )
        )
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public CloudinaryBackup()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudinaryBackup(CloudinaryBackup cloudinaryBackup)
        : base(cloudinaryBackup) { }
#pragma warning restore CS8618

    public CloudinaryBackup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudinaryBackup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CloudinaryBackupFromRaw.FromRawUnchecked"/>
    public static CloudinaryBackup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CloudinaryBackupFromRaw : IFromRawJson<CloudinaryBackup>
{
    /// <inheritdoc/>
    public CloudinaryBackup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CloudinaryBackup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WebFolder, WebFolderFromRaw>))]
public sealed record class WebFolder : JsonModel
{
    /// <summary>
    /// Root URL for the web folder origin.
    /// </summary>
    public required string BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("baseUrl");
        }
        init { this._rawData.Set("baseUrl", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Forward the Host header to origin?
    /// </summary>
    public bool? ForwardHostHeaderToOrigin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("forwardHostHeaderToOrigin");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("forwardHostHeaderToOrigin", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BaseUrl;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("WEB_FOLDER")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.ForwardHostHeaderToOrigin;
        _ = this.IncludeCanonicalHeader;
    }

    public WebFolder()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFolder(WebFolder webFolder)
        : base(webFolder) { }
#pragma warning restore CS8618

    public WebFolder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFolder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFolderFromRaw.FromRawUnchecked"/>
    public static WebFolder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WebFolderFromRaw : IFromRawJson<WebFolder>
{
    /// <inheritdoc/>
    public WebFolder FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebFolder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<WebProxy, WebProxyFromRaw>))]
public sealed record class WebProxy : JsonModel
{
    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("WEB_PROXY")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public WebProxy()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebProxy(WebProxy webProxy)
        : base(webProxy) { }
#pragma warning restore CS8618

    public WebProxy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebProxy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebProxyFromRaw.FromRawUnchecked"/>
    public static WebProxy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebProxy(string name)
        : this()
    {
        this.Name = name;
    }
}

class WebProxyFromRaw : IFromRawJson<WebProxy>
{
    /// <inheritdoc/>
    public WebProxy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WebProxy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Gcs, GcsFromRaw>))]
public sealed record class Gcs : JsonModel
{
    public required string Bucket
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("bucket");
        }
        init { this._rawData.Set("bucket", value); }
    }

    public required string ClientEmail
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clientEmail");
        }
        init { this._rawData.Set("clientEmail", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string PrivateKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("privateKey");
        }
        init { this._rawData.Set("privateKey", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prefix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bucket;
        _ = this.ClientEmail;
        _ = this.Name;
        _ = this.PrivateKey;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("GCS")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public Gcs()
    {
        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Gcs(Gcs gcs)
        : base(gcs) { }
#pragma warning restore CS8618

    public Gcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Gcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GcsFromRaw.FromRawUnchecked"/>
    public static Gcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GcsFromRaw : IFromRawJson<Gcs>
{
    /// <inheritdoc/>
    public Gcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Gcs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AzureBlob, AzureBlobFromRaw>))]
public sealed record class AzureBlob : JsonModel
{
    public required string AccountName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("accountName");
        }
        init { this._rawData.Set("accountName", value); }
    }

    public required string Container
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("container");
        }
        init { this._rawData.Set("container", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required string SasToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("sasToken");
        }
        init { this._rawData.Set("sasToken", value); }
    }

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
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    public string? Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("prefix");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("prefix", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountName;
        _ = this.Container;
        _ = this.Name;
        _ = this.SasToken;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("AZURE_BLOB")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public AzureBlob()
    {
        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AzureBlob(AzureBlob azureBlob)
        : base(azureBlob) { }
#pragma warning restore CS8618

    public AzureBlob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AzureBlob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AzureBlobFromRaw.FromRawUnchecked"/>
    public static AzureBlob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AzureBlobFromRaw : IFromRawJson<AzureBlob>
{
    /// <inheritdoc/>
    public AzureBlob FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AzureBlob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AkeneoPim, AkeneoPimFromRaw>))]
public sealed record class AkeneoPim : JsonModel
{
    /// <summary>
    /// Akeneo instance base URL.
    /// </summary>
    public required string BaseUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("baseUrl");
        }
        init { this._rawData.Set("baseUrl", value); }
    }

    /// <summary>
    /// Akeneo API client ID.
    /// </summary>
    public required string ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clientId");
        }
        init { this._rawData.Set("clientId", value); }
    }

    /// <summary>
    /// Akeneo API client secret.
    /// </summary>
    public required string ClientSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("clientSecret");
        }
        init { this._rawData.Set("clientSecret", value); }
    }

    /// <summary>
    /// Display name of the origin.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Akeneo API password.
    /// </summary>
    public required string Password
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("password");
        }
        init { this._rawData.Set("password", value); }
    }

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
    /// Akeneo API username.
    /// </summary>
    public required string Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("username");
        }
        init { this._rawData.Set("username", value); }
    }

    /// <summary>
    /// URL used in the Canonical header (if enabled).
    /// </summary>
    public string? BaseUrlForCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("baseUrlForCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("baseUrlForCanonicalHeader", value);
        }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public bool? IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("includeCanonicalHeader");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("includeCanonicalHeader", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BaseUrl;
        _ = this.ClientID;
        _ = this.ClientSecret;
        _ = this.Name;
        _ = this.Password;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("AKENEO_PIM")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.Username;
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public AkeneoPim()
    {
        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AkeneoPim(AkeneoPim akeneoPim)
        : base(akeneoPim) { }
#pragma warning restore CS8618

    public AkeneoPim(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AkeneoPim(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AkeneoPimFromRaw.FromRawUnchecked"/>
    public static AkeneoPim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AkeneoPimFromRaw : IFromRawJson<AkeneoPim>
{
    /// <inheritdoc/>
    public AkeneoPim FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AkeneoPim.FromRawUnchecked(rawData);
}
