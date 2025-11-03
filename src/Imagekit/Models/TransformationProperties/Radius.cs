using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using RadiusVariants = Imagekit.Models.TransformationProperties.RadiusVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Specifies the corner radius for rounded corners (e.g., 20) or `max` for circular
/// or oval shape. See [Radius](https://imagekit.io/docs/effects-and-enhancements#radius---r).
/// </summary>
[JsonConverter(typeof(RadiusConverter))]
public record class Radius
{
    public object Value { get; private init; }

    public Radius(double value)
    {
        Value = value;
    }

    public Radius(UnionMember1 value)
    {
        Value = value;
    }

    Radius(UnknownVariant value)
    {
        Value = value;
    }

    public static Radius CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickMax([NotNullWhen(true)] out UnionMember1? value)
    {
        value = this.Value as UnionMember1;
        return value != null;
    }

    public void Switch(Action<double> @double, Action<UnionMember1> max)
    {
        switch (this.Value)
        {
            case double value:
                @double(value);
                break;
            case UnionMember1 value:
                max(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<double, T> @double, Func<UnionMember1, T> max)
    {
        return this.Value switch
        {
            RadiusVariants::Double inner => @double(inner),
            RadiusVariants::Max inner => max(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Radius");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class RadiusConverter : JsonConverter<Radius>
{
    public override Radius? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<UnionMember1>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Radius(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new Radius(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Radius value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            RadiusVariants::Double(var @double) => @double,
            RadiusVariants::Max(var max) => max,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
