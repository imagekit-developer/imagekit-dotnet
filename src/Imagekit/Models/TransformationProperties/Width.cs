using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using WidthVariants = Imagekit.Models.TransformationProperties.WidthVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the width of the output. If a value between 0 and 1 is provided, it
/// is treated as a percentage (e.g., `0.4` represents 40% of the original width).
///  You can also supply arithmetic expressions (e.g., `iw_div_2`). Width transformation
/// – [Images](https://imagekit.io/docs/image-resize-and-crop#width---w) · [Videos](https://imagekit.io/docs/video-resize-and-crop#width---w)
/// </summary>
[JsonConverter(typeof(WidthConverter))]
public abstract record class Width
{
    internal Width() { }

    public static implicit operator Width(double value) => new WidthVariants::Double(value);

    public static implicit operator Width(string value) => new WidthVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as WidthVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as WidthVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<WidthVariants::Double> @double, Action<WidthVariants::String> @string)
    {
        switch (this)
        {
            case WidthVariants::Double inner:
                @double(inner);
                break;
            case WidthVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<WidthVariants::Double, T> @double,
        Func<WidthVariants::String, T> @string
    )
    {
        return this switch
        {
            WidthVariants::Double inner => @double(inner),
            WidthVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class WidthConverter : JsonConverter<Width>
{
    public override Width? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new WidthVariants::Double(
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
                return new WidthVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Width value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            WidthVariants::Double(var @double) => @double,
            WidthVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
