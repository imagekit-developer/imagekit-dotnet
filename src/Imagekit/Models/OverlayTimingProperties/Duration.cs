using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using DurationVariants = Imagekit.Models.OverlayTimingProperties.DurationVariants;

namespace Imagekit.Models.OverlayTimingProperties;

/// <summary>
/// Specifies the duration (in seconds) during which the overlay should appear on
/// the base video. Accepts a positive number up to two decimal places (e.g., `20`
/// or `20.50`) and arithmetic expressions such as `bdu_mul_0.4` or `bdu_sub_idu`.
/// Applies only if the base asset is a video. Maps to `ldu` in the URL.
/// </summary>
[JsonConverter(typeof(DurationConverter))]
public record class Duration
{
    public object Value { get; private init; }

    public Duration(double value)
    {
        Value = value;
    }

    public Duration(string value)
    {
        Value = value;
    }

    Duration(UnknownVariant value)
    {
        Value = value;
    }

    public static Duration CreateUnknownVariant(JsonElement value)
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
            DurationVariants::Double inner => @double(inner),
            DurationVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Duration");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new Duration(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Duration(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
