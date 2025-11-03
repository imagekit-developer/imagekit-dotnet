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
public record class LineHeight
{
    public object Value { get; private init; }

    public LineHeight(double value)
    {
        Value = value;
    }

    public LineHeight(string value)
    {
        Value = value;
    }

    LineHeight(UnknownVariant value)
    {
        Value = value;
    }

    public static LineHeight CreateUnknownVariant(JsonElement value)
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
            LineHeightVariants::Double inner => @double(inner),
            LineHeightVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of LineHeight");
        }
    }

    record struct UnknownVariant(JsonElement value);
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
            return new LineHeight(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new LineHeight(deserialized);
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
