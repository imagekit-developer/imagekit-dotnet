using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;
using Imagekit.Exceptions;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// Origin object as returned by the API (sensitive fields removed).
/// </summary>
[JsonConverter(typeof(OriginResponseConverter))]
public record class OriginResponse : ModelBase
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
                s3: (x) => x.ID,
                s3Compatible: (x) => x.ID,
                cloudinaryBackup: (x) => x.ID,
                webFolder: (x) => x.ID,
                webProxy: (x) => x.ID,
                gcs: (x) => x.ID,
                azureBlob: (x) => x.ID,
                akeneoPim: (x) => x.ID
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

    public bool IncludeCanonicalHeader
    {
        get
        {
            return Match(
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

    public OriginResponse(OriginResponseS3 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseS3Compatible value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseCloudinaryBackup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseWebFolder value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseWebProxy value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseGcs value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseAzureBlob value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(OriginResponseAkeneoPim value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public OriginResponse(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseS3"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3(out var value)) {
    ///     // `value` is of type `OriginResponseS3`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3([NotNullWhen(true)] out OriginResponseS3? value)
    {
        value = this.Value as OriginResponseS3;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseS3Compatible"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickS3Compatible(out var value)) {
    ///     // `value` is of type `OriginResponseS3Compatible`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickS3Compatible([NotNullWhen(true)] out OriginResponseS3Compatible? value)
    {
        value = this.Value as OriginResponseS3Compatible;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseCloudinaryBackup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloudinaryBackup(out var value)) {
    ///     // `value` is of type `OriginResponseCloudinaryBackup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloudinaryBackup(
        [NotNullWhen(true)] out OriginResponseCloudinaryBackup? value
    )
    {
        value = this.Value as OriginResponseCloudinaryBackup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseWebFolder"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFolder(out var value)) {
    ///     // `value` is of type `OriginResponseWebFolder`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFolder([NotNullWhen(true)] out OriginResponseWebFolder? value)
    {
        value = this.Value as OriginResponseWebFolder;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseWebProxy"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebProxy(out var value)) {
    ///     // `value` is of type `OriginResponseWebProxy`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebProxy([NotNullWhen(true)] out OriginResponseWebProxy? value)
    {
        value = this.Value as OriginResponseWebProxy;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseGcs"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGcs(out var value)) {
    ///     // `value` is of type `OriginResponseGcs`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGcs([NotNullWhen(true)] out OriginResponseGcs? value)
    {
        value = this.Value as OriginResponseGcs;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseAzureBlob"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzureBlob(out var value)) {
    ///     // `value` is of type `OriginResponseAzureBlob`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzureBlob([NotNullWhen(true)] out OriginResponseAzureBlob? value)
    {
        value = this.Value as OriginResponseAzureBlob;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OriginResponseAkeneoPim"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAkeneoPim(out var value)) {
    ///     // `value` is of type `OriginResponseAkeneoPim`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAkeneoPim([NotNullWhen(true)] out OriginResponseAkeneoPim? value)
    {
        value = this.Value as OriginResponseAkeneoPim;
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
    ///     (OriginResponseS3 value) =&gt; {...},
    ///     (OriginResponseS3Compatible value) =&gt; {...},
    ///     (OriginResponseCloudinaryBackup value) =&gt; {...},
    ///     (OriginResponseWebFolder value) =&gt; {...},
    ///     (OriginResponseWebProxy value) =&gt; {...},
    ///     (OriginResponseGcs value) =&gt; {...},
    ///     (OriginResponseAzureBlob value) =&gt; {...},
    ///     (OriginResponseAkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<OriginResponseS3> s3,
        Action<OriginResponseS3Compatible> s3Compatible,
        Action<OriginResponseCloudinaryBackup> cloudinaryBackup,
        Action<OriginResponseWebFolder> webFolder,
        Action<OriginResponseWebProxy> webProxy,
        Action<OriginResponseGcs> gcs,
        Action<OriginResponseAzureBlob> azureBlob,
        Action<OriginResponseAkeneoPim> akeneoPim
    )
    {
        switch (this.Value)
        {
            case OriginResponseS3 value:
                s3(value);
                break;
            case OriginResponseS3Compatible value:
                s3Compatible(value);
                break;
            case OriginResponseCloudinaryBackup value:
                cloudinaryBackup(value);
                break;
            case OriginResponseWebFolder value:
                webFolder(value);
                break;
            case OriginResponseWebProxy value:
                webProxy(value);
                break;
            case OriginResponseGcs value:
                gcs(value);
                break;
            case OriginResponseAzureBlob value:
                azureBlob(value);
                break;
            case OriginResponseAkeneoPim value:
                akeneoPim(value);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of OriginResponse"
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
    ///     (OriginResponseS3 value) =&gt; {...},
    ///     (OriginResponseS3Compatible value) =&gt; {...},
    ///     (OriginResponseCloudinaryBackup value) =&gt; {...},
    ///     (OriginResponseWebFolder value) =&gt; {...},
    ///     (OriginResponseWebProxy value) =&gt; {...},
    ///     (OriginResponseGcs value) =&gt; {...},
    ///     (OriginResponseAzureBlob value) =&gt; {...},
    ///     (OriginResponseAkeneoPim value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<OriginResponseS3, T> s3,
        Func<OriginResponseS3Compatible, T> s3Compatible,
        Func<OriginResponseCloudinaryBackup, T> cloudinaryBackup,
        Func<OriginResponseWebFolder, T> webFolder,
        Func<OriginResponseWebProxy, T> webProxy,
        Func<OriginResponseGcs, T> gcs,
        Func<OriginResponseAzureBlob, T> azureBlob,
        Func<OriginResponseAkeneoPim, T> akeneoPim
    )
    {
        return this.Value switch
        {
            OriginResponseS3 value => s3(value),
            OriginResponseS3Compatible value => s3Compatible(value),
            OriginResponseCloudinaryBackup value => cloudinaryBackup(value),
            OriginResponseWebFolder value => webFolder(value),
            OriginResponseWebProxy value => webProxy(value),
            OriginResponseGcs value => gcs(value),
            OriginResponseAzureBlob value => azureBlob(value),
            OriginResponseAkeneoPim value => akeneoPim(value),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of OriginResponse"
            ),
        };
    }

    public static implicit operator OriginResponse(OriginResponseS3 value) => new(value);

    public static implicit operator OriginResponse(OriginResponseS3Compatible value) => new(value);

    public static implicit operator OriginResponse(OriginResponseCloudinaryBackup value) =>
        new(value);

    public static implicit operator OriginResponse(OriginResponseWebFolder value) => new(value);

    public static implicit operator OriginResponse(OriginResponseWebProxy value) => new(value);

    public static implicit operator OriginResponse(OriginResponseGcs value) => new(value);

    public static implicit operator OriginResponse(OriginResponseAzureBlob value) => new(value);

    public static implicit operator OriginResponse(OriginResponseAkeneoPim value) => new(value);

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
                "Data did not match any variant of OriginResponse"
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

    public virtual bool Equals(OriginResponse? other) =>
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
            OriginResponseS3 _ => 0,
            OriginResponseS3Compatible _ => 1,
            OriginResponseCloudinaryBackup _ => 2,
            OriginResponseWebFolder _ => 3,
            OriginResponseWebProxy _ => 4,
            OriginResponseGcs _ => 5,
            OriginResponseAzureBlob _ => 6,
            OriginResponseAkeneoPim _ => 7,
            _ => -1,
        };
    }
}

sealed class OriginResponseConverter : JsonConverter<OriginResponse>
{
    public override OriginResponse? Read(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseS3>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseS3Compatible>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseCloudinaryBackup>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseWebFolder>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseWebProxy>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseGcs>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseAzureBlob>(
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
                    var deserialized = JsonSerializer.Deserialize<OriginResponseAkeneoPim>(
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
                return new OriginResponse(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        OriginResponse value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseS3, OriginResponseS3FromRaw>))]
public sealed record class OriginResponseS3 : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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
    /// Path prefix inside the bucket.
    /// </summary>
    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Bucket;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        _ = this.Prefix;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("S3")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseS3()
    {
        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseS3(OriginResponseS3 originResponseS3)
        : base(originResponseS3) { }
#pragma warning restore CS8618

    public OriginResponseS3(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseS3(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseS3FromRaw.FromRawUnchecked"/>
    public static OriginResponseS3 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseS3FromRaw : IFromRawJson<OriginResponseS3>
{
    /// <inheritdoc/>
    public OriginResponseS3 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OriginResponseS3.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<OriginResponseS3Compatible, OriginResponseS3CompatibleFromRaw>)
)]
public sealed record class OriginResponseS3Compatible : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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
    /// Path prefix inside the bucket.
    /// </summary>
    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
    }

    /// <summary>
    /// Use path-style S3 URLs?
    /// </summary>
    public required bool S3ForcePathStyle
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("s3ForcePathStyle");
        }
        init { this._rawData.Set("s3ForcePathStyle", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Bucket;
        _ = this.Endpoint;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        _ = this.Prefix;
        _ = this.S3ForcePathStyle;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("S3_COMPATIBLE")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseS3Compatible()
    {
        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseS3Compatible(OriginResponseS3Compatible originResponseS3Compatible)
        : base(originResponseS3Compatible) { }
#pragma warning restore CS8618

    public OriginResponseS3Compatible(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("S3_COMPATIBLE");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseS3Compatible(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseS3CompatibleFromRaw.FromRawUnchecked"/>
    public static OriginResponseS3Compatible FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseS3CompatibleFromRaw : IFromRawJson<OriginResponseS3Compatible>
{
    /// <inheritdoc/>
    public OriginResponseS3Compatible FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseS3Compatible.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        OriginResponseCloudinaryBackup,
        OriginResponseCloudinaryBackupFromRaw
    >)
)]
public sealed record class OriginResponseCloudinaryBackup : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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
    /// Path prefix inside the bucket.
    /// </summary>
    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Bucket;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        _ = this.Prefix;
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
    }

    public OriginResponseCloudinaryBackup()
    {
        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseCloudinaryBackup(
        OriginResponseCloudinaryBackup originResponseCloudinaryBackup
    )
        : base(originResponseCloudinaryBackup) { }
#pragma warning restore CS8618

    public OriginResponseCloudinaryBackup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("CLOUDINARY_BACKUP");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseCloudinaryBackup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseCloudinaryBackupFromRaw.FromRawUnchecked"/>
    public static OriginResponseCloudinaryBackup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseCloudinaryBackupFromRaw : IFromRawJson<OriginResponseCloudinaryBackup>
{
    /// <inheritdoc/>
    public OriginResponseCloudinaryBackup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseCloudinaryBackup.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseWebFolder, OriginResponseWebFolderFromRaw>))]
public sealed record class OriginResponseWebFolder : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
    /// Forward the Host header to origin?
    /// </summary>
    public required bool ForwardHostHeaderToOrigin
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("forwardHostHeaderToOrigin");
        }
        init { this._rawData.Set("forwardHostHeaderToOrigin", value); }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BaseUrl;
        _ = this.ForwardHostHeaderToOrigin;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("WEB_FOLDER")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseWebFolder()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseWebFolder(OriginResponseWebFolder originResponseWebFolder)
        : base(originResponseWebFolder) { }
#pragma warning restore CS8618

    public OriginResponseWebFolder(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_FOLDER");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseWebFolder(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseWebFolderFromRaw.FromRawUnchecked"/>
    public static OriginResponseWebFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseWebFolderFromRaw : IFromRawJson<OriginResponseWebFolder>
{
    /// <inheritdoc/>
    public OriginResponseWebFolder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseWebFolder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseWebProxy, OriginResponseWebProxyFromRaw>))]
public sealed record class OriginResponseWebProxy : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("WEB_PROXY")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseWebProxy()
    {
        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseWebProxy(OriginResponseWebProxy originResponseWebProxy)
        : base(originResponseWebProxy) { }
#pragma warning restore CS8618

    public OriginResponseWebProxy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("WEB_PROXY");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseWebProxy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseWebProxyFromRaw.FromRawUnchecked"/>
    public static OriginResponseWebProxy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseWebProxyFromRaw : IFromRawJson<OriginResponseWebProxy>
{
    /// <inheritdoc/>
    public OriginResponseWebProxy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseWebProxy.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseGcs, OriginResponseGcsFromRaw>))]
public sealed record class OriginResponseGcs : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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

    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Bucket;
        _ = this.ClientEmail;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        _ = this.Prefix;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("GCS")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseGcs()
    {
        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseGcs(OriginResponseGcs originResponseGcs)
        : base(originResponseGcs) { }
#pragma warning restore CS8618

    public OriginResponseGcs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("GCS");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseGcs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseGcsFromRaw.FromRawUnchecked"/>
    public static OriginResponseGcs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseGcsFromRaw : IFromRawJson<OriginResponseGcs>
{
    /// <inheritdoc/>
    public OriginResponseGcs FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OriginResponseGcs.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseAzureBlob, OriginResponseAzureBlobFromRaw>))]
public sealed record class OriginResponseAzureBlob : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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

    public required string Prefix
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("prefix");
        }
        init { this._rawData.Set("prefix", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AccountName;
        _ = this.Container;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        _ = this.Prefix;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("AZURE_BLOB")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseAzureBlob()
    {
        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseAzureBlob(OriginResponseAzureBlob originResponseAzureBlob)
        : base(originResponseAzureBlob) { }
#pragma warning restore CS8618

    public OriginResponseAzureBlob(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AZURE_BLOB");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseAzureBlob(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseAzureBlobFromRaw.FromRawUnchecked"/>
    public static OriginResponseAzureBlob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseAzureBlobFromRaw : IFromRawJson<OriginResponseAzureBlob>
{
    /// <inheritdoc/>
    public OriginResponseAzureBlob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseAzureBlob.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OriginResponseAkeneoPim, OriginResponseAkeneoPimFromRaw>))]
public sealed record class OriginResponseAkeneoPim : JsonModel
{
    /// <summary>
    /// Unique identifier for the origin. This is generated by ImageKit when you
    /// create a new origin.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
    /// Whether to send a Canonical header.
    /// </summary>
    public required bool IncludeCanonicalHeader
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("includeCanonicalHeader");
        }
        init { this._rawData.Set("includeCanonicalHeader", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.BaseUrl;
        _ = this.IncludeCanonicalHeader;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("AKENEO_PIM")))
        {
            throw new ImageKitInvalidDataException("Invalid value given for constant");
        }
        _ = this.BaseUrlForCanonicalHeader;
    }

    public OriginResponseAkeneoPim()
    {
        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OriginResponseAkeneoPim(OriginResponseAkeneoPim originResponseAkeneoPim)
        : base(originResponseAkeneoPim) { }
#pragma warning restore CS8618

    public OriginResponseAkeneoPim(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("AKENEO_PIM");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OriginResponseAkeneoPim(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OriginResponseAkeneoPimFromRaw.FromRawUnchecked"/>
    public static OriginResponseAkeneoPim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OriginResponseAkeneoPimFromRaw : IFromRawJson<OriginResponseAkeneoPim>
{
    /// <inheritdoc/>
    public OriginResponseAkeneoPim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OriginResponseAkeneoPim.FromRawUnchecked(rawData);
}
