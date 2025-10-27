using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShadowVariants = Imagekit.Models.TransformationProperties.ShadowVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Adds a shadow beneath solid objects in an image with a transparent background.
///  For AI-based drop shadows, refer to aiDropShadow. Pass `true` for a default
/// shadow, or provide a string for a custom shadow. See [Shadow](https://imagekit.io/docs/effects-and-enhancements#shadow---e-shadow).
/// </summary>
[JsonConverter(typeof(ShadowConverter))]
public record class Shadow
{
    public object Value { get; private init; }

    public Shadow(UnionMember0 value)
    {
        Value = value;
    }

    public Shadow(string value)
    {
        Value = value;
    }

    Shadow(UnknownVariant value)
    {
        Value = value;
    }

    public static Shadow CreateUnknownVariant(JsonElement value)
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
            ShadowVariants::True inner => true1(inner),
            ShadowVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of Shadow");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class ShadowConverter : JsonConverter<Shadow>
{
    public override Shadow? Read(
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
                return new Shadow(deserialized);
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
                return new Shadow(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Shadow value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ShadowVariants::True(var true1) => true1,
            ShadowVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
