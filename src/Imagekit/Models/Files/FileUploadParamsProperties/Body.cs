using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.Files.FileUploadParamsProperties.BodyProperties;
using BodyVariants = Imagekit.Models.Files.FileUploadParamsProperties.BodyVariants;

namespace Imagekit.Models.Files.FileUploadParamsProperties;

[JsonConverter(typeof(BodyConverter))]
public abstract record class Body
{
    internal Body() { }

    public static implicit operator Body(FileUploadV1 value) =>
        new BodyVariants::FileUploadV1(value);

    public static implicit operator Body(FileUploadV1ByURL value) =>
        new BodyVariants::FileUploadV1ByURL(value);

    public bool TryPickFileUploadV1([NotNullWhen(true)] out FileUploadV1? value)
    {
        value = (this as BodyVariants::FileUploadV1)?.Value;
        return value != null;
    }

    public bool TryPickFileUploadV1ByURL([NotNullWhen(true)] out FileUploadV1ByURL? value)
    {
        value = (this as BodyVariants::FileUploadV1ByURL)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BodyVariants::FileUploadV1> fileUploadV1,
        Action<BodyVariants::FileUploadV1ByURL> fileUploadV1ByURL
    )
    {
        switch (this)
        {
            case BodyVariants::FileUploadV1 inner:
                fileUploadV1(inner);
                break;
            case BodyVariants::FileUploadV1ByURL inner:
                fileUploadV1ByURL(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BodyVariants::FileUploadV1, T> fileUploadV1,
        Func<BodyVariants::FileUploadV1ByURL, T> fileUploadV1ByURL
    )
    {
        return this switch
        {
            BodyVariants::FileUploadV1 inner => fileUploadV1(inner),
            BodyVariants::FileUploadV1ByURL inner => fileUploadV1ByURL(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<FileUploadV1>(ref reader, options);
            if (deserialized != null)
            {
                return new BodyVariants::FileUploadV1(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<FileUploadV1ByURL>(ref reader, options);
            if (deserialized != null)
            {
                return new BodyVariants::FileUploadV1ByURL(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Body value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BodyVariants::FileUploadV1(var fileUploadV1) => fileUploadV1,
            BodyVariants::FileUploadV1ByURL(var fileUploadV1ByURL) => fileUploadV1ByURL,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
