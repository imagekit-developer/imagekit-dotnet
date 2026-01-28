using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.Origins.OriginResponseProperties;
using OriginResponseVariants = Imagekit.Models.Accounts.Origins.OriginResponseVariants;

namespace Imagekit.Models.Accounts.Origins;

/// <summary>
/// Origin object as returned by the API (sensitive fields removed).
/// </summary>
[JsonConverter(typeof(OriginResponseConverter))]
public abstract record class OriginResponse
{
    internal OriginResponse() { }

    public static implicit operator OriginResponse(S3 value) =>
        new OriginResponseVariants::S3(value);

    public static implicit operator OriginResponse(S3Compatible value) =>
        new OriginResponseVariants::S3Compatible(value);

    public static implicit operator OriginResponse(CloudinaryBackup value) =>
        new OriginResponseVariants::CloudinaryBackup(value);

    public static implicit operator OriginResponse(WebFolder value) =>
        new OriginResponseVariants::WebFolder(value);

    public static implicit operator OriginResponse(WebProxy value) =>
        new OriginResponseVariants::WebProxy(value);

    public static implicit operator OriginResponse(Gcs value) =>
        new OriginResponseVariants::Gcs(value);

    public static implicit operator OriginResponse(AzureBlob value) =>
        new OriginResponseVariants::AzureBlob(value);

    public static implicit operator OriginResponse(AkeneoPim value) =>
        new OriginResponseVariants::AkeneoPim(value);

    public bool TryPickS3([NotNullWhen(true)] out S3? value)
    {
        value = (this as OriginResponseVariants::S3)?.Value;
        return value != null;
    }

    public bool TryPickS3Compatible([NotNullWhen(true)] out S3Compatible? value)
    {
        value = (this as OriginResponseVariants::S3Compatible)?.Value;
        return value != null;
    }

    public bool TryPickCloudinaryBackup([NotNullWhen(true)] out CloudinaryBackup? value)
    {
        value = (this as OriginResponseVariants::CloudinaryBackup)?.Value;
        return value != null;
    }

    public bool TryPickWebFolder([NotNullWhen(true)] out WebFolder? value)
    {
        value = (this as OriginResponseVariants::WebFolder)?.Value;
        return value != null;
    }

    public bool TryPickWebProxy([NotNullWhen(true)] out WebProxy? value)
    {
        value = (this as OriginResponseVariants::WebProxy)?.Value;
        return value != null;
    }

    public bool TryPickGcs([NotNullWhen(true)] out Gcs? value)
    {
        value = (this as OriginResponseVariants::Gcs)?.Value;
        return value != null;
    }

    public bool TryPickAzureBlob([NotNullWhen(true)] out AzureBlob? value)
    {
        value = (this as OriginResponseVariants::AzureBlob)?.Value;
        return value != null;
    }

    public bool TryPickAkeneoPim([NotNullWhen(true)] out AkeneoPim? value)
    {
        value = (this as OriginResponseVariants::AkeneoPim)?.Value;
        return value != null;
    }

    public void Switch(
        Action<OriginResponseVariants::S3> s3,
        Action<OriginResponseVariants::S3Compatible> s3Compatible,
        Action<OriginResponseVariants::CloudinaryBackup> cloudinaryBackup,
        Action<OriginResponseVariants::WebFolder> webFolder,
        Action<OriginResponseVariants::WebProxy> webProxy,
        Action<OriginResponseVariants::Gcs> gcs,
        Action<OriginResponseVariants::AzureBlob> azureBlob,
        Action<OriginResponseVariants::AkeneoPim> akeneoPim
    )
    {
        switch (this)
        {
            case OriginResponseVariants::S3 inner:
                s3(inner);
                break;
            case OriginResponseVariants::S3Compatible inner:
                s3Compatible(inner);
                break;
            case OriginResponseVariants::CloudinaryBackup inner:
                cloudinaryBackup(inner);
                break;
            case OriginResponseVariants::WebFolder inner:
                webFolder(inner);
                break;
            case OriginResponseVariants::WebProxy inner:
                webProxy(inner);
                break;
            case OriginResponseVariants::Gcs inner:
                gcs(inner);
                break;
            case OriginResponseVariants::AzureBlob inner:
                azureBlob(inner);
                break;
            case OriginResponseVariants::AkeneoPim inner:
                akeneoPim(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<OriginResponseVariants::S3, T> s3,
        Func<OriginResponseVariants::S3Compatible, T> s3Compatible,
        Func<OriginResponseVariants::CloudinaryBackup, T> cloudinaryBackup,
        Func<OriginResponseVariants::WebFolder, T> webFolder,
        Func<OriginResponseVariants::WebProxy, T> webProxy,
        Func<OriginResponseVariants::Gcs, T> gcs,
        Func<OriginResponseVariants::AzureBlob, T> azureBlob,
        Func<OriginResponseVariants::AkeneoPim, T> akeneoPim
    )
    {
        return this switch
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

    public abstract void Validate();
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
                        return new OriginResponseVariants::S3(deserialized);
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
                        return new OriginResponseVariants::S3Compatible(deserialized);
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
                        return new OriginResponseVariants::CloudinaryBackup(deserialized);
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
                        return new OriginResponseVariants::WebFolder(deserialized);
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
                        return new OriginResponseVariants::WebProxy(deserialized);
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
                        return new OriginResponseVariants::Gcs(deserialized);
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
                        return new OriginResponseVariants::AzureBlob(deserialized);
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
                        return new OriginResponseVariants::AkeneoPim(deserialized);
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
