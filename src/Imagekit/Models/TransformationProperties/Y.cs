using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using YVariants = Imagekit.Models.TransformationProperties.YVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Focus using cropped image coordinates - Y coordinate. See [Focus using cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(YConverter))]
public record class Y
{
    public object Value { get; private init; }

    public Y(double value)
    {
        Value = value;
    }

    public Y(string value)
    {
        Value = value;
    }

    Y(UnknownVariant value)
    {
        Value = value;
    }

    public static Y CreateUnknownVariant(JsonElement value)
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
            YVariants::Double inner => @double(inner),
            YVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Y");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new Y(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Y(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
