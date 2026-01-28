using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrimVariants = Imagekit.Models.TransformationProperties.TrimVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Useful for images with a solid or nearly solid background and a central object.
/// This parameter trims the background,  leaving only the central object in the output
/// image. See [Trim edges](https://imagekit.io/docs/effects-and-enhancements#trim-edges---t).
/// </summary>
[JsonConverter(typeof(TrimConverter))]
public abstract record class Trim
{
    internal Trim() { }

    public static implicit operator Trim(double value) => new TrimVariants::Double(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as TrimVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as TrimVariants::Double)?.Value;
        return value != null;
    }

    public void Switch(Action<TrimVariants::True> true1, Action<TrimVariants::Double> @double)
    {
        switch (this)
        {
            case TrimVariants::True inner:
                true1(inner);
                break;
            case TrimVariants::Double inner:
                @double(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<TrimVariants::True, T> true1, Func<TrimVariants::Double, T> @double)
    {
        return this switch
        {
            TrimVariants::True inner => true1(inner),
            TrimVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new TrimVariants::True(
                JsonSerializer.Deserialize<JsonElement>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new TrimVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Trim value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            TrimVariants::True(var true1) => true1,
            TrimVariants::Double(var @double) => @double,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
