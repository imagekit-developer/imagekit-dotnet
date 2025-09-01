using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AspectRatioVariants = Imagekit.Models.TransformationProperties.AspectRatioVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the aspect ratio for the output, e.g., "ar-4-3". Typically used with
/// either width or height (but not both).  For example: aspectRatio = `4:3`, `4_3`,
/// or an expression like `iar_div_2`. See [Image resize and crop – Aspect ratio](https://imagekit.io/docs/image-resize-and-crop#aspect-ratio---ar).
/// </summary>
[JsonConverter(typeof(AspectRatioConverter))]
public abstract record class AspectRatio
{
    internal AspectRatio() { }

    public static implicit operator AspectRatio(double value) =>
        new AspectRatioVariants::Double(value);

    public static implicit operator AspectRatio(string value) =>
        new AspectRatioVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as AspectRatioVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as AspectRatioVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AspectRatioVariants::Double> @double,
        Action<AspectRatioVariants::String> @string
    )
    {
        switch (this)
        {
            case AspectRatioVariants::Double inner:
                @double(inner);
                break;
            case AspectRatioVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<AspectRatioVariants::Double, T> @double,
        Func<AspectRatioVariants::String, T> @string
    )
    {
        return this switch
        {
            AspectRatioVariants::Double inner => @double(inner),
            AspectRatioVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class AspectRatioConverter : JsonConverter<AspectRatio>
{
    public override AspectRatio? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new AspectRatioVariants::Double(
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
                return new AspectRatioVariants::String(deserialized);
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
        AspectRatio value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            AspectRatioVariants::Double(var @double) => @double,
            AspectRatioVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
