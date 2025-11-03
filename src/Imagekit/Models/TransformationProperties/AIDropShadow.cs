using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AIDropShadowVariants = Imagekit.Models.TransformationProperties.AIDropShadowVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Adds an AI-based drop shadow around a foreground object on a transparent or removed
/// background.  Optionally, control the direction, elevation, and saturation of
/// the light source (e.g., `az-45` to change light direction). Pass `true` for the
/// default drop shadow, or provide a string for a custom drop shadow. Supported
/// inside overlay. See [AI Drop Shadow](https://imagekit.io/docs/ai-transformations#ai-drop-shadow-e-dropshadow).
/// </summary>
[JsonConverter(typeof(AIDropShadowConverter))]
public record class AIDropShadow
{
    public object Value { get; private init; }

    public AIDropShadow(UnionMember0 value)
    {
        Value = value;
    }

    public AIDropShadow(string value)
    {
        Value = value;
    }

    AIDropShadow(UnknownVariant value)
    {
        Value = value;
    }

    public static AIDropShadow CreateUnknownVariant(JsonElement value)
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
            AIDropShadowVariants::True inner => true1(inner),
            AIDropShadowVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of AIDropShadow"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class AIDropShadowConverter : JsonConverter<AIDropShadow>
{
    public override AIDropShadow? Read(
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
                return new AIDropShadow(deserialized);
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
                return new AIDropShadow(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        AIDropShadow value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            AIDropShadowVariants::True(var true1) => true1,
            AIDropShadowVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
