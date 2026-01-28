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
public abstract record class Shadow
{
    internal Shadow() { }

    public static implicit operator Shadow(string value) => new ShadowVariants::String(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as ShadowVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as ShadowVariants::String)?.Value;
        return value != null;
    }

    public void Switch(Action<ShadowVariants::True> true1, Action<ShadowVariants::String> @string)
    {
        switch (this)
        {
            case ShadowVariants::True inner:
                true1(inner);
                break;
            case ShadowVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(Func<ShadowVariants::True, T> true1, Func<ShadowVariants::String, T> @string)
    {
        return this switch
        {
            ShadowVariants::True inner => true1(inner),
            ShadowVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
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
            return new ShadowVariants::True(
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
                return new ShadowVariants::String(deserialized);
            }
        }
        catch (JsonException e)
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
