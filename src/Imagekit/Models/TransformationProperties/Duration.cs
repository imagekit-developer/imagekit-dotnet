using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DurationVariants = Imagekit.Models.TransformationProperties.DurationVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the duration (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Typically used with startOffset to indicate the length from the start offset.
/// Arithmetic expressions are supported. See [Trim videos – Duration](https://imagekit.io/docs/trim-videos#duration---du).
/// </summary>
[JsonConverter(typeof(DurationConverter))]
public abstract record class Duration
{
    internal Duration() { }

    public static implicit operator Duration(double value) => new DurationVariants::Double(value);

    public static implicit operator Duration(string value) => new DurationVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as DurationVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as DurationVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<DurationVariants::Double> @double,
        Action<DurationVariants::String> @string
    )
    {
        switch (this)
        {
            case DurationVariants::Double inner:
                @double(inner);
                break;
            case DurationVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<DurationVariants::Double, T> @double,
        Func<DurationVariants::String, T> @string
    )
    {
        return this switch
        {
            DurationVariants::Double inner => @double(inner),
            DurationVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class DurationConverter : JsonConverter<Duration>
{
    public override Duration? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new DurationVariants::Double(
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
                return new DurationVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Duration value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            DurationVariants::Double(var @double) => @double,
            DurationVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
