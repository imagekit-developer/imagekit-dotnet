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
public record class AspectRatio
{
    public object Value { get; private init; }

    public AspectRatio(double value)
    {
        Value = value;
    }

    public AspectRatio(string value)
    {
        Value = value;
    }

    AspectRatio(UnknownVariant value)
    {
        Value = value;
    }

    public static AspectRatio CreateUnknownVariant(JsonElement value)
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
            AspectRatioVariants::Double inner => @double(inner),
            AspectRatioVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of AspectRatio");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new AspectRatio(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new AspectRatio(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
