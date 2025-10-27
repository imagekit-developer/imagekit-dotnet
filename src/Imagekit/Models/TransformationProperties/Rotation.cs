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
public record class Rotation
{
    public object Value { get; private init; }

    public Rotation(double value)
    {
        Value = value;
    }

    public Rotation(string value)
    {
        Value = value;
    }

    Rotation(UnknownVariant value)
    {
        Value = value;
    }

    public static Rotation CreateUnknownVariant(JsonElement value)
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
            RotationVariants::Double inner => @double(inner),
            RotationVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Rotation");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            return new Rotation(JsonSerializer.Deserialize<double>(ref reader, options));
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
                return new Rotation(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
