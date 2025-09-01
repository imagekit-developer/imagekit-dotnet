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
public abstract record class Sharpen
{
    internal Sharpen() { }

    public static implicit operator Sharpen(double value) => new SharpenVariants::Double(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as SharpenVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as SharpenVariants::Double)?.Value;
        return value != null;
    }

    public void Switch(Action<SharpenVariants::True> true1, Action<SharpenVariants::Double> @double)
    {
        switch (this)
        {
            case SharpenVariants::True inner:
                true1(inner);
                break;
            case SharpenVariants::Double inner:
                @double(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SharpenVariants::True, T> true1,
        Func<SharpenVariants::Double, T> @double
    )
    {
        return this switch
        {
            SharpenVariants::True inner => true1(inner),
            SharpenVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
            return new SharpenVariants::True(
                JsonSerializer.Deserialize<JsonElement>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new SharpenVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
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
