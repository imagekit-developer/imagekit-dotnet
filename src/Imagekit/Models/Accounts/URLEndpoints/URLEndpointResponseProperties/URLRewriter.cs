using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterProperties;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties;

/// <summary>
/// Configuration for third-party URL rewriting.
/// </summary>
[JsonConverter(typeof(URLRewriterConverter))]
public record class URLRewriter
{
    public object Value { get; private init; }

    public URLRewriter(Cloudinary value)
    {
        Value = value;
    }

    public URLRewriter(Imgix value)
    {
        Value = value;
    }

    public URLRewriter(Akamai value)
    {
        Value = value;
    }

    URLRewriter(UnknownVariant value)
    {
        Value = value;
    }

    public static URLRewriter CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickCloudinary([NotNullWhen(true)] out Cloudinary? value)
    {
        value = this.Value as Cloudinary;
        return value != null;
    }

    public bool TryPickImgix([NotNullWhen(true)] out Imgix? value)
    {
        value = this.Value as Imgix;
        return value != null;
    }

    public bool TryPickAkamai([NotNullWhen(true)] out Akamai? value)
    {
        value = this.Value as Akamai;
        return value != null;
    }

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
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<Cloudinary, T> cloudinary, Func<Imgix, T> imgix, Func<Akamai, T> akamai)
    {
        return this.Value switch
        {
            URLRewriterVariants::Cloudinary inner => cloudinary(inner),
            URLRewriterVariants::Imgix inner => imgix(inner),
            URLRewriterVariants::Akamai inner => akamai(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of URLRewriter");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class URLRewriterConverter : JsonConverter<URLRewriter>
{
    public override URLRewriter? Read(
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
            case "CLOUDINARY":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Cloudinary>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new URLRewriter(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "IMGIX":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Imgix>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new URLRewriter(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "AKAMAI":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<Akamai>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new URLRewriter(deserialized);
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
        URLRewriter value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            URLRewriterVariants::Cloudinary(var cloudinary) => cloudinary,
            URLRewriterVariants::Imgix(var imgix) => imgix,
            URLRewriterVariants::Akamai(var akamai) => akamai,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
