using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SharpenVariants = Imagekit.Models.TransformationProperties.SharpenVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Sharpens the input image, highlighting edges and finer details.  Pass `true`
/// for default sharpening, or provide a numeric value for custom sharpening. See
/// [Sharpen](https://imagekit.io/docs/effects-and-enhancements#sharpen---e-sharpen).
/// </summary>
[JsonConverter(typeof(SharpenConverter))]
public record class Sharpen
{
    public object Value { get; private init; }

    public Sharpen(UnionMember0 value)
    {
        Value = value;
    }

    public Sharpen(double value)
    {
        Value = value;
    }

    Sharpen(UnknownVariant value)
    {
        Value = value;
    }

    public static Sharpen CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTrue([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public void Switch(Action<UnionMember0> true1, Action<double> @double)
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                true1(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<UnionMember0, T> true1, Func<double, T> @double)
    {
        return this.Value switch
        {
            SharpenVariants::True inner => true1(inner),
            SharpenVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Sharpen");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class SharpenConverter : JsonConverter<Sharpen>
{
    public override Sharpen? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Sharpen(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new Sharpen(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Sharpen value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            SharpenVariants::True(var true1) => true1,
            SharpenVariants::Double(var @double) => @double,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
