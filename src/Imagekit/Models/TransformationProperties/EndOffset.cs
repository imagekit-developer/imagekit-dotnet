using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EndOffsetVariants = Imagekit.Models.TransformationProperties.EndOffsetVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the end offset (in seconds) for trimming videos, e.g., `5` or `10.5`.
///  Typically used with startOffset to define a time window. Arithmetic expressions
/// are supported. See [Trim videos – End offset](https://imagekit.io/docs/trim-videos#end-offset---eo).
/// </summary>
[JsonConverter(typeof(EndOffsetConverter))]
public abstract record class EndOffset
{
    internal EndOffset() { }

    public static implicit operator EndOffset(double value) => new EndOffsetVariants::Double(value);

    public static implicit operator EndOffset(string value) => new EndOffsetVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as EndOffsetVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as EndOffsetVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<EndOffsetVariants::Double> @double,
        Action<EndOffsetVariants::String> @string
    )
    {
        switch (this)
        {
            case EndOffsetVariants::Double inner:
                @double(inner);
                break;
            case EndOffsetVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<EndOffsetVariants::Double, T> @double,
        Func<EndOffsetVariants::String, T> @string
    )
    {
        return this switch
        {
            EndOffsetVariants::Double inner => @double(inner),
            EndOffsetVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class EndOffsetConverter : JsonConverter<EndOffset>
{
    public override EndOffset? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new EndOffsetVariants::Double(
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
                return new EndOffsetVariants::String(deserialized);
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
        EndOffset value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            EndOffsetVariants::Double(var @double) => @double,
            EndOffsetVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
