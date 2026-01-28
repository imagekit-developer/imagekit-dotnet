using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using StartVariants = Imagekit.Models.OverlayTimingProperties.StartVariants;

namespace Imagekit.Models.OverlayTimingProperties;

/// <summary>
/// Specifies the start time (in seconds) for when the overlay should appear on the
/// base video. Accepts a positive number up to two decimal places (e.g., `20` or
/// `20.50`) and arithmetic expressions such as `bdu_mul_0.4` or `bdu_sub_idu`. Applies
/// only if the base asset is a video. Maps to `lso` in the URL.
/// </summary>
[JsonConverter(typeof(StartConverter))]
public record class Start
{
    public object Value { get; private init; }

    public Start(double value)
    {
        Value = value;
    }

    public Start(string value)
    {
        Value = value;
    }

    Start(UnknownVariant value)
    {
        Value = value;
    }

    public static Start CreateUnknownVariant(JsonElement value)
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
            StartVariants::Double inner => @double(inner),
            StartVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Start");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class StartConverter : JsonConverter<Start>
{
    public override Start? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new Start(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Start(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Start value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            StartVariants::Double(var @double) => @double,
            StartVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
