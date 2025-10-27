using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.Origins.OriginResponseProperties;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// Origin object as returned by the API (sensitive fields removed).
/// </summary>
[JsonConverter(typeof(OriginResponseConverter))]
public record class OriginResponse
{
    public object Value { get; private init; }

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

    public OriginResponse(S3 value)
    {
        Value = value;
    }

    public OriginResponse(S3Compatible value)
    {
        Value = value;
    }

    public OriginResponse(CloudinaryBackup value)
    {
        Value = value;
    }

    public OriginResponse(WebFolder value)
    {
        Value = value;
    }

    public OriginResponse(WebProxy value)
    {
        Value = value;
    }

    public OriginResponse(Gcs value)
    {
        Value = value;
    }

    public OriginResponse(AzureBlob value)
    {
        Value = value;
    }

    public OriginResponse(AkeneoPim value)
    {
        Value = value;
    }

    OriginResponse(UnknownVariant value)
    {
        Value = value;
    }

    public static OriginResponse CreateUnknownVariant(JsonElement value)
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
            OriginResponseVariants::S3 inner => s3(inner),
            OriginResponseVariants::S3Compatible inner => s3Compatible(inner),
            OriginResponseVariants::CloudinaryBackup inner => cloudinaryBackup(inner),
            OriginResponseVariants::WebFolder inner => webFolder(inner),
            OriginResponseVariants::WebProxy inner => webProxy(inner),
            OriginResponseVariants::Gcs inner => gcs(inner),
            OriginResponseVariants::AzureBlob inner => azureBlob(inner),
            OriginResponseVariants::AkeneoPim inner => akeneoPim(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of OriginResponse"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class OriginResponseConverter : JsonConverter<OriginResponse>
{
    public override OriginResponse? Read(
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
                        return new OriginResponse(deserialized);
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
        OriginResponse value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            OriginResponseVariants::S3(var s3) => s3,
            OriginResponseVariants::S3Compatible(var s3Compatible) => s3Compatible,
            OriginResponseVariants::CloudinaryBackup(var cloudinaryBackup) => cloudinaryBackup,
            OriginResponseVariants::WebFolder(var webFolder) => webFolder,
            OriginResponseVariants::WebProxy(var webProxy) => webProxy,
            OriginResponseVariants::Gcs(var gcs) => gcs,
            OriginResponseVariants::AzureBlob(var azureBlob) => azureBlob,
            OriginResponseVariants::AkeneoPim(var akeneoPim) => akeneoPim,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
