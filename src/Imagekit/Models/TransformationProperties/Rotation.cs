using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using RotationVariants = Imagekit.Models.TransformationProperties.RotationVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the rotation angle in degrees. Positive values rotate the image clockwise;
/// you can also use, for example, `N40` for counterclockwise rotation  or `auto`
/// to use the orientation specified in the image's EXIF data. For videos, only the
/// following values are supported: 0, 90, 180, 270, or 360. See [Rotate](https://imagekit.io/docs/effects-and-enhancements#rotate---rt).
/// </summary>
[JsonConverter(typeof(RotationConverter))]
public abstract record class Rotation
{
    internal Rotation() { }

    public static implicit operator Rotation(double value) => new RotationVariants::Double(value);

    public static implicit operator Rotation(string value) => new RotationVariants::String(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as RotationVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as RotationVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<RotationVariants::Double> @double,
        Action<RotationVariants::String> @string
    )
    {
        switch (this)
        {
            case RotationVariants::Double inner:
                @double(inner);
                break;
            case RotationVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<RotationVariants::Double, T> @double,
        Func<RotationVariants::String, T> @string
    )
    {
        return this switch
        {
            RotationVariants::Double inner => @double(inner),
            RotationVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class RotationConverter : JsonConverter<Rotation>
{
    public override Rotation? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new RotationVariants::Double(
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
                return new RotationVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Rotation value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            RotationVariants::Double(var @double) => @double,
            RotationVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
