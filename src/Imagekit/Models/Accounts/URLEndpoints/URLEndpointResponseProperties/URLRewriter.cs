using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterProperties;
using URLRewriterVariants = Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties.URLRewriterVariants;

namespace Imagekit.Models.Accounts.URLEndpoints.URLEndpointResponseProperties;

/// <summary>
/// Configuration for third-party URL rewriting.
/// </summary>
[JsonConverter(typeof(URLRewriterConverter))]
public abstract record class URLRewriter
{
    internal URLRewriter() { }

    public static implicit operator URLRewriter(Cloudinary value) =>
        new URLRewriterVariants::Cloudinary(value);

    public bool TryPickCloudinary([NotNullWhen(true)] out Cloudinary? value)
    {
        value = (this as URLRewriterVariants::Cloudinary)?.Value;
        return value != null;
    }

    public bool TryPickImgix([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as URLRewriterVariants::Imgix)?.Value;
        return value != null;
    }

    public bool TryPickAkamai([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as URLRewriterVariants::Akamai)?.Value;
        return value != null;
    }

    public void Switch(
        Action<URLRewriterVariants::Cloudinary> cloudinary,
        Action<URLRewriterVariants::Imgix> imgix,
        Action<URLRewriterVariants::Akamai> akamai
    )
    {
        switch (this)
        {
            case URLRewriterVariants::Cloudinary inner:
                cloudinary(inner);
                break;
            case URLRewriterVariants::Imgix inner:
                imgix(inner);
                break;
            case URLRewriterVariants::Akamai inner:
                akamai(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<URLRewriterVariants::Cloudinary, T> cloudinary,
        Func<URLRewriterVariants::Imgix, T> imgix,
        Func<URLRewriterVariants::Akamai, T> akamai
    )
    {
        return this switch
        {
            URLRewriterVariants::Cloudinary inner => cloudinary(inner),
            URLRewriterVariants::Imgix inner => imgix(inner),
            URLRewriterVariants::Akamai inner => akamai(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
                        return new URLRewriterVariants::Cloudinary(deserialized);
                    }
                }
                catch (JsonException e)
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
                    return new URLRewriterVariants::Imgix(
                        JsonSerializer.Deserialize<JsonElement>(json, options)
                    );
                }
                catch (JsonException e)
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
                    return new URLRewriterVariants::Akamai(
                        JsonSerializer.Deserialize<JsonElement>(json, options)
                    );
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
