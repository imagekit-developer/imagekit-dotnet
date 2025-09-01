using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using GradientVariants = Imagekit.Models.TransformationProperties.GradientVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Creates a linear gradient with two colors. Pass `true` for a default gradient,
/// or provide a string for a custom gradient. See [Gradient](https://imagekit.io/docs/effects-and-enhancements#gradient---e-gradient).
/// </summary>
[JsonConverter(typeof(GradientConverter))]
public abstract record class Gradient
{
    internal Gradient() { }

    public static implicit operator Gradient(string value) => new GradientVariants::String(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as GradientVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as GradientVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<GradientVariants::True> true1,
        Action<GradientVariants::String> @string
    )
    {
        switch (this)
        {
            case GradientVariants::True inner:
                true1(inner);
                break;
            case GradientVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<GradientVariants::True, T> true1,
        Func<GradientVariants::String, T> @string
    )
    {
        return this switch
        {
            GradientVariants::True inner => true1(inner),
            GradientVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class GradientConverter : JsonConverter<Gradient>
{
    public override Gradient? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new GradientVariants::True(
                JsonSerializer.Deserialize<JsonElement>(ref reader, options)
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
                return new GradientVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Gradient value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            GradientVariants::True(var true1) => true1,
            GradientVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
