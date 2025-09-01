using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent0Variants;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldProperties.SchemaProperties.DefaultValueProperties;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent0Converter))]
public abstract record class UnnamedSchemaWithArrayParent0
{
    internal UnnamedSchemaWithArrayParent0() { }

    public static implicit operator UnnamedSchemaWithArrayParent0(string value) =>
        new String(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(double value) =>
        new Double(value);

    public static implicit operator UnnamedSchemaWithArrayParent0(bool value) => new Bool(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as String)?.Value;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = (this as Double)?.Value;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = (this as Bool)?.Value;
        return value != null;
    }

    public void Switch(
        System::Action<String> @string,
        System::Action<Double> @double,
        System::Action<Bool> @bool
    )
    {
        switch (this)
        {
            case String inner:
                @string(inner);
                break;
            case Double inner:
                @double(inner);
                break;
            case Bool inner:
                @bool(inner);
                break;
            default:
                throw new System::InvalidOperationException();
        }
    }

    public T Match<T>(
        System::Func<String, T> @string,
        System::Func<Double, T> @double,
        System::Func<Bool, T> @bool
    )
    {
        return this switch
        {
            String inner => @string(inner),
            Double inner => @double(inner),
            Bool inner => @bool(inner),
            _ => throw new System::InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class UnnamedSchemaWithArrayParent0Converter : JsonConverter<UnnamedSchemaWithArrayParent0>
{
    public override UnnamedSchemaWithArrayParent0? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new Double(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            return new Bool(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent0 value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            Bool(var @bool) => @bool,
            _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
