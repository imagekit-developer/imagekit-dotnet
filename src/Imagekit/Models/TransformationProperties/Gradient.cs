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
public record class Gradient
{
    public object Value { get; private init; }

    public Gradient(UnionMember0 value)
    {
        Value = value;
    }

    public Gradient(string value)
    {
        Value = value;
    }

    Gradient(UnknownVariant value)
    {
        Value = value;
    }

    public static Gradient CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickTrue([NotNullWhen(true)] out UnionMember0? value)
    {
        value = this.Value as UnionMember0;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public void Switch(Action<UnionMember0> true1, Action<string> @string)
    {
        switch (this.Value)
        {
            case UnionMember0 value:
                true1(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<UnionMember0, T> true1, Func<string, T> @string)
    {
        return this.Value switch
        {
            GradientVariants::True inner => true1(inner),
            GradientVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Gradient");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Gradient(deserialized);
            }
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
                return new Gradient(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
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
