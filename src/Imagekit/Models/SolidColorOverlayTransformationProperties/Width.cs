using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using WidthVariants = Imagekit.Models.SolidColorOverlayTransformationProperties.WidthVariants;

namespace Imagekit.Models.SolidColorOverlayTransformationProperties;

/// <summary>
/// Controls the width of the solid color overlay. Accepts a numeric value or an arithmetic
/// expression (e.g., `bw_mul_0.2` or `bh_div_2`). Learn about [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(WidthConverter))]
public abstract record class Width
{
    internal Width() { }

    public static implicit operator Width(double value) => new WidthVariants::Double(value);

    public static implicit operator Width(string value) => new WidthVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as WidthVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as WidthVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<WidthVariants::Double> @double, Action<WidthVariants::String> @string)
    {
        switch (this)
        {
            case WidthVariants::Double inner:
                @double(inner);
                break;
            case WidthVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<WidthVariants::Double, T> @double,
        Func<WidthVariants::String, T> @string
    )
    {
        return this switch
        {
            WidthVariants::Double inner => @double(inner),
            WidthVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class WidthConverter : JsonConverter<Width>
{
    public override Width? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new WidthVariants::Double(
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
                return new WidthVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Width value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            WidthVariants::Double(var @double) => @double,
            WidthVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
