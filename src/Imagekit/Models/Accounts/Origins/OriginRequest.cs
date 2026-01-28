using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.Origins.OriginRequestProperties;
using OriginRequestVariants = Imagekit.Models.Accounts.Origins.OriginRequestVariants;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// Schema for origin request resources.
/// </summary>
[JsonConverter(typeof(OriginRequestConverter))]
public abstract record class OriginRequest
{
    internal OriginRequest() { }

    public static implicit operator OriginRequest(S3 value) => new OriginRequestVariants::S3(value);

    public static implicit operator OriginRequest(S3Compatible value) =>
        new OriginRequestVariants::S3Compatible(value);

    public static implicit operator OriginRequest(CloudinaryBackup value) =>
        new OriginRequestVariants::CloudinaryBackup(value);

    public static implicit operator OriginRequest(WebFolder value) =>
        new OriginRequestVariants::WebFolder(value);

    public static implicit operator OriginRequest(WebProxy value) =>
        new OriginRequestVariants::WebProxy(value);

    public static implicit operator OriginRequest(Gcs value) =>
        new OriginRequestVariants::Gcs(value);

    public static implicit operator OriginRequest(AzureBlob value) =>
        new OriginRequestVariants::AzureBlob(value);

    public static implicit operator OriginRequest(AkeneoPim value) =>
        new OriginRequestVariants::AkeneoPim(value);

    public bool TryPickS3([NotNullWhen(true)] out S3? value)
    {
        value = (this as OriginRequestVariants::S3)?.Value;
        return value != null;
    }

    public bool TryPickS3Compatible([NotNullWhen(true)] out S3Compatible? value)
    {
        value = (this as OriginRequestVariants::S3Compatible)?.Value;
        return value != null;
    }

    public bool TryPickCloudinaryBackup([NotNullWhen(true)] out CloudinaryBackup? value)
    {
        value = (this as OriginRequestVariants::CloudinaryBackup)?.Value;
        return value != null;
    }

    public bool TryPickWebFolder([NotNullWhen(true)] out WebFolder? value)
    {
        value = (this as OriginRequestVariants::WebFolder)?.Value;
        return value != null;
    }

    public bool TryPickWebProxy([NotNullWhen(true)] out WebProxy? value)
    {
        value = (this as OriginRequestVariants::WebProxy)?.Value;
        return value != null;
    }

    public bool TryPickGcs([NotNullWhen(true)] out Gcs? value)
    {
        value = (this as OriginRequestVariants::Gcs)?.Value;
        return value != null;
    }

    public bool TryPickAzureBlob([NotNullWhen(true)] out AzureBlob? value)
    {
        value = (this as OriginRequestVariants::AzureBlob)?.Value;
        return value != null;
    }

    public bool TryPickAkeneoPim([NotNullWhen(true)] out AkeneoPim? value)
    {
        value = (this as OriginRequestVariants::AkeneoPim)?.Value;
        return value != null;
    }

    public void Switch(
        Action<OriginRequestVariants::S3> s3,
        Action<OriginRequestVariants::S3Compatible> s3Compatible,
        Action<OriginRequestVariants::CloudinaryBackup> cloudinaryBackup,
        Action<OriginRequestVariants::WebFolder> webFolder,
        Action<OriginRequestVariants::WebProxy> webProxy,
        Action<OriginRequestVariants::Gcs> gcs,
        Action<OriginRequestVariants::AzureBlob> azureBlob,
        Action<OriginRequestVariants::AkeneoPim> akeneoPim
    )
    {
        switch (this)
        {
            case OriginRequestVariants::S3 inner:
                s3(inner);
                break;
            case OriginRequestVariants::S3Compatible inner:
                s3Compatible(inner);
                break;
            case OriginRequestVariants::CloudinaryBackup inner:
                cloudinaryBackup(inner);
                break;
            case OriginRequestVariants::WebFolder inner:
                webFolder(inner);
                break;
            case OriginRequestVariants::WebProxy inner:
                webProxy(inner);
                break;
            case OriginRequestVariants::Gcs inner:
                gcs(inner);
                break;
            case OriginRequestVariants::AzureBlob inner:
                azureBlob(inner);
                break;
            case OriginRequestVariants::AkeneoPim inner:
                akeneoPim(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<OriginRequestVariants::S3, T> s3,
        Func<OriginRequestVariants::S3Compatible, T> s3Compatible,
        Func<OriginRequestVariants::CloudinaryBackup, T> cloudinaryBackup,
        Func<OriginRequestVariants::WebFolder, T> webFolder,
        Func<OriginRequestVariants::WebProxy, T> webProxy,
        Func<OriginRequestVariants::Gcs, T> gcs,
        Func<OriginRequestVariants::AzureBlob, T> azureBlob,
        Func<OriginRequestVariants::AkeneoPim, T> akeneoPim
    )
    {
        return this switch
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

    public abstract void Validate();
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
                        return new OriginRequestVariants::S3(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::S3Compatible(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::CloudinaryBackup(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::WebFolder(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::WebProxy(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::Gcs(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::AzureBlob(deserialized);
                    }
                }
                catch (JsonException e)
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
                        return new OriginRequestVariants::AkeneoPim(deserialized);
                    }
                }
                catch (JsonException e)
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
