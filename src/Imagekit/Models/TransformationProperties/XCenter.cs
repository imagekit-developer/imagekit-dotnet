using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XCenterVariants = Imagekit.Models.TransformationProperties.XCenterVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Focus using cropped image coordinates - X center coordinate. See [Focus using
/// cropped coordinates](https://imagekit.io/docs/image-resize-and-crop#example---focus-using-cropped-image-coordinates).
/// </summary>
[JsonConverter(typeof(XCenterConverter))]
public abstract record class XCenter
{
    internal XCenter() { }

    public static implicit operator XCenter(double value) => new XCenterVariants::Double(value);

    public static implicit operator XCenter(string value) => new XCenterVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as XCenterVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as XCenterVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<XCenterVariants::Double> @double,
        Action<XCenterVariants::String> @string
    )
    {
        switch (this)
        {
            case XCenterVariants::Double inner:
                @double(inner);
                break;
            case XCenterVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<XCenterVariants::Double, T> @double,
        Func<XCenterVariants::String, T> @string
    )
    {
        return this switch
        {
            XCenterVariants::Double inner => @double(inner),
            XCenterVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class XCenterConverter : JsonConverter<XCenter>
{
    public override XCenter? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new XCenterVariants::Double(
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
                return new XCenterVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, XCenter value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            XCenterVariants::Double(var @double) => @double,
            XCenterVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
