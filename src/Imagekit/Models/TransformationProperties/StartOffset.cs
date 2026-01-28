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
public record class StartOffset
{
    public object Value { get; private init; }

    public StartOffset(double value)
    {
        Value = value;
    }

    public StartOffset(string value)
    {
        Value = value;
    }

    StartOffset(UnknownVariant value)
    {
        Value = value;
    }

    public static StartOffset CreateUnknownVariant(JsonElement value)
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
            StartOffsetVariants::Double inner => @double(inner),
            StartOffsetVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of StartOffset");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new StartOffset(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new StartOffset(deserialized);
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
