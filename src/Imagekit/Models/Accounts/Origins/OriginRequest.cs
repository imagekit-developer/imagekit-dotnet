using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.Origins.OriginRequestProperties;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// Schema for origin request resources.
/// </summary>
[JsonConverter(typeof(OriginRequestConverter))]
public record class OriginRequest
{
    public object Value { get; private init; }

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

    public string? BaseURLForCanonicalHeader
    {
        get
        {
            return Match<string?>(
                s3: (x) => x.BaseURLForCanonicalHeader,
                s3Compatible: (x) => x.BaseURLForCanonicalHeader,
                cloudinaryBackup: (x) => x.BaseURLForCanonicalHeader,
                webFolder: (x) => x.BaseURLForCanonicalHeader,
                webProxy: (x) => x.BaseURLForCanonicalHeader,
                gcs: (x) => x.BaseURLForCanonicalHeader,
                azureBlob: (x) => x.BaseURLForCanonicalHeader,
                akeneoPim: (x) => x.BaseURLForCanonicalHeader
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

    public string? BaseURL
    {
        get
        {
            return Match<string?>(
                s3: (_) => null,
                s3Compatible: (_) => null,
                cloudinaryBackup: (_) => null,
                webFolder: (x) => x.BaseURL,
                webProxy: (_) => null,
                gcs: (_) => null,
                azureBlob: (_) => null,
                akeneoPim: (x) => x.BaseURL
            );
        }
    }

    public OriginRequest(S3 value)
    {
        Value = value;
    }

    public OriginRequest(S3Compatible value)
    {
        Value = value;
    }

    public OriginRequest(CloudinaryBackup value)
    {
        Value = value;
    }

    public OriginRequest(WebFolder value)
    {
        Value = value;
    }

    public OriginRequest(WebProxy value)
    {
        Value = value;
    }

    public OriginRequest(Gcs value)
    {
        Value = value;
    }

    public OriginRequest(AzureBlob value)
    {
        Value = value;
    }

    public OriginRequest(AkeneoPim value)
    {
        Value = value;
    }

    OriginRequest(UnknownVariant value)
    {
        Value = value;
    }

    public static OriginRequest CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickS3([NotNullWhen(true)] out S3? value)
    {
        value = this.Value as S3;
        return value != null;
    }

    public bool TryPickS3Compatible([NotNullWhen(true)] out S3Compatible? value)
    {
        value = this.Value as S3Compatible;
        return value != null;
    }

    public bool TryPickCloudinaryBackup([NotNullWhen(true)] out CloudinaryBackup? value)
    {
        value = this.Value as CloudinaryBackup;
        return value != null;
    }

    public bool TryPickWebFolder([NotNullWhen(true)] out WebFolder? value)
    {
        value = this.Value as WebFolder;
        return value != null;
    }

    public bool TryPickWebProxy([NotNullWhen(true)] out WebProxy? value)
    {
        value = this.Value as WebProxy;
        return value != null;
    }

    public bool TryPickGcs([NotNullWhen(true)] out Gcs? value)
    {
        value = this.Value as Gcs;
        return value != null;
    }

    public bool TryPickAzureBlob([NotNullWhen(true)] out AzureBlob? value)
    {
        value = this.Value as AzureBlob;
        return value != null;
    }

    public bool TryPickAkeneoPim([NotNullWhen(true)] out AkeneoPim? value)
    {
        value = this.Value as AkeneoPim;
        return value != null;
    }

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
                throw new InvalidOperationException();
        }
    }

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
            OriginRequestVariants::S3 inner => s3(inner),
            OriginRequestVariants::S3Compatible inner => s3Compatible(inner),
            OriginRequestVariants::CloudinaryBackup inner => cloudinaryBackup(inner),
            OriginRequestVariants::WebFolder inner => webFolder(inner),
            OriginRequestVariants::WebProxy inner => webProxy(inner),
            OriginRequestVariants::Gcs inner => gcs(inner),
            OriginRequestVariants::AzureBlob inner => azureBlob(inner),
            OriginRequestVariants::AkeneoPim inner => akeneoPim(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of OriginRequest"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class OriginRequestConverter : JsonConverter<OriginRequest>
{
    public override OriginRequest? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "S3":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "S3_COMPATIBLE":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<S3Compatible>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "CLOUDINARY_BACKUP":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CloudinaryBackup>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "WEB_FOLDER":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFolder>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "WEB_PROXY":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebProxy>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "GCS":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Gcs>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "AZURE_BLOB":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AzureBlob>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "AKENEO_PIM":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<AkeneoPim>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new OriginRequest(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        OriginRequest value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            OriginRequestVariants::S3(var s3) => s3,
            OriginRequestVariants::S3Compatible(var s3Compatible) => s3Compatible,
            OriginRequestVariants::CloudinaryBackup(var cloudinaryBackup) => cloudinaryBackup,
            OriginRequestVariants::WebFolder(var webFolder) => webFolder,
            OriginRequestVariants::WebProxy(var webProxy) => webProxy,
            OriginRequestVariants::Gcs(var gcs) => gcs,
            OriginRequestVariants::AzureBlob(var azureBlob) => azureBlob,
            OriginRequestVariants::AkeneoPim(var akeneoPim) => akeneoPim,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
