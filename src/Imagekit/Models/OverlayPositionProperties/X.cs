using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using XVariants = Imagekit.Models.OverlayPositionProperties.XVariants;

namespace Imagekit.Models.OverlayPositionProperties;

/// <summary>
/// Specifies the x-coordinate of the top-left corner of the base asset where the
/// overlay's top-left corner will be positioned. It also accepts arithmetic expressions
/// such as `bw_mul_0.4` or `bw_sub_cw`. Maps to `lx` in the URL. Learn about [Arithmetic
/// expressions](https://imagekit.io/docs/arithmetic-expressions-in-transformations).
/// </summary>
[JsonConverter(typeof(XConverter))]
public abstract record class X
{
    internal X() { }

    public static implicit operator X(double value) => new XVariants::Double(value);

    public static implicit operator X(string value) => new XVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as XVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as XVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<XVariants::Double> @double, Action<XVariants::String> @string)
    {
        switch (this)
        {
            case XVariants::Double inner:
                @double(inner);
                break;
            case XVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<XVariants::Double, T> @double, Func<XVariants::String, T> @string)
    {
        return this switch
        {
            XVariants::Double inner => @double(inner),
            XVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class XConverter : JsonConverter<X>
{
    public override X? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new XVariants::Double(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new XVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, X value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            XVariants::Double(var @double) => @double,
            XVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
