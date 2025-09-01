using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StartOffsetVariants = Imagekit.Models.TransformationProperties.StartOffsetVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the start offset (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Arithmetic expressions are also supported. See [Trim videos – Start offset](https://imagekit.io/docs/trim-videos#start-offset---so).
/// </summary>
[JsonConverter(typeof(StartOffsetConverter))]
public abstract record class StartOffset
{
    internal StartOffset() { }

    public static implicit operator StartOffset(double value) =>
        new StartOffsetVariants::Double(value);

    public static implicit operator StartOffset(string value) =>
        new StartOffsetVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as StartOffsetVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as StartOffsetVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<StartOffsetVariants::Double> @double,
        Action<StartOffsetVariants::String> @string
    )
    {
        switch (this)
        {
            case StartOffsetVariants::Double inner:
                @double(inner);
                break;
            case StartOffsetVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<StartOffsetVariants::Double, T> @double,
        Func<StartOffsetVariants::String, T> @string
    )
    {
        return this switch
        {
            StartOffsetVariants::Double inner => @double(inner),
            StartOffsetVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class StartOffsetConverter : JsonConverter<StartOffset>
{
    public override StartOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new StartOffsetVariants::Double(
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
                return new StartOffsetVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        StartOffset value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            StartOffsetVariants::Double(var @double) => @double,
            StartOffsetVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
