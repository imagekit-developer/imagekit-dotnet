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
public abstract record class Start
{
    internal Start() { }

    public static implicit operator Start(double value) => new StartVariants::Double(value);

    public static implicit operator Start(string value) => new StartVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as StartVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as StartVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<StartVariants::Double> @double, Action<StartVariants::String> @string)
    {
        switch (this)
        {
            case StartVariants::Double inner:
                @double(inner);
                break;
            case StartVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<StartVariants::Double, T> @double,
        Func<StartVariants::String, T> @string
    )
    {
        return this switch
        {
            StartVariants::Double inner => @double(inner),
            StartVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
            return new StartVariants::Double(
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
                return new StartVariants::String(deserialized);
            }
        }
        catch (JsonException e)
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
