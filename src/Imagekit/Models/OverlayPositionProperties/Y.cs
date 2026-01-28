using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using YVariants = Imagekit.Models.OverlayPositionProperties.YVariants;

namespace Imagekit.Models.OverlayPositionProperties;

/// <summary>
/// Specifies the y-coordinate of the top-left corner of the base asset where the
/// overlay's top-left corner will be positioned. It also accepts arithmetic expressions
/// such as `bh_mul_0.4` or `bh_sub_ch`. Maps to `ly` in the URL. Learn about [Arithmetic
/// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(YConverter))]
public abstract record class Y
{
    internal Y() { }

    public static implicit operator Y(double value) => new YVariants::Double(value);

    public static implicit operator Y(string value) => new YVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as YVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as YVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<YVariants::Double> @double, Action<YVariants::String> @string)
    {
        switch (this)
        {
            case YVariants::Double inner:
                @double(inner);
                break;
            case YVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<YVariants::Double, T> @double, Func<YVariants::String, T> @string)
    {
        return this switch
        {
            YVariants::Double inner => @double(inner),
            YVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class YConverter : JsonConverter<Y>
{
    public override Y? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new YVariants::Double(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new YVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Y value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            YVariants::Double(var @double) => @double,
            YVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
