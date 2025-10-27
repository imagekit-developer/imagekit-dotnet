using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent1Variants;
using System = System;

namespace Imagekit.Models.CustomMetadataFields.CustomMetadataFieldCreateParamsProperties.SchemaProperties.DefaultValueProperties;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent1Converter))]
public record class UnnamedSchemaWithArrayParent1
{
    public object Value { get; private init; }

    public UnnamedSchemaWithArrayParent1(string value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent1(double value)
    {
        Value = value;
    }

    public UnnamedSchemaWithArrayParent1(bool value)
    {
        Value = value;
    }

    UnnamedSchemaWithArrayParent1(UnknownVariant value)
    {
        Value = value;
    }

    public static UnnamedSchemaWithArrayParent1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value = this.Value as double?;
        return value != null;
    }

    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value = this.Value as bool?;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new System::InvalidOperationException();
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            String inner => @string(inner),
            Double inner => @double(inner),
            Bool inner => @bool(inner),
            _ => throw new System::InvalidOperationException(),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent1"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class UnnamedSchemaWithArrayParent1Converter : JsonConverter<UnnamedSchemaWithArrayParent1>
{
    public override UnnamedSchemaWithArrayParent1? Read(
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
                return new UnnamedSchemaWithArrayParent1(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new UnnamedSchemaWithArrayParent1(
                JsonSerializer.Deserialize<double>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        try
        {
            return new UnnamedSchemaWithArrayParent1(
                JsonSerializer.Deserialize<bool>(ref reader, options)
            );
        }
        catch (System::Exception e) when (e is JsonException || e is ImageKitInvalidDataException)
        {
            exceptions.Add(e);
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent1 value,
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
