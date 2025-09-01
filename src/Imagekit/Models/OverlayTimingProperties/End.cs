using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using EndVariants = Imagekit.Models.OverlayTimingProperties.EndVariants;

namespace Imagekit.Models.OverlayTimingProperties;

/// <summary>
/// Specifies the end time (in seconds) for when the overlay should disappear from
/// the base video. If both end and duration are provided, duration is ignored. Accepts
/// a positive number up to two decimal places (e.g., `20` or `20.50`) and arithmetic
/// expressions such as `bdu_mul_0.4` or `bdu_sub_idu`. Applies only if the base asset
/// is a video. Maps to `leo` in the URL.
/// </summary>
[JsonConverter(typeof(EndConverter))]
public abstract record class End
{
    internal End() { }

    public static implicit operator End(double value) => new EndVariants::Double(value);

    public static implicit operator End(string value) => new EndVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as EndVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as EndVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<EndVariants::Double> @double, Action<EndVariants::String> @string)
    {
        switch (this)
        {
            case EndVariants::Double inner:
                @double(inner);
                break;
            case EndVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<EndVariants::Double, T> @double, Func<EndVariants::String, T> @string)
    {
        return this switch
        {
            EndVariants::Double inner => @double(inner),
            EndVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class EndConverter : JsonConverter<End>
{
    public override End? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new EndVariants::Double(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new EndVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, End value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            EndVariants::Double(var @double) => @double,
            EndVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
