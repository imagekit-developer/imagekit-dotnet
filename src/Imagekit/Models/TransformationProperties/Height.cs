using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using HeightVariants = Imagekit.Models.TransformationProperties.HeightVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the height of the output. If a value between 0 and 1 is provided, it
/// is treated as a percentage (e.g., `0.5` represents 50% of the original height).
///  You can also supply arithmetic expressions (e.g., `ih_mul_0.5`). Height transformation
/// – [Images](https://imagekit.io/docs/image-resize-and-crop#height---h) · [Videos](https://imagekit.io/docs/video-resize-and-crop#height---h)
/// </summary>
[JsonConverter(typeof(HeightConverter))]
public abstract record class Height
{
    internal Height() { }

    public static implicit operator Height(double value) => new HeightVariants::Double(value);

    public static implicit operator Height(string value) => new HeightVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as HeightVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as HeightVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<HeightVariants::Double> @double,
        Action<HeightVariants::String> @string
    )
    {
        switch (this)
        {
            case HeightVariants::Double inner:
                @double(inner);
                break;
            case HeightVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<HeightVariants::Double, T> @double,
        Func<HeightVariants::String, T> @string
    )
    {
        return this switch
        {
            HeightVariants::Double inner => @double(inner),
            HeightVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class HeightConverter : JsonConverter<Height>
{
    public override Height? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new HeightVariants::Double(
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
                return new HeightVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Height value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            HeightVariants::Double(var @double) => @double,
            HeightVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
