using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ImagekitDiversion.Core;
using ImagekitDiversion.Exceptions;

namespace ImagekitDiversion.Models.Accounts.Origins;

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

    public OriginRequest(OriginRequestS3 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestS3Compatible value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestCloudinaryBackup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestWebFolder value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestWebProxy value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestGcs value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestAzureBlob value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginRequest(OriginRequestAkeneoPim value, JsonElement? element = null)
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
    /// type <see cref="OriginRequestS3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3(out var value)) {
    ///     // `value` is of type `OriginRequestS3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3([NotNullWhen(true)] out OriginRequestS3? value)
    {
        value = this.Value as OriginRequestS3;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestS3Compatible"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3Compatible(out var value)) {
    ///     // `value` is of type `OriginRequestS3Compatible`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3Compatible([NotNullWhen(true)] out OriginRequestS3Compatible? value)
    {
        value = this.Value as OriginRequestS3Compatible;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestCloudinaryBackup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinaryBackup(out var value)) {
    ///     // `value` is of type `OriginRequestCloudinaryBackup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinaryBackup(
        [NotNullWhen(true)] out OriginRequestCloudinaryBackup? value
    )
    {
        value = this.Value as OriginRequestCloudinaryBackup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestWebFolder"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFolder(out var value)) {
    ///     // `value` is of type `OriginRequestWebFolder`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFolder([NotNullWhen(true)] out OriginRequestWebFolder? value)
    {
        value = this.Value as OriginRequestWebFolder;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestWebProxy"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebProxy(out var value)) {
    ///     // `value` is of type `OriginRequestWebProxy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebProxy([NotNullWhen(true)] out OriginRequestWebProxy? value)
    {
        value = this.Value as OriginRequestWebProxy;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestGcs"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGcs(out var value)) {
    ///     // `value` is of type `OriginRequestGcs`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGcs([NotNullWhen(true)] out OriginRequestGcs? value)
    {
        value = this.Value as OriginRequestGcs;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestAzureBlob"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureBlob(out var value)) {
    ///     // `value` is of type `OriginRequestAzureBlob`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureBlob([NotNullWhen(true)] out OriginRequestAzureBlob? value)
    {
        value = this.Value as OriginRequestAzureBlob;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginRequestAkeneoPim"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkeneoPim(out var value)) {
    ///     // `value` is of type `OriginRequestAkeneoPim`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkeneoPim([NotNullWhen(true)] out OriginRequestAkeneoPim? value)
    {
        value = this.Value as OriginRequestAkeneoPim;
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
    ///     (OriginRequestS3 value) =&gt; {...},
    ///     (OriginRequestS3Compatible value) =&gt; {...},
    ///     (OriginRequestCloudinaryBackup value) =&gt; {...},
    ///     (OriginRequestWebFolder value) =&gt; {...},
    ///     (OriginRequestWebProxy value) =&gt; {...},
    ///     (OriginRequestGcs value) =&gt; {...},
    ///     (OriginRequestAzureBlob value) =&gt; {...},
    ///     (OriginRequestAkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<OriginRequestS3> s3,
        Action<OriginRequestS3Compatible> s3Compatible,
        Action<OriginRequestCloudinaryBackup> cloudinaryBackup,
        Action<OriginRequestWebFolder> webFolder,
        Action<OriginRequestWebProxy> webProxy,
        Action<OriginRequestGcs> gcs,
        Action<OriginRequestAzureBlob> azureBlob,
        Action<OriginRequestAkeneoPim> akeneoPim
    )
    {
        switch (this.Value)
        {
            case OriginRequestS3 value:
                s3(value);
                break;
            case OriginRequestS3Compatible value:
                s3Compatible(value);
                break;
            case OriginRequestCloudinaryBackup value:
                cloudinaryBackup(value);
                break;
            case OriginRequestWebFolder value:
                webFolder(value);
                break;
            case OriginRequestWebProxy value:
                webProxy(value);
                break;
            case OriginRequestGcs value:
                gcs(value);
                break;
            case OriginRequestAzureBlob value:
                azureBlob(value);
                break;
            case OriginRequestAkeneoPim value:
                akeneoPim(value);
                break;
            default:
                throw new ImagekitDiversionInvalidDataException(
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
    /// <exception cref="ImagekitDiversionInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (OriginRequestS3 value) =&gt; {...},
    ///     (OriginRequestS3Compatible value) =&gt; {...},
    ///     (OriginRequestCloudinaryBackup value) =&gt; {...},
    ///     (OriginRequestWebFolder value) =&gt; {...},
    ///     (OriginRequestWebProxy value) =&gt; {...},
    ///     (OriginRequestGcs value) =&gt; {...},
    ///     (OriginRequestAzureBlob value) =&gt; {...},
    ///     (OriginRequestAkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<OriginRequestS3, T> s3,
        Func<OriginRequestS3Compatible, T> s3Compatible,
        Func<OriginRequestCloudinaryBackup, T> cloudinaryBackup,
        Func<OriginRequestWebFolder, T> webFolder,
        Func<OriginRequestWebProxy, T> webProxy,
        Func<OriginRequestGcs, T> gcs,
        Func<OriginRequestAzureBlob, T> azureBlob,
        Func<OriginRequestAkeneoPim, T> akeneoPim
    )
    {
        return this.Value switch
        {
            OriginRequestS3 value => s3(value),
            OriginRequestS3Compatible value => s3Compatible(value),
            OriginRequestCloudinaryBackup value => cloudinaryBackup(value),
            OriginRequestWebFolder value => webFolder(value),
            OriginRequestWebProxy value => webProxy(value),
            OriginRequestGcs value => gcs(value),
            OriginRequestAzureBlob value => azureBlob(value),
            OriginRequestAkeneoPim value => akeneoPim(value),
            _ => throw new ImagekitDiversionInvalidDataException(
                "Data did not match any variant of OriginRequest"
            ),
        };
    }

    public static implicit operator OriginRequest(OriginRequestS3 value) => new(value);

    public static implicit operator OriginRequest(OriginRequestS3Compatible value) => new(value);

    public static implicit operator OriginRequest(OriginRequestCloudinaryBackup value) =>
        new(value);

    public static implicit operator OriginRequest(OriginRequestWebFolder value) => new(value);

    public static implicit operator OriginRequest(OriginRequestWebProxy value) => new(value);

    public static implicit operator OriginRequest(OriginRequestGcs value) => new(value);

    public static implicit operator OriginRequest(OriginRequestAzureBlob value) => new(value);

    public static implicit operator OriginRequest(OriginRequestAkeneoPim value) => new(value);

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
            OriginRequestS3 _ => 0,
            OriginRequestS3Compatible _ => 1,
            OriginRequestCloudinaryBackup _ => 2,
            OriginRequestWebFolder _ => 3,
            OriginRequestWebProxy _ => 4,
            OriginRequestGcs _ => 5,
            OriginRequestAzureBlob _ => 6,
            OriginRequestAkeneoPim _ => 7,
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
                    var deserialized = JsonSerializer.Deserialize<OriginRequestS3>(
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
            case "S3_COMPATIBLE":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestS3Compatible>(
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
            case "CLOUDINARY_BACKUP":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestCloudinaryBackup>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginRequestWebFolder>(
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
            case "WEB_PROXY":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestWebProxy>(
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
            case "GCS":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestGcs>(
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
            case "AZURE_BLOB":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestAzureBlob>(
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
            case "AKENEO_PIM":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OriginRequestAkeneoPim>(
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

[JsonConverter(typeof(JsonModelConverter<OriginRequestS3, OriginRequestS3FromRaw>))]
public sealed record class OriginRequestS3 : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public OriginRequestS3()
    {
        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestS3(OriginRequestS3 originRequestS3)
        : base(originRequestS3) { }
#pragma warning restore CS8618

    public OriginRequestS3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestS3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestS3FromRaw.FromRawUnchecked"/>
    public static OriginRequestS3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestS3FromRaw : IFromRawJson<OriginRequestS3>
{
    /// <inheritdoc/>
    public OriginRequestS3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OriginRequestS3.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OriginRequestS3Compatible, OriginRequestS3CompatibleFromRaw>)
)]
public sealed record class OriginRequestS3Compatible : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
        _ = this.S3ForcePathStyle;
    }

    public OriginRequestS3Compatible()
    {
        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestS3Compatible(OriginRequestS3Compatible originRequestS3Compatible)
        : base(originRequestS3Compatible) { }
#pragma warning restore CS8618

    public OriginRequestS3Compatible(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestS3Compatible(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestS3CompatibleFromRaw.FromRawUnchecked"/>
    public static OriginRequestS3Compatible FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestS3CompatibleFromRaw : IFromRawJson<OriginRequestS3Compatible>
{
    /// <inheritdoc/>
    public OriginRequestS3Compatible FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestS3Compatible.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OriginRequestCloudinaryBackup, OriginRequestCloudinaryBackupFromRaw>)
)]
public sealed record class OriginRequestCloudinaryBackup : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public OriginRequestCloudinaryBackup()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestCloudinaryBackup(
        OriginRequestCloudinaryBackup originRequestCloudinaryBackup
    )
        : base(originRequestCloudinaryBackup) { }
#pragma warning restore CS8618

    public OriginRequestCloudinaryBackup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestCloudinaryBackup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestCloudinaryBackupFromRaw.FromRawUnchecked"/>
    public static OriginRequestCloudinaryBackup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestCloudinaryBackupFromRaw : IFromRawJson<OriginRequestCloudinaryBackup>
{
    /// <inheritdoc/>
    public OriginRequestCloudinaryBackup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestCloudinaryBackup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginRequestWebFolder, OriginRequestWebFolderFromRaw>))]
public sealed record class OriginRequestWebFolder : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.ForwardHostHeaderToOrigin;
        _ = this.IncludeCanonicalHeader;
    }

    public OriginRequestWebFolder()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestWebFolder(OriginRequestWebFolder originRequestWebFolder)
        : base(originRequestWebFolder) { }
#pragma warning restore CS8618

    public OriginRequestWebFolder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestWebFolder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestWebFolderFromRaw.FromRawUnchecked"/>
    public static OriginRequestWebFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestWebFolderFromRaw : IFromRawJson<OriginRequestWebFolder>
{
    /// <inheritdoc/>
    public OriginRequestWebFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestWebFolder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginRequestWebProxy, OriginRequestWebProxyFromRaw>))]
public sealed record class OriginRequestWebProxy : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public OriginRequestWebProxy()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestWebProxy(OriginRequestWebProxy originRequestWebProxy)
        : base(originRequestWebProxy) { }
#pragma warning restore CS8618

    public OriginRequestWebProxy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestWebProxy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestWebProxyFromRaw.FromRawUnchecked"/>
    public static OriginRequestWebProxy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OriginRequestWebProxy(string name)
        : this()
    {
        this.Name = name;
    }
}

class OriginRequestWebProxyFromRaw : IFromRawJson<OriginRequestWebProxy>
{
    /// <inheritdoc/>
    public OriginRequestWebProxy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestWebProxy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginRequestGcs, OriginRequestGcsFromRaw>))]
public sealed record class OriginRequestGcs : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public OriginRequestGcs()
    {
        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestGcs(OriginRequestGcs originRequestGcs)
        : base(originRequestGcs) { }
#pragma warning restore CS8618

    public OriginRequestGcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestGcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestGcsFromRaw.FromRawUnchecked"/>
    public static OriginRequestGcs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestGcsFromRaw : IFromRawJson<OriginRequestGcs>
{
    /// <inheritdoc/>
    public OriginRequestGcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OriginRequestGcs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginRequestAzureBlob, OriginRequestAzureBlobFromRaw>))]
public sealed record class OriginRequestAzureBlob : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
        _ = this.Prefix;
    }

    public OriginRequestAzureBlob()
    {
        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestAzureBlob(OriginRequestAzureBlob originRequestAzureBlob)
        : base(originRequestAzureBlob) { }
#pragma warning restore CS8618

    public OriginRequestAzureBlob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestAzureBlob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestAzureBlobFromRaw.FromRawUnchecked"/>
    public static OriginRequestAzureBlob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestAzureBlobFromRaw : IFromRawJson<OriginRequestAzureBlob>
{
    /// <inheritdoc/>
    public OriginRequestAzureBlob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestAzureBlob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginRequestAkeneoPim, OriginRequestAkeneoPimFromRaw>))]
public sealed record class OriginRequestAkeneoPim : JsonModel
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
            throw new ImagekitDiversionInvalidDataException("Invalid value given for constant");
        }
        _ = this.Username;
        _ = this.BaseUrlForCanonicalHeader;
        _ = this.IncludeCanonicalHeader;
    }

    public OriginRequestAkeneoPim()
    {
        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginRequestAkeneoPim(OriginRequestAkeneoPim originRequestAkeneoPim)
        : base(originRequestAkeneoPim) { }
#pragma warning restore CS8618

    public OriginRequestAkeneoPim(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginRequestAkeneoPim(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginRequestAkeneoPimFromRaw.FromRawUnchecked"/>
    public static OriginRequestAkeneoPim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginRequestAkeneoPimFromRaw : IFromRawJson<OriginRequestAkeneoPim>
{
    /// <inheritdoc/>
    public OriginRequestAkeneoPim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginRequestAkeneoPim.FromRawUnchecked(rawData);
}
