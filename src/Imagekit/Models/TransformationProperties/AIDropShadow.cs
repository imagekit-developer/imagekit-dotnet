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
public abstract record class AIDropShadow
{
    internal AIDropShadow() { }

    public static implicit operator AIDropShadow(string value) =>
        new AIDropShadowVariants::String(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as AIDropShadowVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as AIDropShadowVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<AIDropShadowVariants::True> true1,
        Action<AIDropShadowVariants::String> @string
    )
    {
        switch (this)
        {
            case AIDropShadowVariants::True inner:
                true1(inner);
                break;
            case AIDropShadowVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<AIDropShadowVariants::True, T> true1,
        Func<AIDropShadowVariants::String, T> @string
    )
    {
        return this switch
        {
            AIDropShadowVariants::True inner => true1(inner),
            AIDropShadowVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
            return new AIDropShadowVariants::True(
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
                return new AIDropShadowVariants::String(deserialized);
            }
        }
        catch (JsonException e)
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
