using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using PaddingVariants = Imagekit.Models.TextOverlayTransformationProperties.PaddingVariants;

namespace Imagekit.Models.TextOverlayTransformationProperties;

/// <summary>
/// Specifies the padding around the overlaid text. Can be provided as a single positive
/// integer or multiple values separated by underscores (following CSS shorthand order).
/// Arithmetic expressions are also accepted.
/// </summary>
[JsonConverter(typeof(PaddingConverter))]
public abstract record class Padding
{
    internal Padding() { }

    public static implicit operator Padding(double value) => new PaddingVariants::Double(value);

    public static implicit operator Padding(string value) => new PaddingVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as PaddingVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as PaddingVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<PaddingVariants::Double> @double,
        Action<PaddingVariants::String> @string
    )
    {
        switch (this)
        {
            case PaddingVariants::Double inner:
                @double(inner);
                break;
            case PaddingVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<PaddingVariants::Double, T> @double,
        Func<PaddingVariants::String, T> @string
    )
    {
        return this switch
        {
            PaddingVariants::Double inner => @double(inner),
            PaddingVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class PaddingConverter : JsonConverter<Padding>
{
    public override Padding? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new PaddingVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new PaddingVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Padding value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            PaddingVariants::Double(var @double) => @double,
            PaddingVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
