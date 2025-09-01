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
public abstract record class Radius
{
    internal Radius() { }

    public static implicit operator Radius(double value) => new RadiusVariants::Double(value);

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as RadiusVariants::Double)?.Value;
        return value != null;
    }

    public bool TryPickMax([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as RadiusVariants::Max)?.Value;
        return value != null;
    }

    public void Switch(Action<RadiusVariants::Double> @double, Action<RadiusVariants::Max> max)
    {
        switch (this)
        {
            case RadiusVariants::Double inner:
                @double(inner);
                break;
            case RadiusVariants::Max inner:
                max(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<RadiusVariants::Double, T> @double, Func<RadiusVariants::Max, T> max)
    {
        return this switch
        {
            RadiusVariants::Double inner => @double(inner),
            RadiusVariants::Max inner => max(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
            return new RadiusVariants::Max(
                JsonSerializer.Deserialize<JsonElement>(ref reader, options)
            );
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new RadiusVariants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (JsonException e)
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
