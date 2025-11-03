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
public record class Width
{
    public object Value { get; private init; }

    public Width(double value)
    {
        Value = value;
    }

    public Width(string value)
    {
        Value = value;
    }

    Width(UnknownVariant value)
    {
        Value = value;
    }

    public static Width CreateUnknownVariant(JsonElement value)
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
            WidthVariants::Double inner => @double(inner),
            WidthVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Width");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new Width(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Width(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
