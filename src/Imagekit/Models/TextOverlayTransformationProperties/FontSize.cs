using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using FontSizeVariants = Imagekit.Models.TextOverlayTransformationProperties.FontSizeVariants;

namespace Imagekit.Models.TextOverlayTransformationProperties;

/// <summary>
/// Specifies the font size of the overlaid text. Accepts a numeric value or an arithmetic expression.
/// </summary>
[JsonConverter(typeof(FontSizeConverter))]
public abstract record class FontSize
{
    internal FontSize() { }

    public static implicit operator FontSize(double value) => new FontSizeVariants::Double(value);

    public static implicit operator FontSize(string value) => new FontSizeVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as FontSizeVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as FontSizeVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<FontSizeVariants::Double> @double,
        Action<FontSizeVariants::String> @string
    )
    {
        switch (this)
        {
            case FontSizeVariants::Double inner:
                @double(inner);
                break;
            case FontSizeVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<FontSizeVariants::Double, T> @double,
        Func<FontSizeVariants::String, T> @string
    )
    {
        return this switch
        {
            FontSizeVariants::Double inner => @double(inner),
            FontSizeVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class FontSizeConverter : JsonConverter<FontSize>
{
    public override FontSize? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new FontSizeVariants::Double(
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
                return new FontSizeVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, FontSize value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            FontSizeVariants::Double(var @double) => @double,
            FontSizeVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
