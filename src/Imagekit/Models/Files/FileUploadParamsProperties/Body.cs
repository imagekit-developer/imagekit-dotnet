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

    public static implicit operator Body(FileUploadByUrlv1 value) =>
        new BodyVariants::FileUploadByUrlv1(value);

    public bool TryPickFileUploadV1([NotNullWhen(true)] out FileUploadV1? value)
    {
        value = (this as BodyVariants::FileUploadV1)?.Value;
        return value != null;
    }

    public bool TryPickFileUploadByUrlv1([NotNullWhen(true)] out FileUploadByUrlv1? value)
    {
        value = (this as BodyVariants::FileUploadByUrlv1)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BodyVariants::FileUploadV1> fileUploadV1,
        Action<BodyVariants::FileUploadByUrlv1> fileUploadByUrlv1
    )
    {
        switch (this)
        {
            case BodyVariants::FileUploadV1 inner:
                fileUploadV1(inner);
                break;
            case BodyVariants::FileUploadByUrlv1 inner:
                fileUploadByUrlv1(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BodyVariants::FileUploadV1, T> fileUploadV1,
        Func<BodyVariants::FileUploadByUrlv1, T> fileUploadByUrlv1
    )
    {
        return this switch
        {
            BodyVariants::FileUploadV1 inner => fileUploadV1(inner),
            BodyVariants::FileUploadByUrlv1 inner => fileUploadByUrlv1(inner),
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
            var deserialized = JsonSerializer.Deserialize<FileUploadByUrlv1>(ref reader, options);
            if (deserialized != null)
            {
                return new BodyVariants::FileUploadByUrlv1(deserialized);
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
            BodyVariants::FileUploadByUrlv1(var fileUploadByUrlv1) => fileUploadByUrlv1,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
