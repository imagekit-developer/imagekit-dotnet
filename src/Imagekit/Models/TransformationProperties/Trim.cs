using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrimVariants = Imagekit.Models.TransformationProperties.TrimVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Useful for images with a solid or nearly solid background and a central object.
/// This parameter trims the background,  leaving only the central object in the output
/// image. See [Trim edges](https://imagekit.io/docs/effects-and-enhancements#trim-edges---t).
/// </summary>
[JsonConverter(typeof(TrimConverter))]
public record class Trim
{
    public object Value { get; private init; }

    public Trim(UnionMember0 value)
    {
        Value = value;
    }

    public Trim(double value)
    {
        Value = value;
    }

    Trim(UnknownVariant value)
    {
        Value = value;
    }

    public static Trim CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTrue([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public void Switch(Action<UnionMember0> true1, Action<double> @double)
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                true1(value);
                break;
            case double value:
                @double(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<UnionMember0, T> true1, Func<double, T> @double)
    {
        return this.Value switch
        {
            TrimVariants::True inner => true1(inner),
            TrimVariants::Double inner => @double(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Trim");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Trim(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new Trim(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Trim value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            TrimVariants::True(var true1) => true1,
            TrimVariants::Double(var @double) => @double,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
