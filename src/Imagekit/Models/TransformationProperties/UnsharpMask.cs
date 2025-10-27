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
public record class UnsharpMask
{
    public object Value { get; private init; }

    public UnsharpMask(UnionMember0 value)
    {
        Value = value;
    }

    public UnsharpMask(string value)
    {
        Value = value;
    }

    UnsharpMask(UnknownVariant value)
    {
        Value = value;
    }

    public static UnsharpMask CreateUnknownVariant(JsonElement value)
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
            UnsharpMaskVariants::True inner => true1(inner),
            UnsharpMaskVariants::String inner => @string(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException("Data did not match any variant of UnsharpMask");
        }
    }

    private record struct UnknownVariant(JsonElement value);
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
            var deserialized = JsonSerializer.Deserialize<UnionMember0>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new UnsharpMask(deserialized);
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
                return new UnsharpMask(deserialized);
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
