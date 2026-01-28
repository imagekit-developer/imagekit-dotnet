using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Exceptions;
using Imagekit.Models.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueProperties;
using Imagekit.Models.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties.DefaultValueVariants;
using System = System;

namespace Imagekit.Models.Files.FileUploadResponseProperties.SelectedFieldsSchemaProperties.SelectedFieldsSchemaItemProperties;

/// <summary>
/// The default value for this custom metadata field. The value should match the
/// `type` of custom metadata field.
/// </summary>
[JsonConverter(typeof(DefaultValueConverter))]
public abstract record class DefaultValue
{
    internal DefaultValue() { }

    public static implicit operator DefaultValue(string value) => new String(value);

    public static implicit operator DefaultValue(double value) => new Double(value);

    public static implicit operator DefaultValue(bool value) => new Bool(value);

    public static implicit operator DefaultValue(List<UnnamedSchemaWithArrayParent5> value) =>
        new Mixed(value);

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

    public bool TryPickMixed([NotNullWhen(true)] out List<UnnamedSchemaWithArrayParent5>? value)
    {
        value = (this as Mixed)?.Value;
        return value != null;
    }

    public void Switch(
        System::Action<String> @string,
        System::Action<Double> @double,
        System::Action<Bool> @bool,
        System::Action<Mixed> mixed
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
            case Mixed inner:
                mixed(inner);
                break;
            default:
                throw new ImageKitInvalidDataException(
                    "Data did not match any variant of DefaultValue"
                );
        }
    }

    public T Match<T>(
        System::Func<String, T> @string,
        System::Func<Double, T> @double,
        System::Func<Bool, T> @bool,
        System::Func<Mixed, T> mixed
    )
    {
        return this switch
        {
            String inner => @string(inner),
            Double inner => @double(inner),
            Bool inner => @bool(inner),
            Mixed inner => mixed(inner),
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of DefaultValue"
            ),
        };
    }

    public abstract void Validate();
}

sealed class DefaultValueConverter : JsonConverter<DefaultValue>
{
    public override DefaultValue? Read(
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<UnnamedSchemaWithArrayParent5>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Mixed(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new ImageKitInvalidDataException("Data does not match union variant Mixed", e)
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        DefaultValue value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            String(var @string) => @string,
            Double(var @double) => @double,
            Bool(var @bool) => @bool,
            Mixed(var mixed) => mixed,
            _ => throw new ImageKitInvalidDataException(
                "Data did not match any variant of DefaultValue"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
