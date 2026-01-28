using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using LineHeightVariants = Imagekit.Models.TextOverlayTransformationProperties.LineHeightVariants;

namespace Imagekit.Models.TextOverlayTransformationProperties;

/// <summary>
/// Specifies the line height of the text overlay.  Accepts integer values representing
/// line height in points. It can also accept [arithmetic expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations)
/// such as `bw_mul_0.2`, or `bh_div_20`.
/// </summary>
[JsonConverter(typeof(LineHeightConverter))]
public abstract record class LineHeight
{
    internal LineHeight() { }

    public static implicit operator LineHeight(double value) =>
        new LineHeightVariants::Double(value);

    public static implicit operator LineHeight(string value) =>
        new LineHeightVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as LineHeightVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as LineHeightVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<LineHeightVariants::Double> @double,
        Action<LineHeightVariants::String> @string
    )
    {
        switch (this)
        {
            case LineHeightVariants::Double inner:
                @double(inner);
                break;
            case LineHeightVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<LineHeightVariants::Double, T> @double,
        Func<LineHeightVariants::String, T> @string
    )
    {
        return this switch
        {
            LineHeightVariants::Double inner => @double(inner),
            LineHeightVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class LineHeightConverter : JsonConverter<LineHeight>
{
    public override LineHeight? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new LineHeightVariants::Double(
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
                return new LineHeightVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        LineHeight value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            LineHeightVariants::Double(var @double) => @double,
            LineHeightVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
