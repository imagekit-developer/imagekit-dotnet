using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnnamedSchemaWithArrayParent2Variants = Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent2Variants;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldUpdateParamsProperties.SchemaProperties.DefaultValueProperties;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent2Converter))]
public abstract record class UnnamedSchemaWithArrayParent2
{
    internal UnnamedSchemaWithArrayParent2() { }

    public static implicit operator UnnamedSchemaWithArrayParent2(string value) =>
        new UnnamedSchemaWithArrayParent2Variants::String(value);

    public static implicit operator UnnamedSchemaWithArrayParent2(double value) =>
        new UnnamedSchemaWithArrayParent2Variants::Double(value);

    public static implicit operator UnnamedSchemaWithArrayParent2(bool value) =>
        new UnnamedSchemaWithArrayParent2Variants::Bool(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as UnnamedSchemaWithArrayParent2Variants::String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as UnnamedSchemaWithArrayParent2Variants::Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as UnnamedSchemaWithArrayParent2Variants::Bool)?.Value;
        return value != null;
    }

    public void Switch(
        Action<UnnamedSchemaWithArrayParent2Variants::String> @string,
        Action<UnnamedSchemaWithArrayParent2Variants::Double> @double,
        Action<UnnamedSchemaWithArrayParent2Variants::Bool> @bool
    )
    {
        switch (this.Value)
        {
            case UnnamedSchemaWithArrayParent2Variants::String inner:
                @string(inner);
                break;
            case UnnamedSchemaWithArrayParent2Variants::Double inner:
                @double(inner);
                break;
            case UnnamedSchemaWithArrayParent2Variants::Bool inner:
                @bool(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<UnnamedSchemaWithArrayParent2Variants::String, T> @string,
        Func<UnnamedSchemaWithArrayParent2Variants::Double, T> @double,
        Func<UnnamedSchemaWithArrayParent2Variants::Bool, T> @bool
    )
    {
        return this.Value switch
        {
            UnnamedSchemaWithArrayParent2Variants::String inner => @string(inner),
            UnnamedSchemaWithArrayParent2Variants::Double inner => @double(inner),
            UnnamedSchemaWithArrayParent2Variants::Bool inner => @bool(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent3"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class UnnamedSchemaWithArrayParent2Converter : JsonConverter<UnnamedSchemaWithArrayParent2>
{
    public override UnnamedSchemaWithArrayParent2? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new UnnamedSchemaWithArrayParent2Variants::String(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new UnnamedSchemaWithArrayParent2Variants::Double(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new UnnamedSchemaWithArrayParent2Variants::Bool(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent2 value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            UnnamedSchemaWithArrayParent2Variants::String(var @string) => @string,
            UnnamedSchemaWithArrayParent2Variants::Double(var @double) => @double,
            UnnamedSchemaWithArrayParent2Variants::Bool(var @bool) => @bool,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
