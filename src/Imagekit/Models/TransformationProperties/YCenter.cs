using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using YCenterVariants = Imagekit.Models.TransformationProperties.YCenterVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Focus using cropped image coordinates - Y center coordinate. See [Focus using
/// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(YCenterConverter))]
public abstract record class YCenter
{
    internal YCenter() { }

    public static implicit operator YCenter(double value) => new YCenterVariants::Double(value);

    public static implicit operator YCenter(string value) => new YCenterVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as YCenterVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as YCenterVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<YCenterVariants::Double> @double,
        Action<YCenterVariants::String> @string
    )
    {
        switch (this)
        {
            case YCenterVariants::Double inner:
                @double(inner);
                break;
            case YCenterVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<YCenterVariants::Double, T> @double,
        Func<YCenterVariants::String, T> @string
    )
    {
        return this switch
        {
            YCenterVariants::Double inner => @double(inner),
            YCenterVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class YCenterConverter : JsonConverter<YCenter>
{
    public override YCenter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new YCenterVariants::Double(
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
                return new YCenterVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, YCenter value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            YCenterVariants::Double(var @double) => @double,
            YCenterVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
