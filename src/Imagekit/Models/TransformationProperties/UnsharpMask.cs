using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnsharpMaskVariants = Imagekit.Models.TransformationProperties.UnsharpMaskVariants;

namespace Imagekit.Models.TransformationProperties;

/// <summary>
/// Applies Unsharp Masking (USM), an image sharpening technique.  Pass `true` for
/// a default unsharp mask, or provide a string for a custom unsharp mask. See [Unsharp
/// Mask](https://imagekit.io/docs/effects-and-enhancements#unsharp-mask---e-usm).
/// </summary>
[JsonConverter(typeof(UnsharpMaskConverter))]
public abstract record class UnsharpMask
{
    internal UnsharpMask() { }

    public static implicit operator UnsharpMask(string value) =>
        new UnsharpMaskVariants::String(value);

    public bool TryPickTrue([NotNullWhen(true)] out JsonElement? value)
    {
        value = (this as UnsharpMaskVariants::True)?.Value;
        return value != null;
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as UnsharpMaskVariants::String)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UnsharpMaskVariants::True> true1,
        Action<UnsharpMaskVariants::String> @string
    )
    {
        switch (this)
        {
            case UnsharpMaskVariants::True inner:
                true1(inner);
                break;
            case UnsharpMaskVariants::String inner:
                @string(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<UnsharpMaskVariants::True, T> true1,
        Func<UnsharpMaskVariants::String, T> @string
    )
    {
        return this switch
        {
            UnsharpMaskVariants::True inner => true1(inner),
            UnsharpMaskVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UnsharpMaskConverter : JsonConverter<UnsharpMask>
{
    public override UnsharpMask? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            return new UnsharpMaskVariants::True(
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
                return new UnsharpMaskVariants::String(deserialized);
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
        UnsharpMask value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UnsharpMaskVariants::True(var true1) => true1,
            UnsharpMaskVariants::String(var @string) => @string,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
