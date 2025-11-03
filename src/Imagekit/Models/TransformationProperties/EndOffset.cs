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
public record class EndOffset
{
    public object Value { get; private init; }

    public EndOffset(double value)
    {
        Value = value;
    }

    public EndOffset(string value)
    {
        Value = value;
    }

    EndOffset(UnknownVariant value)
    {
        Value = value;
    }

    public static EndOffset CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public void Switch(Action<double> @double, Action<string> @string)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<double, T> @double, Func<string, T> @string)
    {
        return this.Value switch
        {
            EndOffsetVariants::Double inner => @double(inner),
            EndOffsetVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of EndOffset");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new EndOffset(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new EndOffset(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
