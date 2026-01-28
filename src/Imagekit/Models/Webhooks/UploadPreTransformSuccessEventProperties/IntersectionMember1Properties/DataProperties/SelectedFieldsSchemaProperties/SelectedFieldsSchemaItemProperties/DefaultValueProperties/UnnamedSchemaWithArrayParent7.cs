using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties.UnnamedSchemaWithArrayParent7Variants;
using System = System;

namespace Imagekit.Models.Webhooks.UploadPreTransformSuccessEventProperties.IntersectionMember1Properties.DataProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;

[JsonConverter(typeof(UnnamedSchemaWithArrayParent7Converter))]
public abstract record class UnnamedSchemaWithArrayParent7
{
    internal UnnamedSchemaWithArrayParent7() { }

    public static implicit operator UnnamedSchemaWithArrayParent7(string value) =>
        new String(value);

    public static implicit operator UnnamedSchemaWithArrayParent7(double value) =>
        new Double(value);

    public static implicit operator UnnamedSchemaWithArrayParent7(bool value) => new Bool(value);

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
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of UnnamedSchemaWithArrayParent7"
                );
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
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent7"
            ),
        };
    }

    public abstract void Validate();
}

sealed class UnnamedSchemaWithArrayParent7Converter : JsonConverter<UnnamedSchemaWithArrayParent7>
{
    public override UnnamedSchemaWithArrayParent7? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<ImageKitInvalidDataException> exceptions = [];

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
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant String", e)
            );
        }

        try
        {
            return new Double(JsonSerializer.Deserialize<double>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant Double", e)
            );
        }

        try
        {
            return new Bool(JsonSerializer.Deserialize<bool>(ref reader, options));
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant Bool", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent7 value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            Bool(var @bool) => @bool,
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of UnnamedSchemaWithArrayParent7"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
