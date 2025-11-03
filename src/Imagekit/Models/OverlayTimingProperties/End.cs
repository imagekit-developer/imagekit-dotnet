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
public record class End
{
    public object Value { get; private init; }

    public End(double value)
    {
        Value = value;
    }

    public End(string value)
    {
        Value = value;
    }

    End(UnknownVariant value)
    {
        Value = value;
    }

    public static End CreateUnknownVariant(JsonElement value)
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
            EndVariants::Double inner => @double(inner),
            EndVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of End");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new End(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new End(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
