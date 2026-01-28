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
public record class Height
{
    public object Value { get; private init; }

    public Height(double value)
    {
        Value = value;
    }

    public Height(string value)
    {
        Value = value;
    }

    Height(UnknownVariant value)
    {
        Value = value;
    }

    public static Height CreateUnknownVariant(JsonElement value)
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
            HeightVariants::Double inner => @double(inner),
            HeightVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Height");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new Height(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Height(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
